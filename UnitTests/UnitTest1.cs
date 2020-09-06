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
        public void Setup(){ }

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

        //Runway Selector tests

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
            runway_d_list.Add(330);
            runway_d_list.Add(45);
            runway_d_list.Add(170);
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


        //Optimal Runway Direction Tests
        [Test]
        public void SelectOptimalRunwayDirection_MustBeExpectedValue_A(){
            List<int> runway_d_list = new List<int>();
            runway_d_list.Add(360);
            runway_d_list.Add(185);
            runway_d_list.Add(135);
            var result = runwayselector_module.SelectOptimalRunwayDirection( runway_d_list, 315);
            int expected_value = 135;
            Assert.IsTrue(result == expected_value, $"SelectOptimalRunwayDirection returned angle {result}, Expected value was {expected_value}");
        }

        [Test]
        public void SelectOptimalRunwayDirection_MustBeExpectedValue_B(){
            List<int> runway_d_list = new List<int>();
            runway_d_list.Add(45);
            runway_d_list.Add(90);
            runway_d_list.Add(85);
            var result = runwayselector_module.SelectOptimalRunwayDirection( runway_d_list, 45);
            int expected_value = 225;
            Assert.IsTrue(result == expected_value, $"RunwaySelector returned index value {result}, Expected value was {expected_value}");
        }

        [Test]
        public void SelectOptimalRunwayDirection_MustBeExpectedValue_C(){
            List<int> runway_d_list = new List<int>();
            runway_d_list.Add( 100 );
            runway_d_list.Add( 200 );
            runway_d_list.Add( 300 );
            var result = runwayselector_module.SelectOptimalRunwayDirection( runway_d_list, 285);
            int expected_value = 100;
            Assert.IsTrue(result == expected_value, $"RunwaySelector returned index value {result}, Expected value was {expected_value}");
        }
    }
}