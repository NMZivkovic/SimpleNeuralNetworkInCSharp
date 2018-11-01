using System.Collections.Generic;
using NeuralNetwork.Synapses;

namespace NeuralNetwork.Input
{

    public interface IInput
    {
        void CalculateInput(List<ISynapse> inputs);
    }
}