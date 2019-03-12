using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Microsoft.Azure.CognitiveServices.Vision.ComputerVision;
using Microsoft.Azure.CognitiveServices.Vision.ComputerVision.Models;
using Newtonsoft.Json.Linq;
using Plugin.Media;
using Plugin.Media.Abstractions;
using Plugin.Permissions;
using Plugin.Permissions.Abstractions;
using Plugin.SimpleAudioPlayer;
using Xamarin.Forms;

namespace ACS
{
    public class ViewModel : ViewModelBase
    {
        private readonly HttpClient _httpClient;
        private bool _isBusy;
        private MediaFile _photo;
        private ImageSource _photoSource;
        private string _description;

        public ViewModel()
        {
            _httpClient = new HttpClient();
            _isBusy = false;
            _photoSource = "mug_logo.png";
            _description = null;

            CaptureCommand = new RelayCommand(CaptureCommandExecute, CaptureCommandCanExecute);
            AnalyzeCommand = new RelayCommand(AnalyzeCommandExecute, AnalyzeCommandCanExecute);
            SpeechCommand = new RelayCommand(SpeechCommandExecute, SpeechCommandCanExecute);
        }

        #region Properties

        public bool IsBusy
        {
            get => _isBusy;
            set
            {
                Set(ref _isBusy, value);
                CaptureCommand.RaiseCanExecuteChanged();
                AnalyzeCommand.RaiseCanExecuteChanged();
                SpeechCommand.RaiseCanExecuteChanged();
            }
        }

        public ImageSource PhotoSource
        {
            get => _photoSource;

            set
            {
                Set(ref _photoSource, value);
                AnalyzeCommand.RaiseCanExecuteChanged();
            }
        }

        public string Description
        {
            get => _description;
            set
            {
                Set(ref _description, value);
                SpeechCommand.RaiseCanExecuteChanged();
            }
        }

        public RelayCommand CaptureCommand { get; }

        public RelayCommand AnalyzeCommand { get; }

        public RelayCommand SpeechCommand { get; }

        #endregion

        #region Private Methods

        private IPermissions PermissionsPlugin => CrossPermissions.Current;

        private IMedia MediaPlugin => CrossMedia.Current;

        private ISimpleAudioPlayer AudioPlugin => CrossSimpleAudioPlayer.Current;

        private void CaptureCommandExecute()
        {
            RunBusyAction(async () =>
            {
                try
                {
                    var canAccessCamera = await CanAccessCameraAsync();

                    if (!canAccessCamera)
                        return;

                    _photo = await TakePhotoAsync();

                    if (_photo == null)
                        return;

                    PhotoSource = ImageSource.FromStream(_photo.GetStream);
                    Description = string.Empty;
                }
                catch (Exception exception)
                {
                    Description = $"Error: {exception.Message}.";
                }
            });
        }

        private bool CaptureCommandCanExecute()
        {
            if (IsBusy)
                return false;

            return true;
        }

        private void AnalyzeCommandExecute()
        {
            RunBusyAction(async () =>
            {
                var descriptionInEnglish = await GetDescriptionForPhotoAsync(_photo);
                var descriptionInGerman = await GetTranslationForTextAsync(descriptionInEnglish, "de");

                Description = descriptionInGerman;
            });
        }

        private bool AnalyzeCommandCanExecute()
        {
            if (IsBusy)
                return false;

            if (_photo == null)
                return false;

            return true;
        }

        private void SpeechCommandExecute()
        {
            RunBusyAction(async () =>
            {
                var speechToken = await GetAccessTokenAsync(Configuration.TextToSpeechKey);
                var speechOutput = await GetSpeechFromText(Description, speechToken);

                await PlayAudioAsync(speechOutput);
            });
        }

        private bool SpeechCommandCanExecute()
        {
            if (IsBusy)
                return false;

            if (string.IsNullOrWhiteSpace(Description))
                return false;

            return true;
        }

