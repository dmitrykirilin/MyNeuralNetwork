using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNeuronNetwork
{
    public class Neuron
    {
        public List<double> Weigths { get; set; }

        public List<double> Inputs { get; set; }

        public NeuronType NeuronType { get; set; }

        public double Output { get; private set; }

        public double Delta { get; set; }

        public Neuron(int InputCount, NeuronType type = NeuronType.Normal)
        {
            NeuronType = type;
            Weigths = new List<double>();
            Inputs = new List<double>();

            InitWeightsRandomValue(InputCount);
        }

        private void InitWeightsRandomValue(int InputCount)
        {
            var rnd = new Random();
            for (int i = 0; i < InputCount; i++)
            {
                if (NeuronType == NeuronType.Input)
                {
                    Weigths.Add(1);
                }
                else
                {
                    Weigths.Add(rnd.NextDouble());
                }
                Inputs.Add(0);
            }
        }

        public double FeedForward(List<double> inputs)
        {
            for (int i = 0; i < inputs.Count; i++)
            {
                Inputs[i] = inputs[i];
            }

            var sum = 0.0;
            for (int i = 0; i < inputs.Count; i++)
            {
                sum += inputs[i] * Weigths[i];
            }
            if (NeuronType != NeuronType.Input)
            {
                Output = Sigmoid(sum);
            }
            else
            {
                Output = sum;
            }

            return Output;
        }

        private double Sigmoid(double x)
        {
            var result = 1.0 / (1.0 + Math.Pow(Math.E, -x));
            return result;
        }

        private double SigmoidDx(double x)
        {
            var sigmoid = Sigmoid(x);
            var result = sigmoid / (1 - sigmoid);
            return result;
        }
        

        // Обучение. Метод вычисления нового веса для каждого входа.
        public void Learn(double error, double learningRate)
        {
            if (NeuronType == NeuronType.Input)
            {
                return;
            }

            Delta = error * SigmoidDx(Output);

            for (int i = 0; i < Weigths.Count; i++)
            {
                var weigth = Weigths[i];
                var input = Inputs[i];

                var newWeigth = weigth - input * Delta * learningRate;
                Weigths[i] = newWeigth;
            }
        }

        public override string ToString()
        {
            return Output.ToString();
        }
    }
}
