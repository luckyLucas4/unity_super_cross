using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BikeSelector : MonoBehaviour {

    // Alla motorcyklar i menyn läggs till i fältet
    public Toggle[] bikeToggles;

    void Start() {
        // "Klickar i" väljaren för första motorcykeln
        bikeToggles[0].isOn = true;
	}

    // Anropas av knappen som täcker motorcykeln, tar emot motorcykeln som parameter
    public void BikeChange (GameObject caller)
    {
        // "Klickar ur" alla väljare
        foreach (Toggle toggle in bikeToggles) {
            toggle.isOn = false;
        }
        // "Klickar i" väljaren på första motorcykeln
        caller.GetComponent<Toggle>().isOn = true;
    }

    //Ändrar den valda motorcykeln i StartOptions-scriptet på huvudmenyn

    public void SetBike (GameObject bike)
    {
        GameObject menu = GameObject.FindGameObjectWithTag("MainMenu");
        menu.GetComponent<StartOptions>().selectedBike = bike;
    }
}
