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
### android build
```
fastlane android build
```
Create an APK from source code.
### android install
```
fastlane android install
```
Installs a previously built APK on the connect device.
### android build_and_install
```
fastlane android build_and_install
```
Combines the lanes 'build' and 'install'.

----

## iOS
### ios build
```
fastlane ios build
```
Create an IPA from source code.

----

This README.md is auto-generated and will be re-generated every time [fastlane](https://fastlane.tools) is run.
More information about fastlane can be found on [fastlane.tools](https://fastlane.tools).
The documentation of fastlane can be found on [docs.fastlane.tools](https://docs.fastlane.tools).
