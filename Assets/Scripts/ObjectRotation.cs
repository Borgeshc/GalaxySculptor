using UnityEngine;
using System.Collections;

public class ObjectRotation : MonoBehaviour
{
    [HideInInspector]
    public float planetRotationSpeed; //How fast does the object rotate
    [HideInInspector]
    public float moonRotationSpeed;
    [HideInInspector]
    public Vector3 rotationDirection;   //This will change depending on which bool you check.
    bool rotateUp;   //Rotate object up.
    bool rotateDown; //Rotate object down.
    bool rotateLeft; //Rotate object left.
    bool rotateRight;    //Rotate object right.

    bool isPlanet;
    bool isMoon;

    private string rotationChosen;

    GameObject gameManager; //Reference the gameManager object.
    GalaxySculptor galaxySculptor;  //Reference to the GalaxySculpter script.

    void Start()
    {
        gameManager = GameObject.Find("GameManager");   //Find the GameManager object.
        galaxySculptor = gameManager.GetComponent<GalaxySculptor>();    //Get the GalaxySculpter component on the gameManager object.
        planetRotationSpeed = Random.Range(galaxySculptor.planetsMinRotationSpeed, galaxySculptor.planetsMaxRotationSpeed);
        moonRotationSpeed = Random.Range(galaxySculptor.moonMinRotationSpeed, galaxySculptor.moonMaxRotationSpeed);
        rotationChosen = galaxySculptor.rotationDirection;
        //Set the rotation of this object based upon the values given in the GalaxySculpter script.

        switch (galaxySculptor.rotationDirection)   //Set the rotation of the object based upon the string choosen in the GalaxySculpter script
        {
            case "rotateUp":
                rotationDirection = Vector3.up;
                break;
            case "rotateDown":
                rotationDirection = Vector3.down;
                break;
            case "rotateLeft":
                rotationDirection = Vector3.left;
                break;
            case "rotateRight":
                rotationDirection = Vector3.right;
                break;
        }

        switch (transform.tag)
        {
            case "Planet":
                isPlanet = true;
                break;
            case "Moon":
                isMoon = true;
                break;
        }
    }

    void Update()
    {
        if(isPlanet)
            transform.Rotate(rotationDirection * planetRotationSpeed * Time.deltaTime);   //Object rotates based upon the bool chosen * the speed.
        if(isMoon)
            transform.Rotate(rotationDirection * moonRotationSpeed * Time.deltaTime);   //Object rotates based upon the bool chosen * the speed.
    }
}
