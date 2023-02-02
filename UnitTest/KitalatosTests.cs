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
        public void KitalalosConstructorNullReferenceTest()
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
        [TestMethod]
        public void KitalalosStartGameOneTest()
        {
            var ui = new FakeUI();
            var kitalalos = new Kitalalos(ui);
            ui.ReadResult = '1';
            kitalalos.Start();

            Assert.IsTrue(ui.TestSteps.Count == 7, "Túl sok vagy kevés az output");
            Assert.IsTrue(ui.TestSteps[0].StartsWith("Sound"), "Nem a zene lejátszásával indul");
            Assert.IsTrue(ui.TestSteps[0].Contains("Good"), "Nem a Good zene kerül lejátszásra induláskor");
            Assert.IsTrue(ui.TestSteps[1].StartsWith("Clear"), "Nem történik képernyő törlés zene lejátszása után");
            Assert.IsTrue(ui.TestSteps[1].Contains("fg:DarkRed|bg:Yellow"), "Törléskor nem megfelelő a szinek beállítása");
            Assert.IsTrue(ui.TestSteps[2].Contains("Válassz játékmódot"), "Nem lett kiírva a játékmód választás");
            Assert.IsTrue(ui.TestSteps[3].Contains("1"), "Nem lett kiírva az 1. játékmód");
            Assert.IsTrue(ui.TestSteps[4].Contains("2"), "Nem lett kiírva a 2. játékmód");
            Assert.IsTrue(ui.TestSteps[5].Contains("3"), "Nem lett kiírva a visszalépés lehetősége");
        }
        [TestMethod]
        public void KitalalosPlayGameModeOneHigherTest()
        {
            var ui = new FakeUI();
            var kitalalos = new Kitalalos(ui);
            
            //TODO:A tesztet meg lehet írni anélkül is, hogy a gamer-t publikusra állítod.
            kitalalos.gamer = 1;
            ui.ReadResult = 'n';
            
            kitalalos.Play();

            Assert.IsTrue(ui.TestSteps.Count == 36, "Túl sok vagy kevés az output");

            Assert.IsTrue(ui.TestSteps[0].StartsWith("Sound"), "Nem a zene lejátszásával indul");
            Assert.IsTrue(ui.TestSteps[0].Contains("Good"), "Nem a Good zene kerül lejátszásra induláskor");

            Assert.IsTrue(ui.TestSteps[1].StartsWith("Clear"), "Nem történik képernyő törlés zene lejátszása után");
            Assert.IsTrue(ui.TestSteps[2].Contains("Gondolj egy számra! (1 - 100)"), "Nem lett kiírva a számok intervalluma");
            Assert.IsTrue(ui.TestSteps[5].StartsWith("Sound"), "Nem játsza le a hangot");
            Assert.IsTrue(ui.TestSteps[5].Contains("Good"), "Nem a Good zene kerül lejátszásra");

            Assert.IsTrue(ui.TestSteps[6].StartsWith("Clear"), "Nem történik meg a képernyő törlése");

            Assert.IsTrue(ui.TestSteps[7].Contains("tippje"), "Nem lett kiírva a gép tippje");
            Assert.IsTrue(ui.TestSteps[8].Contains("A számítógép szerint a szám"), "Nem lett kiírva a gép tippje");
            Assert.IsTrue(ui.TestSteps[9].Contains("Szerinted? kisebb, nagyobb, egyenlő (k/n/e)"), "Nem lett kiírva a gép tippje");
            Assert.IsTrue(ui.TestSteps[11].StartsWith("Sound"), "Nem játsza le a hangot");
            Assert.IsTrue(ui.TestSteps[11].Contains("Step"), "Nem a Step hang került lejátszásra");

            Assert.IsTrue(ui.TestSteps[12].StartsWith("Clear"), "Nem történik meg a képernyő törlése");

            Assert.IsTrue(ui.TestSteps[13].Contains("tippje"), "Nem lett kiírva a gép tippje");
            Assert.IsTrue(ui.TestSteps[14].Contains("A számítógép szerint a szám"), "Nem lett kiírva a gép tippje");
            Assert.IsTrue(ui.TestSteps[15].Contains("Szerinted? kisebb, nagyobb, egyenlő (k/n/e)"), "Nem lett kiírva a gép tippje");
            Assert.IsTrue(ui.TestSteps[17].StartsWith("Sound"), "Nem játsza le a hangot");
            Assert.IsTrue(ui.TestSteps[17].Contains("Step"), "Nem a Step hang került lejátszásra");
        }
        [TestMethod]
        public void KitalalosPlayGameModeOneLowerTest()
        {
            var ui = new FakeUI();
            var kitalalos = new Kitalalos(ui);
            kitalalos.gamer = 1;
            ui.ReadResult = 'k';
            kitalalos.Play();

            Assert.IsTrue(ui.TestSteps.Count == 36, "Túl sok vagy kevés az output");
            
            Assert.IsTrue(ui.TestSteps[0].StartsWith("Sound"), "Nem a zene lejátszásával indul");
            Assert.IsTrue(ui.TestSteps[0].Contains("Good"), "Nem a Good zene kerül lejátszásra induláskor");

            Assert.IsTrue(ui.TestSteps[1].StartsWith("Clear"), "Nem történik képernyő törlés zene lejátszása után");
            Assert.IsTrue(ui.TestSteps[2].Contains("Gondolj egy számra! (1 - 100)"), "Nem lett kiírva a számok intervalluma");
            Assert.IsTrue(ui.TestSteps[5].StartsWith("Sound"), "Nem játsza le a hangot");
            Assert.IsTrue(ui.TestSteps[5].Contains("Good"), "Nem a Good zene kerül lejátszásra");

            Assert.IsTrue(ui.TestSteps[6].StartsWith("Clear"), "Nem történik meg a képernyő törlése");

            Assert.IsTrue(ui.TestSteps[7].Contains("tippje"), "Nem lett kiírva a gép tippje");
            Assert.IsTrue(ui.TestSteps[8].Contains("A számítógép szerint a szám"), "Nem lett kiírva a gép tippje");
            Assert.IsTrue(ui.TestSteps[9].Contains("Szerinted? kisebb, nagyobb, egyenlő (k/n/e)"), "Nem lett kiírva a gép tippje");
            Assert.IsTrue(ui.TestSteps[11].StartsWith("Sound"), "Nem játsza le a hangot");
            Assert.IsTrue(ui.TestSteps[11].Contains("Step"), "Nem a Step hang került lejátszásra");
        }
        [TestMethod]
        public void KitalalosPlayGameModeOneEqualTest()
        {
            var ui = new FakeUI();
            var kitalalos = new Kitalalos(ui);
            kitalalos.gamer = 1;
            ui.ReadResult = 'e';
            kitalalos.Play();

            Assert.IsTrue(ui.TestSteps.Count == 12, "Túl sok vagy kevés az output");
            
            Assert.IsTrue(ui.TestSteps[0].StartsWith("Sound"), "Nem a zene lejátszásával indul");
            Assert.IsTrue(ui.TestSteps[0].Contains("Good"), "Nem a Good zene kerül lejátszásra induláskor");

            Assert.IsTrue(ui.TestSteps[1].StartsWith("Clear"), "Nem történik képernyő törlés zene lejátszása után");
            Assert.IsTrue(ui.TestSteps[2].Contains("Gondolj egy számra! (1 - 100)"), "Nem lett kiírva a számok intervalluma");
            Assert.IsTrue(ui.TestSteps[5].StartsWith("Sound"), "Nem játsza le a hangot");
            Assert.IsTrue(ui.TestSteps[5].Contains("Good"), "Nem a Good zene kerül lejátszásra");

            Assert.IsTrue(ui.TestSteps[6].StartsWith("Clear"), "Nem történik meg a képernyő törlése");
            
            Assert.IsTrue(ui.TestSteps[7].Contains("tippje"), "Nem lett kiírva a gép tippje");
            Assert.IsTrue(ui.TestSteps[8].Contains("A számítógép szerint a szám"), "Nem lett kiírva a gép tippje");
            Assert.IsTrue(ui.TestSteps[9].Contains("Szerinted? kisebb, nagyobb, egyenlő (k/n/e)"), "Nem lett kiírva a gép tippje");
            Assert.IsTrue(ui.TestSteps[11].StartsWith("Sound"), "Nem játsza le a hangot");
            Assert.IsTrue(ui.TestSteps[11].Contains("Step"), "Nem a Step hang került lejátszásra");
        }
        [TestMethod]
        public void KitalalosGameModeTwoTest()
        {
            var ui = new FakeUI();
            var kitalalos = new Kitalalos(ui);
            kitalalos.gamer = 2;
            ui.ReadNumberResult = 1;
            kitalalos.Play();

            //Assert.IsTrue(ui.TestSteps.Count == 5, "Túl sok vagy kevés az output");

            Assert.IsTrue(ui.TestSteps[0].StartsWith("Sound"), "Nem a zene lejátszásával indul");
            Assert.IsTrue(ui.TestSteps[0].Contains("Good"), "Nem a Good zene kerül lejátszásra induláskor");

            Assert.IsTrue(ui.TestSteps[1].StartsWith("Clear"), "Nem történik képernyő törlése");
            Assert.IsTrue(ui.TestSteps[2].Contains("A gép gondolt egy számra 0-100-ig"), "Nem lett kiírva a szabályok");
        }
        [TestMethod]
        public void KitalalosResultGameOneWinTest()
        {
            var ui = new FakeUI();
            var kitalalos = new Kitalalos(ui);

            kitalalos.EndResult(5);

            Assert.IsTrue(ui.TestSteps.Count == 5, "Túl sok vagy kevés az output");
            
            Assert.IsTrue(ui.TestSteps[0].Contains("Nyertél!"), "Nem jó végeredmény lett kiírva");
            Assert.IsTrue(ui.TestSteps[0].Contains("fg:DarkGreen"), "Nem megfelelő a szinek beállítása");
            Assert.IsTrue(ui.TestSteps[1].StartsWith("Sound"), "Nem a zene lejátszásával indul");
            Assert.IsTrue(ui.TestSteps[1].Contains("Win"), "Nem a Win zene kerül lejátszásra induláskor");
        }
        [TestMethod]
        public void KitalalosResultGameTwoWinTest()
        {
            var ui = new FakeUI();
            var kitalalos = new Kitalalos(ui);

            kitalalos.EndResult(10);

            Assert.IsTrue(ui.TestSteps.Count == 5, "Túl sok vagy kevés az output");
            
            Assert.IsTrue(ui.TestSteps[0].Contains("Nyertél!"), "Nem jó végeredmény lett kiírva");
            Assert.IsTrue(ui.TestSteps[0].Contains("fg:DarkGreen"), "Nem megfelelő a szinek beállítása");
            Assert.IsTrue(ui.TestSteps[1].StartsWith("Sound"), "Nem a zene lejátszásával indul");
            Assert.IsTrue(ui.TestSteps[1].Contains("Win"), "Nem a Win zene kerül lejátszásra induláskor");
        }
        [TestMethod]
        public void KitalalosResultGameTwoLoseTest()
        {
            var ui = new FakeUI();
            var kitalalos = new Kitalalos(ui);

            kitalalos.EndResult(15);

            Assert.IsTrue(ui.TestSteps.Count == 4, "Túl sok vagy kevés az output");

            Assert.IsTrue(ui.TestSteps[0].StartsWith("Sound"), "Nem a zene lejátszásával indul");
            Assert.IsTrue(ui.TestSteps[0].Contains("Lose"), "Nem a Lose zene kerül lejátszásra induláskor");
        }
        [TestMethod]
        public void KitalalosResultGameOneLoseTest()
        {
            var ui = new FakeUI();
            var kitalalos = new Kitalalos(ui);

            kitalalos.EndResult(20);

            Assert.IsTrue(ui.TestSteps.Count == 5, "Túl sok vagy kevés az output");

            Assert.IsTrue(ui.TestSteps[0].Contains("Vesztettél"), "Nem jó végeredmény lett kiírva");
            Assert.IsTrue(ui.TestSteps[1].StartsWith("Sound"), "Nem a zene lejátszásával indul");
            Assert.IsTrue(ui.TestSteps[1].Contains("Lose"), "Nem a Lose zene kerül lejátszásra induláskor");
        }

    }
}
