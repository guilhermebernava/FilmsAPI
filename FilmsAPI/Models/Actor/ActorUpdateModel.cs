namespace FilmsAPI.Models;

public class ActorUpdateModel
{
    public ActorUpdateModel(ActorModel actorModel, int id)
    {
        ActorModel = actorModel;
        Id = id;
    }

    public ActorModel ActorModel { get; private set; }
    public int   Id { get; private set; }
}
