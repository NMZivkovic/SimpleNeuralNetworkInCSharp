/*
 * Author: Nikola Živković
 * Website: rubikscode.net
 * Year: 2018
 */

using System;

namespace NeuralNetworkCSharp.Synapses
{
    /// <summary>
    /// Interface for synapses (connections).
    /// </summary>
    public interface ISynapse
    {
        double Weight { get; set; }
        double PreviousWeight { get; set; }
        double GetOutput();

        bool IsFromNeuron(Guid fromNeuronId);
        void UpdateWeight(double learningRate, double delta);
    }
}
