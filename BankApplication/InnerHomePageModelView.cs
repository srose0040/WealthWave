namespace BankApplication
{
    public class InnerHomePageModelView
    {
        public string GreetingMessage { get; set; }
        public string UserAccountNumber { get; set; }


        public InnerHomePageModelView()
        {
            // Initialize non-nullable properties here
            GreetingMessage = string.Empty;
            UserAccountNumber = string.Empty;
        }
    }
}
