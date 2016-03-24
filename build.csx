using System.IO;
using System.Diagnostics;

string buildDirectory = "build", contentDirectory = "content";
string buildContentDirectory = Path.Combine(buildDirectory, contentDirectory);
string scriptsTargetDirectory = Path.Combine(buildContentDirectory, "Scripts");

private void SetupBuildDirectories()
{
  if (Directory.Exists(buildDirectory))
    Directory.Delete(buildDirectory, true);

  if (!Directory.Exists(buildContentDirectory))
    Directory.CreateDirectory(buildContentDirectory);
}

private void CopyFileToScriptsFolder(string fileName)
{
  string source = Path.Combine("ko-bindings", "Scripts", fileName);
  string target = Path.Combine(scriptsTargetDirectory, fileName);
  File.Copy(source, target, true);
}

private void PrepareSlideDownVisible()
{
  SetupBuildDirectories();

  if (!Directory.Exists(scriptsTargetDirectory))
    Directory.CreateDirectory(scriptsTargetDirectory);

  CopyFileToScriptsFolder("knockout-slideDownVisible.js");
  CopyFileToScriptsFolder("knockout-slideDownVisible.min.js");
}

private void PrepareFadeVisible()
{
  SetupBuildDirectories();

  if (!Directory.Exists(scriptsTargetDirectory))
    Directory.CreateDirectory(scriptsTargetDirectory);

  CopyFileToScriptsFolder("knockout-fadeVisible.js");
  CopyFileToScriptsFolder("knockout-fadeVisible.min.js");
}

private void NugetPack(string specFile)
{
  string nuget = Path.Combine("tools", "nuget.exe");
  string args = $"pack {specFile} -basepath {buildDirectory} -o {buildDirectory}";
  Process.Start(nuget, args).WaitForExit();
}

PrepareSlideDownVisible();
NugetPack("knockout-slideDownVisible.nuspec");

PrepareFadeVisible();
NugetPack("knockout-fadeVisible.nuspec");
