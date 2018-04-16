using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BikeHandler : MonoBehaviour {

    public float enginePower;

    public GameObject wheel;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if( Input.GetAxis("Vertical") > 0)
        {
            wheel.GetComponent<WheelJoint2D>().motor.motorSpeed = enginePower;
        }
	}
}
