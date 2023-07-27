﻿namespace FilmsAPI.Models;

public class UserModel
{
    public UserModel(string email, string password)
    {
        Email = email;
        Password = password;
    }

    public string Email { get; private set; }
    public string Password { get; private set; }
}
