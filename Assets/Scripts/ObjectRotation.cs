using UnityEngine;
using System.Collections;

public class ObjectRotation : MonoBehaviour
{
    [HideInInspector]
    public float rotationSpeed; //How fast does the object rotate
    public Vector3 rotationDirection;   //This will change depending on which bool you check.
    public bool rotateUp;   //Rotate object up.
    public bool rotateDown; //Rotate object down.
    public bool rotateLeft; //Rotate object left.
    public bool rotateRight;    //Rotate object right.

    GameObject gameManager; //Reference the gameManager object.
    GalaxySculpter galaxySculpter;  //Reference to the GalaxySculpter script.

    void Start()
    {
        gameManager = GameObject.Find("GameManager");   //Find the GameManager object.
        galaxySculpter = gameManager.GetComponent<GalaxySculpter>();    //Get the GalaxySculpter component on the gameManager object.
        rotationSpeed = Random.Range(galaxySculpter.planetsMinRotationSpeed, galaxySculpter.plnaetsMaxRotationSpeed);
        //Set the rotation of this object based upon the values given in the GalaxySculpter script.

        switch (galaxySculpter.rotationDirection)   //Set the rotation of the object based upon the string choosen in the GalaxySculpter script
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
    }

    void Update()
    {
        transform.Rotate(rotationDirection * rotationSpeed * Time.deltaTime);   //Object rotates based upon the bool chosen * the speed.
    }
}
