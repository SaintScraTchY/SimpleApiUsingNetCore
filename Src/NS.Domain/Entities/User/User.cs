namespace NS.Domain.Entities.User;

public class User(string username, string password)
{
    public long Id { get; private set; }
    public string Username { get; init; } = username;
    public string Password { get; private set; } = password;

    public void ChangePassword(string newPassword)
    {
        Password = newPassword;
    }
}