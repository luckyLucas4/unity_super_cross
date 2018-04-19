using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BikeHandler : MonoBehaviour {

    public float enginePower = 100;
    public float maxPower = 1500;
    public float minPower = -500;
    public WheelJoint2D wheel;
    public 

    private JointMotor2D m;
    private Rigidbody2D rb;

	// Use this for initialization
	void Start () {
        rb = gameObject.GetComponent<Rigidbody2D>();
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

        rb.AddTorque(20);
	}
}
