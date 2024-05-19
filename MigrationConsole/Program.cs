using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using StorageDBO.Data;

var builder = Host.CreateApplicationBuilder();

builder.Services.AddDbContext<StorageDBContext>(options =>
{
    options.UseSqlServer("server=localhost;initial catalog=Storage_client;integrated security=True;");
});

var host = builder.Build();

host.Run();

// Run this command on root (the .sln file path):
// $ dotnet ef migrations add InitialCreate --project StorageDBO --startup-project MigrationConsole --output-dir ./Migrations