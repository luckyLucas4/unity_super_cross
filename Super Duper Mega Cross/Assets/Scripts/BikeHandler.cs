using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BikeHandler : MonoBehaviour {

    public float enginePower;
    public float maxPower;
    public float minPower;
    public WheelJoint2D wheel;

    private JointMotor2D m;

	// Use this for initialization
	void Start () {
        
        m = wheel.motor;
	}
	
	// Update is called once per frame
	void Update () {
        if(Input.GetAxis("Vertical") != 0 && m.motorSpeed < maxPower && m.motorSpeed > minPower)
        {
            m.motorSpeed += enginePower * Input.GetAxis("Vertical");
        }
        else if(m.motorSpeed > 0)
        {
            m.motorSpeed -= maxPower / 50;
        }
        else if(m.motorSpeed < 0)
        {
            m.motorSpeed -= minPower / 50;
        }
        wheel.motor = m;

	}
}