        private async void RunBusyAction(Func<Task> action)
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                await action();
            }
            finally
            {
                IsBusy = false;
            }
        }

        private async Task<bool> CanAccessCameraAsync()
        {
            var permissionStatus = await PermissionsPlugin.CheckPermissionStatusAsync(Permission.Camera);

            if (permissionStatus != PermissionStatus.Granted)
            {
                var results = await PermissionsPlugin.RequestPermissionsAsync(Permission.Camera);
                permissionStatus = results[Permission.Camera];
            }

            return permissionStatus == PermissionStatus.Granted;
        }

        private async Task<MediaFile> TakePhotoAsync()
        {
            await MediaPlugin.Initialize();

            if (!MediaPlugin.IsCameraAvailable)
                throw new Exception("No camera available.");

            if (!MediaPlugin.IsTakePhotoSupported)
                throw new Exception("Can not take photos.");

            var newPhotoOptions = new StoreCameraMediaOptions
            {
                PhotoSize = PhotoSize.MaxWidthHeight,
                MaxWidthHeight = 1920,
                CompressionQuality = 80,
                SaveToAlbum = false,
                DefaultCamera = CameraDevice.Rear
            };

            return await MediaPlugin.TakePhotoAsync(newPhotoOptions);
        }

        private async Task<string> GetDescriptionForPhotoAsync(MediaFile photo)
        {
            var credentials = new ApiKeyServiceClientCredentials(Configuration.ComputerVisionKey);

            var visionClient = new ComputerVisionClient(credentials, _httpClient, false)
            {
                Endpoint = Configuration.ComputerVisionEndPoint
            };

            var features = new List<VisualFeatureTypes>
            {
                VisualFeatureTypes.Description
            };

            try
            {
                var analysisResult = await visionClient.AnalyzeImageInStreamAsync(
                    photo.GetStream(),
                    features,
                    language: "en");

                var bestCaption = analysisResult.Description.Captions.FirstOrDefault();

                return bestCaption != null ? bestCaption.Text : "No description found.";
            }
            catch (Exception exception)
            {
                return $"Error: {exception.Message}";
            }
        }

        private async Task<string> GetTranslationForTextAsync(string text, string targetLanguageCode)
        {
            var uri = $"{Configuration.TranslationEndPoint}&to={targetLanguageCode}";
            var body = "[{ \"Text\": \"" + text + "\"}]";

            var httpContent = new StringContent(body, Encoding.UTF8, "application/json");
            httpContent.Headers.Add("Ocp-Apim-Subscription-Key", Configuration.TranslationKey);

            try
            {
                var httpResponse = await _httpClient.PostAsync(uri, httpContent);

                if (!httpResponse.IsSuccessStatusCode)
                    return $"HTTP Error: {httpResponse.StatusCode}";

                var jsonResponse = await httpResponse.Content.ReadAsStringAsync();
                dynamic textBlocks = JArray.Parse(jsonResponse);
                string translatedText = textBlocks[0].translations[0].text;

                return translatedText;
            }
            catch(Exception exception)
            {
                return $"Communication Error: {exception.Message}";
            }
        }

        private async Task<string> GetAccessTokenAsync(string serviceKey)
        {
            var uri = Configuration.FetchTokenEndPoint;

            var httpContent = new StringContent(string.Empty);
            httpContent.Headers.Add("Ocp-Apim-Subscription-Key", serviceKey);

            try
            {
                var httpResponse = await _httpClient.PostAsync(uri, httpContent);

                if (!httpResponse.IsSuccessStatusCode)
                    return string.Empty;

                var token = await httpResponse.Content.ReadAsStringAsync();

                return token;
            }
            catch (Exception exception)
            {
                return $"Communication Error: {exception.Message}";
            }
        }

        private async Task<byte[]> GetSpeechFromText(string text, string accessToken)
        {
            var uri = Configuration.TextToSpeechEndPoint;
            var body = "<speak version=\"1.0\" xmlns=\"http://www.w3.org/2001/10/synthesis\" xml:lang=\"en-US\"><voice name=\"Microsoft Server Speech Text to Speech Voice (de-CH, Karsten)\">" + text + "</voice></speak>";

            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri(uri),
                Content = new StringContent(body, Encoding.UTF8, "application/ssml+xml")
            };
            request.Headers.Add("Authorization", $"Bearer {accessToken}");
            request.Headers.Add("Connection", "Keep-Alive");
            request.Headers.Add("Cache-Control", "no-cache");
            request.Headers.Add("User-Agent", Configuration.TextToSpeechService);
            request.Headers.Add("X-Microsoft-OutputFormat", "audio-24khz-96kbitrate-mono-mp3");

            try
            {
                var httpResponse = await _httpClient.SendAsync(request);

                if (!httpResponse.IsSuccessStatusCode)
                    return new byte[0];

                return await httpResponse.Content.ReadAsByteArrayAsync();
            }
            catch
            {
                return new byte[0];
            }
        }

        private Task PlayAudioAsync(byte[] audio)
        {
            using (var stream = new MemoryStream(audio))
            {
                AudioPlugin.Load(stream);
                AudioPlugin.Play();

                return Task.CompletedTask;
            }
        }

        #endregion
    }
}
