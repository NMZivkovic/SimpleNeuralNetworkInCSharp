/*
 * Author: Nikola Živković
 * Website: rubikscode.net
 * Year: 2018
 */

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NeuralNetworkCSharp.Neuron;
using NeuralNetworkCSharp.Synapses;

namespace NeuralNetworkCSharpTests
{
    [TestClass]
    public class InputSynapseTest
    {
        [TestMethod]
        public void Constructor_WeightInitialization_RandomWeightCreated()
        {
            var toNeruonMock = new Mock<INeuron>();
            var connection = new InputSynapse(toNeruonMock.Object);

            Assert.AreEqual(1, connection.Weight);
        }

        [TestMethod]
        public void GetOutput_ProperlyInitialized_SameAsFromNeuronOutput()
        {
            var toNeruonMock = new Mock<INeuron>();

            var connection = new InputSynapse(toNeruonMock.Object, 1);

            Assert.AreEqual(1, connection.GetOutput());
        }
    }
}
