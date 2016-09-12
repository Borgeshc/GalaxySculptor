using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GalaxySculptor : MonoBehaviour
{

    //Planets

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
    public float planetsMaxRotationSpeed;  //A planets maximum rotation speed.
    private Vector3 desiredPlanetPosition; //Where the planet is trying to spawn.
    private float sizeChosen;


    //Moons
    public List<GameObject> moons;    //List of planets.
    public float moonMinSize;   //Min size a planet could be.
    public float moonMaxSize;   //Max size a planet could be.

    public float moonsMinX; //Max for the X a planet could spawn.
    public float moonsMaxX; //Min for the X a planet could spawn.
    public float moonsMinY; //Min for the Y a planet could spawn.
    public float moonsMaxY; //Max for the Y a planet could spawn.
    public float moonsMinZ; //Min for the Z a planet could spawn.
    public float moonsMaxZ; //Max for the Z a planet could spawn.

    public List<Vector3> occupiedMoonPositions; //The positons of spawned planets.

    public float moonMinRotationSpeed;  //A planets minimum rotation speed.
    public float moonMaxRotationSpeed;  //A planets maximum rotation speed.
    private Vector3 desiredMoonPosition; //Where the planet is trying to spawn.

    public List<GameObject> activePlanets;

    void Start ()
    {
        Planets();
        Moons();
    }
	void Moons ()
    {
        foreach (GameObject moon in moons)  //For every moon in the array named planet.
        {
            GameObject clone = Instantiate(moon, transform.position, transform.rotation) as GameObject; //Create the moon.
            clone.transform.SetParent(activePlanets[Random.Range(0, activePlanets.Count)].transform);
            occupiedMoonPositions.Add(clone.transform.position);
            //This will pick a random Vector3 to spawn the moon on.
            desiredMoonPosition = new Vector3(Random.Range(moonsMinX, moonsMaxX), Random.Range(moonsMinY, moonsMaxY), Random.Range(moonsMinZ, moonsMaxZ));
            for (int i = 0; i < occupiedMoonPositions.Count; i++)
            {
                if (!occupiedMoonPositions.Contains(desiredMoonPosition))    //If the desiredPosition of the moon is not on another moon
                {
                    clone.transform.position = desiredMoonPosition;  //Move the moon to the desired position
                    occupiedMoonPositions.Add(clone.transform.position); //Add the moon new position to the list
                    i = occupiedMoonPositions.Count; //End the loop
                }
                else
                    //if the desired position is on top of a moon, choose a different position.
                    desiredMoonPosition = new Vector3(Random.Range(moonsMinX, moonsMaxX) , Random.Range(moonsMinY, moonsMaxY), Random.Range(moonsMinZ, moonsMaxZ));
            }
            clone.tag = "Moon";
            clone.AddComponent<ObjectRotation>();  //Add the rotation script to the gameobject.
            //Scale the gameObject according to public variables
            sizeChosen = Random.Range(moonMinSize, moonMaxSize);    //Chooses a random size based upon the min and max sizes chosen.
            clone.transform.localScale = new Vector3 (sizeChosen,sizeChosen,sizeChosen); //Scales the gameobject to that size.
            rotationDirection = rotationOptions[Random.Range(0, rotationOptions.Length)];   //Choose a random rotation for the moon.


            //Place the gameObject randomly in the scene.
        }
	}
    void Planets()
    {
        foreach (GameObject planet in planets)  //For every planet in the array named planet.
        {
            GameObject clone = Instantiate(planet, transform.position, transform.rotation) as GameObject;//Create the planet.
            activePlanets.Add(clone);
            occupiedPlanetPositions.Add(clone.transform.position);
            //This will pick a random Vector3 to spawn the planet on.
            desiredPlanetPosition = new Vector3(Random.Range(planetsMinX, planetsMaxX), Random.Range(planetsMinY, planetsMaxY), Random.Range(planetsMinZ, planetsMaxZ));
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
                    desiredPlanetPosition = new Vector3(Random.Range(planetsMinX, planetsMaxX), Random.Range(planetsMinY, planetsMaxY), Random.Range(planetsMinZ, planetsMaxZ));
            }
            clone.tag = "Planet";
            clone.AddComponent<ObjectRotation>();  //Add the rotation script to the gameobject.
            //Scale the gameObject according to public variables
            sizeChosen = Random.Range(planetMinSize, planetMaxSize);    //Chooses a random size based upon the min and max sizes chosen.
            clone.transform.localScale = new Vector3(sizeChosen, sizeChosen, sizeChosen); //Scales the gameobject to that size.
            rotationDirection = rotationOptions[Random.Range(0, rotationOptions.Length)];   //Choose a random rotation for the planet.
           //clone.GetComponent<ObjectRotation>().ChooseRotation(clone);
           //Place the gameObject randomly in the scene.
        }
    }
}
