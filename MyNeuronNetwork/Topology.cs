﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNeuronNetwork
{
    public class Topology
    {
        public int InputCount { get; }
        public int OutputCount { get; }
        public double LearningRate { get; set; }
        public List<int> HiddenLayersCount { get; }

        public Topology(int inputCount, int outputCount, double learningRate, params int[] layers)
        {
            InputCount = inputCount;
            OutputCount = outputCount;
            LearningRate = learningRate;
            HiddenLayersCount = new List<int>();
            HiddenLayersCount.AddRange(layers);
        }
    }
}
