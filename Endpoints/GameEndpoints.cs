using System;
using FirstASP.Data;
using FirstASP.Dtos;
using FirstASP.Entities;
using FirstASP.Mapping;
using Microsoft.EntityFrameworkCore;

namespace FirstASP.Endpoints;

public static class GameEndpoints {

    const string GetGameEndpointName = "GetGame";

    private static readonly List<GameSummaryDto> games = [
        new (
            1, 
            "The Legend of Zelda: Breath of the Wild", 
            "Action-adventure", 
            59.99m, 
            new DateOnly(2017, 3, 3)
        ),

        new (
            2,
            "Super Mario Odyssey",
            "Platformer",
            59.99m,
            new DateOnly(2017, 10, 27)
        ),

        new (
            3,
            "Mario Kart 8 Deluxe",
            "Racing",
            59.99m,
            new DateOnly(2017, 4, 28)
        ) 
    
    ];

    public static RouteGroupBuilder MapGameEndpoints(this WebApplication app) {

        var group = app.MapGroup("games").WithParameterValidation();

        // get all the games
        group.MapGet("/", async (GameStoreContext dbContext) =>{
            return (
                await dbContext.Games
                        .Include(game => game.Genre)
                        .Select(game => game.ToSummaryDto())
                        .AsNoTracking()
                        .ToListAsync()
            );
        });

        // get all genres
        group.MapGet("/genres", async (GameStoreContext dbContext) => {
          return (
                await dbContext.Genres
                        .Select(genre => genre.ToSummaryDto())
                        .AsNoTracking()
                        .ToListAsync()
          );
        });
        // get a single game
        group.MapGet("/{id}", async (int id, GameStoreContext dbContext) => {
            Game? game = await dbContext.Games.FindAsync(id);
            
            return game is null ? Results.NotFound() : Results.Ok(game.ToGameDetailsDto());
        })
        .WithName(GetGameEndpointName);       // name of the route

        // POST /games
        group.MapPost("/", async (CreateGameDto newGame, GameStoreContext dbContext) => {
            
            Game game = newGame.ToEntity();
            game.Genre = dbContext.Genres.Find(newGame.GenreId);

            dbContext.Games.Add(game);
            await dbContext.SaveChangesAsync();

            return Results.CreatedAtRoute(
                GetGameEndpointName,
                new {id = game.Id},
                game.ToSummaryDto());
        });


        // PUT /games/{id}
        group.MapPut("/{id}", async (int id, UpdateGameDto updatedGame, GameStoreContext dbContext) => {
            var existingGame = await dbContext.Games.FindAsync(id);

            if(existingGame is null){
                return Results.NotFound();
            }

            dbContext.Entry(existingGame)
                .CurrentValues
                .SetValues(updatedGame.ToUpdateEntity(id));

            await dbContext.SaveChangesAsync();

            return Results.NoContent();
        });

        // DELETE /games/{id}
        group.MapDelete("/{id}", async (int id, GameStoreContext dbContext) => {
            await dbContext.Games
                    .Where(game => game.Id == id)
                    .ExecuteDeleteAsync();

            return Results.NoContent();
        });

        return group;

    }
    
}
