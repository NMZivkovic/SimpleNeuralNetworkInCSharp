/*
 * Author: Nikola Živković
 * Website: rubikscode.net
 * Year: 2018
 */

using NeuralNetworkCSharp.Neuron;
using System.Collections.Generic;
using System.Linq;

namespace NeuralNetworkCSharp
{
    /// <summary>
    /// Implementation of the single layer in Artificial Neural Network.
    /// </summary>
    public class NeuralLayer
    {
        public List<INeuron> Neurons;

        public NeuralLayer()
        {
            Neurons = new List<INeuron>();
        }

        /// <summary>
        /// Connecting two layers.
        /// </summary>
        public void ConnectLayers(NeuralLayer inputLayer)
        {
            var combos = Neurons.SelectMany(neuron => inputLayer.Neurons, (neuron, input) => new { neuron, input });
            combos.ToList().ForEach(x => x.neuron.AddInputNeuron(x.input));
        }
    }
}
