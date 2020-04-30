using NUnit.Framework;
using WpfGuiApp.Services;

namespace TestsLibrary.FServicesTests
{
    [TestFixture]
    public class CalculatorTests
    {
        private IMyCalculator _myCalculator;

        [OneTimeSetUp]
        public void Init()
        {
            _myCalculator = new MyCalculator();
        }

        [TestCase(1, 2, 3)]
        [TestCase(32, -1, 31)]
        [TestCase(-72, +30, -42)]
        public void CalculatorCorrectAddition(int a, int b, int expectedResult)
        {
            var actualResult = _myCalculator.Add(a, b);

            Assert.AreEqual(actualResult, expectedResult);
        }

        [TestCase(1, 2, -1)]
        [TestCase(32, -1, 33)]
        [TestCase(-72, +30, -102)]
        public void CalculatorCorrectSubtract(int a, int b, int expectedResult)
        {
            var actualResult = _myCalculator.Sub(a, b);

            Assert.AreEqual(actualResult, expectedResult);
        }
    }
}
