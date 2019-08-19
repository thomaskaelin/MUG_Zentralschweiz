fastlane documentation
================
# Installation

Make sure you have the latest version of the Xcode command line tools installed:

```
xcode-select --install
```

Install _fastlane_ using
```
[sudo] gem install fastlane -NV
```
or alternatively using `brew cask install fastlane`

# Available Actions
### tests
```
fastlane tests
```
Executes unit- and integration-tests.

----

## Android
### android reset
```
fastlane android reset
```
Reverts local changes to the source code of the Android-app and deletes temporary data.
### android build
```
fastlane android build
```
Creates an APK from source code.
### android install
```
fastlane android install
```
Installs a previously built APK on the connect device.
### android deploy
```
fastlane android deploy
```
Deploys a previously built APK to Visual Studio App Center.
### android publish
```
fastlane android publish
```
Deploys a previously built APK to Google Play Store. Only available for 'Production'-environment.
### android build_and_install
```
fastlane android build_and_install
```
Combines the lanes 'build' and 'install'.

----

## iOS
### ios reset
```
fastlane ios reset
```
Reverts local changes to the source code of the iOS-app and deletes temporary data.
### ios build
```
fastlane ios build
```
Creates an IPA from source code.
### ios sync_certificates
```
fastlane ios sync_certificates
```
Synchronizes all mandatory certificates with the Apple Developer Portal. If necessary, certificates will be updated.

----

This README.md is auto-generated and will be re-generated every time [fastlane](https://fastlane.tools) is run.
More information about fastlane can be found on [fastlane.tools](https://fastlane.tools).
The documentation of fastlane can be found on [docs.fastlane.tools](https://docs.fastlane.tools).
