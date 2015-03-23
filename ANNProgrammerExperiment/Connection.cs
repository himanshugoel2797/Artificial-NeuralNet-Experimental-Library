using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ANNProgrammerExperiment
{
    public class Connection
    {
        public Perceptron Child;
        public float Weight;
        public float AvgInput;
        public float InputWeightRatio;      //0 = no input, 1 = all input
    }
}
