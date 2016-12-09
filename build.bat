
cls
"%NUGET%" "Install" "FAKE" "-OutputDirectory" "src\packages" "-ExcludeVersion"
"src\packages\FAKE\tools\Fake.exe" build.fsx