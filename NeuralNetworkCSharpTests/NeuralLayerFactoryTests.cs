/*
 * Author: Nikola Živković
 * Website: rubikscode.net
 * Year: 2018
 */

using Microsoft.VisualStudio.TestTools.UnitTesting;
using NeuralNetworkCSharp;
using NeuralNetworkCSharp.ActivationFunctions;
using NeuralNetworkCSharp.InputFunctions;

namespace NeuralNetworkCSharpTests
{
    [TestClass]
    public class NeuralLayerFactoryTests
    {
        [TestMethod]
        public void CreateNeuralLayer_NumberOfNeuronsPasses_CorrectLayerCreated()
        {
            var neuralLayerFactory = new NeuralLayerFactory();
            var neuralLayer = neuralLayerFactory.CreateNeuralLayer(11, new StepActivationFunction(0.5), new WeightedSumFunction());

            Assert.AreEqual(11, neuralLayer.Neurons.Count);
        }
    }
}
