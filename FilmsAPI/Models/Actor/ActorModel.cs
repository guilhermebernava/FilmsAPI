﻿namespace FilmsAPI.Models;

public class ActorModel
{
    public ActorModel(string name, int age)
    {
        Name = name;
        Age = age;
    }

    public string Name { get; private set; }
    public int   Age { get; private set; }
}
