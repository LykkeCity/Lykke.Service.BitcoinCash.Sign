using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common;
using Common.Log;
using Lykke.Service.BitcoinCash.Sign.Core.Exceptions;
using Lykke.Service.BitcoinCash.Sign.Core.Sign;
using NBitcoin;
using NBitcoin.JsonConverters;
using Newtonsoft.Json;

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
        private readonly ILog _log;
        public TransactionSigningService(Network network, ILog log)
        {
            _network = network;
            _log = log;
        }

        public ISignResult Sign(string transactionContext, IEnumerable<string> privateKeys)
        {
            var context = Serializer.ToObject<TransactionInfo>(transactionContext);

            var tx = new Transaction(context.TransactionHex);


            var secretKeys = privateKeys.Select(p => Key.Parse(p, _network)).ToList();

            Key GetPrivateKey(TxDestination pubKeyHash)
            {
                foreach (var secret in secretKeys)
                {
                    var key = new BitcoinSecret(secret, _network);
                    if (key.PubKey.Hash == pubKeyHash)
                        return key.PrivateKey;
                }

                return null;
            }

            const SigHash hashType = SigHash.All | SigHash.ForkId;

            for (int i = 0; i < tx.Inputs.Count; i++)
            {
                var input = tx.Inputs[i];

                var output = context.UsedCoins.FirstOrDefault(o => o.Outpoint == input.PrevOut)?.TxOut;

                if (output == null)
                    throw new BusinessException("Input not found", ErrorCode.InputNotFound);

                if (PayToPubkeyHashTemplate.Instance.CheckScriptPubKey(output.ScriptPubKey))
                {
                    var secret = GetPrivateKey(PayToPubkeyHashTemplate.Instance.ExtractScriptPubKeyParameters(output.ScriptPubKey));
                    if (secret != null)
                    {
                        var hash = Script.SignatureHash(output.ScriptPubKey, tx, i, hashType, output.Value);
                        var signature = secret.Sign(hash, hashType);

                        tx.Inputs[i].ScriptSig = PayToPubkeyHashTemplate.Instance.GenerateScriptSig(signature, secret.PubKey);
                        continue;
                    }
                    throw new BusinessException("Incompatible private key", ErrorCode.IncompatiblePrivateKey);
                }

                if (PayToPubkeyTemplate.Instance.CheckScriptPubKey(output.ScriptPubKey))
                {
                    var secret = GetPrivateKey(PayToPubkeyTemplate.Instance.ExtractScriptPubKeyParameters(output.ScriptPubKey).Hash);
                    if (secret != null)
                    {
                        var hash = Script.SignatureHash(output.ScriptPubKey, tx, i, hashType, output.Value);
                        var signature = secret.Sign(hash, hashType);

                        tx.Inputs[i].ScriptSig = PayToPubkeyTemplate.Instance.GenerateScriptSig(signature);
                        continue;
                    }
                    throw new BusinessException("Incompatible private key", ErrorCode.InvalidScript);
                }


                throw new BusinessException("Incompatible private key", ErrorCode.InvalidScript);
            }

            return SignResult.Ok(tx.ToHex());
        }
    }
}
