using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ANNProgrammerExperiment
{
    //Connection class stores weights?

    public class Perceptron
    {
        public float Threshold;
        public Connection[] Children;


        public Perceptron() { }

        internal void Train() { }
        
        internal void Process( /*Inputs*/ ) { }

        internal void SpecifyInput(float input)
        {
            //Specify weighted input
        }

    }
}
