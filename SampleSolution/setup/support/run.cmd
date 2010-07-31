@ECHO OFF
SETLOCAL
ECHO %~n0, Version 1.0 for DBRampUp

:: Command Line Arguments and directions:
::  %1        => WebsitePath 
::  %2        => PopulateData
::  %3 and %4 => [SolutionPath] [FrameworkVersion]


:: verify the command line arguments
IF "%1"=="/?" GOTO HELP
IF "%1"=="" GOTO HELP
IF "%2"=="" GOTO HELP

IF "%2"=="0" GOTO ContinueVerify
IF "%2"=="1" GOTO ContinueVerify
GOTO HELP

:: Setup some local parameter names
:ContinueVerify
SET websitePath=%1
SET populateData=%2
SET solutionPath=%3
SET framework=%4


::
:: ========== TO BUILD, OR NOT TO BUILD LOGIC ===========
::
IF "%solutionPath%" NEQ "" GOTO BuildSolution
GOTO SetupWorkingDirectory


::
:: ========== BUILD SOLUTION ==========
::
:BuildSolution

ECHO.
ECHO Building solution with options "/t:Build /p:Configuration=Debug"
IF "%framework%"=="4.0" GOTO 40Build
GOTO 35Build

:40Build
ECHO "%windir%\Microsoft.NET\Framework\v4.0.30319\msbuild" %solutionPath% /t:Build /p:Configuration=Debug > setup\build.txt
"%windir%\Microsoft.NET\Framework\v4.0.30319\msbuild" %solutionPath% /t:Build /p:Configuration=Debug >> setup\build.txt
GOTO ContinueBuild

:35Build
ECHO "%windir%\Microsoft.NET\Framework\v3.5\msbuild" %solutionPath% /t:Build /p:Configuration=Debug > setup\build.txt
"%windir%\Microsoft.NET\Framework\v3.5\msbuild" %solutionPath% /t:Build /p:Configuration=Debug >> setup\build.txt
GOTO ContinueBuild

:ContinueBuild
IF ERRORLEVEL = 1 GOTO BuildError
ECHO Solution Build Completed.
DEL setup\build.txt /Q
GOTO SetupWorkingDirectory


::
:: ========== SETUP TEMP DIR ==========
::
:SetupWorkingDirectory
ECHO.
ECHO Setting up Working directory...
IF EXIST setup\temp RD setup\temp /Q /S
XCOPY setup\support\*.* setup\temp /Y /I /Q


::
:: ========== COPY DOMAIN ELEMENTS TO WORKING DIR ==========
::
ECHO.
ECHO Copying bin assemblies and config files ...
XCOPY "%websitePath%\bin\*.*" setup\temp  /Y /I /Q
XCOPY "%websitePath%\*.config" setup\temp /Y /I /Q
IF EXIST setup\temp\web.config REN setup\temp\web.config DBRampUp.exe.config

::
:: ========== TO DEBUG OR NOT TO DEBUG ==========
::
ECHO.
CHOICE /C ny /N /T:5 /D n /M "Pause DBRampUp.exe to attach debugger (Y/N)?"
IF ERRORLEVEL ==2 SET dbRampUpDebugMode=-debug


::
:: ========== DO DATA OR NOT ==========
::
IF "%populateData%" == "0" GOTO ExecuteDatabaseOnly
GOTO ExecuteDatabaseAndData


::
:: ========== EXECUTE Database and Data  ==========
::
:ExecuteDatabaseAndData
ECHO.
echo Executing DBRampUp -teardowndb -buildDB -CustomSettings -test -log %dbRampUpDebugMode% ...
setup\temp\DBRampUp.exe -teardowndb -buildDB -CustomSettings -test -log %dbRampUpDebugMode%
IF ERRORLEVEL 1 GOTO ERROR
GOTO CleanUp


::
:: ========== EXECUTE Database Only  ==========
::
:ExecuteDatabaseOnly
ECHO.
echo Executing DBRampUp -teardowndb -buildDB -log %dbRampUpDebugMode% ...
setup\temp\DBRampUp.exe -teardowndb -buildDB -log %dbRampUpDebugMode%
IF ERRORLEVEL 1 GOTO ERROR
GOTO CleanUp


::
:: ========== Clean Up and we're Done  ==========
::
:CleanUp
ECHO.
CHOICE /C ny /N /T:30 /D n /M "Pause to inspect (Y/N)?"
IF ERRORLEVEL ==2 pause
ECHO.
ECHO Cleaning temp directory ...
CD setup
RD temp /Q /S
GOTO END


:BuildError
ECHO.
ECHO.
ECHO A build error occurred in the solution. Open the solution and resolve the 
ECHO build issue(s) before continuing.  Terminating DBRampUp.
ECHO.
ECHO You can view the build output at: setup\build.txt
ECHO.
CHOICE /C ny /N /T:30 /D n /M "Pause to inspect (Y/N)?"
IF ERRORLEVEL ==2 pause
GOTO END

:ERROR
ECHO.
ECHO.
ECHO DBRampUp Error Occurred above.
ECHO.
CHOICE /C ny /N /T:30 /D n /M "Pause to inspect (Y/N)?"
IF ERRORLEVEL ==2 pause
GOTO END

:HELP
ECHO.
ECHO DBRampUp is a database utility that restores a database to a known state.
ECHO Optionally, DBRampUp can build a solution, executing domain objects and 
ECHO run a set of SQL scripts.
ECHO.
ECHO Usage: %~n0 WebsitePath PopulateData [SolutionPath] [Framework]
ECHO Where: 
ECHO        WebsitePath      = (Required) The relative path to the web solution.
ECHO                           Usually is "MyProject.Website"
ECHO.
ECHO        PopulateData     = (Required) Enter "1" to execute the DBRampUp driver
ECHO                           found in any assemblies to populate the database
ECHO                           which passes the -CustomSettings -test options to
ECHO                           DBRampUp.exe.
ECHO                           Enter "0" to just teardown and build the DB, with
ECHO                           no data being populated.
ECHO.
ECHO        SolutionPath     = (Optional) The path to the solution file.
ECHO                           Usually just "MyProject.sln"
ECHO.
ECHO        Framework        = (Optional) The solution's framework version. 
ECHO                           Currently supports either "4.0" or "3.5".
ECHO.
ECHO Example:
ECHO %~n0 "websites\MyProject.Website" 1 MyProject.sln 4.0
ECHO.
ECHO.

:END