﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BikeHandler : MonoBehaviour {



    // Ändrar hur snabbt motorns kraft ökar
    public float enginePower = 100;

    // Max/min för motorns kraft
    public float maxPower = 1500;
    public float minPower = -500;

    // Hur snabbt rotationen ökar, och maxvärdet
    public float torque = 50;
    public float maxTorque = 200;

    // Referens till hjulet
    public WheelJoint2D wheel;

    // En referenser som används senare
    private Rigidbody2D rb;
    private JointMotor2D m;

	// Anropas när spelet startar
	void Awake () {
        // rb tilldelas objektets Rigidbody2D-komponent
        rb = gameObject.GetComponent<Rigidbody2D>();

        //  m fåren kopia av motorn på vår WheelJoint2D
        m = wheel.motor;
	}
	
    // Anropas med jämna mellanrum
	void FixedUpdate () {
        // Om en knapp på vertikala axeln (up, down, w, s) har tryckts ner
        // och motorkraften är inom de tillåtna gränserna
        if(Input.GetAxis("Vertical") != 0 && m.motorSpeed < maxPower && m.motorSpeed > minPower)
        {
            // Öka motorkraften proportionellt mot enginePower, upp ger positivt
            m.motorSpeed += enginePower * Input.GetAxis("Vertical");
        }
        // Två funktioner som ser till att motorkraften minskar i lagom fart
        // om ingen knapp är nedtryckt
        else if(m.motorSpeed > 0)
        {
            m.motorSpeed -= maxPower / 50;
        }
        else if(m.motorSpeed < 0)
        {
            m.motorSpeed -= minPower / 50;
        }
        // m kopieras till hjulets motor, 
        wheel.motor = m;

        // Om rotationshastigheten är inom de tillåtna gränserna
        if(rb.angularVelocity < maxTorque && rb.angularVelocity > -maxTorque)
        {
            // Rotationskraft tillförs proportionerligt mot torque om left, right, a eller d
            // är nedtryckt, minustecknet omvandlar så att höger nu ger medsols
            rb.AddTorque(torque * -Input.GetAxis("Horizontal"));
        }
	}
}
