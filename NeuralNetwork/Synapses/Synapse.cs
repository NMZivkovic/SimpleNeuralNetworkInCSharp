namespace NeuralNetwork.Synapses
{
    public class Synapse: ISynapse
    {
        public double Weight { get; set; }
        public double PreviousWeight { get; set; }

        public void UpdateWeight(double learningRate, double delta)
        {
            throw new System.NotImplementedException();
        }
    }
}