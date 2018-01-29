/*
 * Author: Nikola Živković
 * Website: rubikscode.net
 * Year: 2018
 */

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NeuralNetworkCSharp.InputFunctions;
using NeuralNetworkCSharp.Synapses;
using System.Collections.Generic;

namespace NeuralNetworkCSharpTests
{
    [TestClass]
    public class WeightedSumFunctionTest
    {
        [TestMethod]
        public void CalculateInput_ListOfInputsPassed_WeightedOutputCalculated()
        {
            var input1 = new Mock<ISynapse>();
            input1.Setup(x => x.Weight).Returns(2);
            input1.Setup(x => x.GetOutput()).Returns(333);

            var input2 = new Mock<ISynapse>();
            input2.Setup(x => x.Weight).Returns(3);
            input2.Setup(x => x.GetOutput()).Returns(222);

            var listOfInputs = new List<ISynapse>();
            listOfInputs.Add(input1.Object);
            listOfInputs.Add(input2.Object);

            var weightedSum = new WeightedSumFunction();

            Assert.AreEqual(1332, weightedSum.CalculateInput(listOfInputs));
        }
    }
}
