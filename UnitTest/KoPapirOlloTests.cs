﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using szamkitjat;

namespace UnitTest
{
    [TestClass]
    public class KoPapirOlloTests
    {
        [TestMethod]
        [ExpectedException(typeof(NullReferenceException), "Constructor null paraméter exception test ok.")]
        public void KoPapirOlloConstructorNullReferenceTest()
        {
            _ = new KoPapirOllo(null);
        }
        [TestMethod]
        public void KitalalosCreateTest()
        {
            var kopapirollo = new KoPapirOllo(new FakeUI());
            Assert.IsNotNull(kopapirollo);
        }
        //[TestMethod]
        //public void KoPapirOlloMethodTest()
        //{
        //    var ui = new FakeUI();
        //    //TODO:Nem a Game osztályodat kellene itt tesztelni
        //    var gameCtrl = new Game(ui);

        //    Assert.IsTrue(ui.TestSteps.Count == 1, "Nincs UI output vagy túl sok az output");
        //    Assert.IsTrue(ui.TestSteps[0].StartsWith("PrintLN"), "AZ UI nem printLN indít");
        //    Assert.IsTrue(ui.TestSteps[0].Contains("Érvénytelten tét"), "A megadott tét nem megfelelő");
        //    Assert.IsTrue(ui.TestSteps[0].Contains("Nincs elegendő Coin."), "Coin/vége hibás");
        //}
        [TestMethod]
        public void KoPapirOlloKPOSzinekTest()
        {
            var ui = new FakeUI();
            var kopapirollo = new KoPapirOllo(ui);

            kopapirollo.KPOSzinek();

            Assert.IsTrue(ui.TestSteps.Count == 1, "Túl sok vagy kevés az output");
            Assert.IsTrue(ui.TestSteps[0].Contains("fg:DarkBlue|bg:Cyan"), "Táblázat nem megfelelő a szinek beállítása");
        }
        [TestMethod]
        public void KoPapirOlloStartTest()
        {
            var ui = new FakeUI();
            var kopapirollo = new KoPapirOllo(ui);

            kopapirollo.Start();

            Assert.IsTrue(ui.TestSteps.Count == 4, "Túl sok vagy kevés az output");
            Assert.IsTrue(ui.TestSteps[0].StartsWith("Sound"), "Nem a zene lejátszásával indul");
            Assert.IsTrue(ui.TestSteps[0].Contains("Good"), "Nem a Good zene kerül lejátszásra induláskor");
            Assert.IsTrue(ui.TestSteps[1].StartsWith("Clear"), "Nem történik képernyő törlés zene lejátszása után");
            Assert.IsTrue(ui.TestSteps[2].Contains("Válassz a három lehetőség közül! kő, papír, olló (k/p/o)"), "Nem lettek kiírva a lehetőségek");
            Assert.IsTrue(ui.TestSteps[3].Contains("A játék 5 pontig megy!"), "Nem lett kiírva a szabály");
        }
        [TestMethod]
        public void KoPapirOlloProbaTest()
        {
            var ui = new FakeUI();
            var kopapirollo = new KoPapirOllo(ui);

            kopapirollo.Proba();

            Assert.IsTrue(ui.TestSteps.Count == 1, "Túl sok vagy kevés az output");
            Assert.IsTrue(ui.TestSteps[0].Contains("ReadKeyTrue"), "Nem a olvassa be a karaktert");
            Assert.IsNull(ui.ReadResult, "Nem a olvassa be a karaktert");
        }
        [TestMethod]
        public void KoPapirOlloPlayTest()
        {
            var ui = new FakeUI();
            var kopapirollo = new KoPapirOllo(ui);
            ui.ReadResult = 'k';

            kopapirollo.Play();

            //Assert.IsTrue(ui.TestSteps.Count == 4, "Túl sok vagy kevés az output");
            Assert.IsTrue(ui.TestSteps[1].Contains("Mit választasz? (k/p/o)"), "Nem lettek kiírva a lehetőségek");
            Assert.IsTrue(ui.TestSteps[3].StartsWith("Sound"), "Nem a sound lejátszásával indul");
            Assert.IsTrue(ui.TestSteps[3].Contains("Step"), "Nem a Step zene kerül lejátszásra lépéskor");

            Assert.IsTrue(ui.TestSteps[4].StartsWith("Clear"), "Nem történik képernyő törlése");
            Assert.IsTrue(ui.TestSteps[5].Contains("Játékos:"), "Nem lettek kiírva a lehetőségek");

            Assert.IsTrue(ui.TestSteps[7].Contains("fg:DarkBlue|bg:Cyan"), "Nem megfelelő a szinek beállítása");
            Assert.IsTrue(ui.TestSteps[8].Contains("Az állás:"), "Nem lettek kiírva a lehetőségek");
            Assert.IsTrue(ui.TestSteps[9].StartsWith("Sound"), "Nem a sound lejátszásával ér véget");
        }
        public void KoPapirOlloResultTest()
        {

        }
        [TestMethod]
        public void KoPapirOlloEndResultPlayerLoseTest()
        {
            var ui = new FakeUI();
            var kopapirollo = new KoPapirOllo(ui);

            kopapirollo.EndResultComputer(5);

            Assert.IsTrue(ui.TestSteps.Count == 4, "Túl sok vagy kevés az output");
            Assert.IsTrue(ui.TestSteps[0].StartsWith("Sound"), "Nem a zene lejátszásával indul");
            Assert.IsTrue(ui.TestSteps[0].Contains("Lose"), "Nem a Lose zene kerül lejátszásra induláskor");
            Assert.IsTrue(ui.TestSteps[1].Contains("Vesztettél!"), "Nem jó végeredmény lett kiírva");
            Assert.IsTrue(ui.TestSteps[1].Contains("fg:Red"), "Nem megfelelő a szinek lettek beállítva");
            Assert.IsTrue(ui.TestSteps[3].Contains("A Számítógép:"), "Nem jó végeredmény lett kiírva");

        }
        [TestMethod]
        public void KoPapirOlloEndResultPlayerWinTest()
        {
            var ui = new FakeUI();
            var kopapirollo = new KoPapirOllo(ui);

            kopapirollo.EndResultPlayer(5);

            Assert.IsTrue(ui.TestSteps.Count == 4, "Túl sok vagy kevés az output");
            Assert.IsTrue(ui.TestSteps[0].StartsWith("Sound"), "Nem a zene lejátszásával indul");
            Assert.IsTrue(ui.TestSteps[0].Contains("Win"), "Nem a Win zene kerül lejátszásra induláskor");
            Assert.IsTrue(ui.TestSteps[1].Contains("Gratulálunk! Nyertél!"), "Nem jó végeredmény lett kiírva");
            Assert.IsTrue(ui.TestSteps[1].Contains("fg:DarkGreen"), "Nem megfelelő a szinek lettek beállítva");
            Assert.IsTrue(ui.TestSteps[3].Contains("A Játékos:"), "Nem jó végeredmény lett kiírva");
        }
    }
}
