namespace MinApiTestsSample.Services;

public class EmailService : IEmailService
{
    public Task Send(string emailAddress, string body)
    {
        return Task.CompletedTask;
    }
}