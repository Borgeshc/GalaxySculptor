using UnityEngine;
using System.Collections;

public class ObjectRotation : MonoBehaviour
{
    public float planetRotationSpeed; //How fast does the object rotate
    public float moonRotationSpeed;
    public float sunRotationSpeed;

    [HideInInspector]
    public Vector3 rotationDirection;   //This will change depending on which bool you check.
    bool rotateUp;   //Rotate object up.
    bool rotateDown; //Rotate object down.
    bool rotateLeft; //Rotate object left.
    bool rotateRight;    //Rotate object right.

    bool isPlanet;
    bool isMoon;
    bool isSun;

    private string rotationChosen;

    GameObject gameManager; //Reference the gameManager object.
    GalaxySculptor galaxySculptor;  //Reference to the GalaxySculpter script.

    void Start()
    {
        gameManager = GameObject.Find("GameManager");   //Find the GameManager object.
        galaxySculptor = gameManager.GetComponent<GalaxySculptor>();    //Get the GalaxySculpter component on the gameManager object.
        planetRotationSpeed = Random.Range(galaxySculptor.planetsMinRotationSpeed, galaxySculptor.planetsMaxRotationSpeed);
        moonRotationSpeed = Random.Range(galaxySculptor.moonMinRotationSpeed, galaxySculptor.moonMaxRotationSpeed);
        sunRotationSpeed = Random.Range(galaxySculptor.sunMinRotationSpeed, galaxySculptor.sunMaxRotationSPeed);
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
            case "Sun":
                isSun = true;
                break;
        }
    }

    void Update()
    {
        //Hector I changed the 2 on line 70, 72, and 74
        if(isPlanet)
            transform.Rotate(rotationDirection * (planetRotationSpeed * 50) * Time.deltaTime);   //Object rotates based upon the bool chosen * the speed.
        if(isMoon)
            transform.Rotate(rotationDirection * (moonRotationSpeed * 50) * Time.deltaTime);   //Object rotates based upon the bool chosen * the speed.
        if (isSun)
            transform.Rotate(rotationDirection * (sunRotationSpeed * 50) * Time.deltaTime);   //Object rotates based upon the bool chosen * the speed.
    }
}
