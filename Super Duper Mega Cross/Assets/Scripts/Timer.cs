using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {
    public float startTime = 45;
    public float maxDistance;
    public Score scoreScript;
    public Text finalText;

    public Transform player;
    public Transform filmingPosition;

    public GameObject winPanel;
    public GameObject endPanel;

    public AudioSource engineSound;

    [HideInInspector] public bool hasWon = false;

    private float timeLeft;
    private Text timeText; 

	// Use this for initialization
	void Awake () {
        finalText.text = "";

        timeText = gameObject.GetComponent<Text>();
        timeLeft = startTime;

        // Ser till att spelet inte är pausat
        Time.timeScale = 1;
	}
	
	// Update is called once per frame
	void Update () {
        timeLeft -= Time.deltaTime;

        if(!hasWon)
            timeText.text = timeLeft.ToString("0");

        if(player.position.x > maxDistance && !hasWon)
        {
            hasWon = true;

            SetTexts();

            filmingPosition.parent = null;
            engineSound.Stop();
            winPanel.SetActive(true);
        }
        else if (timeLeft <= 0)
        {
            SetTexts();
            Time.timeScale = 0;
            endPanel.SetActive(true);
        }
    }

    public void SetTexts()
    {
        timeText.text = "";
        scoreScript.scoreText.text = "";

        int score = scoreScript.maxScore;
        int bonusScore = (int)timeLeft * 10;
        string text = String.Format("Avstånd: {0}m\nTidsbonus: {1}\nSumma: {2}",
            score, bonusScore, score + bonusScore);
        finalText.text = text;
    }
}
