using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelector : MonoBehaviour {

    // Ett startvärde för scenen som ska laddas
    public int levelSelected = 1;

    // Ett fält dit alla "Toggle" objekt länkas
    public Toggle[] levelToggles;

    // Här sparas en referens till StartOptions-scriptet
    private StartOptions startOptions;

    // Anropas när spelet startas
    private void Start()
    {
        // Hittar StartOptions-scriptet
        startOptions = GameObject.FindGameObjectWithTag("MainMenu").GetComponent<StartOptions>();

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

    // Ändrar vilken scen som ska startas
    public void ChangeLevel(int level)
    {
        startOptions.sceneToStart = level;
    }
    
}