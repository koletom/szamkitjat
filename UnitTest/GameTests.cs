using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using szamkitjat;

namespace UnitTest
{
    [TestClass]
    public class GameTests
    {
        [TestMethod]
        [ExpectedException(typeof(NullReferenceException),  "Constructor null paraméter exception test ok.")]
        public void GameContructorNullReferenceTest()
        {
            _ = new Game(null);
        }
    }
}
