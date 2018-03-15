using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lykke.Service.BitcoinCash.Sign.Core.Sign
{
    public interface ISignResult
    {
        string TransactionHex { get; }
    }   

    public interface ITransactionSigningService
    {
        ISignResult Sign(string transactionContext, IEnumerable<string> privateKeys);
    }
}
