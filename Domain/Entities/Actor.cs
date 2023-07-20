namespace Domain.Entities;

public class Actor : Entity
{
    public Actor(string name,int age)
    {
        Name = name;
        Age = age;
    }

    public string Name { get; set; }
    public int Age { get; set; }
    public ICollection<FilmActor> FilmActors { get; private set; }
}
