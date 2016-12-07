using System.Threading.Tasks;

namespace ProBonoTracker.Services
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}
