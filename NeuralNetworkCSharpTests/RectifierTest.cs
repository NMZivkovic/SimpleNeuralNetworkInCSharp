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
    public class RectifierTest
    {
        [TestMethod]
        public void CalculateOutput_InputLargerThanZeroPassed_CorrectOutput()
        {
            var rectifier = new RectifiedActivationFuncion();

            Assert.AreEqual(0.23, rectifier.CalculateOutput(0.23));
        }

        [TestMethod]
        public void CalculateOutput_InputSmallerThanZeroPassed_CorrectOutput()
        {
            var rectifier = new RectifiedActivationFuncion();

            Assert.AreEqual(0, rectifier.CalculateOutput(-0.23));
        }
    }
}
