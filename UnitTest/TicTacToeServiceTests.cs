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

        [TestMethod]
        public void GameType()
        {
            var service = new TicTacToeService();
            Assert.IsNotNull(service, "Nem sikerült a szervíz létrehozása");

            var result = service.GameType;
            Assert.IsTrue(result == szamkitjatiterfaces.Services.AmobaType.TicTacToe, "Nem a megfelelő GameType indult el.");
        }

        [TestMethod]
        public void TableRowTest()
        {
            var service = new TicTacToeService();
            Assert.IsNotNull(service, "Nem sikerült a szervíz létrehozása");

            var result = service.TableRow;
            Assert.IsTrue(result == 3, "Nem 3 soros lett a táblázat");
        }

        [TestMethod]
        public void TableColumnTest()
        {
            var service = new TicTacToeService();
            Assert.IsNotNull(service, "Nem sikerült a szervíz létrehozása");

            var result = service.TableColumn;
            Assert.IsTrue(result == 3, "Nem 3 oszlopos lett a táblázat");
        }

        [TestMethod]
        public void GameNameTest()
        {
            var service = new TicTacToeService();
            Assert.IsNotNull(service, "Nem sikerült a szervíz létrehozása");

            var result = service.GameName;
            Assert.IsTrue(result.Contains("3x3"), "Nem megfelelő név lett kiírva");
        }

        [TestMethod]
        public void GameDescriptionTest()
        {
            var service = new TicTacToeService();
            Assert.IsNotNull(service, "Nem sikerült a szervíz létrehozása");

            var result = service.GameDescription;
            Assert.IsTrue(result.Contains("a cél"), "Nem lett kiírva a szabályok");
        }

        [TestMethod]
        public void TableSizeTest()
        {
            var service = new TicTacToeService();
            Assert.IsNotNull(service, "Nem sikerült a szervíz létrehozása");
            
            //TODO:Ezt a tesztet egy kicsit gondold át és próbáld ciklusok nélkül megoldani
            //ráadásul ez v. elszáll exception v. akkor is igaz lesz ha a sorok és oszlopok száma 
            //több mint az elvárt.
            for (byte row = 0; row < service.Table.GetLength(0); row++)
            {
                for (byte col = 0; col < service.Table.GetLength(1); col++)
                {
                    if (col == 2 && row == 2)
                    {
                        service.Table[row, col] = (byte)3;
                    }
                }
            }

            var result = service.Table[2, 2];

            Assert.IsTrue(result == 3, "Nem sikerült a táblázat létrehozása");
        }

        [TestMethod]
        public void AddBetResultTrueTest()
        {
            var service = new TicTacToeService();
            Assert.IsNotNull(service, "Nem sikerült a szervíz létrehozása");

            var result = service.AddBet(2, 2, 2);

            Assert.IsTrue(result, "");
        }


        [TestMethod]
        public void AddBetResultFalseTest()
        {
            //TODO:Hiányzik
        }

        [TestMethod]
        public void AddComputerBetResultTrueTest()
        {
            var service = new TicTacToeService();
            Assert.IsNotNull(service, "Nem sikerült a szervíz létrehozása");

            var result = service.AddBet(2, 2, 2);

            Assert.IsTrue(result, "");
        }

        [TestMethod]
        public void AddComputerBetResultFalseTest()
        {
           //TODO:Hiányzik
        }
    }
}