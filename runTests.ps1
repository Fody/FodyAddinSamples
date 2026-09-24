param(
    # only run the specified target framework
    [string]$Framework
)

$ErrorActionPreference = 'Stop'

# TUnit test projects are executables. They are run with 'dotnet run' for each target framework.
$projects = @(
    'CatelSample\CatelSample.csproj',
    'ConfigureAwaitSample\ConfigureAwaitSample.csproj',
    'CosturaSample\CosturaSample.csproj',
    'InlineILSample\InlineILSample.csproj',
    'InSolutionWeaving\InSolutionWeaving.csproj',
    'MethodDecoratorSample\MethodDecoratorSample.csproj',
    'NullGuardSample\NullGuardSample.csproj',
    'ReactiveUISample\ReactiveUISample.csproj',
    'Samples\Samples.csproj',
    'ThrottleSample\ThrottleSample.csproj',
    'ToStringSample\ToStringSample.csproj',
    'WeakEventHandlerSample\WeakEventHandlerSample.csproj'
)

$failed = @()
foreach ($project in $projects) {
    $frameworks = (dotnet msbuild $project -getProperty:TargetFrameworks -p:Configuration=Release).Trim().Split(';', [StringSplitOptions]::RemoveEmptyEntries)
    if (-not $frameworks) {
        $frameworks = @((dotnet msbuild $project -getProperty:TargetFramework -p:Configuration=Release).Trim())
    }
    if ($Framework) {
        $frameworks = $frameworks | Where-Object { $_ -eq $Framework }
    }
    foreach ($targetFramework in $frameworks) {
        Write-Host "Running $project ($targetFramework)"
        dotnet run --project $project -c Release -f $targetFramework --no-build
        if ($LASTEXITCODE -ne 0) {
            $failed += "$project ($targetFramework)"
        }
    }
}

if ($failed.Count -gt 0) {
    Write-Host "Failed test runs:`n$($failed -join "`n")"
    exit 1
}
