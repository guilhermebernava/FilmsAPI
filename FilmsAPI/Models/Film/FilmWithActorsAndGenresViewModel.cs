namespace FilmsAPI.Models;

public class FilmWithActorsAndGenresViewModel
{
    public FilmWithActorsAndGenresViewModel(FilmViewModel filmViewModel, List<ActorViewModel> actorViewModels, List<GenreViewModel> genreViewModels)
    {
        FilmViewModel = filmViewModel;
        ActorViewModels = actorViewModels;
        GenreViewModels = genreViewModels;
    }

    public FilmViewModel FilmViewModel { get; set; }
    public List<ActorViewModel> ActorViewModels { get; set; }
    public List<GenreViewModel> GenreViewModels { get; set; }
}
