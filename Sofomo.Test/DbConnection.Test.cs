using System;
using System.Net.NetworkInformation;
using Moq;
using NUnit.Framework;
using Sofomo.Extension;
using Sofomo.IpStack;

namespace Tests
{
    [TestFixture]
    public class DbConnectionTest
    {

        [Test]
        public void TestDbConnection()
        {
            var mockDbTest = new Mock<DbSettings>();
            IDbAlive dbAlive = new DBAlive(mockDbTest.Object);
            var result = dbAlive.CheckDbConnection("Server=(local);Database=Sofomo;Trusted_Connection=True;");
            Assert.AreEqual(true,result);

        }
    }
}