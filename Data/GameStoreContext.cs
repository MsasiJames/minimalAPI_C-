using System;
using FirstASP.Entities;
using Microsoft.EntityFrameworkCore;

namespace FirstASP.Data;

public class GameStoreContext(DbContextOptions <GameStoreContext> options) : DbContext (options) {

    public DbSet<Game> Games => Set<Game>();
    public DbSet<Genre> Genres => Set<Genre>();

    protected override void OnModelCreating(ModelBuilder modelBuilder) {    // when migration is executed, this function is execuetd as well
        modelBuilder.Entity<Genre>().HasData(
            new { Id = 1, Name = "Action" },
            new { Id = 2, Name = "Adventure" },
            new { Id = 3, Name = "RPG" },
            new { Id = 4, Name = "Simulation" },
            new { Id = 5, Name = "Strategy" }
        );
    }

}
