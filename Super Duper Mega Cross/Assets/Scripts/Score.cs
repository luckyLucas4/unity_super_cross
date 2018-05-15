using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    public Transform player;
    public Text scoreText;

    private int playerStartX;
    private int maxScore = 0;

    private void Start()
    {
        playerStartX = (int)player.position.x;
    }

    // Update is called once per frame
    void Update () {
        int playerX = (int)player.position.x - playerStartX;
        if (playerX > maxScore)
        {
            maxScore = playerX;
        }

        scoreText.text = maxScore.ToString("0");
	}
}
