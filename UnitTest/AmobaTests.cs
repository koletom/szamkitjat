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
        public void AmobaConstructorNullReferenceTest()
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
            Assert.IsTrue(ui.TestSteps[5].Contains("0"), "Táblázat nem megfelelő sora lett kiírva");
            Assert.IsTrue(ui.TestSteps[5].Contains("fg:DarkGray|bg:Gray"), "Táblázat nem megfelelő a szinek beállítása");
            Assert.IsTrue(ui.TestSteps[6].Contains("3"), "Táblázat nem megfelelő sora lett kiírva");
            Assert.IsTrue(ui.TestSteps[6].Contains("fg:DarkGray|bg:Gray"), "Táblázat nem megfelelő a szinek beállítása");
            Assert.IsTrue(ui.TestSteps[7].Contains("6"), "Táblázat nem megfelelő sora lett kiírva");
            Assert.IsTrue(ui.TestSteps[7].Contains("fg:DarkGray|bg:Gray"), "Táblázat nem megfelelő a szinek beállítása");


        }
        //[TestMethod]
        public void AmobaPlayTest()
        {
            var ui = new FakeUI();
            var amoba = new Amoba(ui);

            amoba.Play();

            Assert.IsTrue(ui.TestSteps.Count == 13, "Túl sok vagy kevés az output");
            Assert.IsTrue(ui.TestSteps[0].Contains("Írj be egy számot"), "Nem történt meg a szám kérése");
            Assert.IsTrue(ui.TestSteps[0].Contains("fg:Blue"), "Nem megfelelő a szin beállítása");

            Assert.IsTrue(ui.TestSteps[2].StartsWith("Sound"), "Nem a sound lejátszásával indul");
            Assert.IsTrue(ui.TestSteps[2].Contains("Step"), "Nem a Step zene kerül lejátszásra lépéskor");
            Assert.IsTrue(ui.TestSteps[3].StartsWith("Clear"), "Nem történik képernyő törlés zene lejátszása után");

            Assert.IsTrue(ui.TestSteps[4].Contains("A beírt karakter nem egy szám"), "Nem lett kiírva a hiba jelzése");
            Assert.IsTrue(ui.TestSteps[4].Contains("fg:Blue"), "Nem megfelelő a szin beállítása");

            Assert.IsTrue(ui.TestSteps[5].StartsWith("Sound"), "Nem az error lejátszásával indul");
            Assert.IsTrue(ui.TestSteps[5].Contains("Error"), "Nem az Error sound kerül lejátszásra");
            Assert.IsTrue(ui.TestSteps[6].Contains("A beírt szám:"), "Nem lett kiírva a nem megfelelő szám hiba jelzése");
            Assert.IsTrue(ui.TestSteps[6].Contains("fg:Blue"), "Nem megfelelő a szin beállítása");
            Assert.IsTrue(ui.TestSteps[7].Contains("A beírt szám nem megfelelő"), "Nem lett kiírva a nem megfelelő szám hiba jelzése");
            Assert.IsTrue(ui.TestSteps[7].Contains("fg:Red"), "Nem megfelelő a szin beállítása");

            Assert.IsTrue(ui.TestSteps[8].StartsWith("Sound"), "Nem az error lejátszásával indul");
            Assert.IsTrue(ui.TestSteps[8].Contains("Error"), "Nem az Error sound kerül lejátszásra");
            Assert.IsTrue(ui.TestSteps[9].Contains("A beírt szám:"), "Nem lett kiírva a foglalt helyet jelző hiba");
            Assert.IsTrue(ui.TestSteps[9].Contains("fg:Blue"), "Nem megfelelő a szin beállítása");
            Assert.IsTrue(ui.TestSteps[10].Contains("A beírt szám helye foglalt"), "Nem lett kiírva a nem megfelelő szám hiba jelzése");
            Assert.IsTrue(ui.TestSteps[10].Contains("fg:Red"), "Nem megfelelő a szin beállítása");

            Assert.IsTrue(ui.TestSteps[11].Contains("A beírt szám:"), "Nem lett kiírva a beírt szám jelzése");
            Assert.IsTrue(ui.TestSteps[11].Contains("fg:Blue"), "Nem megfelelő a szin beállítása");

            Assert.IsTrue(ui.TestSteps[12].Contains("A gép által választott szám"), "Nem lett kiírva a gép/random szám jelzése");
            Assert.IsTrue(ui.TestSteps[12].Contains("fg:Blue"), "Nem megfelelő a szin beállítása");
        }
        public void AmobaValidNumberTest() 
        {
        
        }

        [TestMethod]
        public void AmobaEndTest() 
        {
            var ui = new FakeUI();
            var amoba = new Amoba(ui);

            amoba.End();

            Assert.IsTrue(ui.TestSteps.Count == 14, "Túl sok vagy kevés az output");
            Assert.IsTrue(ui.TestSteps[12].Contains("Döntetlen!"), "Nem jó végeredmény lett kiírva");
            Assert.IsTrue(ui.TestSteps[12].Contains("fg:Yellow"), "Nem megfelelő a szinek lettek beállítva");
            Assert.IsTrue(ui.TestSteps[13].StartsWith("Sound"), "Nem a zene lejátszásával végződik");
            Assert.IsTrue(ui.TestSteps[13].Contains("Tie"), "Nem a Tie zene kerül lejátszásra");
        }

        [TestMethod]
        public void AmobaEndJatekosNyerTest()
        {
            var ui = new FakeUI();
            var amoba = new Amoba(ui);
            var privAmoba = new PrivateObject(amoba);
            privAmoba.SetField("tabla", new int[9] { 1, 1, 1, 2, 0, 2, 0, 0, 0 });

            amoba.End();

            Assert.IsTrue(ui.TestSteps.Count == 15, "Túl sok vagy kevés az output");
            Assert.IsTrue(ui.TestSteps[12].Contains("Gratulálunk! Nyertél!"), "Nem jó végeredmény lett kiírva");
            Assert.IsTrue(ui.TestSteps[12].Contains("fg:DarkGreen"), "Nem megfelelő a szinek lettek beállítva");
            Assert.IsTrue(ui.TestSteps[13].Contains("Jatékos nyert"), "Nem jó végeredmény lett kiírva");
            Assert.IsTrue(ui.TestSteps[13].Contains("fg:DarkGreen"), "Nem megfelelő a szinek lettek beállítva");

            Assert.IsTrue(ui.TestSteps[14].StartsWith("Sound"), "Nem a zene lejátszásával végződik");
            Assert.IsTrue(ui.TestSteps[14].Contains("Win"), "Nem a Tie zene kerül lejátszásra");
        }
        [TestMethod]
        public void AmobaEndJatekosVesztettTest()
        {
            var ui = new FakeUI();
            var amoba = new Amoba(ui);
            var privAmoba = new PrivateObject(amoba);
            privAmoba.SetField("tabla", new int[9] { 1, 1, 0, 2, 2, 2, 0, 1, 0 });

            amoba.End();
            
            Assert.IsTrue(ui.TestSteps.Count == 2, "Túl sok vagy kevés az output");
            Assert.IsTrue(ui.TestSteps[0].Contains("Veszítettél!"), "Nem jó végeredmény lett kiírva");
            Assert.IsTrue(ui.TestSteps[0].Contains("fg:Red"), "Nem megfelelő a szinek lettek beállítva");
            Assert.IsTrue(ui.TestSteps[1].StartsWith("Sound"), "Nem a zene lejátszásával végződik");
            Assert.IsTrue(ui.TestSteps[1].Contains("Lose"), "Nem a Lose zene kerül lejátszásra");
        }
        [TestMethod]
        //TODO: Itt egy olyan állapotot kellene tesztelni, ahol még nincs eredmény, mert még lehet a táblára tenni
        public void AmobaEndNemJatekosNemComputerNyerNemDontetenTest()
        {
            var ui = new FakeUI();
            var amoba = new Amoba(ui);
            var privAmoba = new PrivateObject(amoba);
            privAmoba.SetField("tabla", new int[9] { 1, 0, 1, 2, 0, 2, 0, 0, 0 });

            amoba.End();

            Assert.IsTrue(ui.TestSteps.Count == 14, "Túl sok vagy kevés az output");
            Assert.IsTrue(ui.TestSteps[12].Contains("A játék még nem fejeződött be!"), "Nem jó végeredmény lett kiírva");            
        }


        [TestMethod]
        public void AmobaEndResultJatekosNyerTest()
        {
            var ui = new FakeUI();
            var amoba = new Amoba(ui);

            amoba.EndResult(1);
            Assert.IsTrue(ui.TestSteps.Count == 15, "Túl sok vagy kevés az output");
            Assert.IsTrue(ui.TestSteps[12].Contains("Gratulálunk! Nyertél!"), "Nem jó végeredmény lett kiírva");
            Assert.IsTrue(ui.TestSteps[12].Contains("fg:DarkGreen"), "Nem megfelelő a szinek lettek beállítva");
            Assert.IsTrue(ui.TestSteps[13].Contains("Jatékos nyert"), "Nem jó végeredmény lett kiírva");
            Assert.IsTrue(ui.TestSteps[13].Contains("fg:DarkGreen"), "Nem megfelelő a szinek lettek beállítva");
            Assert.IsTrue(ui.TestSteps[14].StartsWith("Sound"), "Nem a zene lejátszásával végződik");
            Assert.IsTrue(ui.TestSteps[14].Contains("Win"), "Nem a Win zene kerül lejátszásra");
        }
        [TestMethod]
        public void AmobaEndResultJatekosVeszitTest()
        {
            var ui = new FakeUI();
            var amoba = new Amoba(ui);

            amoba.EndResult(2);
            Assert.IsTrue(ui.TestSteps.Count == 2, "Túl sok vagy kevés az output");
            Assert.IsTrue(ui.TestSteps[0].Contains("Veszítettél!"), "Nem jó végeredmény lett kiírva");
            Assert.IsTrue(ui.TestSteps[0].Contains("fg:Red"), "Nem megfelelő a szinek lettek beállítva");
            Assert.IsTrue(ui.TestSteps[1].StartsWith("Sound"), "Nem a zene lejátszásával végződik");
            Assert.IsTrue(ui.TestSteps[1].Contains("Lose"), "Nem a Lose zene kerül lejátszásra");
        }
    }
}
