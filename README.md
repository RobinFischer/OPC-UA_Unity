{\rtf1\ansi\ansicpg1252\deff0\nouicompat{\fonttbl{\f0\fnil\fcharset0 Courier New;}{\f1\froman\fprq2\fcharset0 Times New Roman;}{\f2\froman\fprq2\fcharset0 Consolas;}}
{\colortbl ;\red0\green0\blue255;\red0\green0\blue0;\red255\green255\blue255;\red46\green117\blue182;\red163\green21\blue21;}
{\*\generator Riched20 10.0.17134}\viewkind4\uc1 
\pard\f0\fs22\lang1031 # OPC-UA_Unity\par
Disclamer: Project is depricated and doesn't seem to work anymore!\par
\par
## Overview\par
This Project has been developed as a students project of the Hochschule Darmstadt.\par
an OPC UA Sample Client. Designed to be used with a Microsoft HoloLens.\par
Code is based on the Sample Client of the OPC Foundation: {{\field{\*\fldinst{HYPERLINK https://github.com/OPCFoundation/UA-.NETStandard }}{\fldrslt{https://github.com/OPCFoundation/UA-.NETStandard\ul0\cf0}}}}\f0\fs22\par
\par
## Getting Started\par
\par

\pard\nowidctlpar\hyphpar0\kerning1\ul\b\f1\fs32\lang255 Creating a Hololens OPC Client\par
\ulnone\b0\fs24\par
\fs28 by C. Malauschek\fs24\par
\par
The steps to build a Hololens application with OPC functionality include the following 3 steps:\par
- create a OPC library class with Visual Studio that Unity can compile correctly \par
- create a Unity project for hologram functionality\par
- build the UWP app of the Unity solution with Visual Studio\par
\par
\ul\b\fs28 Create the DLL\ulnone\b0\fs24\par
\b\fs28\par
\b0\fs24 Download and install the newest Version of Visual Studio.\par
Make sure you install the following components: \par
\par
- .NET desktop development\par
- Universal Windows Platform development (with latest Windows 10 SDK)\par
- Game development with Unity\par
\par
Create a new Project with Visual Studio.\par
File -> New -> Project\par
\par
In the "New Project" window select "Class Library (.NET STandard)"\par
 Visual C# -> .NET Standard -> Class Library (.NET STandard)\par
\par
Name the project as you want und click "OK"\par
\par
To make your code work with the Hololens you need  Netstandard 1.4 functionality. \par
Therfore you have to make the following change:\par
\par
Go to the project folder: \par
Right-Click on Project -> Open Folder in File Explorer\par
\par
Open the .csproj file of the project with a text editor.\par
Add in the property group "Target Frameworks" the string: "netstandard1.4" and save the file.\par
It should look like this:\par
\par
  <PropertyGroup>\par
    <TargetFrameworks>netstandard1.4;net46</TargetFrameworks>\par
    <ApplicationIcon />\par
    <OutputType>Library</OutputType>\par
    <StartupObject />\par
    <GeneratePackageOnBuild>true</GeneratePackageOnBuild>\par
  </PropertyGroup>\par
\par
\par
You can download the OPC Foundation library with NuGet, a package manager.\par
In Visual Studio open the NuGet Manager.\par
Right-Click on project -> Manage NuuGet Packages.\par
\par
In the "Browse" tab searsch for "OPC" and download "OPCFoundation.NetStandard.Opc.Ua" Version="1.3.352.12".\par
\par
Your project should now  look like this:\par
\par
![alt text]({{\field{\*\fldinst{HYPERLINK https://github.com/RobinFischer/OPC-UA_Unity/blob/OPC-UA_Unity2018.1.1f1/doc/image_1.png }}{\fldrslt{https://github.com/RobinFischer/OPC-UA_Unity/blob/OPC-UA_Unity2018.1.1f1/doc/image_1.png\ul0\cf0}}}}\f1\fs24  "image_1")\par
\par
You can now write your code into the Class1.cs created within the project. \par
For a simple OPC client use the code in the appendix (sample_client.cs)\par
\par
You can now build the project and the DLL files are created in the "bin" folder of the project.\par
\par
\ul\b\fs28 Create the Unity Project\ulnone\b0\fs24\par
\par
Download  Unity 2018.1.1f1  (there will be errors in newer versions) and create a new project.\par
\par
Create a folder in "Assets" named "Plugins". Unity will automatically load  DLL files in this folder.\par
Create two subfolders, "net46" and "netstandard1.4". Paste your created  DLLs in these folders accordingly.\par
\par
Select all files within the \b "net46" \b0 folder and in the Inspector window check to only include platforms "Editor" and "Standalone". It should look like this:\par
\par
![alt text]({{\field{\*\fldinst{HYPERLINK https://github.com/RobinFischer/OPC-UA_Unity/blob/OPC-UA_Unity2018.1.1f1/doc/image_2.png }}{\fldrslt{https://github.com/RobinFischer/OPC-UA_Unity/blob/OPC-UA_Unity2018.1.1f1/doc/image_2.png\ul0\cf0}}}}\f1\fs24  "image_2")\par
\par
Select all files within the \b "netstandard1.4" \b0 folder and in the Inspector window check to only include platforms "WSAPlayer" and the "Don't process" box. It should look like this:\par
\par
![alt text]({{\field{\*\fldinst{HYPERLINK https://github.com/RobinFischer/OPC-UA_Unity/blob/OPC-UA_Unity2018.1.1f1/doc/image_3.png }}{\fldrslt{https://github.com/RobinFischer/OPC-UA_Unity/blob/OPC-UA_Unity2018.1.1f1/doc/image_3.png\ul0\cf0}}}}\f1\fs24  "image_3")\par
\par
Create a new GameObject in the Scene.\par
Right-Click in "Hierarchy" window -> Create Empty\par
\par
Create a new C# script in the the assets folder.\par
Here you put your code that executes the functions you created before in the DLL (see Appendix: unity_script.cs)\par
\par
Add the script to the empty game object.\par
\par
\b\fs28 Settings\b0\fs24\par
\b\par
\b0 Go to: File -> Build Settings.\par
- Select the scene with the gameobject with the script attached to it.\par
- Switch to Platform "Universal Windows Platform".\par
- Change the "Target Device" to "Hololens".\par
- Select the latest Windows 10 SDK.\par
It should look similiar to this: \par
\par
![alt text]({{\field{\*\fldinst{HYPERLINK https://github.com/RobinFischer/OPC-UA_Unity/blob/OPC-UA_Unity2018.1.1f1/doc/image_4.png }}{\fldrslt{https://github.com/RobinFischer/OPC-UA_Unity/blob/OPC-UA_Unity2018.1.1f1/doc/image_4.png\ul0\cf0}}}}\f1\fs24  "image_4")\par
\par
Open the Player Settings.\par
\par
In the "Other Settings" tab make sure to configure like this:\par
\par
![alt text]({{\field{\*\fldinst{HYPERLINK https://github.com/RobinFischer/OPC-UA_Unity/blob/OPC-UA_Unity2018.1.1f1/doc/image_5.png }}{\fldrslt{https://github.com/RobinFischer/OPC-UA_Unity/blob/OPC-UA_Unity2018.1.1f1/doc/image_5.png\ul0\cf0}}}}\f1\fs24  "image_5")\par
\par
In the "Publishing Settings" check the following boxes:\par
\par
![alt text]({{\field{\*\fldinst{HYPERLINK https://github.com/RobinFischer/OPC-UA_Unity/blob/OPC-UA_Unity2018.1.1f1/doc/image_6.png }}{\fldrslt{https://github.com/RobinFischer/OPC-UA_Unity/blob/OPC-UA_Unity2018.1.1f1/doc/image_6.png\ul0\cf0}}}}\f1\fs24  "image_6")\par
\par
In the "XR Settings" check "Virtual Reality Supported": \par
\par
![alt text]({{\field{\*\fldinst{HYPERLINK https://github.com/RobinFischer/OPC-UA_Unity/blob/OPC-UA_Unity2018.1.1f1/doc/image_7.png }}{\fldrslt{https://github.com/RobinFischer/OPC-UA_Unity/blob/OPC-UA_Unity2018.1.1f1/doc/image_7.png\ul0\cf0}}}}\f1\fs24  "image_7")\par
\par
Now build the project in a new folder within the project named "App".\par
\par
\par

\pard\pagebb\nowidctlpar\hyphpar0\ul\b\fs28 Create the UWP App\ulnone\b0\fs24\par

\pard\nowidctlpar\hyphpar0\par
After compiling open the created solution file.(sls) with Visual Studio.\par
\par
In the Solution Explorer open the "project.json" file and change the code to the following:\par
\par
\cf2\highlight3\f2\fs19\{\cf0\highlight0\f1\fs24\par
\cf2\highlight3\f2\fs19   \cf4 "dependencies"\cf2 : \{\cf0\highlight0\f1\fs24\par
\cf2\highlight3\f2\fs19     \cf4 "Microsoft.ApplicationInsights"\cf2 : \cf5 "1.0.0"\cf2 ,\cf0\highlight0\f1\fs24\par
\cf2\highlight3\f2\fs19     \cf4 "Microsoft.ApplicationInsights.PersistenceChannel"\cf2 : \cf5 "1.0.0"\cf2 ,\cf0\highlight0\f1\fs24\par
\cf2\highlight3\f2\fs19     \cf4 "Microsoft.ApplicationInsights.WindowsApps"\cf2 : \cf5 "1.0.0"\cf2 ,\cf0\highlight0\f1\fs24\par
\cf2\highlight3\f2\fs19     \cf4 "Microsoft.NETCore.UniversalWindowsPlatform"\cf2 : \cf5 "5.2.3"\cf2 ,\cf0\highlight0\f1\fs24\par
\cf2\highlight3\f2\fs19     \cf4 "Newtonsoft.Json"\cf2 : \cf5 "10.0.3"\cf2 ,\cf0\highlight0\f1\fs24\par
\cf2\highlight3\f2\fs19     \cf4 "Portable.BouncyCastle"\cf2 : \cf5 "1.8.1.3"\cf2 ,\cf0\highlight0\f1\fs24\par
\cf2\highlight3\f2\fs19     \cf4 "System.Data.Common"\cf2 : \cf5 "4.3.0"\cf2 ,\cf0\highlight0\f1\fs24\par
\cf2\highlight3\f2\fs19     \cf4 "System.Private.ServiceModel"\cf2 : \cf5 "4.3.0"\cf2 ,\cf0\highlight0\f1\fs24\par
\cf2\highlight3\f2\fs19     \cf4 "System.ServiceModel.Primitives"\cf2 : \cf5 "4.3.0"\cf0\highlight0\f1\fs24\par
\cf2\highlight3\f2\fs19   \},\cf0\highlight0\f1\fs24\par
\cf2\highlight3\f2\fs19   \},\cf0\highlight0\f1\fs24\par
\cf2\highlight3\f2\fs19   \cf5 "frameworks"\cf2 : \{\cf0\highlight0\f1\fs24\par
\cf2\highlight3\f2\fs19     \cf4 "uap10.0"\cf2 : \{\}\cf0\highlight0\f1\fs24\par
\cf2\highlight3\f2\fs19   \},\cf0\highlight0\f1\fs24\par
\cf2\highlight3\f2\fs19   \cf5 "runtimes"\cf2 : \{\cf0\highlight0\f1\fs24\par
\cf2\highlight3\f2\fs19     \cf4 "win10-arm"\cf2 : \{\},\cf0\highlight0\f1\fs24\par
\cf2\highlight3\f2\fs19     \cf4 "win10-arm-aot"\cf2 : \{\},\cf0\highlight0\f1\fs24\par
\cf2\highlight3\f2\fs19     \cf4 "win10-x86"\cf2 : \{\},\cf0\highlight0\f1\fs24\par
\cf2\highlight3\f2\fs19     \cf4 "win10-x86-aot"\cf2 : \{\},\cf0\highlight0\f1\fs24\par
\cf2\highlight3\f2\fs19     \cf4 "win10-x64"\cf2 : \{\},\cf0\highlight0\f1\fs24\par
\cf2\highlight3\f2\fs19     \cf4 "win10-x64-aot"\cf2 : \{\}\cf0\highlight0\f1\fs24\par
\cf2\highlight3\f2\fs19   \}\cf0\highlight0\f1\fs24\par
\cf2\highlight3\f2\fs19\}\cf0\highlight0\f1\fs24\par
\par
Build the project. \par
\par
You can test it on the Local Machine or the Device. Make sure you have a working OPC Server, otherwise there will be errors.\par
\par
\par
\b\fs28 Annotation\b0\fs24\par
\b\fs28\par
\b0\fs24 I recomment to download the latest OPC Foundation Sample .Net Server and test it with that before you deploy on a real device ( {{\field{\*\fldinst{HYPERLINK https://github.com/OPCFoundation/UA-.NET-Legacy }}{\fldrslt{https://github.com/OPCFoundation/UA-.NET-Legacy\ul0\cf0}}}}\f1\fs24  ).\par
\par
Due to the DLL workaround in Unity it is not possible to use propper console funktions for debugging purposes. \par
In addition if you want to change something in the functionality of the client it has to be done in the DLL, thus it is a huge build cycle involved everytime. \par
\par

\pard\kerning0\f0\fs22\lang1031\par
(c) Hochschule Darmstadt\par
\par
}
 