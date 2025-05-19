# Aspire minimal repro 
## The problem
This repo aims to reproduce an issue with aspire that occured after .net sdk 9.0.200. 

We use one aspire project to orchestrate projects from multiple solutions using paths. Using .net sdk 8.0.x this worked perfectly, after updating all our projects to the .net 9 SDK and after the release of .net 9.0.200 this way of doing things no longer works. Also tested in the latest sdk version (as of writing 9.0.300)

The problem only occurs when using dotnet watch, dotnet run works. 

The way to reproduce is: 
1. Clone the repo 
2. Navigate to the SampleAppHost folder 
3. Run `dotnet watch`

This should produce the following error message (some part of the paths excluded with ..): 
``` 
dotnet watch ❌ Project '..\AspireMinimalRepro\ProjectInOtherSolution\ProjectInOtherSolution.csproj' not found in the project graph.
```
Along with this additional error message (some parts of the paths excluded with ..): 
```
fail: Aspire.Hosting.Dcp.dcpctrl.ExecutableReconciler[0]
      run session could not be started: IDE returned a response indicating failure      {"Executable": {"name":"projectinothersolution-raygkpwh"}, "Reconciliation": 3, "Status": "500 Internal Server Error", "Body": "Failed to launch project '..\\AspireMinimalRepro\\ProjectInOtherSolution\\ProjectInOtherSolution.csproj'."}
```

## Current workaround 
We use a global.json to lock the SDK version of the aspire project (also how we isolated that the .net sdk was the problem): 
```json
{
    "sdk": {
      "version": "8.0.100",
      "rollForward": "latestFeature"
    }
  }
```