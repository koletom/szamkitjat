using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using szamkitjat;

namespace UnitTest
{
    [TestClass]
    public class AmobaTests
    {
        [TestMethod]
        [ExpectedException(typeof(NullReferenceException), "Constructor null paraméter exception test ok.")]
        public void AmobaContructorNullReferenceTest()
        {
            _ = new Amoba(null);
        }
        [TestMethod]
        public void AmobaCreateTest()
        {
            var amoba = new Amoba(new FakeUI());
            Assert.IsNotNull(amoba);
        }

        [TestMethod]
        public void AmobaMethodTest()
        {
            var ui = new FakeUI();
            var gameCtrl = new Game(ui);

            Assert.IsTrue(ui.TestSteps.Count == 1, "Nincs UI output vagy túl sok az output");
            Assert.IsTrue(ui.TestSteps[0].StartsWith("PrintLN"), "AZ UI nem printLN indít");
            Assert.IsTrue(ui.TestSteps[0].Contains("A beírt szám nem megfelelő"), "Karakter hibás");
            Assert.IsTrue(ui.TestSteps[0].Contains("A beírt szám helye foglalt"), "A szám már korábban meg lett adva");
        }
        public void AmobaStartTest()
        {

        }
        public void AmobaPlayTest()
        {

        }
        public void AmobaValidNumberTest() 
        {

        }
        public void AmobaResultTest() 
        {

        }
    }
}
