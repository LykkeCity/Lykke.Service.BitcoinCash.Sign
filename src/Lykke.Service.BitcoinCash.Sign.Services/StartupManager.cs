using System.Threading.Tasks;
using Lykke.Service.BitcoinCash.Sign.Core.Services;

namespace Lykke.BitcoinCash.Sign.Services
{
    public class StartupManager : IStartupManager
    {
        public async Task StartAsync()
        {
            await Task.CompletedTask;
        }
    }
}
