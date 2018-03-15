using Autofac;
using Common.Log;
using Lykke.BitcoinCash.Sign.Services.Sign;
using Lykke.Service.BitcoinCash.Sign.Core.Settings.ServiceSettings;
using Lykke.Service.BitcoinCash.Sign.Core.Sign;
using Lykke.SettingsReader;
using NBitcoin;

namespace Lykke.BitcoinCash.Sign.Services
{
    public  class ServiceModule:Module
    {
        private readonly ILog _log;
        private readonly IReloadingManager<BitcoinCashSignSettings> _settings;
        public ServiceModule(IReloadingManager<BitcoinCashSignSettings> settings, ILog log)
        {
            _log = log;
            _settings = settings;
        }

        protected override void Load(ContainerBuilder builder)
        {
            RegisterNetwork(builder);
            
            builder.RegisterType<TransactionSigningService>().As<ITransactionSigningService>();
        }

        private void RegisterNetwork(ContainerBuilder builder)
        {          
            builder.RegisterInstance(Network.GetNetwork(_settings.CurrentValue.Network)).As<Network>();
          
        }
    }
}
