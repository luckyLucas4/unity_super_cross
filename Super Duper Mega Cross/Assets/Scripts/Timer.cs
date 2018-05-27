using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

    // Maximala tiden och antalet meter spelaren kan köra
    public float startTime = 45;
    public float maxDistance;

    // En referens till Score-scriptet
    public Score scoreScript;

    // Där text ska skrivas när spelet slutar
    public Text finalText;

    // Positioner för spelaren och punkten kameran filmar
    public Transform player;
    public Transform filmingPosition;

    // Spel objekten som ska visas när spelaren vinner/förlorar
    public GameObject winPanel;
    public GameObject endPanel;

    // Motorns ljudkälla
    public AudioSource engineSound;

    // Visar om spelaren har vunnit, öppen så att andra script kan använda den
    [HideInInspector] public bool hasWon = false;

    // Här sparas den återstående tiden och textfältet som tiden ska skrivas i
    private float timeLeft;
    private Text timeText; 

    // Anropas när spelobjektet skapas
	void Awake () {
        // Här ska det inte vara någon text nu
        finalText.text = "";

        // Referens till textfältet
        timeText = gameObject.GetComponent<Text>();

        // Tiden som är kvar börjar vid startTime
        timeLeft = startTime;

        // Ser till att spelet inte är pausat
        Time.timeScale = 1;
	}
	
    // Anropas av spelet så ofta det går
	void Update () {

        // Timern räknar ner, deltaTime är tiden det tog att visa den förra spelbilden
        timeLeft -= Time.deltaTime;

        // Om spelaren inte har vunnit ska timern visa tiden som är kvar utan decimaler
        if(!hasWon)
            timeText.text = timeLeft.ToString("0");

        // Om spelaren har kommit längre än maxavståndet och inte redan har vunnit
        if(player.position.x > maxDistance && !hasWon)
        {
            // Spelaren har nu vunnit
            hasWon = true;

            // SetTexts-metoden definieras nedan
            SetTexts();

            // Punkten som kameran filmar kopplas loss från spelaren
            filmingPosition.parent = null;

            // Motorljudet tystas
            engineSound.Stop();

            // Visar hela vinst-menyn
            winPanel.SetActive(true);
        }
        // Om tiden är slut och spelaren inte redan har vunnit
        else if (timeLeft <= 0 && !hasWon)
        {
            // Definieras nedan
            SetTexts();

            // Spelet pausas
            Time.timeScale = 0;

            // Motorljudet tystas
            engineSound.Stop();

            // Visar förlust-menyn
            endPanel.SetActive(true);
        }
    }

    // Skriver ut texter när spelet är slut
    public void SetTexts()
    {
        // Suddar ut texten i timer- och poängfälten
        timeText.text = "";
        scoreScript.scoreText.text = "";

        // Börjar med att skapa en int där maxScore från score-scriptet sparas
        int score = scoreScript.maxScore;

        // 10 bonuspoäng för varje sekund som är kvar
        int bonusScore = (int)timeLeft * 10;

        // Formaterar en textsträng med alla värden som ska visas
        string text = String.Format("Avstånd: {0}m\nTidsbonus: {1}\nSumma: {2}",
            score, bonusScore, score + bonusScore);

        // Texten skrivs ut
        finalText.text = text;
    }
}
