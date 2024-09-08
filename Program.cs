using FirstASP.Data;
using FirstASP.Endpoints;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("GameStore");

builder.Services.AddSqlite<GameStoreContext>(connectionString);     // this is a scoped lifetime service

var app = builder.Build();

app.MapGameEndpoints();

await app.MigrateAsync();

app.Run();
