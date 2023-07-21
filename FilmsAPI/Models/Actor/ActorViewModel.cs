namespace FilmsAPI.Models;

public class ActorViewModel
{
    public ActorViewModel(string name, int age)
    {
        Name = name;
        Age = age;
    }

    public string Name { get; private set; }
    public int   Age { get; private set; }
}
