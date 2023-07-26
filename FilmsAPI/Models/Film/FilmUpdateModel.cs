namespace FilmsAPI.Models;

public class FilmUpdateModel
{
    public FilmUpdateModel(FilmModel filmModel, int filmId)
    {
        FilmModel = filmModel;
        FilmId = filmId;
    }

    public FilmModel FilmModel { get; private set; }
    public int   FilmId { get; private set; }
}
