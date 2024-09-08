using System;
using FirstASP.Dtos;
using FirstASP.Entities;

namespace FirstASP.Mapping;

public static class GameMapping {

    public static Game ToEntity(this CreateGameDto game){
        return new Game(){
            Name = game.Name,
            GenreId = game.GenreId,
            Price = game.Price,
            ReleaseDate = game.ReleaseDate
        };

    }

    public static Game ToUpdateEntity(this UpdateGameDto game, int Id){
        return new Game(){
            Id = Id,
            Name = game.Name,
            GenreId = game.GenreId,
            Price = game.Price,
            ReleaseDate = game.ReleaseDate
        };
    }

    public static GameSummaryDto ToSummaryDto(this Game game){
        return new GameSummaryDto(
            game.Id,
            game.Name,
            game.Genre!.Name,   // ! is telling the compiler that Name will never be null
            game.Price,
            game.ReleaseDate
        );

    }

    public static GameDetailsDto ToGameDetailsDto(this Game game){
        return new GameDetailsDto(
            game.Id,
            game.Name,
            game.GenreId,
            game.Price,
            game.ReleaseDate
        );
    }

}
