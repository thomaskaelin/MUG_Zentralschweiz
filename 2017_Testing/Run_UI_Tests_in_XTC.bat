set MSBUILD="C:\Program Files (x86)\MSBuild\14.0\Bin\MSBuild.exe"
set XTC_CLIENT="packages\Xamarin.UITest.2.0.8\tools\test-cloud.exe"
set SOLUTION="MUG_App.sln"
set ANDROID_PROJ="MUG_App\MUG_App.Android\MUG_App.Android.csproj"
set UITEST_PROJ="MUG_App.Test\MUG_App.Test.UI.csproj"

%MSBUILD% %SOLUTION% /t:Clean /p:Configuration=Debug /v:minimal
%MSBUILD% %SOLUTION% /t:Clean /p:Configuration=Release /v:minimal
%MSBUILD% %ANDROID_PROJ% /t:SignAndroidPackage /p:Configuration=Release /v:minimal
%MSBUILD% %UITEST_PROJ% /t:Build /p:Configuration=Release /v:minimal

%XTC_CLIENT% submit^
	MUG_App\MUG_App.Android\bin\Release\MUG_App.Android-Signed.apk^
	6c65c18ebeb015bb5abbc16e8dc8ab56^
	--devices 46034fd0^
	--series "master"^
	--locale "en_US"^
	--user thomas.kaelin@bbv.ch^
	--assembly-dir MUG_App.Test\bin\Release