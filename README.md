# OPC-UA_Unity
Disclamer: Project is depricated and doesn't seem to work anymore!

## Overview
This Project has been developed as a students project of the Hochschule Darmstadt.
an OPC UA Sample Client. Designed to be used with a Microsoft HoloLens.
Code is based on the Sample Client of the OPC Foundation: https://github.com/OPCFoundation/UA-.NETStandard

## Getting Started

Creating a Hololens OPC Client

by C. Malauschek

The steps to build a Hololens application with OPC functionality include the following 3 steps:
- create a OPC library class with Visual Studio that Unity can compile correctly 
- create a Unity project for hologram functionality
- build the UWP app of the Unity solution with Visual Studio

Create the DLL

Download and install the newest Version of Visual Studio.
Make sure you install the following components: 

- .NET desktop development
- Universal Windows Platform development (with latest Windows 10 SDK)
- Game development with Unity

Create a new Project with Visual Studio.
File -> New -> Project

In the "New Project" window select "Class Library (.NET STandard)"
 Visual C# -> .NET Standard -> Class Library (.NET STandard)

Name the project as you want und click "OK"

To make your code work with the Hololens you need  Netstandard 1.4 functionality. 
Therfore you have to make the following change:

Go to the project folder: 
Right-Click on Project -> Open Folder in File Explorer

Open the .csproj file of the project with a text editor.
Add in the property group "Target Frameworks" the string: "netstandard1.4" and save the file.
It should look like this:

  <PropertyGroup>
    <TargetFrameworks>netstandard1.4;net46</TargetFrameworks>
    <ApplicationIcon />
    <OutputType>Library</OutputType>
    <StartupObject />
    <GeneratePackageOnBuild>true</GeneratePackageOnBuild>
  </PropertyGroup>


You can download the OPC Foundation library with NuGet, a package manager.
In Visual Studio open the NuGet Manager.
Right-Click on project -> Manage NuuGet Packages.

In the "Browse" tab searsch for "OPC" and download "OPCFoundation.NetStandard.Opc.Ua" Version="1.3.352.12".

Your project should now  look like this:

![alt text](https://github.com/RobinFischer/OPC-UA_Unity/blob/OPC-UA_Unity2018.1.1f1/doc/image_1.png "image_1")

You can now write your code into the Class1.cs created within the project. 
For a simple OPC client use the code in the appendix (sample_client.cs)

You can now build the project and the DLL files are created in the "bin" folder of the project.

Create the Unity Project

Download  Unity 2018.1.1f1  (there will be errors in newer versions) and create a new project.

Create a folder in "Assets" named "Plugins". Unity will automatically load  DLL files in this folder.
Create two subfolders, "net46" and "netstandard1.4". Paste your created  DLLs in these folders accordingly.

Select all files within the "net46" folder and in the Inspector window check to only include platforms "Editor" and "Standalone". It should look like this:

![alt text](https://github.com/RobinFischer/OPC-UA_Unity/blob/OPC-UA_Unity2018.1.1f1/doc/image_2.png "image_2")

Select all files within the "netstandard1.4" folder and in the Inspector window check to only include platforms "WSAPlayer" and the "Don't process" box. It should look like this:

![alt text](https://github.com/RobinFischer/OPC-UA_Unity/blob/OPC-UA_Unity2018.1.1f1/doc/image_3.png "image_3")

Create a new GameObject in the Scene.
Right-Click in "Hierarchy" window -> Create Empty

Create a new C# script in the the assets folder.
Here you put your code that executes the functions you created before in the DLL (see Appendix: unity_script.cs)

Add the script to the empty game object.

Settings

Go to: File -> Build Settings.
- Select the scene with the gameobject with the script attached to it.
- Switch to Platform "Universal Windows Platform".
- Change the "Target Device" to "Hololens".
- Select the latest Windows 10 SDK.
It should look similiar to this: 

![alt text](https://github.com/RobinFischer/OPC-UA_Unity/blob/OPC-UA_Unity2018.1.1f1/doc/image_4.png "image_4")

Open the Player Settings.

In the "Other Settings" tab make sure to configure like this:

![alt text](https://github.com/RobinFischer/OPC-UA_Unity/blob/OPC-UA_Unity2018.1.1f1/doc/image_5.png "image_5")

In the "Publishing Settings" check the following boxes:

![alt text](https://github.com/RobinFischer/OPC-UA_Unity/blob/OPC-UA_Unity2018.1.1f1/doc/image_6.png "image_6")

In the "XR Settings" check "Virtual Reality Supported": 

![alt text](https://github.com/RobinFischer/OPC-UA_Unity/blob/OPC-UA_Unity2018.1.1f1/doc/image_7.png "image_7")

Now build the project in a new folder within the project named "App".


Create the UWP App

After compiling open the created solution file.(sls) with Visual Studio.

In the Solution Explorer open the "project.json" file and change the code to the following:

{
  "dependencies": {
    "Microsoft.ApplicationInsights": "1.0.0",
    "Microsoft.ApplicationInsights.PersistenceChannel": "1.0.0",
    "Microsoft.ApplicationInsights.WindowsApps": "1.0.0",
    "Microsoft.NETCore.UniversalWindowsPlatform": "5.2.3",
    "Newtonsoft.Json": "10.0.3",
    "Portable.BouncyCastle": "1.8.1.3",
    "System.Data.Common": "4.3.0",
    "System.Private.ServiceModel": "4.3.0",
    "System.ServiceModel.Primitives": "4.3.0"
  },
  },
  "frameworks": {
    "uap10.0": {}
  },
  "runtimes": {
    "win10-arm": {},
    "win10-arm-aot": {},
    "win10-x86": {},
    "win10-x86-aot": {},
    "win10-x64": {},
    "win10-x64-aot": {}
  }
}

Build the project. 

You can test it on the Local Machine or the Device. Make sure you have a working OPC Server, otherwise there will be errors.


Annotation

I recomment to download the latest OPC Foundation Sample .Net Server and test it with that before you deploy on a real device ( https://github.com/OPCFoundation/UA-.NET-Legacy ).

Due to the DLL workaround in Unity it is not possible to use propper console funktions for debugging purposes. 
In addition if you want to change something in the functionality of the client it has to be done in the DLL, thus it is a huge build cycle involved everytime. 


(c) Hochschule Darmstadt
