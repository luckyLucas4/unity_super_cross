using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LinkMenuButtons : MonoBehaviour {

    // En referens till scriptet för att pausa på huvudmenyn
    public Pause mainMenuPause;

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
