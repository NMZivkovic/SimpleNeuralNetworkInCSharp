using System;
using System.Collections.Generic;
using NeuralNetwork.Input;
using NeuralNetwork.Synapses;

namespace NeuralNetwork.Program
{
    public class Program
    {
        static void Main(string[] args)
        {
            var synapseInputList = new List<ISynapse>
            {
                new Synapse { Weight = 1, PreviousWeight = 0 },
                new Synapse { Weight = 2, PreviousWeight = 1 },
                new Synapse { Weight = 3, PreviousWeight = 2 }
            };

            var calculateWeightedSum = new CalculateWeightedSum();
            calculateWeightedSum.CalculateInput(synapseInputList);
        }

    }
}
