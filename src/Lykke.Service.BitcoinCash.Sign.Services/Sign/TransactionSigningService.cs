using System;
using System.Collections.Generic;
using System.Linq;
using Lykke.Service.BitcoinCash.Sign.Core.Exceptions;
using Lykke.Service.BitcoinCash.Sign.Core.Sign;
using NBitcoin;
using NBitcoin.JsonConverters;

namespace Lykke.BitcoinCash.Sign.Services.Sign
{
    internal class SignResult : ISignResult
    {
        public string TransactionHex { get; private set; }


        public static SignResult Ok(string signedHex)
        {
            return new SignResult
            {
                TransactionHex = signedHex
            };
        }
    }

    public class TransactionInfo
    {
        public string TransactionHex { get; set; }
        
        public IEnumerable<Coin> UsedCoins { get; set; }
    }

    public class TransactionSigningService : ITransactionSigningService
    {
        private readonly Network _network;
        public TransactionSigningService(Network network)
        {
            _network = network;
        }

        public ISignResult Sign(string transactionContext, IEnumerable<string> privateKeys)
        {
            try
            {
                var context = Serializer.ToObject<TransactionInfo>(transactionContext);

                var tx = Transaction.Parse(context.TransactionHex, _network);

                var secretKeys = privateKeys.Select(p => Key.Parse(p, _network)).ToArray();

                var signed = _network.CreateTransactionBuilder()
                    .AddCoins(context.UsedCoins)
                    .AddKeys(secretKeys)
                    .SignTransaction(tx);

                return SignResult.Ok(signed.ToHex());
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
