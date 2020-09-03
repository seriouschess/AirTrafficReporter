using NUnit.Framework;
using MainApp.Helpers;
using MainApp.BusinessLogic;
using System.Collections.Generic;

namespace UnitTests
{
    public class Tests
    {
        private TestClass twelve_module = new TestClass();
        private RunwaySelector runwayselector_module = new RunwaySelector();

        [SetUp]
        public void Setup()
        {
            //TestClass twelve_module = new TestClass();
        }

        [Test]
        public void ReturnsTwelve_MustBeTwelve()
        {
            int result = twelve_module.ReturnsTwelve();
            Assert.IsTrue(result == 12, "Method did not return 12");
        }

        [TestCase(12)]
        public void ReturnsTwelve_MustBeTwelvePara(int value)
        {
            var result = twelve_module.ReturnsTwelve();
            Assert.IsTrue(result == value, $"Method did not return 12");
        }

        [Test]
        public void SelectRunway_MustBeExpectedValue_A(){
            List<int> runway_d_list = new List<int>();
            runway_d_list.Add(37);
            runway_d_list.Add(0);
            runway_d_list.Add(340);
            var result = runwayselector_module.SelectRunway( runway_d_list, 180);
            Assert.IsTrue(result == 1, $"RunwaySelector returned index value {result}");
        }

        [Test]
        public void SelectRunway_MustBeExpectedValue_B(){
            List<int> runway_d_list = new List<int>();
            runway_d_list.Add(10);
            runway_d_list.Add(330);
            runway_d_list.Add(130);
            var result = runwayselector_module.SelectRunway( runway_d_list, 0);
            Assert.IsTrue(result == 2, $"RunwaySelector returned index value {result}");
        }

        [Test]
        public void SelectRunway_MustBeExpectedValue_C(){
            List<int> runway_d_list = new List<int>();
            runway_d_list.Add(37);
            runway_d_list.Add(375);
            runway_d_list.Add(195);
            var result = runwayselector_module.SelectRunway( runway_d_list, 285);
            Assert.IsTrue(result == 0, $"RunwaySelector returned index value {result}");
        }
    }
}