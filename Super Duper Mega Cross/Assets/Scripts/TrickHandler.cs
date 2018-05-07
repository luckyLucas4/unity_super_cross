using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrickHandler : MonoBehaviour {

    public Sprite orginal;
    public Sprite trick;
    private Sprite temp;



    // Use this for initialization
    void Start () {
        temp = orginal;


	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKey(KeyCode.Z) || Input.GetKey(KeyCode.Space))
        {
            temp = trick;
        }
        else
        {
            temp = orginal;
        }
        gameObject.GetComponent<SpriteRenderer>().sprite = temp;
	}
}
