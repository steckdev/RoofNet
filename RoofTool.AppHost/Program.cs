var builder = DistributedApplication.CreateBuilder(args);

var api = builder.AddProject<Projects.RoofTool_API>("api");


builder.Build().Run();
