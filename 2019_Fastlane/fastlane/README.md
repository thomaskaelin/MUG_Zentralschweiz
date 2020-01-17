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
### reset
```
fastlane reset
```
Reverts local changes to the source code of the Android- and iOS-app and deletes temporary data.
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
### ios build_adhoc
```
fastlane ios build_adhoc
```
Creates an IPA for AdHoc-deployment from source code.
### ios build_store
```
fastlane ios build_store
```
Creates an IPA for Store-deployment from source code. Only available for 'Production'-environment.
### ios install
```
fastlane ios install
```
Installs a previously built IPA on the connect device.
### ios build_adhoc_and_install
```
fastlane ios build_adhoc_and_install
```
Combines the lanes 'build_adhoc' and 'install'.
### ios deploy
```
fastlane ios deploy
```
Deploys a previously built IPA to Visual Studio App Center.
### ios publish
```
fastlane ios publish
```
Deploys a previously built IPA to the Apple App Store. Only available for 'Production'-environment.
### ios sync_certificates
```
fastlane ios sync_certificates
```
Synchronizes all mandatory certificates with the Apple Developer Portal. If necessary, certificates will be updated.

----

This README.md is auto-generated and will be re-generated every time [fastlane](https://fastlane.tools) is run.
More information about fastlane can be found on [fastlane.tools](https://fastlane.tools).
The documentation of fastlane can be found on [docs.fastlane.tools](https://docs.fastlane.tools).
