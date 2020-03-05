set /P path="Where should i put Admy's folder? "
IF NOT "%path:~-1%"=="\" (path=%path%\)
xcopy /E /I "%~dp0admy" "%path%\admy"
reg add "HKEY_CLASSES_ROOT\exefile\shell\Admy it!\command" /d "%path%admy\admy_client.exe \"%%1\""
reg add "HKEY_CLASSES_ROOT\exefile\shell\Admy it!" /f /v "Icon" /t REG_SZ /d "%path%admy\u_icon.ico"
reg add "HKEY_CLASSES_ROOT\Msi.Package\shell\Admy it!\command" /d "%path%admy\admy_client.exe \"%%1\""
reg add "HKEY_CLASSES_ROOT\Msi.Package\shell\Admy it!" /f /v "Icon" /t REG_SZ /d "%path%admy\u_icon.ico"
pause