namespace FilmsAPI.Models;

public class UserPasswordModel
{
    public UserPasswordModel(string id, string newPassword, string password)
    {
        Id = id;
        NewPassword = newPassword;
        Password = password;
    }

    public string Id { get; set; }
    public string NewPassword { get; set; }
    public string Password { get; set; }
}
