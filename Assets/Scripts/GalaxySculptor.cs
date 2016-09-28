using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GalaxySculptor : MonoBehaviour
{
    public List<GameObject> planets;    //List of planets.
    public float planetMinSize;   //Min size a planet could be.
    public float planetMaxSize;   //Max size a planet could be.
    
    public float planetsMinX; //Max for the X a planet could spawn.
    public float planetsMaxX; //Min for the X a planet could spawn.
    public float planetsMinY; //Min for the Y a planet could spawn.
    public float planetsMaxY; //Max for the Y a planet could spawn.
    public float planetsMinZ; //Min for the Z a planet could spawn.
    public float planetsMaxZ; //Max for the Z a planet could spawn.

    public List<Vector3> occupiedPlanetPositions; //The positons of spawned planets.

    [HideInInspector]
    public string[] rotationOptions = new string[] { "rotateUp", "rotateDown", "rotateLeft", "RotateRight" };   //Options for the rotation directions
    [HideInInspector]
    public string rotationDirection;    //The choosen rotation.

    public float planetsMinRotationSpeed;  //A planets minimum rotation speed.
    public float plnaetsMaxRotationSpeed;  //A planets maximum rotation speed.
    private Vector3 desiredPlanetPosition; //Where the planet is trying to spawn.
    private float sizeChosen;

    void Start ()
    {
        Planets();
    }
	void Planets ()
    {
       
        foreach (GameObject planet in planets)  //For every planet in the array named planet.
        {
            GameObject clone = Instantiate(planet, transform.position, transform.rotation) as GameObject;//Create the planet.
            occupiedPlanetPositions.Add(clone.transform.position);
            //This will pick a random Vector3 to spawn the planet on.
            desiredPlanetPosition = new Vector3(Random.Range(planetsMinX, planetsMaxX), Random.Range(planetsMinY, planetsMaxY), Random.Range(planetsMinZ, planetsMaxZ));
            print(desiredPlanetPosition);
            for (int i = 0; i < occupiedPlanetPositions.Count; i++)
            {
                if (!occupiedPlanetPositions.Contains(desiredPlanetPosition))    //If the desiredPosition of the plnaet is not on another planet
                {
                    clone.transform.position = desiredPlanetPosition;  //Move the planet to the desired position
                    occupiedPlanetPositions.Add(clone.transform.position); //Add the planets new position to the list
                    i = occupiedPlanetPositions.Count; //End the loop
                }
                else
                    //if the desired position is on top of a planet, choose a different position.
                    desiredPlanetPosition = new Vector3(Random.Range(planetsMinX, planetsMaxX) , Random.Range(planetsMinY, planetsMaxY), Random.Range(planetsMinZ, planetsMaxZ));
            }
            clone.tag = "Planet";
            clone.AddComponent<ObjectRotation>();  //Add the rotation script to the gameobject.
            //Scale the gameObject according to public variables
            sizeChosen = Random.Range(planetMinSize, planetMaxSize);    //Chooses a random size based upon the min and max sizes chosen.
            clone.transform.localScale = new Vector3 (sizeChosen,sizeChosen,sizeChosen); //Scales the gameobject to that size.
            rotationDirection = rotationOptions[Random.Range(0, rotationOptions.Length)];   //Choose a random rotation for the planet.

            //Place the gameObject randomly in the scene.
           
            
        }
	}
}
