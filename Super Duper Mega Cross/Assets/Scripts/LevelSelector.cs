using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelector : MonoBehaviour {

    // Ett startvärde för scenen som ska startas
    public int levelSelected = 1;

    // Ett fält dit alla "Toggle" objekt länkas
    public Toggle[] levelToggles;

    private void Start()
    {
        // Markerar vår första "Toggle" och skickar in startvärdet
        ChangeLevelToggle(levelToggles[0]);
        ChangeLevel(levelSelected);
    }

    // Anropas av knapparna
    public void ChangeLevelToggle(Toggle callerToggle)
    {
        // "Klickar ur" alla levelToggles
        foreach (Toggle toggle in levelToggles)
        {
            toggle.isOn = false;
        }

        // Klickar i den toggle som har tagits emot
        callerToggle.isOn = true;
    }

    public void ChangeLevel(int level)
    {
        // Hittar StartOptions-scriptet på huvudmenyn och väljer vilken scen den ska starta
        GameObject menu = GameObject.FindGameObjectWithTag("MainMenu");
        menu.GetComponent<StartOptions>().sceneToStart = level;
    }
    
}
