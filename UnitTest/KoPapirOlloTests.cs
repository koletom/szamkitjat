using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using szamkitjat;

namespace UnitTest
{
    [TestClass]
    public class KoPapirOlloTests
    {
        [TestMethod]
        [ExpectedException(typeof(NullReferenceException), "Constructor null paraméter exception test ok.")]
        public void KoPapirOlloContructorNullReferenceTest()
        {
            _ = new KoPapirOllo(null);
        }
        [TestMethod]
        public void KitalalosCreateTest()
        {
            var kopapirollo = new KoPapirOllo(new FakeUI());
            Assert.IsNotNull(kopapirollo);
        }
    }
}
