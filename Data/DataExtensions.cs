using System;
using FirstASP.Entities;
using Microsoft.EntityFrameworkCore;

namespace FirstASP.Data;

public static class DataExtensions {

    public static async Task MigrateAsync(this WebApplication app){      // this function helps to run migrations during startup
        using var scope = app.Services.CreateScope();   // scope must be created so resources are released once migration is complete

        var dbContext = scope.ServiceProvider.GetRequiredService<GameStoreContext>();   // database context is required for the migration
        
        await dbContext.Database.MigrateAsync();

    }

}
