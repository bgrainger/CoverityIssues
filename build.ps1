Task Default -depends Coverity

Task Build {
  mkdir build\coverity -force
  & "C:\Program Files\Coverity\cov-analysis-win64-fresno-cs-beta\bin\cov-build.exe" `--dir build\coverity `--debug `--enable-cs-parse-error-recovery msbuild /m:4 /property:Configuration=Release CoverityIssues.sln
  if ($LastExitCode -ne 0) {
    throw "Error executing cov-build.exe"
  }
}

Task Coverity -depends Build {
  & "C:\Program Files\Coverity\cov-analysis-win64-fresno-cs-beta\bin\cov-analyze-cs.exe" `--all `--dir build\coverity -j auto `--strip-path $(get-location).Path
  if ($LastExitCode -ne 0) {
    throw "Error executing cov-analyze-cs.exe"
  }
  $headSha = & "C:\Program Files (x86)\Git\bin\git.exe" rev-parse HEAD
  & "C:\Program Files\Coverity\cov-analysis-win64-fresno-cs-beta\bin\cov-commit-defects.exe" `--host coverity `--dataport 9090 `--stream CoverityIssuesBeta `--user logosutilityreporter `--password password `--dir build\coverity `--version $headSha
  if ($LastExitCode -ne 0) {
    throw "Error executing cov-commit-defects.exe"
  }
}
