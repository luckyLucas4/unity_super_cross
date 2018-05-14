using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    public Transform player;
    public Text scoreText;
    private int maxScore = 0;

	// Update is called once per frame
	void Update () {
        int playerX = (int)player.position.x + 5;
        if (playerX > maxScore)
        {
            maxScore = playerX;
        }

        scoreText.text = maxScore.ToString("0");
	}
}
