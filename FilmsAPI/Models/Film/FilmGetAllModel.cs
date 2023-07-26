namespace FilmsAPI.Models;

public class FilmGetAllModel
{
    public FilmGetAllModel(int take, int page)
    {
        Take = take;
        Page = page;
    }

    public int Take { get; private set; }
    public int Page { get; private set; }
}
