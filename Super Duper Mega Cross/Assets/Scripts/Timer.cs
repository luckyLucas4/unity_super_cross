using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {
    private float timeLeft;
    public Text timeText;
    public float startTime = 45;
    public GameObject pausePanel;

	// Use this for initialization
	void Start () {
        timeLeft = startTime;

	}
	
	// Update is called once per frame
	void Update () {
        timeLeft -= Time.deltaTime;

        timeText.text = timeLeft.ToString("0");

        if (timeLeft <= 0)
        {
            Time.timeScale = 0;
            pausePanel.SetActive(true);
            timeText.text = " ";
        }
    }
}
