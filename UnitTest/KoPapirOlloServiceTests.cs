using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.ComponentModel.Design;
using szamkitjatservices;

namespace UnitTest
{
    [TestClass]
    public class KoPapirOlloServiceTests
    {
        [TestMethod]
        public void GameDescription()
        {
            var service = new KoPapirOlloService();
            Assert.IsNotNull(service, "Nem sikerült a szervíz létrehozása");

            var result = service.GameDescription;
            Assert.IsTrue(result.Contains("A cél"), "Nem lett kiírva a szabályok");
        }

        [TestMethod]
        public void GameName()
        {
            var service = new KoPapirOlloService();
            Assert.IsNotNull(service, "Nem sikerült a szervíz létrehozása");

            var result = service.GameName;
            Assert.IsTrue(result.Contains("Kő"), "Nem megfelelő név lett kiírva");
        }

        [TestMethod]
        public void WinnerCheckResult0Test()
        {
            var service = new KoPapirOlloService();
            Assert.IsNotNull(service, "Nem sikerült a szervíz létrehozása");

            var result = service.WinnerCheck;

            Assert.IsTrue(result == 0, "Winnercheck nem adja vissza hogy még van lehetőség tovább folytatni");
        }
    }
}
