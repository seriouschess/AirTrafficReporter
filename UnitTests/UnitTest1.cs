using NUnit.Framework;
using MainApp.Helpers;

namespace UnitTests
{
    public class Tests
    {
        private TestClass module = new TestClass();
        [SetUp]
        public void Setup()
        {
            //TestClass module = new TestClass();
        }

        [Test]
        public void ReturnsTwelve_MustBeTwelve()
        {
            int result = module.ReturnsTwelve();
            Assert.IsTrue(result == 12, "Method did not return 12");
        }

        [TestCase(12)]
        [TestCase(11)]
        public void ReturnsTwelve_MustBeTwelvePara(int value)
        {
            var result = module.ReturnsTwelve();

            Assert.IsFalse(result == value, $"Method did not return 12");
        }
    }
}