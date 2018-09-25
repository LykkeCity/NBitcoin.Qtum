using Xunit;

namespace NBitcoin.Qtum.Tests
{
    public class QtumNetworksTests
    {
        [Fact]
        public void ShouldGenerateAndParsePrivateKeyTest()
        {
            var key = new Key();
            var net = QtumNetworks.Instance.Testnet;
            var privateKey = key.GetWif(net).ToString();
            var address = key.PubKey.GetAddress(net).ToString();
            Assert.Equal(net, BitcoinAddress.Create(address, net).Network);
            Assert.Equal(address, new BitcoinSecret(privateKey, net).GetAddress().ToString());
        }

        [Fact]
        public void ShouldGenerateAndParsePrivateKeyMain()
        {
            var key = new Key();
            var net = QtumNetworks.Instance.Mainnet;
            var privateKey = key.GetWif(net).ToString();
            var address = key.PubKey.GetAddress(net).ToString();
            Assert.Equal(net, BitcoinAddress.Create(address, net).Network);
            Assert.Equal(address, new BitcoinSecret(privateKey, net).GetAddress().ToString());
        }

        [Fact]
        public void ShouldGetNetByName()
        {
            QtumNetworks.Instance.EnsureRegistered();

            var net = Network.GetNetwork("qtum-testnet");
            Assert.NotNull(net);
            Assert.Equal(QtumNetworks.Instance.Testnet, net);

            net = Network.GetNetwork("qtum-test");
            Assert.NotNull(net);
            Assert.Equal(QtumNetworks.Instance.Testnet, net);


            net = Network.GetNetwork("qtum-main");
            Assert.NotNull(net);
            Assert.Equal(QtumNetworks.Instance.Mainnet, net);

            net = Network.GetNetwork("qtum-mainnet");
            Assert.NotNull(net);
            Assert.Equal(QtumNetworks.Instance.Mainnet, net);

        }

        
    }
}
