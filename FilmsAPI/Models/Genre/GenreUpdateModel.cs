namespace FilmsAPI.Models;

public class GenreUpdateModel
{
    public GenreUpdateModel(int id, string name)
    {
        Id = id;
        Name = name;
    }

    public int Id { get; set; }
    public string Name { get; set; }
}
