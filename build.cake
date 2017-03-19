var target          = Argument("target", "Default");
var configuration   = Argument<string>("configuration", "Release");
var ciMode          = Argument<bool>("ciMode", false);
var buildNumber     = Argument<string>("buildNumber", "");

///////////////////////////////////////////////////////////////////////////////
// GLOBAL VARIABLES
///////////////////////////////////////////////////////////////////////////////
var buildArtifacts      = Directory("./artifacts/packages");
var sourceRoot          = "./src";
var testsRoot           = "./test";
var sourceProjects      = sourceRoot + "/**/*.csproj";
var testProjects        = testsRoot + "/**/*.csproj";
var nugetConfigFile     = new FilePath("NuGet.config");


 Information("CI MODE");
 Information(ciMode.ToString());
 Information("Build Number");
 Information(buildNumber);

Task("Build")
    .IsDependentOn("Clean")
    .IsDependentOn("Restore")
    .Does(() =>
{
	var projects = GetFiles(sourceProjects);

	foreach(var project in projects)
	{
        Information("build " + project.FullPath);
        
        var settings = new DotNetCoreBuildSettings 
        {
            Configuration = configuration
        };

        DotNetCoreBuild(project.FullPath, settings); 
    }
});

Task("RunTests")
    .IsDependentOn("Restore")
    .IsDependentOn("Clean")
    .Does(() =>
{
    var projects = GetFiles(testProjects);

    foreach(var project in projects)
	{
        var settings = new DotNetCoreTestSettings
        {
            Configuration = configuration
        };

        if (!IsRunningOnWindows())
        {
            Information("Not running on Windows - skipping tests for full .NET Framework");
            settings.Framework = "netcoreapp1.1";
        }

        DotNetCoreTest(project.FullPath, settings);
    }
});

Task("Pack")
    .IsDependentOn("Restore")
    .IsDependentOn("Clean")
    .Does(() =>
{
    var projects = GetFiles(sourceProjects);
    foreach (var project in projects) {
        var settings = new DotNetCorePackSettings
        {
            Configuration = configuration,
            OutputDirectory = buildArtifacts,
        };

        // add build suffix for CI builds
        if (ciMode) {
           settings.VersionSuffix = buildNumber;
        }

        DotNetCorePack(project.GetDirectory().FullPath, settings);
    }   
});

Task("Clean")
    .Does(() =>
{
    CleanDirectories(new DirectoryPath[] { buildArtifacts });
});

Task("Restore")
    .Does(() =>
{
    var projects = GetFiles(sourceProjects);
    DotNetCoreRestoreSettings settings = new DotNetCoreRestoreSettings();

    if (FileExists(nugetConfigFile)) 
    {
        settings.ConfigFile = nugetConfigFile;
    } else {
        settings.Sources = new [] { 
            "https://api.nuget.org/v3/index.json",
            "https://www.myget.org/F/aspnet-contrib/api/v3/index.json",
            "https://dotnet.myget.org/F/aspnetcore-ci-dev/api/v3/index.json" 
        };
    };

	foreach(var project in projects)
	{
        Information("restore " + project.FullPath);
        DotNetCoreRestore(project.FullPath, settings);
    }

});

Task("Default")
  .IsDependentOn("Build")
  .IsDependentOn("RunTests")
  .IsDependentOn("Pack");

RunTarget(target);