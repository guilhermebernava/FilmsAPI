namespace FilmsAPI.Models;

public class GenreViewModel
{
    public string Name { get; set; }

    public GenreViewModel(string name)
    {
        Name = name;
    }
}
