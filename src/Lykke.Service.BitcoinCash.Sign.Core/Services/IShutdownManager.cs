using System.Threading.Tasks;

namespace Lykke.Service.BitcoinCash.Sign.Core.Services
{
    public interface IShutdownManager
    {
        Task StopAsync();
    }
}
