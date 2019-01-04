#!/bin/sh

MSBUILD=msbuild
APPCENTER=appcenter
TESTCLOUD=$HOME"/.nuget/packages/xamarin.uitest/2.2.7/tools"

ANDROID_PROJ="../MUGAppCenter.UI.Android/MUGAppCenter.UI.Android.csproj"
ANDROID_PROJ_CFG="Release"
ANDROID_OUTPUT="../MUGAppCenter.UI.Android/bin/Release/ch.mugz.mug_app_center-Signed.apk"

TEST_PROJ="../MUGAppCenter.Test.UI/MUGAppCenter.Test.UI.csproj"
TEST_PROJ_CFG="Release"
TEST_OUTPUT="../MUGAppCenter.Test.UI/bin/Release/"

APPCENTER_APP="Mobile-User-Group-Zentralschweiz/Hello-App-Center"
APPCENTER_DEVICES=61ed3b41
APPCENTER_SERIES="master"
APPCENTER_LOCALE="de_DE"

clear

$MSBUILD $ANDROID_PROJ /t:Clean,Restore,SignAndroidPackage /p:Configuration="$ANDROID_PROJ_CFG"
$MSBUILD $TEST_PROJ /t:Clean,Restore,Build /p:Configuration="$TEST_PROJ_CFG" /p:BuildProjectReferences=false

$APPCENTER login
$APPCENTER test run uitest \
  --app $APPCENTER_APP \
  --devices $APPCENTER_DEVICES \
  --app-path $ANDROID_OUTPUT \
  --test-series $APPCENTER_SERIES \
  --locale $APPCENTER_LOCALE \
  --build-dir $TEST_OUTPUT \
  --uitest-tools-dir $TESTCLOUD