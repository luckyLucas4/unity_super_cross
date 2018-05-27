using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BikeHandler : MonoBehaviour {

    // Max/min för motorns kraft
    public float maxPower = 1500;
    public float minPower = -500;

    // Ändrar hur snabbt motorns kraft ökar
    public float enginePower = 100;

    // Hur snabbt rotationen ökar, och maxvärdet
    public float torque = 50;
    public float maxTorque = 200;

    // Referens till hjulet
    public WheelJoint2D wheel;

    // Referenser till ljudklippen och ljudkällan där klippen ska spelas
    public AudioClip engineIdling;
    public AudioClip engineDriving;
    public AudioSource engineSource;

    public float pitchRange = 0.2f; // Inom det här området kommer tonen variera
    private float originalPitch;    // Här sparas den ursprungliga tonen

    //En referens till timer-scriptet
    public Timer timer; 

    // Variabler som används senare
    private Rigidbody2D rb;
    private JointMotor2D m;


	// Anropas när spelet startar
	void Awake () {
        // rb tilldelas spelobjektets Rigidbody2D-komponent
        rb = gameObject.GetComponent<Rigidbody2D>();

        //  m får en kopia av motorn på vår WheelJoint2D
        m = wheel.motor;

        // Sparar den ursprungliga tonen och startar motorljudet
        originalPitch = engineSource.pitch;
        engineSource.Play();

    }
	
    // Anropas med jämna mellanrum
	void FixedUpdate () {

        // Om en knapp på vertikala axeln (up, down, w, s) har tryckts ner
        // och motorkraften är inom de tillåtna gränserna
        if(Input.GetAxis("Vertical") != 0 && m.motorSpeed < maxPower && m.motorSpeed > minPower)
        {
            // Öka motorkraften proportionellt mot enginePower, upp ger positivt och ner ger negativt
            m.motorSpeed += enginePower * Input.GetAxis("Vertical");
        }
        // Annars ska motorkraften minska kontrollerat
        else if(m.motorSpeed > 0)
        {
            m.motorSpeed -= maxPower / 50;
        }
        else if(m.motorSpeed < 0)
        {
            m.motorSpeed -= minPower / 50;
        }

        // Alla värden som "m" har fått kopieras till hjulets motor
        wheel.motor = m;

        // Om input-värdet är nära noll ska tomgångs-ljudet spelas
        if(Mathf.Abs(Input.GetAxis("Vertical")) < 0.6f)
        {
            // Om kör-ljudet spelas och vi inte har en timer som säger att spelet är vunnet
            if(engineSource.clip == engineDriving && (timer == null || !timer.hasWon ))
            {
                // ändrar vi klipp på ljudkällan och ger den en slumpad ton
                engineSource.clip = engineIdling;
                engineSource.pitch = Random.Range(originalPitch - pitchRange, originalPitch + pitchRange);
                engineSource.Play();
            }
        }
        // Annars ska kör-ljudet spelas
        else
        {
            if(engineSource.clip == engineIdling && (timer == null || !timer.hasWon))
            {
                engineSource.clip = engineDriving;
                engineSource.pitch = Random.Range(originalPitch - pitchRange, originalPitch + pitchRange);
                engineSource.Play();
            }
        }

        // Om rotationshastigheten är inom de tillåtna gränserna
        if(rb.angularVelocity < maxTorque && rb.angularVelocity > -maxTorque)
        {
            // Rotationskraft tillförs proportionerligt mot vår konstant torque, om en horisontell knapp är nedtryckt
            // Minustecknet omvandlar så att höger knapp ger medsols
            rb.AddTorque(torque * -Input.GetAxis("Horizontal"));
        }
	}
}
