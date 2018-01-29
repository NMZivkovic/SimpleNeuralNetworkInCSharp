/*
 * Author: Nikola Živković
 * Website: rubikscode.net
 * Year: 2018
 */

using NeuralNetworkCSharp.Synapses;
using System.Collections.Generic;

namespace NeuralNetworkCSharp.InputFunctions
{
    /// <summary>
    /// Interface for Input Functions.
    /// </summary>
    public interface IInputFunction
    {
        double CalculateInput(List<ISynapse> inputs);
    }
}
