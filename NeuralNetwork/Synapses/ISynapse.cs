namespace NeuralNetwork.Synapses
{
    public interface ISynapse
    {
        double Weight { get; set; }
        double PreviousWeight { get; set; }
        void UpdateWeight(double learningRate, double delta);
    }
}