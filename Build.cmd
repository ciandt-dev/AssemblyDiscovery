@ECHO OFF

%SystemRoot%\Microsoft.NET\Framework\v4.0.30319\msbuild "%~dp0\AssemblyDiscovery.msbuild" /t:%1 %2 /v:minimal /maxcpucount /nodeReuse:false