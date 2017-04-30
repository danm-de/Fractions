@echo off

set root=%~dp0
set dir=%root%.paket
set bootstrapper=%dir%\paket.bootstrapper.exe

"%bootstrapper%" "--run" %*

if errorlevel 1 (
  exit /b %errorlevel%
)