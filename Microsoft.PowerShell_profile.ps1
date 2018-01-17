function buildVS
{
    param
    (
        [parameter(Mandatory=$true)]
        [String] $path
    )

    process
    {
        $msBuildExe = 'C:\Program Files (x86)\Microsoft Visual Studio\2017\Enterprise\MSBuild\15.0\Bin\msbuild.exe'

        Write-Host "Building $($path)\\" -foregroundcolor green
        & "$($msBuildExe)" "$($path)" /t:Build /m
    }
}

function rassusStart
{
    param
    (
        [parameter(Mandatory=$true)]
        [String] $path
    )

    process
    {
         $root_path = "$($path)\\TemporalProcessSynchronization\\TemporalProcessSynchronization"
        buildVS -path $root_path;
        Start-process -FilePath "$($root_path)\\Broker\\bin\\Debug\\Broker.exe";
 		Start-process -FilePath "$($root_path)\\User\\bin\\Debug\\User.exe";
        Start-process -FilePath "$($root_path)\\User\\bin\\Debug\\User.exe";
        Start-process -FilePath "$($root_path)\\GeigerCounterSystem\\bin\\Debug\\GeigerCounterSystem.exe";
    }
}
