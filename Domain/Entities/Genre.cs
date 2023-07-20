namespace Domain.Entities;

public class Genre : Entity
{
    public Genre(string name) 
    {
       Name = name;
    }

    public string Name { get; set; }
    public ICollection<FilmGenre> FilmGenres { get; private set; }
}
