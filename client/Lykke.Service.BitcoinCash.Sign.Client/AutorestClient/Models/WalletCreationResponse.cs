// <auto-generated>
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Lykke.Service.BitcoinCash.Sign.Client.AutorestClient.Models
{
    using Newtonsoft.Json;
    using System.Linq;

    public partial class WalletCreationResponse
    {
        /// <summary>
        /// Initializes a new instance of the WalletCreationResponse class.
        /// </summary>
        public WalletCreationResponse()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the WalletCreationResponse class.
        /// </summary>
        public WalletCreationResponse(string publicAddress = default(string), string privateKey = default(string))
        {
            PublicAddress = publicAddress;
            PrivateKey = privateKey;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "publicAddress")]
        public string PublicAddress { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "privateKey")]
        public string PrivateKey { get; set; }

    }
}