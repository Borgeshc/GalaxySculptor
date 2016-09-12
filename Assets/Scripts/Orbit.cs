﻿using UnityEngine;
using System.Collections;

public class Orbit : MonoBehaviour {
	public Transform target;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		Vector3 relativePos = (target.position + new Vector3(0, .5f, 0)) - transform.position;
		Quaternion rotation = Quaternion.LookRotation(relativePos);
		Quaternion current = transform.localRotation;     
		transform.localRotation = Quaternion.Slerp(current, rotation, Time.deltaTime);
		transform.Translate(0, 0, 50 * Time.deltaTime);

	}
}
