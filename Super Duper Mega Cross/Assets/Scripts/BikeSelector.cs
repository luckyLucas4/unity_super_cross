using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BikeSelector : MonoBehaviour {

    // Alla motorcyklar i menyn läggs till i fältet
    public Toggle[] bikeToggles;

    // Här sparas en referens till StartOptions-scriptet 
    private StartOptions startOptions;

    // Anropas när spelet startas
    void Start() {
        // Hittar StartOptions-scriptet på huvudmenyn och sparar en referens i en lokal variabel
        startOptions = GameObject.FindGameObjectWithTag("MainMenu").GetComponent<StartOptions>();

        // "Klickar i" rätt väljare
        if(startOptions.selectedBike.name == "DogOnBike")
        {
            bikeToggles[1].isOn = true;
        }
        else
        {
            bikeToggles[0].isOn = true;
        }
    }

    // Anropas av knappen som täcker motorcykeln, tar emot motorcykeln som parameter
    public void BikeChange (GameObject caller)
    {
        // "Klickar ur" alla väljare
        foreach (Toggle toggle in bikeToggles) {
            toggle.isOn = false;
        }
        // "Klickar i" väljaren som skickades som parameter
        caller.GetComponent<Toggle>().isOn = true;
    }

    //Ändrar den valda motorcykeln i StartOptions-scriptet på huvudmenyn
    public void SetBike (GameObject bike)
    {
        startOptions.selectedBike = bike;
    }
}
