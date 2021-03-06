@echo off
cls

.paket\paket.bootstrapper.exe
if errorlevel 1 (
  exit /b %errorlevel%
)

.paket\paket.exe restore
if errorlevel 1 (
  exit /b %errorlevel%
)

IF NOT EXIST build.fsx (
  .paket\paket.exe update
  packages\build\FAKE\tools\FAKE.exe init.fsx
)

IF EXIST "C:\Secrets\TestSecrets.fs" ( COPY C:\Secrets\TestSecrets.fs .\Tests\ )
IF EXIST "E:\Secrets\TestSecrets.fs" ( COPY E:\Secrets\TestSecrets.fs .\Tests\ )

packages\build\FAKE\tools\FAKE.exe build.fsx %*
