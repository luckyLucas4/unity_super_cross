using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LinkMenuButtons : MonoBehaviour {

    // En referens till scriptet för att pausa på huvudmenyn
    private Pause mainMenuPause;

    private void Awake()
    {
        // Om huvudmenyn har laddats kan vi hämta scriptet
        if(SceneManager.GetSceneByBuildIndex(0).isLoaded)
        {
            mainMenuPause = StartOptions.startOptions.GetComponent<Pause>();
        }

    }

    // Startar om scenen
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    // Om vi har scriptet kan vi använda en metod för att återvända till huvudmenyn
    public void Return()
    {
        if (mainMenuPause != null)
            mainMenuPause.Return();
    }

    // Metoden för att avsluta
    public void Quit()
    {
        if (mainMenuPause != null)
            mainMenuPause.Quit();
    }
}
