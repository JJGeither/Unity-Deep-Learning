using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement : MonoBehaviour
{

    public float MovementSpeed = 60f;
    public float RotationSpeed = 10f;
    public MeshRenderer CarColor;

    float HorizontalInput;

    Rigidbody CarBody;

    // Start is called before the first frame update
    void Start()
    {

        CarBody = this.GetComponent<Rigidbody>();

        RandomizeCarColor();
        InvokeRepeating("RandomMovement", 0f, .5f);


    }

    // Update is called once per frame
    void Update()
    {
        MoveForward();


        UpdateRotation(HorizontalInput);

        //HorizontalInput = Input.GetAxis("Horizontal");
        //UpdateRotation(HorizontalInput);

        if (Input.GetKeyDown(KeyCode.R))
            RandomizeCarColor();

    }

    public void RandomizeCarColor()
    {
        Color RandomColor = Random.ColorHSV(0f, 1f, .8f, 1f);
        Material CarMat = new Material(Shader.Find("Standard"));
        CarMat.SetColor("_Color", RandomColor);
        CarColor.material = CarMat;
    }

    public void MoveForward()
    {
        Vector3 Movement = transform.forward * MovementSpeed;
        CarBody.velocity = Movement;
    }



    public void RandomMovement()
    {

        int RandomInput = Random.Range(1, 4);

        switch (RandomInput) {
            case 1:
                TurnLeft();
                Debug.Log("LEFT");
                break;

            case 2:
                TurnRight();
                Debug.Log("RIGHT");
                break;

            case 3:
                GoStraight();
                Debug.Log("STRAIGHT");
                break;

            default:
                break;
        };

    }

    public void UpdateRotation(float RotationInput)
    {
        float CarRotation = RotationInput * RotationSpeed * Time.deltaTime;
        Quaternion rotation = new Quaternion(0f, CarRotation, 0f, 1);
        CarBody.MoveRotation(CarBody.rotation * rotation);
    }

    public void TurnLeft()
    {
        HorizontalInput = -1;
    }

    public void TurnRight()
    {
        HorizontalInput = 1;
    }

    public void GoStraight()
    {
        HorizontalInput = 0;
    }
}
