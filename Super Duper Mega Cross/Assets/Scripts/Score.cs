using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    // Referenser till spelaren och Timer-scriptet
    public Transform player;
    public Timer timer;

    // De här variablerna kommer användas av Timer-scriptet, 
    // därför är de public men gömda i programmet
    [HideInInspector] public Text scoreText;
    [HideInInspector] public int maxScore = 0;

    // Här sparas spelarens ursprungliga x-värde
    private int playerStartX;

    // Anropas när spelet startas
    private void Start()
    {
        // Sparar spelarens startvärde i x-led
        playerStartX = (int)player.position.x;

        // Skapar en referens till textkomponenten och skriver en nolla i textfältet 
        // ("0" betyder noll decimaler) 
        scoreText = gameObject.GetComponent<Text>();
        scoreText.text = maxScore.ToString("0");
    }
    
    // Anropas av spelet så ofta det går
    void Update () {

        // Skillnaden i x-led mellan spelaren och startpositionen
        int playerX = (int)player.position.x - playerStartX;

        // Om skillnaden är större än det största tidigare värdet 
        // och timern inte säger att spelet är slut
        if (playerX > maxScore && !timer.hasWon)
        {
            // Sätter det nya maxvärdet och skriver ut utan decimaler
            maxScore = playerX;
            scoreText.text = maxScore.ToString("0");
        }
	}
}
