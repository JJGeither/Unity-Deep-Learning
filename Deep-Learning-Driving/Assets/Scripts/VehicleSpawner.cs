using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleSpawner : MonoBehaviour
{

    public GameObject CarPrefab;
    public int NumberOfCars;

    // Start is called before the first frame update
    void Start()
    {
        SpawnCars(NumberOfCars);
    }

    void SpawnCars(int NumberOfCars)
    {
        for (int SpawnIterator = 0; SpawnIterator < NumberOfCars; SpawnIterator++)
        {
            Instantiate(CarPrefab, this.gameObject.transform);
        }

    }
}
