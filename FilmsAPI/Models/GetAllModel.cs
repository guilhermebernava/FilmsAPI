namespace FilmsAPI.Models;

public class GetAllModel
{
    public GetAllModel(int take, int page)
    {
        Take = take;
        Page = page;
    }

    public int Take { get; private set; }
    public int Page { get; private set; }
}
