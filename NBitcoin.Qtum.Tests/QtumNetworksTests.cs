using Xunit;

namespace NBitcoin.Dash.Tests
{
    public class QtumNetworksTests
    {
        [Fact]
        public void ShouldGenerateAndParsePrivateKeyTest()
        {
            var key = new Key();
            var privateKey = key.GetWif(QtumNetworks.Testnet).ToString();
            var address = key.PubKey.GetAddress(QtumNetworks.Testnet).ToString();

            Assert.Equal(QtumNetworks.Testnet, BitcoinAddress.Create(address).Network);
            Assert.Equal(address, new BitcoinSecret(privateKey, QtumNetworks.Testnet).GetAddress().ToString());
        }

        [Fact]
        public void ShouldGenerateAndParsePrivateKeyMain()
        {
            var key = new Key();
            var privateKey = key.GetWif(QtumNetworks.Mainnet).ToString();
            var address = key.PubKey.GetAddress(QtumNetworks.Mainnet).ToString();

            Assert.Equal(QtumNetworks.Mainnet, BitcoinAddress.Create(address).Network);
            Assert.Equal(address, new BitcoinSecret(privateKey, QtumNetworks.Mainnet).GetAddress().ToString());
        }
    }
}
