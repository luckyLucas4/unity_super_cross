using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BikeSelector : MonoBehaviour {

    // Alla motorcyklar i menyn läggs till i fältet
    public GameObject[] bikeButtons;

    void Start() {
        // "Klickar i" väljaren för första motorcykeln
        bikeButtons[0].GetComponent<Toggle>().isOn = true;
	}

    // Anropas av knappen som täcker motorcykeln, tar emot motorcykeln som parameter
    public void BikeChange (GameObject caller)
    {
        // "Klickar ur" alla väljare
        foreach (GameObject bike in bikeButtons) {
            bike.GetComponent<Toggle>().isOn = false;
        }
        // "Klickar i" väljaren på första motorcykeln
        caller.GetComponent<Toggle>().isOn = true;
    }

    public void SetBike (GameObject bike)
    {
        GameObject menu = GameObject.FindGameObjectWithTag("MainMenu");
        menu.GetComponent<StartOptions>().selectedBike = bike;
    }
}
