using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNeuronNetwork
{
    class Program
    {
        static void Main(string[] args)
        {
            var outputs = new double[] { 0, 0, 1, 0, 0, 0, 1, 0, 1, 1, 1, 1, 1, 0, 1, 1 };

            // Результат - Пациент болен - 1
            //             Пациент Здоров - 0

            // Неправильная температура T
            // Хороший возраст A
            // Курит S
            // Правильно питается F
            //T  A  S  F
            var inputs = new double[][]
            { new double[] { 0, 0, 0, 0 },
            new double[] { 0, 0, 0, 1 },
            new double[] { 0, 0, 1, 0 },
            new double[] { 0, 0, 1, 1 },
            new double[] { 0, 1, 0, 0 },
            new double[] { 0, 1, 0, 1 },
            new double[] { 0, 1, 1, 0 },
            new double[] { 0, 1, 1, 1 },
            new double[] { 1, 0, 0, 0 },
            new double[] { 1, 0, 0, 1 },
            new double[] { 1, 0, 1, 0 },
            new double[] { 1, 0, 1, 1 },
            new double[] { 1, 1, 0, 0 },
            new double[] { 1, 1, 0, 1 },
            new double[] { 1, 1, 1, 0 },
            new double[] { 1, 1, 1, 1 }
            };
               
            var topology = new Topology(4, 1, 0.1, 2);
            var neuralNetwork = new NeuralNetworks(topology);

            //Act
            var difference = neuralNetwork.Learn(outputs, inputs, 40000);

            var results = new List<double>();
            for (int i = 0; i < inputs.Length; i++)
            {
                var r = neuralNetwork.FeedForward(inputs[i]).Output;
                results.Add(r);
            }

            //assert

            for (int i = 0; i < results.Count; i++)
            {
                var expected = Math.Round(outputs[i], 3);
                var actual = Math.Round(results[i], 4);
                Console.WriteLine(expected + " - " + actual);
            }

            Console.ReadLine();
        }
    }
}
