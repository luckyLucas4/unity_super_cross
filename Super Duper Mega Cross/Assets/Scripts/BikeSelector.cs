using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BikeSelector : MonoBehaviour {

    // Alla motorcyklar i menyn läggs till i fältet
    public GameObject[] bikes;


    void Start() {
        // "Klickar i" väljaren för första motorcykeln
        bikes[0].GetComponent<Toggle>().isOn = true;
	}

    // Anropas av knappen som täcker motorcykeln, tar emot motorcykeln som parameter
    public void BikeChange (GameObject caller)
    {
        // "Klickar ur" alla väljare
        foreach (GameObject bike in bikes) {
            bike.GetComponent<Toggle>().isOn = false;
        }
        // "Klickar i" väljaren på första motorcykeln
        caller.GetComponent<Toggle>().isOn = true;
    }
}
