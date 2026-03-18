public class EmailService
{
    public void Send(string to, string subject, string body)
    {
        Console.WriteLine($"Email sent to {to}");
    }
}
