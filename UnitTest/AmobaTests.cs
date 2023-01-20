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
    }
}
