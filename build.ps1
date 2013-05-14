Task Default -depends Coverity

Task Build {
  Exec { msbuild /m:4 /property:Configuration=Release CoverityBugs.sln }
}

Task Coverity -depends Build {
  mkdir build\coverity -force
  & "C:\Program Files\Coverity\Coverity Static Analysis\bin\cov-analyze-cs.exe" `--all `--max-mem 8192 `--dir build\coverity bin\Release\CoverityBugs.dll
  if ($LastExitCode -ne 0) {
    throw "Error executing cov-analyze-cs.exe"
  }
  $headSha = & "C:\Program Files (x86)\Git\bin\git.exe" rev-parse HEAD
  & "C:\Program Files\Coverity\Coverity Static Analysis\bin\cov-commit-defects.exe" `--host coverity `--dataport 9090 `--stream CoverityBugs `--user logosutilityreporter `--password password `--dir build\coverity `--version $headSha `--strip-path $(get-location).Path
  if ($LastExitCode -ne 0) {
    throw "Error executing cov-commit-defects.exe"
  }
}
