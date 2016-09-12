using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GalaxySculptor : MonoBehaviour
{

    //Planets
    public List<GameObject> planets;    //List of planets.
    public List<GameObject> activePlanets;  //List of active planets.
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
    private float planetSizeChosen;


    //Moons
    public List<GameObject> moons;    //List of planets.
    public List<GameObject> activeMoons;
    public float moonMinSize;   //Min size a planet could be.
    public float moonMaxSize;   //Max size a planet could be.

    public float moonsMinX; //Max for the X a planet could spawn.
    public float moonsMaxX; //Min for the X a planet could spawn.
    public float moonsMinY; //Min for the Y a planet could spawn.
    public float moonsMaxY; //Max for the Y a planet could spawn.
    public float moonsMinZ; //Min for the Z a planet could spawn.
    public float moonsMaxZ; //Max for the Z a planet could spawn.

    public List<Vector3> occupiedMoonPositions; //The positons of spawned planets.

    private float moonSizeChosen;
    public float moonMinRotationSpeed;  //A planets minimum rotation speed.
    public float moonMaxRotationSpeed;  //A planets maximum rotation speed.
    private Vector3 desiredMoonPosition; //Where the planet is trying to spawn.

    //Sun
    public List<GameObject> activeSuns;
    public GameObject sun;
    public float sunMinSize;   //Min size a sun could be.
    public float sunMaxSize;   //Max size a sun could be.

    public float sunsMinX; //Max for the X a planet could spawn.
    public float sunsMaxX; //Min for the X a planet could spawn.
    public float sunsMinY; //Min for the Y a planet could spawn.
    public float sunsMaxY; //Max for the Y a planet could spawn.
    public float sunsMinZ; //Min for the Z a planet could spawn.
    public float sunsMaxZ; //Max for the Z a planet could spawn.

    private Vector3 desiredSunPosition; //Where the planet is trying to spawn.
    private float sunSizeChosen;
    public Vector3 localRotationSpeed;

    void Start ()
    {
        //localRotationSpeed = new Vector3(Random.Range())
        Suns();
        Planets();
        Moons();
    }
	void Moons ()
    {
        foreach (GameObject moon in moons)  //For every moon in the array named planet.
        {
            GameObject moonClone = Instantiate(moon, transform.position, transform.rotation) as GameObject; //Create the moon.
            activeMoons.Add(moonClone);
            moonSizeChosen = Random.Range(moonMinSize, moonMaxSize);    //Chooses a random size based upon the min and max sizes chosen.
            moonClone.transform.localScale = new Vector3(moonSizeChosen, moonSizeChosen, moonSizeChosen); //Scales the gameobject to that size.
            moonClone.transform.SetParent(activePlanets[Random.Range(0, activePlanets.Count)].transform);
            occupiedMoonPositions.Add(moonClone.transform.position);
            //This will pick a random Vector3 to spawn the moon on.
            desiredMoonPosition = new Vector3(Random.Range(moonsMinX, moonsMaxX), Random.Range(moonsMinY, moonsMaxY), Random.Range(moonsMinZ, moonsMaxZ));
            for (int i = 0; i < occupiedMoonPositions.Count; i++)
            {
                if (!occupiedMoonPositions.Contains(desiredMoonPosition))    //If the desiredPosition of the moon is not on another moon
                {
                    moonClone.transform.position = desiredMoonPosition;  //Move the moon to the desired position
                    occupiedMoonPositions.Add(moonClone.transform.position); //Add the moon new position to the list
                    i = occupiedMoonPositions.Count; //End the loop
                }
                else
                    //if the desired position is on top of a moon, choose a different position.
                    desiredMoonPosition = new Vector3(Random.Range(moonsMinX, moonsMaxX) , Random.Range(moonsMinY, moonsMaxY), Random.Range(moonsMinZ, moonsMaxZ));
            }
            moonClone.tag = "Moon";
            moonClone.AddComponent<ObjectRotation>();  //Add the rotation script to the gameobject.
            moonClone.AddComponent<Orbit>(); //adding the orbiting script to the moon.
            moonClone.GetComponent<Orbit>().target = activePlanets[Random.Range(0, activePlanets.Count)].transform;
            //Scale the gameObject according to public variables
            rotationDirection = rotationOptions[Random.Range(0, rotationOptions.Length)];   //Choose a random rotation for the moon.

            //Place the gameObject randomly in the scene.
        }
	}
    void Planets()
    {
        foreach (GameObject planet in planets)  //For every planet in the array named planet.
        {
            GameObject planetClone = Instantiate(planet, transform.position, transform.rotation) as GameObject;//Create the planet.
            activePlanets.Add(planetClone);
            planetSizeChosen = Random.Range(planetMinSize, planetMaxSize);    //Chooses a random size based upon the min and max sizes chosen.
            planetClone.transform.localScale = new Vector3(planetSizeChosen, planetSizeChosen, planetSizeChosen); //Scales the gameobject to that size.
            planetClone.transform.SetParent(activeSuns[Random.Range(0, activeSuns.Count)].transform);
            occupiedPlanetPositions.Add(planetClone.transform.position);
            //This will pick a random Vector3 to spawn the planet on.
            desiredPlanetPosition = new Vector3(Random.Range(planetsMinX, planetsMaxX), Random.Range(planetsMinY, planetsMaxY), Random.Range(planetsMinZ, planetsMaxZ));
            for (int i = 0; i < occupiedPlanetPositions.Count; i++)
            {
                if (!occupiedPlanetPositions.Contains(desiredPlanetPosition))    //If the desiredPosition of the plnaet is not on another planet
                {
                    planetClone.transform.position = desiredPlanetPosition;  //Move the planet to the desired position
                    occupiedPlanetPositions.Add(planetClone.transform.position); //Add the planets new position to the list
                    i = occupiedPlanetPositions.Count; //End the loop
                }
                else
                    //if the desired position is on top of a planet, choose a different position.
                    desiredPlanetPosition = new Vector3(Random.Range(planetsMinX, planetsMaxX), Random.Range(planetsMinY, planetsMaxY), Random.Range(planetsMinZ, planetsMaxZ));
            }
            planetClone.tag = "Planet";
            planetClone.AddComponent<ObjectRotation>();  //Add the rotation script to the gameobject.
            planetClone.AddComponent<Orbit>(); //adding the orbiting script to the planet
            planetClone.GetComponent<Orbit>().target = activeSuns[Random.Range(0, activeSuns.Count)].transform;
            //Scale the gameObject according to public variables
            planetSizeChosen = Random.Range(planetMinSize, planetMaxSize);    //Chooses a random size based upon the min and max sizes chosen.
            
            rotationDirection = rotationOptions[Random.Range(0, rotationOptions.Length)];   //Choose a random rotation for the planet.
           //clone.GetComponent<ObjectRotation>().ChooseRotation(clone);
           //Place the gameObject randomly in the scene.
        }
    }
    public void Suns()
    {
        desiredPlanetPosition = new Vector3(Random.Range(sunsMinX, sunsMaxX), Random.Range(sunsMinY, sunsMaxY), Random.Range(sunsMinZ, sunsMaxZ)); //finding a desired location to place the sun similarly to the planets
        GameObject sunClone = Instantiate(sun, transform.position, transform.rotation) as GameObject; //Creating the sun
        activeSuns.Add(sunClone);
        sunClone.transform.position = desiredSunPosition;  //Move the sun to the desired position
        //clone.AddComponent<ObjectRotation>(); //adding the roation script to the sun
        sunClone.tag = "Sun"; //asiging the tag, "Sun," the game object
        sunSizeChosen = Random.Range(sunMinSize, sunMaxSize);    //Chooses a random size based upon the min and max sizes chosen.
        sunClone.transform.localScale = new Vector3(sunSizeChosen, sunSizeChosen, sunSizeChosen); //Scales the gameobject to that size.
    }
}
