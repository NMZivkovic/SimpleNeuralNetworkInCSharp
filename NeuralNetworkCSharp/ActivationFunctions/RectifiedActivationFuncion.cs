/*
 * Author: Nikola Živković
 * Website: rubikscode.net
 * Year: 2018
 */

using System;

namespace NeuralNetworkCSharp.ActivationFunctions
{
    /// <summary>
    /// Implementation of Rectifier Activation Function.
    /// </summary>
    public class RectifiedActivationFuncion : IActivationFunction
    {
        public double CalculateOutput(double input)
        {
            return Math.Max(0, input);
        }
    }
}
