using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeuralNetwork : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    class NetworkInput
    {

    }

    class Layer
    {
        int NumInputNodes;
        int NumOutputNodes;

        double[,] Weights;
        double[] Biases;

        // Creates The Layer
        public Layer(int NumInputNodes, int NumOutputNodes)
        {
            this.NumInputNodes = NumInputNodes;
            this.NumOutputNodes = NumOutputNodes;

            Weights = new double[NumInputNodes, NumOutputNodes];
            Biases = new double[NumOutputNodes];
        }


        
    }
}
