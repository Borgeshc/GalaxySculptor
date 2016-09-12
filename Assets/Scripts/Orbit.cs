using UnityEngine;
using System.Collections;

public class Orbit : MonoBehaviour {
	public Transform target;
    float distance;
	// Use this for initialization
	void Start ()
    {
        distance = target.localScale.x / 50;
	}
	
	// Update is called once per frame
	void Update () 
	{
		Vector3 relativePos = (target.position + new Vector3(0, .5f, 0)) - transform.position;
		Quaternion rotation = Quaternion.LookRotation(relativePos);
		Quaternion current = transform.localRotation;     
		transform.localRotation = Quaternion.Slerp(current, rotation, Time.deltaTime);
		transform.Translate(distance, 0, 100 * Time.deltaTime);

	}
}
