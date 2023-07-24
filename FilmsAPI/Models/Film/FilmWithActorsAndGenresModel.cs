namespace FilmsAPI.Models;

public class FilmWithActorsAndGenresModel
{
    public FilmWithActorsAndGenresModel(FilmModel filmViewModel, List<ActorModel> actorViewModels, List<GenreModel> genreViewModels)
    {
        FilmViewModel = filmViewModel;
        ActorViewModels = actorViewModels;
        GenreViewModels = genreViewModels;
    }

    public FilmModel FilmViewModel { get; set; }
    public List<ActorModel> ActorViewModels { get; set; }
    public List<GenreModel> GenreViewModels { get; set; }
}
