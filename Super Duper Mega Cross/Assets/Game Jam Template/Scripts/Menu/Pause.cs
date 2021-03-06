﻿using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Pause : MonoBehaviour {

    // En länk till quit-scriptet
    public QuitApplication quitScript;

	private ShowPanels showPanels;						//Reference to the ShowPanels script used to hide and show UI panels
	private bool isPaused;								//Boolean to check if the game is paused or not
	private StartOptions startScript;					//Reference to the StartButton script
	
	//Awake is called before Start()
	void Awake()
	{
		//Get a component reference to ShowPanels attached to this object, store in showPanels variable
		showPanels = GetComponent<ShowPanels> ();
		//Get a component reference to StartButton attached to this object, store in startScript variable
		startScript = GetComponent<StartOptions> ();
	}

	// Update is called once per frame
	void Update () {

		//Check if the Cancel button in Input Manager is down this frame (default is Escape key) and that game is not paused, and that we're not in main menu
		if (Input.GetButtonDown ("Cancel") && !isPaused && !startScript.inMainMenu) 
		{
			//Call the DoPause function to pause the game
			DoPause();
		} 
		//If the button is pressed and the game is paused and not in main menu
		else if (Input.GetButtonDown ("Cancel") && isPaused && !startScript.inMainMenu) 
		{
			//Call the UnPause function to unpause the game
			UnPause ();
		}
	}


	public void DoPause()
	{
		//Set isPaused to true
		isPaused = true;
		//Set time.timescale to 0, this will cause animations and physics to stop updating
		Time.timeScale = 0;
		//call the ShowPausePanel function of the ShowPanels script
		showPanels.ShowPausePanel ();
	}


	public void UnPause()
	{
		//Set isPaused to false
		isPaused = false;
		//Set time.timescale to 1, this will cause animations and physics to continue updating at regular speed
		Time.timeScale = 1;
		//call the HidePausePanel function of the ShowPanels script
		showPanels.HidePausePanel ();
	}

    // Laddar om scenen
    public void Restart()
    {
        UnPause();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    // Återvänder till huvudmenyn
    public void Return()
    {
        // Återställer paus-menyn
        UnPause();
        showPanels.HidePausePanel();

        // Hittar index för scenen som har laddats
        int buildIndex = gameObject.GetComponent<StartOptions>().sceneToStart;

        // Samlar alla objekt i den scenen
        GameObject[] goArray = SceneManager.GetSceneByBuildIndex(buildIndex).GetRootGameObjects();

        // Om det första objektet har ett UnloadLevel-script ska vi köra det
        if (goArray[0].GetComponent<UnloadLevel>() != null)
        {
            goArray[0].GetComponent<UnloadLevel>().Unload();
        }

        // Laddar och visar huvudmenyn
        SceneManager.LoadScene(0);
        showPanels.ShowMenu();
    }

    // Använder quit-metoden på quit-scriptet som ligger
    public void Quit()
    {
        quitScript.Quit();
    }
}
