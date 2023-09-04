using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class NeuralNetwork : MonoBehaviour
{
    public Network carNetwork;
    public CarSensors carSensors;
    public CarMovement carMovement;

    // Start is called before the first frame update
    void Start()
    {
        carNetwork = new Network(6,6,2);
        Debug.Log("test");
    }

    private void Update()
    {
        DetermineMove(carNetwork.Classify(carSensors.distances));
    }

    public void DetermineMove(int moveOutput)
    {
        switch (moveOutput)
        {
            case 0:
                carMovement.TurnLeft();
                break;

            case 1:
                carMovement.TurnRight();
                break;

            default:
                break;
        }
    }

    public class Network
    {
        Layer[] layers;

        public Network(params int[] numNodes)
        {
            int numLayers = numNodes.Length;
            layers = new Layer[numLayers];
            for (int layerIterator = 0; layerIterator < numLayers - 1; layerIterator++)
            {
                layers[layerIterator] = new Layer(numNodes[layerIterator], numNodes[layerIterator + 1]);
            }
        }

        public double[] CalculateNetworkOutput(double[] inputs)
        {

            for (int i = 0; i < layers.Length - 1; i++)
            {
                inputs = layers[i].CalculateLayerOutputs(inputs);
            }
            return inputs;
        }

        public int Classify(double[] inputs)
        {
            double[] outputs = CalculateNetworkOutput(inputs);
            return GetMaxIndex(outputs);
        }

        static int GetMaxIndex(double[] array)
        {
            int maxIndex = 0;
            double maxValue = array[0];

            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] > maxValue)
                {
                    maxValue = array[i];
                    maxIndex = i;
                }
            }

            return maxIndex;
        }

    }
 
    class Layer
    {
        public int numInputNodes;
        public int numOutputNodes;

        double[,] weights;
        double[] biases;

        // Creates The Layer
        public Layer(int NumInputNodes, int NumOutputNodes)
        {
            this.numInputNodes = NumInputNodes;
            this.numOutputNodes = NumOutputNodes;

            weights = new double[NumInputNodes, NumOutputNodes];
            biases = new double[NumOutputNodes];

            for (int i = 0; i < NumOutputNodes; i++)
            {
                biases[i] = UnityEngine.Random.Range(0f, 1f); // Generates a random float between 0 and 10.
                for (int j = 0; j < NumInputNodes; j++)
                {
                    weights[j, i] = UnityEngine.Random.Range(0f, 1f); // Generates a random float between 0 and 1.
                }
            }
        }


        public double[] CalculateLayerOutputs(double[] inputs)
        {
            double[] finalOutputs = new double[numOutputNodes];
            double weightedInput;
            for (int nodesOut = 0; nodesOut < numOutputNodes; nodesOut++)
            {
                weightedInput = biases[nodesOut];
                for (int nodesIn = 0; nodesIn < numInputNodes; nodesIn++)
                {
                    weightedInput += inputs[nodesIn] * weights[nodesIn, nodesOut];
                }
                finalOutputs[nodesOut] = weightedInput;
            }

            return finalOutputs;
        }


    }
}
