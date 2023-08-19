using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSensors : MonoBehaviour
{
    public RaycastData[] rays; // Array of raycast data

    [System.Serializable]
    public class RaycastData
    {
        public float angle;         // Angle of the ray in degrees
        public float rayLength;     // Length of the ray
        public LayerMask collisionMask; // Layer mask to filter collisions
    }

    private void Update()
    {
        foreach (RaycastData rayData in rays)
        {
            // Calculate the direction of the ray based on the angle
            Vector3 rayDirection = Quaternion.Euler(0, rayData.angle, 0) * transform.forward;

            // Perform the raycast
            RaycastHit hit;
            if (Physics.Raycast(transform.position, rayDirection, out hit, rayData.rayLength, rayData.collisionMask))
            {
                // A collision occurred, do something with the hit information
                Debug.DrawLine(transform.position, hit.point, Color.red);
                Debug.Log("Ray hit at angle " + rayData.angle + ": " + hit.collider.gameObject.name);
            }
            else
            {
                // No collision, draw a debug line to visualize the ray
                Debug.DrawRay(transform.position, rayDirection * rayData.rayLength, Color.green);
            }
        }
    }
}
