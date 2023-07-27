﻿namespace Domain.Entities;

public class Film : Entity
{
    public Film(string title, int duration, double score, string description, DateTime releaseDate)
    {
        Title = title;
        Duration = duration;
        Score = score;
        Description = description;
        ReleaseDate = releaseDate;
    }

    public string Title { get; set; }
    public int Duration { get; set; }
    public double Score { get; set; }
    public string Description { get; set; }
    public DateTime ReleaseDate { get; set; }
    public virtual ICollection<FilmActor> FilmActors { get; private set; }
    public virtual ICollection<FilmGenre> FilmGenres { get; private set; }
}
