using Lykke.Service.BitcoinCash.Sign.Core.Settings.ServiceSettings;
using Lykke.Service.BitcoinCash.Sign.Core.Settings.SlackNotifications;

namespace Lykke.Service.BitcoinCash.Sign.Core.Settings
{
    public class AppSettings
    {
        public BitcoinCashSignSettings BitcoinCashSign { get; set; }
        public SlackNotificationsSettings SlackNotifications { get; set; }
    }
}
