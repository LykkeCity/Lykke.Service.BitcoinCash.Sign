using Autofac;
using Lykke.Service.BitcoinCash.Sign.Core.Settings.ServiceSettings;
using Lykke.SettingsReader;

namespace Lykke.Service.BitcoinCash.Sign.Modules
{
    public class SignInModule : Module
    {
        private readonly IReloadingManager<BitcoinCashSignSettings> _settings;

        public SignInModule(IReloadingManager<BitcoinCashSignSettings> settings)
        {
            _settings = settings;
        }

        protected override void Load(ContainerBuilder builder)
        {
            // TODO: Do not register entire settings in container, pass necessary settings to services which requires them
            // ex:
            //  builder.RegisterType<QuotesPublisher>()
            //      .As<IQuotesPublisher>()
            //      .WithParameter(TypedParameter.From(_settings.CurrentValue.QuotesPublication))

       

            // TODO: Add your dependencies here
        }
    }
}
