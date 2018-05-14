using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    public Transform player;
    public Transform filmMan;
    public Text scoreText;
    private int maxScore = 0;

	// Update is called once per frame
	void Update () {
        int playerX = (int)player.position.x;
        int filmManX = (int)filmMan.position.x;
        if (playerX > maxScore)
        {
            maxScore = playerX;
        }
        if (filmManX > maxScore)
        {
            maxScore = filmManX;
        }

        scoreText.text = maxScore.ToString("0");
	}
}
