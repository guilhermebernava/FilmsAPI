namespace FilmsAPI.Models;

public class GenreUpdateModel
{
    public GenreUpdateModel(int id, GenreModel genreModel)
    {
        Id = id;
        GenreModel = genreModel;
    }

    public int Id { get; set; }
    public GenreModel GenreModel { get; set; }
}
