$env:DOTNET_ENABLE_CDAC=1

windbgx C:\Users\maxcharlamb\source\reposA\runtime\artifacts\bin\testhost\net10.0-windows-Release-x64\dotnet.exe C:\Users\maxcharlamb\source\repos\NibbleMapReplacement\bin\Debug\net8.0\NibbleMapReplacement.dll

# See: https://learn.microsoft.com/en-us/windows-hardware/drivers/debugger/debugging-managed-code

# g
# .loadby sos coreclr
# !sos.DumpDomain