# BuildHelpers

- By: Maarten R. Struijk Wilbrink
- For: Leiden University SOSXR
- Fully open source: Feel free to add to, or modify, anything you see fit.


## Installation
1. Open the Unity project you want to install the gizmos into.
2. Open the Package Manager window.
3. Click on the `+` button and select `Add package from git URL...`.
4. Paste the URL of this repo into the text field and press `Add`.


## Usage
This will increment the last digit of the SemVer build number (found in the Project Settings > Player > Version Number). This can be useful for keeping track of the number of builds that have been made, or for debugging purposes. The build number will be incremented every time the game is built. The build number will be reset to 0 when the game is built for the first time. It will do the same for the Android Bundle / Gradle version code, which is used to determine the version of the app in the for ArborXR for example.

You can use TextMeshPro and the `ShowBuildInfo` script to display the build number in the game. Combine this with a [DestroyInProductionBuild script](https://github.com/mrstruijk/BuildHelpers/blob/main/Runtime/DestroyInProductionBuild.cs) for example to remove the build number from the game when it is built for production.

It will log the build number to a .csv which will be stored in the `Assets/Resources/build_info.csv` file. It also logs when the build has been made, and whether it's a production build.

It runs automatically when you're starting a build. This means that it will also increment / log the failed builds. 

It is up to you to manually increment the SemVer numbers at the first and second position. This will only increment the final ('patch') position. E.g:
1. Automatically incremented:
    - 1.0.0 -> 1.0.1
    - 1.0.1 -> 1.0.2
    - 1.0.2 -> 1.0.3
2. Manually incremented:
    - 1.0.3 -> 1.1.0
    - 1.1.0 -> 1.2.0
    - 1.2.0 -> 2.0.0
