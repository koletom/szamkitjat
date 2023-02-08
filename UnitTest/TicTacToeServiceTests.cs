using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.ComponentModel.Design;
using szamkitjatservices;

namespace UnitTest
{
    [TestClass]
    public class TicTacToeServiceTests
    {
        #region testhelpers
        private TicTacToeService GetServiceWithFullTableHelper()
        {
            var service = new TicTacToeService();
            if (service == null)
            {
                return service;
            }

            for (byte row = 0; row < service.Table.GetLength(0); row++)
            {
                for (byte col = 0; col < service.Table.GetLength(1); col++)
                {
                    if (col < 2 && (row == 0 || row==2))
                    {
                        service.Table[row, col] = 1;
                    }
                    else if (row == 0 || row == 2)
                    {
                        service.Table[row, col] = 2;
                    } else if (col < 2 && row == 1)
                    {
                        service.Table[row, col] = 2;
                    }
                    else if (row == 1)
                    {
                        service.Table[row, col] = 1;
                    }
                }
            }

            return service;
        }

        #endregion testhelpers

        [TestMethod]
        public void WinnerCheckResult0Test()
        {
            var service = new TicTacToeService();
            Assert.IsNotNull(service, "Nem sikerült a szervíz létrehozása");

            var result = service.WinnerCheck;

            Assert.IsTrue(result == 0, "Winnercheck nem adja vissza hogy még van lehetőség a táblára tenni");
        }

        [TestMethod]
        public void WinnerCheckResult3Test()
        {
            var service = GetServiceWithFullTableHelper();
            Assert.IsNotNull(service, "Nem sikerült a szervíz létrehozása");

            var result = service.WinnerCheck;

            Assert.IsTrue(result == 3, "Winnercheck nem adja vissza a döntetlent");
        }

        [TestMethod]
        public void WinnerCheckResult1Test()
        {
            var service = GetServiceWithFullTableHelper();
            Assert.IsNotNull(service, "Nem sikerült a szervíz létrehozása");
            for (byte col= 0;col<service.Table.GetLength(1);col++)
            {
                service.Table[0, col] = (byte)1;
            }

            var result = service.WinnerCheck;

            Assert.IsTrue(result == 1, "Winnercheck nem adja vissza ha 1. játékos nyer");
        }

        [TestMethod]
        public void WinnerCheckResult2Test()
        {
            var service = GetServiceWithFullTableHelper();
            Assert.IsNotNull(service, "Nem sikerült a szervíz létrehozása");
            for (byte col = 0; col < service.Table.GetLength(1); col++)
            {
                service.Table[0, col] = (byte)2;
            }

            var result = service.WinnerCheck;

            Assert.IsTrue(result == 2, "Winnercheck nem adja vissza ha 2. játékos nyer");
        }

    }
}