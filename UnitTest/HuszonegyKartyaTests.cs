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

            Assert.IsTrue(ui.TestSteps.Count == 30, "Túl sok vagy kevés az output");
        }
        public void HuszonegyKartyaDeckTest()
        {

        }
        public void HuszonegyKartyaBetTest()
        {

        }
        public void HuszonegyKartyaChoiceTest()
        {

        }
        public void HuszonegyKartyaPlayTest()
        {

        }
        public void HuszonegyKartyaResultTest()
        {

        }
    }
}
