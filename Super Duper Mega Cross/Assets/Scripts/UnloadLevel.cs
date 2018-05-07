using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnloadLevel : MonoBehaviour {

    public string[] taBort; 

    public void Unload()
    {
        GameObject filmare = GameObject.FindGameObjectWithTag("FilmingPosition");

        filmare.transform.parent = null;

        foreach(string tag in taBort)
        {
            foreach (GameObject obj in GameObject.FindGameObjectsWithTag(tag))
            {
                Destroy(obj);
            }
        }
    }
}
