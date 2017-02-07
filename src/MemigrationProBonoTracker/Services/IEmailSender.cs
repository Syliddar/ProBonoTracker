using System.Threading.Tasks;

namespace MemigrationProBonoTracker.Services
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}
