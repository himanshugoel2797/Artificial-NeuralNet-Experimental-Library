using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AForge.Neuro;
using AForge.Neuro.Learning;

namespace ANNProgrammerExperiment
{
    public class NeuralNetwork
    {

        #region Instance implementation
        public double Error;

        Perceptron[][] PerceptronNetwork;

        public NeuralNetwork(int seed, params int[] neuronsCount)
        {
            //The seed allows results to be duplicated
            Random rng = new Random(seed);

            //Build graph of neurons so that all inputs are evaluated before activating the child

            //Initialize basic neural network
            PerceptronNetwork = new Perceptron[neuronsCount.Length][];
            for (int neuronCount = 0; neuronCount < neuronsCount.Length; neuronCount++)
            {
                PerceptronNetwork[neuronCount] = new Perceptron[neuronsCount[neuronCount]];
            }

            //Currently the neurons are not actually connected, so now they need to be wired up
            for (int n = 0; n < neuronsCount.Length - 1; n++) //All the layers  (skips the last layer)
            {
                for (int n0 = 0; n0 < neuronsCount[n]; n0++)    //All the neurons on the current layer
                {
                    PerceptronNetwork[n][n0].Threshold = rng.Next();
                    PerceptronNetwork[n][n0].Children = new Connection[neuronsCount[n + 1]];       //As many connections as neurons on the next layer - basically, connect to each of the next layer neurons

                    for (int n1 = 0; n1 < neuronsCount[n + 1]; n1++)    //Setup connections to all the neurons on the next layer
                    {
                        PerceptronNetwork[n][n0].Children[n1] = new Connection()
                        {
                            Child = PerceptronNetwork[n + 1][n1],
                            InputWeightRatio = 0.5f,
                            Weight = rng.Next()
                        };
                    }
                }
            }

            //Children can be set to null in order to disable the specific connection, the weight can also be set to zero with memory disabled so no inputs sent will be processed by hte linked neuron

            //Setup some sort of output mechanism for final layer
        }

        //Allow the user to access the neural network perceptrons in order to adjust the connections and enable/disable memory wherever it is deemed unnecessary
        public Perceptron[] this[int layer]
        {
            get
            {
                return PerceptronNetwork[layer];
            }
            set
            {
                PerceptronNetwork[layer] = value;
            }
        }
        public Perceptron this[int layer, int index]
        {
            get
            {
                return PerceptronNetwork[layer][index];
            }
            set
            {
                PerceptronNetwork[layer][index] = value;
            }
        }

        //Figure out how to do neural network teaching for something that can have a variable internal structure
        public void Teach() { }

        //Execute the neural network with the supplied inputs
        public void Run(params float[] inputs) { }

        public void Save(string filename)
        {
            //Save the neural network configuration as an xml file storing the connections so that they can be loaded back in later
        }
        #endregion

        #region Static Methods
        public static NeuralNetwork Load(string filename)
        {
            //TODO parse and load saved XML file representiing neural network structure
            return null;
        }
        #endregion
    }
}
