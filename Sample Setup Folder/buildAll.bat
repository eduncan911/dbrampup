rd working /Q /S
xcopy *.* working  /Y /I
cd ..

echo.

xcopy **WEBFOLDER**\bin\*.* setup\working  /Y /I
xcopy **WEBFOLDER**\*.config setup\working /Y /I
echo.

ren setup\working\web.config DBRampUp.exe.config

setup\working\DBRampUp.exe -teardowndb -buildDB -CustomSettings -test -log 
rd setup\working /Q /S