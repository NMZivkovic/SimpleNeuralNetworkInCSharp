/*
 * Author: Nikola Živković
 * Website: rubikscode.net
 * Year: 2018
 */

using Microsoft.VisualStudio.TestTools.UnitTesting;
using NeuralNetworkCSharp.ActivationFunctions;

namespace NeuralNetworkCSharpTests
{
    [TestClass]
    public class MyTestClass
    {
        [TestMethod]
        public void CalculateOutput_InputSmallerThanTreshold_ZeroReturned()
        {
            var stepFunction = new StepActivationFunction(111);

            Assert.AreEqual(0, stepFunction.CalculateOutput(110));
        }

        [TestMethod]
        public void CalculateOutput_InputLargerThanTreshold_OneReturned()
        {
            var stepFunction = new StepActivationFunction(111);

            Assert.AreEqual(1, stepFunction.CalculateOutput(112));
        }
    }
}
