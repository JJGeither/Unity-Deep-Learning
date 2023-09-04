using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSensors : MonoBehaviour
{
    public RaycastData[] rays; // Array of raycast data
    public double[] distances;   // Array to store distances from hit objects

    [System.Serializable]
    public class RaycastData
    {
        public float angle;         // Angle of the ray in degrees
        public float rayLength;     // Length of the ray
        public LayerMask collisionMask; // Layer mask to filter collisions
    }

    private void Start()
    {
        distances = new double[rays.Length]; // Initialize the distances array
    }

    private void Update()
    {
        for (int i = 0; i < rays.Length; i++)
        {
            RaycastData rayData = rays[i];

            // Calculate the direction of the ray based on the angle
            Vector3 rayDirection = Quaternion.Euler(0, rayData.angle, 0) * transform.forward;

            // Perform the raycast
            RaycastHit hit;
            if (Physics.Raycast(transform.position, rayDirection, out hit, rayData.rayLength, rayData.collisionMask))
            {
                // Store the hit distance in the distances array
                distances[i] = hit.distance;

                // Do something with the hit information
                Debug.DrawLine(transform.position, hit.point, Color.red);
            }
            else
            {
                // No collision, store distance as ray length
                distances[i] = rayData.rayLength;

                // Draw a debug line to visualize the ray
                Debug.DrawRay(transform.position, rayDirection * rayData.rayLength, Color.green);
            }
        }
    }
}
