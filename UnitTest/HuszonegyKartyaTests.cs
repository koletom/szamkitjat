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
        public void HuszonegyKartyaContructorNullReferenceTest()
        {
            _ = new HuszonegyKartya(null);
        }
        [TestMethod]
        public void HuszonegyKartyaCreateTest()
        {
            var huszonegykartya = new HuszonegyKartya(new FakeUI());
            Assert.IsNotNull(huszonegykartya);
        }
    }
}
