using Newtonsoft.Json;

namespace Domain.Entities;

public class Genre : Entity
{
    public Genre(string name) 
    {
       Name = name;
    }

    public string Name { get; set; }
    [JsonIgnore]
    public virtual ICollection<FilmGenre> FilmGenres { get; private set; }
}
