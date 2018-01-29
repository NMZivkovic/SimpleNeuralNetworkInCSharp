/*
 * Author: Nikola Živković
 * Website: rubikscode.net
 * Year: 2018
 */

using Microsoft.VisualStudio.TestTools.UnitTesting;
using NeuralNetworkCSharp;
using NeuralNetworkCSharp.ActivationFunctions;
using NeuralNetworkCSharp.InputFunctions;
using System.Linq;

namespace NeuralNetworkCSharpTests
{
    [TestClass]
    public class SimpleNeuralNetworkTest
    {
        [TestMethod]
        public void Initialization_Constructor_NeuralNetworkInitialized()
        {
            var network = new SimpleNeuralNetwork(3);
            Assert.AreEqual(1, network._layers.Count);
            Assert.AreEqual(3, network._layers.First().Neurons.Count);

            Assert.AreEqual(2.95, network._learningRate);
        }

        [TestMethod]
        public void AddLayer_NeuralAddingNewLayer_LayerAdded()
        {
            var network = new SimpleNeuralNetwork(3);
            var layerFactory = new NeuralLayerFactory();
            network.AddLayer(layerFactory.CreateNeuralLayer(3, new RectifiedActivationFuncion(), new WeightedSumFunction()));

            Assert.AreEqual(2, network._layers.Count);
        }

        [TestMethod]
        public void PushInputValues_ValuesSentToNetwork_ValuesSetOnInput()
        {
            var network = new SimpleNeuralNetwork(3);
            network.PushInputValues(new double[] {3, 5, 7});

            Assert.AreEqual(3, network._layers.First().Neurons.First().Inputs.First().GetOutput());
        }

        [TestMethod]
        public void PushExpectedResults_ValuesSentToNetwork_ValuesStored()
        {
            var network = new SimpleNeuralNetwork(3);
            network.PushExpectedValues(new double[][] { new double[] { 3, 5, 7 } });

            Assert.AreEqual(3, network._expectedResult[0][0]);
            Assert.AreEqual(5, network._expectedResult[0][1]);
            Assert.AreEqual(7, network._expectedResult[0][2]);
        }

        [TestMethod]
        public void Train_RuningTraining_NetworkIsTrained()
        {
            var network = new SimpleNeuralNetwork(3);

            var layerFactory = new NeuralLayerFactory();
            network.AddLayer(layerFactory.CreateNeuralLayer(3, new RectifiedActivationFuncion(), new WeightedSumFunction()));
            network.AddLayer(layerFactory.CreateNeuralLayer(1, new SigmoidActivationFunction(0.7), new WeightedSumFunction()));

            network.PushExpectedValues(
                new double[][] {
                    new double[] { 0 },
                    new double[] { 1 },
                    new double[] { 1 },
                    new double[] { 0 },
                    new double[] { 1 },
                    new double[] { 0 },
                    new double[] { 0 },
                });

            network.Train(
                new double[][] {
                    new double[] { 150, 2, 0 },
                    new double[] { 1002, 56, 1 },
                    new double[] { 1060, 59, 1 },
                    new double[] { 200, 3, 0 },
                    new double[] { 300, 3, 1 },
                    new double[] { 120, 1, 0 },
                    new double[] { 80, 1, 0 },
                }, 10000);

            network.PushInputValues(new double[] { 1054, 54, 1 });
            var outputs = network.GetOutput();
        }
    }
}
