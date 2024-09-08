using System;
using FirstASP.Dtos;
using FirstASP.Entities;

namespace FirstASP.Mapping;

public static class GenreMapping {
    public static GenreDto ToSummaryDto(this Genre genre){
        return new GenreDto(
            genre.Id,
            genre.Name
        );
    }
}
