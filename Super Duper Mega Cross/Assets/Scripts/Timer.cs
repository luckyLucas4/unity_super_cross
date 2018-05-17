using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {
    private float timeLeft;
    public Text timeText;
    public float startTime = 45;

    public float maxDistance;
    public Transform player;
    public Transform filmingPosition;

    public GameObject winPanel;
    public GameObject endPanel;

    [HideInInspector] public bool hasWon = false;

	// Use this for initialization
	void Awake () {
        timeLeft = startTime;

        // Ser till att spelet inte är pausat
        Time.timeScale = 1;
	}
	
	// Update is called once per frame
	void Update () {
        timeLeft -= Time.deltaTime;

        timeText.text = timeLeft.ToString("0");

        if(player.position.x > maxDistance)
        {
            hasWon = true;
            timeText.text = " ";
            filmingPosition.parent = null;
            winPanel.SetActive(true);
        }
        else if (timeLeft <= 0)
        {
            timeText.text = " ";
            Time.timeScale = 0;
            endPanel.SetActive(true);
        }
    }
}
