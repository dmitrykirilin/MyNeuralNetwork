using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNeuronNetwork
{
    public class Layer
    {
        public List<Neuron> Neurons { get; }
        public int NeuronCount => Neurons?.Count ?? 0;
        public NeuronType Type;

        public Layer(List<Neuron> neurons, NeuronType type = NeuronType.Normal)
        {
            // TODO: Проверить все входные нейроны на соответствие типу
            Type = type;
            Neurons = neurons;
        }

        public List<double> GetSignals()
        {
            var result = new List<double>();
            foreach (var item in Neurons)
            {
                result.Add(item.Output);
            }
            return result;

        }

        public override string ToString()
        {
            return Type.ToString();
        }
    }
}
