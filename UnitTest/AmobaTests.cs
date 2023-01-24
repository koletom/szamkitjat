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

        //[TestMethod]
        //public void AmobaMethodTest()
        //{
        //    var ui = new FakeUI();
        //    //TODO:Nem a Game osztályodat kellene itt tesztelni
        //    var gameCtrl = new Game(ui);

        //    Assert.IsTrue(ui.TestSteps.Count == 1, "Nincs UI output vagy túl sok az output");
        //    Assert.IsTrue(ui.TestSteps[0].StartsWith("PrintLN"), "AZ UI nem printLN indít");
        //    Assert.IsTrue(ui.TestSteps[0].Contains("A beírt szám nem megfelelő"), "Karakter hibás");
        //    Assert.IsTrue(ui.TestSteps[0].Contains("A beírt szám helye foglalt"), "A szám már korábban meg lett adva");
        //}
        
        [TestMethod]
        public void AmobaStartTest()
        {
            var ui = new FakeUI();
            var amoba = new Amoba(ui);
            
            amoba.Start();

            Assert.IsTrue(ui.TestSteps.Count == 8, "Túl sok vagy kevés az output");
            Assert.IsTrue(ui.TestSteps[0].StartsWith("Sound"), "Nem a zene lejátszásával indul");
            Assert.IsTrue(ui.TestSteps[0].Contains("Good"), "Nem a Good zene kerül lejátszásra induláskor");
            Assert.IsTrue(ui.TestSteps[1].StartsWith("Clear"), "Nem történik képernyő törlés zene lejátszása után");
            Assert.IsTrue(ui.TestSteps[1].Contains("fg:DarkGray|bg:Gray"), "Törléskor nem megfelelő a szinek beállítása");
            //TODO:Hashonlóképpen folytasd

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
