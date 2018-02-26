using System.Runtime.Serialization;

namespace Lykke.Service.BitcoinCash.Sign.Models.Sign
{
    [DataContract]
    public class SignOkTransactionResponce
    {
        [DataMember(Name = "signedTransaction")]
        public string SignedTransaction { get; set; }
    }
}
