using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {
    private float timeLeft;
    public Text timeText;

	// Use this for initialization
	void Start () {
        timeLeft = 45;
	}
	
	// Update is called once per frame
	void Update () {
        timeLeft -= Time.deltaTime;

        timeText.text = timeLeft.ToString("0");
    }
}
