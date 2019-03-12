namespace ACS
{
    public static class Configuration
    {
        public static string DataCenterLocation = "westeurope";

        public static string MultiServiceKey = "";

        public static string FetchTokenEndPoint = $"https://{DataCenterLocation}.api.cognitive.microsoft.com/sts/v1.0/issueToken";

        public static string ComputerVisionEndPoint = $"https://{DataCenterLocation}.api.cognitive.microsoft.com";
        public static string ComputerVisionKey = MultiServiceKey;

        public static string TranslationEndPoint = "https://api.cognitive.microsofttranslator.com/translate/?api-version=3.0";
        public static string TranslationKey = "";

        public static string TextToSpeechEndPoint = $"https://{DataCenterLocation}.tts.speech.microsoft.com/cognitiveservices/v1";
        public static string TextToSpeechKey = "";
        public static string TextToSpeechService = "";
    }
}
