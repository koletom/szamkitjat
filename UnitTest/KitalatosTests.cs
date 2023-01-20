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
    }
}
