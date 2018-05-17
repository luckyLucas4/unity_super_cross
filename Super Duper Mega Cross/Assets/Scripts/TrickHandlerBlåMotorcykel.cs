using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrickHandlerBlåMotorcykel : MonoBehaviour
{

    public Sprite orginal;
    public Sprite trick;
    public Sprite trick2;
    private Sprite temp;



    // Use this for initialization
    void Start()
    {
        temp = orginal;


    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.Z) || Input.GetKey(KeyCode.K))
        {
            temp = trick;
        }
        else if (Input.GetKey(KeyCode.X) || Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.L))
        {
            temp = trick2;
        }
        else
        {
            temp = orginal;
        }
        gameObject.GetComponent<SpriteRenderer>().sprite = temp;
    }
}