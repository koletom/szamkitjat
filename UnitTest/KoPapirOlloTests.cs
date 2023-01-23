using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using szamkitjat;

namespace UnitTest
{
    [TestClass]
    public class KoPapirOlloTests
    {
        [TestMethod]
        [ExpectedException(typeof(NullReferenceException), "Constructor null paraméter exception test ok.")]
        public void KoPapirOlloContructorNullReferenceTest()
        {
            _ = new KoPapirOllo(null);
        }
        [TestMethod]
        public void KitalalosCreateTest()
        {
            var kopapirollo = new KoPapirOllo(new FakeUI());
            Assert.IsNotNull(kopapirollo);
        }
        [TestMethod]
        public void KoPapirOlloMethodTest()
        {
            var ui = new FakeUI();
            var gameCtrl = new Game(ui);

            Assert.IsTrue(ui.TestSteps.Count == 1, "Nincs UI output vagy túl sok az output");
            Assert.IsTrue(ui.TestSteps[0].StartsWith("PrintLN"), "AZ UI nem printLN indít");
            Assert.IsTrue(ui.TestSteps[0].Contains("Érvénytelten tét"), "A megadott tét nem megfelelő");
            Assert.IsTrue(ui.TestSteps[0].Contains("Nincs elegendő Coin."), "Coin/vége hibás");
        }
        public void KoPapirOlloStartTest()
        {

        }
        public void KoPapirOlloPlayTest()
        {

        }
        public void KoPapirOlloResultTest()
        {

        }
        public void KoPapirOlloEndResultTest()
        {

        }
    }
}
