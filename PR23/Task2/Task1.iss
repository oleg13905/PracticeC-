#define MyAppName "Task2"
#define MyAppVersion GetDateTimeString('yyyy.mm.dd', '', '')
#define MyAppPublisher "PR23"
#define MyAppExeName "Task1.exe"
; Источник файлов приложения (готовый publish/выход сборки)
#define MyAppSourceDir "d:\КПиЯП\Практика\PR23\Task1"
; Куда класть собранный инсталлятор
#define MyOutputDir "d:\КПиЯП\Практика\PR23\Task2\installer"
#define MyWebUrl "http://localhost:5000"
#define MyTaskName "Task2-Autostart"

[Setup]
AppId={{9D6D1B18-7E2B-4B8E-9E3A-5F9E74A4D4A5}}
AppName={#MyAppName}
AppVersion={#MyAppVersion}
AppPublisher={#MyAppPublisher}
DefaultDirName={autopf}\{#MyAppName}
DefaultGroupName={#MyAppName}
DisableProgramGroupPage=yes
OutputDir={#MyOutputDir}
OutputBaseFilename={#MyAppName}-Setup
Compression=lzma2
SolidCompression=yes
WizardStyle=modern
ArchitecturesAllowed=x64
ArchitecturesInstallIn64BitMode=x64

[Languages]
Name: "ru"; MessagesFile: "compiler:Languages\Russian.isl"

[Tasks]
Name: "desktopicon"; Description: "Создать значок на рабочем столе"; GroupDescription: "Дополнительно:"; Flags: unchecked
Name: "autostart"; Description: "Автозапуск (Планировщик заданий)"; GroupDescription: "Дополнительно:"; Flags: unchecked

[Dirs]
Name: "{localappdata}\{#MyAppName}"

[Files]
Source: "{#MyAppSourceDir}\*"; DestDir: "{app}"; Flags: ignoreversion recursesubdirs createallsubdirs

[Icons]
Name: "{autoprograms}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"
Name: "{autoprograms}\{#MyAppName}\Открыть сайт"; Filename: "{cmd}"; Parameters: "/c start """" ""{#MyWebUrl}"""
Name: "{autodesktop}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"; Tasks: desktopicon
Name: "{autodesktop}\{#MyAppName} (сайт)"; Filename: "{cmd}"; Parameters: "/c start """" ""{#MyWebUrl}"""; Tasks: desktopicon

[Run]
Filename: "{sys}\schtasks.exe"; \
  Parameters: "/Create /F /SC ONLOGON /RL LIMITED /TN ""{#MyTaskName}"" /TR """"""{app}\{#MyAppExeName}"""""""; \
  Flags: runhidden; Tasks: autostart

Filename: "{app}\{#MyAppExeName}"; Description: "Запустить {#MyAppName}"; Flags: nowait postinstall skipifsilent

[UninstallRun]
Filename: "{sys}\schtasks.exe"; Parameters: "/Delete /F /TN ""{#MyTaskName}"""; Flags: runhidden

[Code]
function ReplaceAll(const S, FromStr, ToStr: string): string;
var
  P: Integer;
  R: string;
begin
  R := S;
  P := Pos(FromStr, R);
  while P > 0 do
  begin
    Delete(R, P, Length(FromStr));
    Insert(ToStr, R, P);
    P := Pos(FromStr, R);
  end;
  Result := R;
end;

procedure UpdateAppSettingsJson();
var
  Path, ContentS, DbPathWin, DbPathJson: string;
  ContentA: AnsiString;
begin
  Path := ExpandConstant('{app}\appsettings.json');
  if not LoadStringFromFile(Path, ContentA) then
    exit;
  ContentS := String(ContentA);

  DbPathWin := ExpandConstant('{localappdata}\{#MyAppName}\todo.db');
  DbPathJson := ReplaceAll(DbPathWin, '\', '\\');

  ContentS := ReplaceAll(ContentS, 'Data Source=todo.db', 'Data Source=' + DbPathJson);
  SaveStringToFile(Path, ContentS, False);
end;

procedure CurStepChanged(CurStep: TSetupStep);
begin
  if CurStep = ssPostInstall then
    UpdateAppSettingsJson();
end;