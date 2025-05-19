var builder = DistributedApplication.CreateBuilder(args);
builder.AddProject("projectinothersolution", "../ProjectInOtherSolution/ProjectInOtherSolution.csproj");
builder.Build().Run();