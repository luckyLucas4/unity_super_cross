using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnloadLevel : MonoBehaviour {

    // En lista med alla taggar vi ska leta efter
    public string[] taBort; 

    // Anropas när scenen ska återställas
    public void Unload()
    {
        // Spelaren kommer tas bort. Filmaren är ett barn till spelaren, så vi måste rädda den
        GameObject filmare = GameObject.FindGameObjectWithTag("FilmingPosition");
        filmare.transform.parent = null;

        // Går igenom alla strängar i listan
        foreach(string tag in taBort)
        {
            // Går igenom alla objekt som matchar taggen och markerar att de ska raderas
            foreach (GameObject obj in GameObject.FindGameObjectsWithTag(tag))
            {
                Destroy(obj);
            }
        }
    }
}
