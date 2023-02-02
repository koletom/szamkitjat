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
        [TestMethod]
        public void HuszonegyKartyaStartMFranciaTest()
        {
            var ui = new FakeUI();
            var huszonegykartya = new HuszonegyKartya(ui);
            ui.ReadResult = "francia";
            ui.ReadNumberResult = 1;
            huszonegykartya.Start();

            Assert.IsTrue(ui.TestSteps.Count == 18, "Túl sok vagy kevés az output");
            Assert.IsTrue(ui.TestSteps[0].StartsWith("Sound"), "Nem a zene lejátszásával végződik");
            Assert.IsTrue(ui.TestSteps[0].Contains("Good"), "Nem a Good zene kerül lejátszásra");
            Assert.IsTrue(ui.TestSteps[1].StartsWith("Clear"), "Nem történik képernyő törlés zene lejátszása után");
            Assert.IsTrue(ui.TestSteps[1].Contains("fg:White|bg:Black"), "Törléskor nem megfelelő a szinek beállítása");
            Assert.IsTrue(ui.TestSteps[2].Contains("Az nyer akinél nagyobb száma van vagy előbb lesz 21"), "Nem lett kiírva a szabályok");

            Assert.IsTrue(ui.TestSteps[3].Contains("Adja meg a játékosok számát (max 5)"), "Nem lett bekérve a játékosok száma");

            Assert.IsTrue(ui.TestSteps[6].StartsWith("Clear"), "Nem történik képernyő törlése");
            Assert.IsTrue(ui.TestSteps[7].Contains("Válassz kártya paklit."), "Nem lett kiírva a választási lehetőség");

            Assert.IsTrue(ui.TestSteps[9].StartsWith("Clear"), "Nem történik képernyő törlése");
            Assert.IsTrue(ui.TestSteps[10].Contains("Választott pakli:"), "Nem lett kiírva a választott pakli");
            Assert.IsTrue(ui.TestSteps[11].Contains("Dáma"), "Nem lett kiírva a lapok értéke");
            Assert.IsTrue(ui.TestSteps[12].Contains("A játékszabályok:"), "Nem lettek kiírva a játékszabályok");
            Assert.IsTrue(ui.TestSteps[13].Contains("Ha az osztó és játékos lapjainak értéke egyenlő a játékos visszakapja a tétet!"), "Nem lettek kiírva a játékszabályok");

            Assert.IsTrue(ui.TestSteps[14].Contains("darab játékos játsza"), "Nem lett kiírva a játékosok száma és a paki tipusa");
            Assert.IsTrue(ui.TestSteps[15].Contains("Kezdődjön a játék!"), "Nem lett kiírva a kezdés jelzése");
        }
        [TestMethod]
        public void HuszonegyKartyaStartMagyarTest()
        {
            var ui = new FakeUI();
            var huszonegykartya = new HuszonegyKartya(ui);
            ui.ReadResult = "magyar";
            ui.ReadNumberResult = 1;
            huszonegykartya.Start();

            Assert.IsTrue(ui.TestSteps.Count == 18, "Túl sok vagy kevés az output");
            Assert.IsTrue(ui.TestSteps[0].StartsWith("Sound"), "Nem a zene lejátszásával végződik");
            Assert.IsTrue(ui.TestSteps[0].Contains("Good"), "Nem a Good zene kerül lejátszásra");
            Assert.IsTrue(ui.TestSteps[1].StartsWith("Clear"), "Nem történik képernyő törlés zene lejátszása után");
            Assert.IsTrue(ui.TestSteps[1].Contains("fg:White|bg:Black"), "Törléskor nem megfelelő a szinek beállítása");
            Assert.IsTrue(ui.TestSteps[2].Contains("Az nyer akinél nagyobb száma van vagy előbb lesz 21"), "Nem lett kiírva a szabályok");

            Assert.IsTrue(ui.TestSteps[3].Contains("Adja meg a játékosok számát (max 5)"), "Nem lett bekérve a játékosok száma");

            Assert.IsTrue(ui.TestSteps[6].StartsWith("Clear"), "Nem történik képernyő törlése");
            Assert.IsTrue(ui.TestSteps[7].Contains("Válassz kártya paklit."), "Nem lett kiírva a választási lehetőség");

            Assert.IsTrue(ui.TestSteps[9].StartsWith("Clear"), "Nem történik képernyő törlése");
            Assert.IsTrue(ui.TestSteps[10].Contains("Választott pakli:"), "Nem lett kiírva a választott pakli");
            Assert.IsTrue(ui.TestSteps[11].Contains("Felső"), "Nem lett kiírva a lapok értéke");
            Assert.IsTrue(ui.TestSteps[12].Contains("A játékszabályok:"), "Nem lettek kiírva a játékszabályok");
            Assert.IsTrue(ui.TestSteps[13].Contains("Ha az osztó és játékos lapjainak értéke egyenlő a játékos vesztett!"), "Nem lettek kiírva a játékszabályok");

            Assert.IsTrue(ui.TestSteps[14].Contains("darab játékos játsza"), "Nem lett kiírva a játékosok száma és a paki tipusa");
            Assert.IsTrue(ui.TestSteps[15].Contains("Kezdődjön a játék!"), "Nem lett kiírva a kezdés jelzése");
        }
        public void HuszonegyKartyaDeckMagyarTest()
        {
            var ui = new FakeUI();
            var huszonegykartya = new HuszonegyKartya(ui);

            huszonegykartya.Start();

            Assert.IsTrue(ui.TestSteps.Count == 5, "Túl sok vagy kevés az output");
            Assert.IsTrue(ui.TestSteps[0].StartsWith("Clear"), "Nem történik képernyő törlés");
            Assert.IsTrue(ui.TestSteps[1].Contains("Választott pakli:"), "Nem lett kiírva a pakli");
            Assert.IsTrue(ui.TestSteps[2].Contains("A lapok értéke:"), "Nem lett kiírva a lapok értéke");
            Assert.IsTrue(ui.TestSteps[3].Contains("A játékszabályok:"), "Nem lett kiírva a játékszabályok");
            Assert.IsTrue(ui.TestSteps[4].Contains("Ha valakinek több van mint 21 vesztett"), "Nem lett kiírva a játékszabályok");
        }
        public void HuszonegyKartyaDeckFranciaTest()
        {
            var ui = new FakeUI();
            var huszonegykartya = new HuszonegyKartya(ui);

            huszonegykartya.Start();

            Assert.IsTrue(ui.TestSteps.Count == 5, "Túl sok vagy kevés az output");
            Assert.IsTrue(ui.TestSteps[0].StartsWith("Clear"), "Nem történik képernyő törlés");
            Assert.IsTrue(ui.TestSteps[1].Contains("Választott pakli:"), "Nem lett kiírva a pakli");
            Assert.IsTrue(ui.TestSteps[2].Contains("A lapok értéke:"), "Nem lett kiírva a lapok értéke");
            Assert.IsTrue(ui.TestSteps[3].Contains("A játékszabályok:"), "Nem lett kiírva a játékszabályok");
            Assert.IsTrue(ui.TestSteps[4].Contains("Ha valakinek több van mint 21 vesztett"), "Nem lett kiírva a játékszabályok");
        }
        //[TestMethod]
        //public void HuszonegyKartyaKorKezdesTest()
        //{
        //    var ui = new FakeUI();
        //    var huszonegykartya = new HuszonegyKartya(ui);

        //    huszonegykartya.KorKezdes();

        //    Assert.IsTrue(ui.TestSteps.Count == 4, "Túl sok vagy kevés az output");
        //    Assert.IsTrue(ui.TestSteps[0].StartsWith("Clear"), "Nem történik képernyő törlés");
        //    Assert.IsTrue(ui.TestSteps[0].Contains("fg:White|bg:Black"), "Törléskor nem megfelelő a szinek beállítása");
        //}
        public void HuszonegyKartyaPlayTest()
        {
            var ui = new FakeUI();
            var huszonegykartya = new HuszonegyKartya(ui);
            

            huszonegykartya.Play();
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
        [TestMethod]
        public void HuszonegyKartyaResultBustTest()
        {
            var ui = new FakeUI();
            var huszonegykartya = new HuszonegyKartya(ui);

            huszonegykartya.KorVege(HuszonegyKartya.Vegeredmeny.BUST); 
            
            Assert.IsTrue(ui.TestSteps.Count == 4, "Túl sok vagy kevés az output");
            Assert.IsTrue(ui.TestSteps[0].Contains("A játékos túl sok lapot húzott"), "Rossz eredmény lett kiírva");
            Assert.IsTrue(ui.TestSteps[0].Contains("fg:Red"), "Nem megfelelő piros betű szinek beállítása");
            Assert.IsTrue(ui.TestSteps[1].Contains("fg:DarkBlue|bg:Cyan"), "Nem megfelelő a szinek beállítása");

        }
        [TestMethod]
        public void HuszonegyKartyaResultSurrenderTest()
        {
            var ui = new FakeUI();
            var huszonegykartya = new HuszonegyKartya(ui);

            huszonegykartya.KorVege(HuszonegyKartya.Vegeredmeny.SURRENDER);

            Assert.IsTrue(ui.TestSteps.Count == 5, "Túl sok vagy kevés az output");
            Assert.IsTrue(ui.TestSteps[0].Contains("A Játékos feladta."), "Rossz eredmény lett kiírva");
            Assert.IsTrue(ui.TestSteps[0].Contains("fg:Red"), "Nem megfelelő piros betű szinek beállítása");
            Assert.IsTrue(ui.TestSteps[1].Contains("Coint visszakap"), "Rossz eredmény lett kiírva");
            Assert.IsTrue(ui.TestSteps[1].Contains("fg:DarkGreen"), "Nem megfelelő piros betű szinek beállítása");
            Assert.IsTrue(ui.TestSteps[2].Contains("fg:DarkBlue|bg:Cyan"), "Nem megfelelő a szinek beállítása");
        }
        [TestMethod]
        public void HuszonegyKartyaResultWinTest()
        {
            var ui = new FakeUI();
            var huszonegykartya = new HuszonegyKartya(ui);

            huszonegykartya.KorVege(HuszonegyKartya.Vegeredmeny.WIN);

            Assert.IsTrue(ui.TestSteps.Count == 4, "Túl sok vagy kevés az output");
            Assert.IsTrue(ui.TestSteps[0].Contains("A Játékos 2 Ászt húzott."), "Rossz eredmény lett kiírva");
            Assert.IsTrue(ui.TestSteps[0].Contains("fg:DarkGreen"), "Nem megfelelő piros betű szinek beállítása");
            Assert.IsTrue(ui.TestSteps[1].Contains("fg:DarkBlue|bg:Cyan"), "Nem megfelelő a szinek beállítása");

        }
        [TestMethod]
        public void HuszonegyKartyaResultBlackjackTest()
        {
            var ui = new FakeUI();
            var huszonegykartya = new HuszonegyKartya(ui);

            huszonegykartya.KorVege(HuszonegyKartya.Vegeredmeny.BLACKJACK);

            Assert.IsTrue(ui.TestSteps.Count == 4, "Túl sok vagy kevés az output");
            Assert.IsTrue(ui.TestSteps[0].Contains("Blackjack. Játékos nyert."), "Rossz eredmény lett kiírva");
            Assert.IsTrue(ui.TestSteps[0].Contains("fg:DarkGreen"), "Nem megfelelő piros betű szinek beállítása");
            Assert.IsTrue(ui.TestSteps[1].Contains("fg:DarkBlue|bg:Cyan"), "Nem megfelelő a szinek beállítása");
        }
        [TestMethod]
        public void HuszonegyKartyaResultNyertTest()
        {
            var ui = new FakeUI();
            var huszonegykartya = new HuszonegyKartya(ui);

            huszonegykartya.KorVege(HuszonegyKartya.Vegeredmeny.NYERT);

            Assert.IsTrue(ui.TestSteps.Count == 4, "Túl sok vagy kevés az output");
            Assert.IsTrue(ui.TestSteps[0].Contains("Játékos nyert. Nyeremény:"), "Rossz eredmény lett kiírva");
            Assert.IsTrue(ui.TestSteps[0].Contains("fg:DarkGreen"), "Nem megfelelő piros betű szinek beállítása");
            Assert.IsTrue(ui.TestSteps[1].Contains("fg:DarkBlue|bg:Cyan"), "Nem megfelelő a szinek beállítása");
        }
        [TestMethod]
        public void HuszonegyKartyaResultVesztettTest()
        {
            var ui = new FakeUI();
            var huszonegykartya = new HuszonegyKartya(ui);

            huszonegykartya.KorVege(HuszonegyKartya.Vegeredmeny.VESZTETT);

            Assert.IsTrue(ui.TestSteps.Count == 4, "Túl sok vagy kevés az output");
            Assert.IsTrue(ui.TestSteps[0].Contains("Osztó nyert"), "Rossz eredmény lett kiírva");
            Assert.IsTrue(ui.TestSteps[0].Contains("fg:Red"), "Nem megfelelő piros betű szinek beállítása");
            Assert.IsTrue(ui.TestSteps[1].Contains("fg:DarkBlue|bg:Cyan"), "Nem megfelelő a szinek beállítása");
        }
        [TestMethod]
        public void HuszonegyKartyaResultDontetlenTest()
        {
            var ui = new FakeUI();
            var huszonegykartya = new HuszonegyKartya(ui);

            huszonegykartya.KorVege(HuszonegyKartya.Vegeredmeny.DONTETLEN);

            Assert.IsTrue(ui.TestSteps.Count == 5, "Túl sok vagy kevés az output");
            Assert.IsTrue(ui.TestSteps[0].Contains("Döntetlen"), "Rossz eredmény lett kiírva");
            Assert.IsTrue(ui.TestSteps[0].Contains("fg:Yellow"), "Nem megfelelő piros betű szinek beállítása");
            Assert.IsTrue(ui.TestSteps[1].Contains("Coint visszakap."), "Rossz eredmény lett kiírva");
            Assert.IsTrue(ui.TestSteps[1].Contains("fg:DarkGreen"), "Nem megfelelő piros betű szinek beállítása");
            Assert.IsTrue(ui.TestSteps[2].Contains("fg:DarkBlue|bg:Cyan"), "Nem megfelelő a szinek beállítása");
        }
        [TestMethod]
        public void HuszonegyKartyaEndTest()
        {
            var ui = new FakeUI();
            var huszonegykartya = new HuszonegyKartya(ui);

            huszonegykartya.End();

            Assert.IsTrue(ui.TestSteps.Count == 6, "Túl sok vagy kevés az output");
            Assert.IsTrue(ui.TestSteps[0].Contains("fg:Black|bg:White"), "Nem megfelelő a szinek beállítása");
            Assert.IsTrue(ui.TestSteps[1].Contains("Nincs elegendő Coin."), "Rossz eredmény lett kiírva");
            Assert.IsTrue(ui.TestSteps[2].Contains("A játéknak vége!"), "Rossz eredmény lett kiírva");
        }
    }
}
