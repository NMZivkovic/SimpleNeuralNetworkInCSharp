/*
 * Author: Nikola Živković
 * Website: rubikscode.net
 * Year: 2018
 */

using NeuralNetworkCSharp.ActivationFunctions;
using NeuralNetworkCSharp.InputFunctions;
using NeuralNetworkCSharp.Synapses;
using System;
using System.Linq;
using System.Collections.Generic;

namespace NeuralNetworkCSharp.Neuron
{
    /// <summary>
    /// Neuron implementation.
    /// </summary>
    public class Neuron : INeuron
    {
        private IActivationFunction _activationFunction;
        private IInputFunction _inputFunction;

        /// <summary>
        /// Input connections of the neuron.
        /// </summary>
        public List<ISynapse> Inputs { get; set; }

        /// <summary>
        /// Output connections of the neuron.
        /// </summary>
        public List<ISynapse> Outputs { get; set; }

        public Guid Id { get; private set; }

        /// <summary>
        /// Calculated partial derivate in previous iteration of training process.
        /// </summary>
        public double PreviousPartialDerivate { get; set; }

        public Neuron(IActivationFunction activationFunction, IInputFunction inputFunction)
        {
            Id = Guid.NewGuid();
            Inputs = new List<ISynapse>();
            Outputs = new List<ISynapse>();

            _activationFunction = activationFunction;
            _inputFunction = inputFunction;
        }

        /// <summary>
        /// Connect two neurons. 
        /// This neuron is the output neuron of the connection.
        /// </summary>
        /// <param name="inputNeuron">Neuron that will be input neuron of the newly created connection.</param>
        public void AddInputNeuron(INeuron inputNeuron)
        {
            var synapse = new Synapse(inputNeuron, this);
            Inputs.Add(synapse);
            inputNeuron.Outputs.Add(synapse);
        }

        /// <summary>
        /// Connect two neurons. 
        /// This neuron is the input neuron of the connection.
        /// </summary>
        /// <param name="outputNeuron">Neuron that will be output neuron of the newly created connection.</param>
        public void AddOutputNeuron(INeuron outputNeuron)
        {
            var synapse = new Synapse(this, outputNeuron);
            Outputs.Add(synapse);
            outputNeuron.Inputs.Add(synapse);
        }

        /// <summary>
        /// Calculate output value of the neuron.
        /// </summary>
        /// <returns>
        /// Output of the neuron.
        /// </returns>
        public double CalculateOutput()
        {
            return _activationFunction.CalculateOutput(_inputFunction.CalculateInput(this.Inputs));
        }

        /// <summary>
        /// Input Layer neurons just receive input values.
        /// For this they need to have connections.
        /// This function adds this kind of connection to the neuron.
        /// </summary>
        /// <param name="inputValue">
        /// Initial value that will be "pushed" as an input to connection.
        /// </param>
        public void AddInputSynapse(double inputValue)
        {
            var inputSynapse = new InputSynapse(this, inputValue);
            Inputs.Add(inputSynapse);
        }

        /// <summary>
        /// Sets new value on the input connections.
        /// </summary>
        /// <param name="inputValue">
        /// New value that will be "pushed" as an input to connection.
        /// </param>
        public void PushValueOnInput(double inputValue)
        {
            ((InputSynapse)Inputs.First()).Output = inputValue;
        }
    }
}
