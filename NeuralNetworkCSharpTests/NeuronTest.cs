/*
 * Author: Nikola Živković
 * Website: rubikscode.net
 * Year: 2018
 */

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NeuralNetworkCSharp.ActivationFunctions;
using NeuralNetworkCSharp.InputFunctions;
using NeuralNetworkCSharp.Neuron;
using NeuralNetworkCSharp.Synapses;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NeuralNetworkCSharpTests
{
    [TestClass]
    public class NeuronTest
    {
        [TestMethod]
        public void Constructor_ActivationFunctionInputFunction_NeuronInitialized()
        {
            var activationFunction = new Mock<IActivationFunction>();
            var inputFunction = new Mock<IInputFunction>();

            var neuron = new Neuron(activationFunction.Object, inputFunction.Object);

            Assert.IsNotNull(neuron);
            Assert.AreNotEqual(Guid.Empty, neuron.Id);
            Assert.IsNotNull(neuron.Inputs);
            Assert.IsNotNull(neuron.Outputs);
        }

        [TestMethod]
        public void AddInput_NeuronPassed_ConnectionCreated()
        {
            var activationFunction = new Mock<IActivationFunction>();
            var inputFunction = new Mock<IInputFunction>();

            var neuron = new Neuron(activationFunction.Object, inputFunction.Object);

            var inputNeuron = new Neuron(activationFunction.Object, inputFunction.Object);

            neuron.AddInputNeuron(inputNeuron);

            Assert.AreEqual(1, neuron.Inputs.Count);
        }

        [TestMethod]
        public void AddOutput_NeuronPassed_ConnectionCreated()
        {
            var activationFunction = new Mock<IActivationFunction>();
            var inputFunction = new Mock<IInputFunction>();

            var neuron = new Neuron(activationFunction.Object, inputFunction.Object);

            var outputNeuron = new Neuron(activationFunction.Object, inputFunction.Object);

            neuron.AddOutputNeuron(outputNeuron);

            Assert.AreEqual(1, neuron.Outputs.Count);
        }

        [TestMethod]
        public void AddInputSynapse_SynapsePassed_ConnectionCreated()
        {
            var activationFunction = new Mock<IActivationFunction>();
            var inputFunction = new Mock<IInputFunction>();

            var neuron = new Neuron(activationFunction.Object, inputFunction.Object);
            neuron.AddInputSynapse(0.11);

            Assert.AreEqual(1, neuron.Inputs.Count);
            Assert.AreEqual(1, neuron.Inputs.First().Weight);
            Assert.AreEqual(0.11, neuron.Inputs.First().GetOutput());
        }

        [TestMethod]
        public void CalculateOutput_MockingFunctions_OutputReturned()
        {
            var activationFunction = new Mock<IActivationFunction>();
            activationFunction.Setup(x => x.CalculateOutput(It.IsAny<double>())).Returns(111);

            var inputFunction = new Mock<IInputFunction>();
            inputFunction.Setup(x => x.CalculateInput(It.IsAny<List<ISynapse>>())).Returns(23);

            var neuron = new Neuron(activationFunction.Object, inputFunction.Object);

            Assert.AreEqual(111, neuron.CalculateOutput());
        }

        [TestMethod]
        public void AddInputSynapse_SynapseAdded_NumberOdSynapsesIncreased()
        {
            var activationFunction = new Mock<IActivationFunction>();
            activationFunction.Setup(x => x.CalculateOutput(It.IsAny<double>())).Returns(111);

            var inputFunction = new Mock<IInputFunction>();
            inputFunction.Setup(x => x.CalculateInput(It.IsAny<List<ISynapse>>())).Returns(23);

            var neuron = new Neuron(activationFunction.Object, inputFunction.Object);

            neuron.AddInputSynapse(0);

            Assert.AreEqual(1, neuron.Inputs.Count);
        }

        [TestMethod]
        public void PushInputValueToInput_SendingValueToInput_ProperValueOnInputSet()
        {
            var activationFunction = new Mock<IActivationFunction>();
            activationFunction.Setup(x => x.CalculateOutput(It.IsAny<double>())).Returns(111);

            var inputFunction = new Mock<IInputFunction>();
            inputFunction.Setup(x => x.CalculateInput(It.IsAny<List<ISynapse>>())).Returns(23);

            var neuron = new Neuron(activationFunction.Object, inputFunction.Object);
            neuron.AddInputSynapse(0);

            neuron.PushValueOnInput(1);
            Assert.AreEqual(1, neuron.Inputs.First().GetOutput());
        }
    }
}
