dotnet build
Copy-Item .\bin\cosmos\Debug\net6.0\Lynox.iso .\VMWareConfigs\
Set-Location .\VMWareConfigs
& 'C:\Program Files (x86)\VMware\VMware Player\vmplayer.exe' Cosmos.vmx