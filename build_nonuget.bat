dotnet publish src/Booma.Proxy.Client.Unity.BuildAll/Booma.Proxy.Client.Unity.BuildAll.csproj -c release

if not exist "build\client\release" mkdir build\client\release
xcopy src\Booma.Proxy.Client.Unity.BuildAll\bin\Release\net46\publish build\client\release /Y /q /EXCLUDE:BuildExclude.txt