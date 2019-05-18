Add-Type -assembly "system.io.compression.filesystem"
$archiveName = "$env:PKG_BASE_DIR/$env:APPLICATION_NAME/netdemo-client.zip"
Write-Output "Extracting Archive: $archiveName"
[io.compression.zipfile]::ExtractToDirectory($archiveName, "$env:PKG_BASE_DIR/$env:APPLICATION_NAME")
Write-Output "Done Extracting"

$Command = "$env:PKG_BASE_DIR/$env:APPLICATION_NAME/netdemo-client.exe"
Invoke-Expression $Command

$healthprocess = Get-Process netdemo-client -ErrorAction SilentlyContinue
if ($null -eq $healthprocess) {
    Get-Process
    throw [System.Exception] "application not started"
} else {
    Write-Host "Application has started."
    ipconfig.exe
}