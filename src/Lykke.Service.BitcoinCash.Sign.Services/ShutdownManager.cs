using System.Threading.Tasks;
using Lykke.Service.BitcoinCash.Sign.Core.Services;

namespace Lykke.BitcoinCash.Sign.Services
{
    public class ShutdownManager : IShutdownManager
    {
        public async Task StopAsync()
        {
            // TODO: Implement your shutdown logic here. Good idea is to log every step

            await Task.CompletedTask;
        }
    }
}
