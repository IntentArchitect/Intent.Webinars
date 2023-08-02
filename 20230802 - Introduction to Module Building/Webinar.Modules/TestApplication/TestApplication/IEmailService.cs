using System.Threading.Tasks;
using Intent.RoslynWeaver.Attributes;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Webinar.Modules.SmtpEmail.EmailServiceInterface", Version = "1.0")]

namespace TestApplication
{
    public interface IEmailService
    {
        Task SendEmailAsync(string to, string subject, string body);
    }
}