using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class VisualizeNetwork : MonoBehaviour
{
    public VehicleSpawner vehicleSpawnerObject; 
    public Image spriteImage;
    public Vector3 spriteWorldPosition;
    private List<GameObject> vehicleList;

    private void Start()
    {
        vehicleList = vehicleSpawnerObject.instantiatedCars;
        // Assuming you have a PNG sprite assigned to spriteImage in the Unity Editor.
        PositionSpriteAtWorldCoordinate();
    }

    public void Update()
    {
        
    }

    private void PositionSpriteAtWorldCoordinate()
    {

        Image newImage = Instantiate(spriteImage, this.gameObject.transform);
        newImage.transform.position = spriteWorldPosition;




    }
}
