using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using szamkitjat;

namespace UnitTest
{
    [TestClass]
    public class HuszonegyKartyaTests
    {
        [TestMethod]
        [ExpectedException(typeof(NullReferenceException), "Constructor null paraméter exception test ok.")]
        public void HuszonegyKartyaConstructorNullReferenceTest()
        {
            _ = new HuszonegyKartya(null);
        }

        [TestMethod]
        public void HuszonegyKartyaCreateTest()
        {
            var huszonegykartya = new HuszonegyKartya(new FakeUI());
            Assert.IsNotNull(huszonegykartya);
        }

        //[TestMethod]
        //public void HuszonegyKartyaMethodTest()
        //{
        //    var ui = new FakeUI();
        //    //TODO:Nem a Game osztályodat kellene itt tesztelni
        //    var gameCtrl = new Game(ui);

        //    Assert.IsTrue(ui.TestSteps.Count == 1, "Nincs UI output vagy túl sok az output");
        //    Assert.IsTrue(ui.TestSteps[0].StartsWith("PrintLN"), "AZ UI nem printLN indít");
        //    Assert.IsTrue(ui.TestSteps[0].Contains("Érvénytelten tét"), "A megadott tét nem megfelelő");
        //    Assert.IsTrue(ui.TestSteps[0].Contains("Nincs elegendő Coin."), "Coin/vége hibás");
        //}

        //[TestMethod]
        public void HuszonegyKartyaStartTest()
        {
            var ui = new FakeUI();
            var huszonegykartya = new HuszonegyKartya(ui);

            huszonegykartya.Start();

            Assert.IsTrue(ui.TestSteps.Count == 7, "Túl sok vagy kevés az output");
        }

        public void HuszonegyKartyaDeckTest()
        {
        }

        public void HuszonegyKartyaChoiceTest()
        {
        }

        public void HuszonegyKartyaPlayTest()
        {
        }

        [TestMethod]
        public void HuszonegyKartyaTetekTest()
        {
            var ui = new FakeUI();
            var huszonegykartya = new HuszonegyKartya(ui);

            huszonegykartya.Tetek();

            Assert.IsTrue(ui.TestSteps.Count == 9, "Túl sok vagy kevés az output");
            Assert.IsTrue(ui.TestSteps[0].Contains("Jelnlegi"), "Nem lett kiírva Jelnlegi Coinok száma");
            Assert.IsTrue(ui.TestSteps[1].Contains($""), "Nem lett kiírva Jelnlegi Coinok száma");

            Assert.IsTrue(ui.TestSteps[3].Contains("Minimum tét:"), "Nem lett kiírva a MinimumKezdoTet");
            Assert.IsTrue(ui.TestSteps[4].Contains($""), "Nem lett kiírva a MinimumKezdoTet");

            Assert.IsTrue(ui.TestSteps[6].Contains("Kérem a téteket:"), "Nem kérjük be a téteket");

            Assert.IsTrue(ui.TestSteps[8].Contains("A beírt adat nem egy szám!"), "Karakter hiba");
        }

        [TestMethod]
        public void HuszonegyKartyaHSzinekTest()
        {
            var ui = new FakeUI();
            var huszonegykartya = new HuszonegyKartya(ui);

            huszonegykartya.HSzinek();

            Assert.IsTrue(ui.TestSteps.Count == 1, "Túl sok vagy kevés az output");
            Assert.IsTrue(ui.TestSteps[0].Contains("fg:DarkBlue|bg:Cyan"), "Nem megfelelő a szinek beállítása");
        }

        //[TestMethod]
        public void HuszonegyKartyaResultBustTest()
        {
            var ui = new FakeUI();
            var huszonegykartya = new HuszonegyKartya(ui);

            huszonegykartya.KorVege(HuszonegyKartya.Vegeredmeny.BUST);

            Assert.IsTrue(ui.TestSteps.Count == 4, "Túl sok vagy kevés az output");
        }

        public void HuszonegyKartyaResultSurrenderTest()
        {
            var ui = new FakeUI();
            var huszonegykartya = new HuszonegyKartya(ui);

            huszonegykartya.KorVege(HuszonegyKartya.Vegeredmeny.SURRENDER);
        }

        public void HuszonegyKartyaResultWinTest()
        {
            var ui = new FakeUI();
            var huszonegykartya = new HuszonegyKartya(ui);

            huszonegykartya.KorVege(HuszonegyKartya.Vegeredmeny.WIN);
        }

        public void HuszonegyKartyaResultBlackjackTest()
        {
            var ui = new FakeUI();
            var huszonegykartya = new HuszonegyKartya(ui);

            huszonegykartya.KorVege(HuszonegyKartya.Vegeredmeny.BLACKJACK);
        }

        public void HuszonegyKartyaResultNyertTest()
        {
            var ui = new FakeUI();
            var huszonegykartya = new HuszonegyKartya(ui);

            huszonegykartya.KorVege(HuszonegyKartya.Vegeredmeny.NYERT);
        }

        public void HuszonegyKartyaResultVesztettTest()
        {
            var ui = new FakeUI();
            var huszonegykartya = new HuszonegyKartya(ui);

            huszonegykartya.KorVege(HuszonegyKartya.Vegeredmeny.VESZTETT);
        }

        public void HuszonegyKartyaResultDontetlenTest()
        {
            var ui = new FakeUI();
            var huszonegykartya = new HuszonegyKartya(ui);

            huszonegykartya.KorVege(HuszonegyKartya.Vegeredmeny.DONTETLEN);
        }
    }
}