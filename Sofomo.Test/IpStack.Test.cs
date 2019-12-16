using System;
using System.Net.NetworkInformation;
using NUnit.Framework;
using Sofomo.Extension;
using Sofomo.IpStack;

namespace Tests
{
    [TestFixture]
    public class IpStackTest
    {

        [Test]
        public void PingIpStack()
        {
            var result = ApiAlive.IsApiAlive($"http://api.ipstack.com/https://ipstack.com/?api_key=123");
            Assert.AreEqual(true,result);

        }
    }
}