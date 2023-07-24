namespace FilmsAPI.Models;

public class GenreModel
{
    public string Name { get; set; }

    public GenreModel(string name)
    {
        Name = name;
    }
}
