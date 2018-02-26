// <auto-generated>
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Lykke.Service.BitcoinCash.Sign.Client.AutorestClient
{
    using Models;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Extension methods for BitcoinCashServiceSign.
    /// </summary>
    public static partial class BitcoinCashServiceSignExtensions
    {
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            public static object IsAlive(this IBitcoinCashServiceSign operations)
            {
                return operations.IsAliveAsync().GetAwaiter().GetResult();
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<object> IsAliveAsync(this IBitcoinCashServiceSign operations, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.IsAliveWithHttpMessagesAsync(null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='sourceTx'>
            /// </param>
            public static object SignRawTx(this IBitcoinCashServiceSign operations, SignRequest sourceTx = default(SignRequest))
            {
                return operations.SignRawTxAsync(sourceTx).GetAwaiter().GetResult();
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='sourceTx'>
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<object> SignRawTxAsync(this IBitcoinCashServiceSign operations, SignRequest sourceTx = default(SignRequest), CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.SignRawTxWithHttpMessagesAsync(sourceTx, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            public static WalletCreationResponse ApiWalletsPost(this IBitcoinCashServiceSign operations)
            {
                return operations.ApiWalletsPostAsync().GetAwaiter().GetResult();
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<WalletCreationResponse> ApiWalletsPostAsync(this IBitcoinCashServiceSign operations, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.ApiWalletsPostWithHttpMessagesAsync(null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

    }
}
