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

        [TestMethod]
        public void GameCreateTest()
        {
            var game = new Game(new FakeUI());
            Assert.IsNotNull(game);
        }

        [TestMethod]
        public void EndingMethodTest()
        {
            var ui = new FakeUI();
            var gameCtrl = new Game(ui);

            gameCtrl.Ending();
            Assert.IsTrue(ui.TestSteps.Count == 1,"Nincs UI output vagy túl sok az output");
            Assert.IsTrue(ui.TestSteps[0].StartsWith("PrintLN"),"AZ UI nem printLN indít");
            Assert.IsTrue(ui.TestSteps[0].Contains("Viszlát"),"Visszlát hibás");
        }
        
    }
}
