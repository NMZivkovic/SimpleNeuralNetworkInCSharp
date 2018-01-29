/*
 * Author: Nikola Živković
 * Website: rubikscode.net
 * Year: 2018
 */

namespace NeuralNetworkCSharp.ActivationFunctions
{
    /// <summary>
    /// Interface for activation functions.
    /// </summary>
    public interface IActivationFunction
    {
        double CalculateOutput(double input);
    }
}
