/*
 * Author: Nikola Živković
 * Website: rubikscode.net
 * Year: 2018
 */

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NeuralNetworkCSharp.Synapses;
using NeuralNetworkCSharp.Neuron;

namespace NeuralNetworkCSharpTests
{
    [TestClass]
    public class SynapseTest
    {
        [TestMethod]
        public void Constructor_WeightInitialization_RandomWeightCreated()
        {
            var fromNeruonMock = new Mock<INeuron>();
            var toNeruonMock = new Mock<INeuron>();
            var connection = new Synapse(fromNeruonMock.Object, toNeruonMock.Object);

            Assert.AreNotEqual(0, connection.Weight);
        }

        [TestMethod]
        public void Constructor_WeightPassed_WeightCreated()
        {
            var fromNeruonMock = new Mock<INeuron>();
            var toNeruonMock = new Mock<INeuron>();
            var connection = new Synapse(fromNeruonMock.Object, toNeruonMock.Object, 111);

            Assert.AreEqual(111, connection.Weight);
        }

        [TestMethod]
        public void GetOutput_ProperlyInitialized_SameAsFromNeuronOutput()
        {
            var fromNeruonMock = new Mock<INeuron>();
            fromNeruonMock.Setup(x => x.CalculateOutput()).Returns(23);

            var toNeruonMock = new Mock<INeuron>();

            var connection = new Synapse(fromNeruonMock.Object, toNeruonMock.Object, 111);

            Assert.AreEqual(23, connection.GetOutput());
        }
    }
}
