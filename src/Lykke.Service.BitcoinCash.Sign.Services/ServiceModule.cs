using Autofac;
using Lykke.BitcoinCash.Sign.Services.Sign;
using Lykke.Service.BitcoinCash.Sign.Core.Settings.ServiceSettings;
using Lykke.Service.BitcoinCash.Sign.Core.Sign;
using Lykke.SettingsReader;
using NBitcoin;
using NBitcoin.Altcoins;

namespace Lykke.BitcoinCash.Sign.Services
{
    public  class ServiceModule:Module
    {
        private readonly IReloadingManager<BitcoinCashSignSettings> _settings;
        public ServiceModule(IReloadingManager<BitcoinCashSignSettings> settings)
        {
            _settings = settings;
        }

        protected override void Load(ContainerBuilder builder)
        {
            RegisterNetwork(builder);
            
            builder.RegisterType<TransactionSigningService>().As<ITransactionSigningService>();
        }

        private void RegisterNetwork(ContainerBuilder builder)
        {          
            builder.RegisterInstance(Network.GetNetwork(_settings.CurrentValue.Network) == Network.Main ? BCash.Instance.Mainnet : BCash.Instance.Testnet).As<Network>();
          
        }
    }
}
