using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    public Transform player;
    public Timer timer;

    [HideInInspector] public Text scoreText;
    [HideInInspector] public int maxScore = 0;
    private int playerStartX;

    private void Start()
    {
        scoreText = gameObject.GetComponent<Text>();
        playerStartX = (int)player.position.x;
        scoreText.text = maxScore.ToString("0");
    }
    
    void Update () {

        int playerX = (int)player.position.x - playerStartX;

        if (playerX > maxScore && !timer.hasWon)
        {
            maxScore = playerX;
            scoreText.text = maxScore.ToString("0");
        }
	}

    public void SetScore(string text)
    {
        scoreText.text = text;
    }
}
