using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.ComponentModel.Design;
using szamkitjatservices;

namespace UnitTest
{
    [TestClass]
    public class GomokuServiceTests
    {
        #region testhelpers
        private GomokuService GetServiceWithFullTableHelper()
        {
            var service = new GomokuService();
            if (service == null)
            {
                return service;
            }

            for (byte row = 0; row < service.Table.GetLength(0); row++)
            {
                for (byte col = 0; col < service.Table.GetLength(1); col++)
                {
                    if (col < 2)
                    {

                    }
                }
            }
            return service;
        }
            #endregion testhelpers

            [TestMethod]
        public void WinerCheckTest0()
        {
            var service = new GomokuService();
            Assert.IsNotNull(service, "Nem sikerült a szervíz létrehozása");

            var result = service.WinnerCheck;
            Assert.IsTrue(result == 0, "");
        }
        [TestMethod]
        public void WinerCheckTest1()
        {
            var service = GetServiceWithFullTableHelper();
            Assert.IsNotNull(service, "Nem sikerült a szervíz létrehozása");

            for (byte col = 0; col < service.Table.GetLength(1); col++)
            {
                service.Table[0, col] = 1;
            }

            var result = service.WinnerCheck;
            Assert.IsTrue(result == 1, "Winnercheck nem adja vissza ha 1. játékos nyer");
        }

        [TestMethod]
        public void WinerCheckTest2()
        {
            var service = GetServiceWithFullTableHelper();
            Assert.IsNotNull(service, "Nem sikerült a szervíz létrehozása");

            for (byte col = 0; col < service.Table.GetLength(1); col++)
            {
                service.Table[0, col] = 2;
            }

            var result = service.WinnerCheck;
            Assert.IsTrue(result == 2, "Winnercheck nem adja vissza ha 2. játékos nyer");
        }

        [TestMethod]
        public void WinerCheckTest3()
        {
            var service = GetServiceWithFullTableHelper();
            Assert.IsNotNull(service, "Nem sikerült a szervíz létrehozása");

            var result = service.WinnerCheck;

            Assert.IsTrue(result == 3, "Winnercheck nem adja vissza a döntetlent");
        }
    }
}
