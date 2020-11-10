; Script generated by the Inno Setup Script Wizard.
; SEE THE DOCUMENTATION FOR DETAILS ON CREATING INNO SETUP SCRIPT FILES!

#define MyAppName "Gavilya"
#define MyAppVersion "0.4.0.2011"
#define MyAppPublisher "L�o Corporation"
#define MyAppURL "https://www.leocorp.fr/"
#define MyAppExeName "Gavilya.exe"

[Setup]
; NOTE: The value of AppId uniquely identifies this application. Do not use the same AppId value in installers for other applications.
; (To generate a new GUID, click Tools | Generate GUID inside the IDE.)
AppId={{082C0850-C47C-4A75-9513-BE082FE3FA61}
AppName={#MyAppName}
AppVersion={#MyAppVersion}
;AppVerName={#MyAppName} {#MyAppVersion}
AppPublisher={#MyAppPublisher}
AppPublisherURL={#MyAppURL}
AppSupportURL={#MyAppURL}
AppUpdatesURL={#MyAppURL}
DefaultDirName={autopf}\{#MyAppName}
DefaultGroupName=L�o Corp
DisableProgramGroupPage=yes
; The [Icons] "quicklaunchicon" entry uses {userappdata} but its [Tasks] entry has a proper IsAdminInstallMode Check.
UsedUserAreasWarning=no
LicenseFile=C:\Users\L�o Peyronnet\source\repos\Gavilya\LICENSE
; Uncomment the following line to run in non administrative install mode (install for current user only.)
;PrivilegesRequired=admin
PrivilegesRequiredOverridesAllowed=dialog
OutputDir=C:\Users\L�o Peyronnet\source\repos\Gavilya\Gavilya.Setup\Output
OutputBaseFilename=GavilyaSetup
SetupIconFile=C:\Users\L�o Peyronnet\source\repos\Gavilya\Gavilya\Gavilya.ico
Compression=lzma
SolidCompression=yes
WizardStyle=modern

[Languages]
Name: "english"; MessagesFile: "compiler:Default.isl"
Name: "french"; MessagesFile: "compiler:Languages\French.isl"

[Tasks]
Name: "desktopicon"; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked
Name: "quicklaunchicon"; Description: "{cm:CreateQuickLaunchIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked; OnlyBelowVersion: 6.1; Check: not IsAdminInstallMode

[Files]
Source: "C:\Users\L�o Peyronnet\source\repos\Gavilya\Gavilya.Setup\Files\Gavilya.exe"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\L�o Peyronnet\source\repos\Gavilya\Gavilya.Setup\Files\Gavilya.deps.json"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\L�o Peyronnet\source\repos\Gavilya\Gavilya.Setup\Files\Gavilya.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\L�o Peyronnet\source\repos\Gavilya\Gavilya.Setup\Files\gavilya.ico"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\L�o Peyronnet\source\repos\Gavilya\Gavilya.Setup\Files\Gavilya.pdb"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\L�o Peyronnet\source\repos\Gavilya\Gavilya.Setup\Files\Gavilya.runtimeconfig.dev.json"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\L�o Peyronnet\source\repos\Gavilya\Gavilya.Setup\Files\Gavilya.runtimeconfig.json"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\L�o Peyronnet\source\repos\Gavilya\Gavilya.Setup\Files\Gavilya.SDK.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\L�o Peyronnet\source\repos\Gavilya\Gavilya.Setup\Files\LeoCorpLibrary.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\L�o Peyronnet\source\repos\Gavilya\Gavilya.Setup\Files\RestSharp.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\L�o Peyronnet\source\repos\Gavilya\Gavilya.Setup\Files\Xalyus Updater.deps.json"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\L�o Peyronnet\source\repos\Gavilya\Gavilya.Setup\Files\Xalyus Updater.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\L�o Peyronnet\source\repos\Gavilya\Gavilya.Setup\Files\Xalyus Updater.exe"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\L�o Peyronnet\source\repos\Gavilya\Gavilya.Setup\Files\Xalyus Updater.pdb"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\L�o Peyronnet\source\repos\Gavilya\Gavilya.Setup\Files\Xalyus Updater.runtimeconfig.dev.json"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\L�o Peyronnet\source\repos\Gavilya\Gavilya.Setup\Files\Xalyus Updater.runtimeconfig.json"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\L�o Peyronnet\source\repos\Gavilya\Gavilya.Setup\Files\en-US\*"; DestDir: "{app}\en-US"; Flags: ignoreversion recursesubdirs createallsubdirs
Source: "C:\Users\L�o Peyronnet\source\repos\Gavilya\Gavilya.Setup\Files\fr-FR\*"; DestDir: "{app}\fr-FR"; Flags: ignoreversion recursesubdirs createallsubdirs
; NOTE: Don't use "Flags: ignoreversion" on any shared system files

[Icons]
Name: "{group}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"
Name: "{autodesktop}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"; Tasks: desktopicon
Name: "{userappdata}\Microsoft\Internet Explorer\Quick Launch\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"; Tasks: quicklaunchicon

[Run]
Filename: "{app}\{#MyAppExeName}"; Description: "{cm:LaunchProgram,{#StringChange(MyAppName, '&', '&&')}}"; Flags: nowait postinstall skipifsilent

