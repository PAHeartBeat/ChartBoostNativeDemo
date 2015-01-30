#Chartboost Unity SDK 5.1.1
Chartboost Unity SDK Demo project

##Change Log
============
###v1.1
Preprocessor `TESTMODE_CHARTBOOST` used to display OnGUI buttons
	- For final build remove 'TESTMODE_CHARTBOOST' from Unity Build setting
- Remove `ChartboostSettings.assets` file from "Chartboost/Resources" folder
- Remove `CBSettings.cs` file from Chartboost warper.
- Remove `CBSettingsEditor.cs` and `CBManifestEditor.cs` from editor.
- Modifyes `CBExternal.cs` remove lines which get data from `ChartboostSettings.assets` using `CBSetings.cs`
- Modify `CBPostProcess.cs` now it will not mearge and create new manifest for android and call iOS post process from new folder structure.
- Folder structure chages
	- `_Demo` Contins Chartboost SDK Example Scene and script
	- `Editor/Chartboost` Cantinas Chartboost Preprossors and editor settings
	- `Plugins/Andorid` Cantinas ChartboostSDK folder with jar and libs
	- `Plugins/Chartboost`Cantinas wraper code for iOS and Andorid
	- `Plugins/iOS` Cantinas chartboost iOS Native codes
- Removes Chartboost pefeb
- Modify `Chartboost.cs` add new static construcuter which will now add chartboost Manager gameobject in scene if it's not present to recevie events from native codes

###v1.0
- Chatboost Unity SDK v5.1.1
- Basic Tested code with iOS Platform
- Support `shouldDisplayInterstitial()`, `shouldDisplayMoreApps()` and `shouldDisplayRewardedVideo()` delegate methods
- AutoCache On this project
