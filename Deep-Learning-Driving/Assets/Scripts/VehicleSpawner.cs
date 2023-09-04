using System.Collections.Generic;
using UnityEngine;

public class VehicleSpawner : MonoBehaviour
{
    public GameObject CarPrefab;
    public int NumberOfCars;

    public List<GameObject> instantiatedCars = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        SpawnCars(NumberOfCars);
    }

    void SpawnCars(int numberOfCars)
    {
        for (int spawnIterator = 0; spawnIterator < numberOfCars; spawnIterator++)
        {
            GameObject newCar = Instantiate(CarPrefab, this.transform);
            instantiatedCars.Add(newCar);
        }
    }
}
