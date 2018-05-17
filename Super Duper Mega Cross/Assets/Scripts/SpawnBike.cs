using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class SpawnBike : MonoBehaviour {

    // Ett spelobjekt som kameran kan följa
    public GameObject filmare;

    // Scripten på Score och Timer texterna
    public Score scoreText;
    public Timer timerText;

    // Anropas när banan ska laddas
    public void SpawnObject(GameObject bike)
    {
        // Avaktiverar alla objekt med taggen "Player" eller "EditorOnly" som finns i banan

        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("Player"))
        {
            obj.SetActive(false);
        }

        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("EditorOnly"))
        {
            obj.SetActive(false);
        }

        // Skapar en ny motorcykeli den här punkten
        GameObject newBike = Instantiate(bike, transform);

        // Cykeln ska inte vara ett barn under det här objektet
        newBike.transform.parent = null;

        // Filmaren blir ett barn till motorcykeln, följer med den
        filmare.transform.parent = newBike.transform;

        // Länkar spelaren till scripten som sitter på canvas-objektet
        timerText.player = newBike.transform;
        scoreText.player = newBike.transform;
    }
}
