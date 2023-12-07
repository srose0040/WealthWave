namespace BankApplication
{
    public class LoginViewModel
{
    public string Username { get; set; }
    public string Password { get; set; }

    public LoginViewModel()
    {
        // Initialize non-nullable properties here
        Username = string.Empty;
        Password = string.Empty;
    }
}


}
