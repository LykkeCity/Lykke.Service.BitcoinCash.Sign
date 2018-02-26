using System;
using Common.Log;

namespace Lykke.Service.BitcoinCash.Sign.Client
{
    public class BitcoinCashClient : IBitcoinCashClient, IDisposable
    {
        private readonly ILog _log;

        public BitcoinCashClient(string serviceUrl, ILog log)
        {
            _log = log;
        }

        public void Dispose()
        {
            //if (_service == null)
            //    return;
            //_service.Dispose();
            //_service = null;
        }
    }
}
