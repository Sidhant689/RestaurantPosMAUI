var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.RestaurantPosMAUI_API>("restaurantposmaui-api");

builder.Build().Run();
