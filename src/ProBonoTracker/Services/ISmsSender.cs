using System.Threading.Tasks;

namespace ProBonoTracker.Services
{
    public interface ISmsSender
    {
        Task SendSmsAsync(string number, string message);
    }
}
