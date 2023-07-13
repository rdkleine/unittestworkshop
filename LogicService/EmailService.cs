namespace LogicService;
public interface IEmailService
{
    bool SendEmail(string to, string subject, string body);
}

public class EmailService : IEmailService
{
    public bool SendEmail(string to, string subject, string body)
    {
        if (new string[] { to, subject, body }.Any(string.IsNullOrWhiteSpace))
            return false;
        if (!to.Contains("@"))
            return false;

        Console.WriteLine($"Sending email to {to} with subject {subject} and body {body}");
        return true;
    }
}