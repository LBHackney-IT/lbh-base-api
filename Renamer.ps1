[CmdletBinding()]
param(
    [Parameter(Mandatory = $true)]
    [String]$apiName
)

Write-Host "`nScanning files...`n"

Get-ChildItem -File -Recurse -exclude *.ps1 | % {
    $contents = (Get-Content $_.PSPath)
    $fileName = $_.Name

    if ($contents -match "base-api" -or $contents -match "base_api") {
        $contents -replace 'base-api', $apiName -replace 'base_api', $apiName | Set-Content $_.PSPath
        Write-Host $("'{0}': contents changed." -f $fileName)
    }
    
    if ($fileName -match 'base-api') {
        $newName = $_.Name -replace 'base-api', $apiName
        Rename-Item -Path $_.PSPath -NewName $newName
        Write-Host $("File renamed from '{0}' to '{1}'." -f $fileName, $newName)
    }
}
