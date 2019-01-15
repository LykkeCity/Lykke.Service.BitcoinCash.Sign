using System;
using Lykke.Service.BitcoinCash.Sign.Models.Wallet;
using Microsoft.AspNetCore.Mvc;
using NBitcoin;

namespace Lykke.Service.BitcoinCash.Sign.Controllers
{
    [Route("api/[controller]")]
    public class WalletsController
    {
        private readonly Network _network;

        public WalletsController(Network network)
        {
            _network = network;
        }

        [HttpPost]
        public WalletCreationResponse CreateWallet()
        {
            throw new Exception("Disabled");
            var key = new Key();

            return new WalletCreationResponse
            {
                PublicAddress = key.PubKey.GetAddress(_network).ToString(),
                PrivateKey = key.GetWif(_network).ToString()
            };
        }
    }
}
