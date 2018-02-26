namespace Lykke.Service.BitcoinCash.Sign.Core
{
    public interface IGeneratedWallet
    {
        string Address { get; }
        string PrivateKey { get; }
    }
    public interface IWalletGenerator
    {
        IGeneratedWallet Generate();
    }
}
