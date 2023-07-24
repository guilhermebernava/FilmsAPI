namespace FilmsAPI.Models;

public class FilmUpdateViewModel
{
    public FilmUpdateViewModel(FilmViewModel filmViewModel, int filmId)
    {
        FilmViewModel = filmViewModel;
        FilmId = filmId;
    }

    public FilmViewModel FilmViewModel { get; private set; }
    public int   FilmId { get; private set; }
}
