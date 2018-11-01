using System.Collections.Generic;
using NeuralNetwork.Synapses;

namespace NeuralNetwork.Input
{
    public class CalculateWeightedSum: IInput
    {
        private List<ISynapse> _inputs;

        public void CalculateInput(List<ISynapse> inputs)
        {
            _inputs = inputs;
        }
    }

}