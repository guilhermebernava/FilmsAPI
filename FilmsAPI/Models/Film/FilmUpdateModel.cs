namespace FilmsAPI.Models;

public class FilmUpdateModel
{
    public FilmUpdateModel(FilmModel filmViewModel, int filmId)
    {
        FilmViewModel = filmViewModel;
        FilmId = filmId;
    }

    public FilmModel FilmViewModel { get; private set; }
    public int   FilmId { get; private set; }
}
