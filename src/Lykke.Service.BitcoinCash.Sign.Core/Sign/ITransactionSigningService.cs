using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lykke.Service.BitcoinCash.Sign.Core.Sign
{
    public interface ISignResult
    {
        string TransactionHex { get; }
    }

    public enum SignError
    {
        IncompatiblePrivateKey,

        InvalidScript
    }

    public interface ITransactionSigningService
    {
        Task<ISignResult> SignAsync(string transactionContext, IEnumerable<string> privateKeys);
    }
}
