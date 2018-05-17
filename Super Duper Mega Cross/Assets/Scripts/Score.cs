using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    public Transform player;
    public Text scoreText;
    public Timer timer;

    private int playerStartX;
    private int maxScore = 0;

    private void Start()
    {
        playerStartX = (int)player.position.x;
    }
    
    void Update () {

        int playerX = (int)player.position.x - playerStartX;

        if (playerX > maxScore && !timer.hasWon)
        {
            maxScore = playerX;
        }

        scoreText.text = maxScore.ToString("0");
	}
}
