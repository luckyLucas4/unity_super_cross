using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrickHandler : MonoBehaviour {

    public Sprite orginal;
    public Sprite trick;
    public Sprite trick2;
    private Sprite temp;



    // Use this for initialization
    void Start () {
        temp = orginal;
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKey(KeyCode.Z) || Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.K))
        {
            temp = trick;
        }
        else if (Input.GetKey(KeyCode.X) || Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.L))
        {
            temp = trick2;

            SpriteRenderer[] ts = gameObject.GetComponentsInChildren<SpriteRenderer>();
            ts[1].enabled = false;
            ts[2].enabled = false;
        }
        else
        {
            temp = orginal;

            SpriteRenderer[] ts = gameObject.GetComponentsInChildren<SpriteRenderer>();
            ts[1].enabled = true;
            ts[2].enabled = true;
        }
        gameObject.GetComponent<SpriteRenderer>().sprite = temp;
	}
}
