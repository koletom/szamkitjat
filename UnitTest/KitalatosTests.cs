using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using szamkitjat;

namespace UnitTest
{
    [TestClass]
    public class KitalatosTests
    {
        [TestMethod]
        [ExpectedException(typeof(NullReferenceException), "Constructor null paraméter exception test ok.")]
        public void KitalalosContructorNullReferenceTest()
        {
            _ = new Kitalalos(null);
        }
        [TestMethod]
        public void KitalalosCreateTest()
        {
            var kitalalos = new Kitalalos(new FakeUI());
            Assert.IsNotNull(kitalalos);
        }
        //[TestMethod]
        //public void KitalalosMethodTest()
        //{
        //    var ui = new FakeUI();
        //    //TODO:Nem a Game osztályodat kellene itt tesztelni
        //    var gameCtrl = new Game(ui);

        //    Assert.IsTrue(ui.TestSteps.Count == 1, "Nincs UI output vagy túl sok az output");
        //    Assert.IsTrue(ui.TestSteps[0].StartsWith("PrintLN"), "AZ UI nem printLN indít");
        //    Assert.IsTrue(ui.TestSteps[0].Contains("A beírt karakter nincs a lehetőségek között!"), "Karakter hibás");
        //    Assert.IsTrue(ui.TestSteps[0].Contains("A beírt adat nem egy szám!"), "Karakter hibás");
        //}
        public void KitalalosStartTest()
        {

        }
        public void KitalalosPlayTest()
        {

        }
        public void KitalalosGameModeOneTest()
        {

        }
        public void KitalalosGameModeTwoTest()
        {

        }
        public void KitalalosResultTest()
        {

        }

    }
}
