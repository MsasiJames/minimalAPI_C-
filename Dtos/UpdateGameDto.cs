using System.ComponentModel.DataAnnotations;

namespace FirstASP.Dtos;

public record class UpdateGameDto (
    [Required][StringLength (50)]string Name, 
    int GenreId, 
    [Range(1, 150)]decimal Price, 
    DateOnly ReleaseDate
);

