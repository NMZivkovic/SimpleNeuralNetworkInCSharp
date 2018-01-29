/*
 * Author: Nikola Živković
 * Website: rubikscode.net
 * Year: 2018
 */

using System;

namespace NeuralNetworkCSharp.ActivationFunctions
{
    /// <summary>
    /// Implementation of Step Activation Function.
    /// </summary>
    public class StepActivationFunction : IActivationFunction
    {
        private double _treshold;

        public StepActivationFunction(double treshold)
        {
            _treshold = treshold;
        }

        public double CalculateOutput(double input)
        {
            return Convert.ToDouble(input > _treshold);
        }
    }
}
