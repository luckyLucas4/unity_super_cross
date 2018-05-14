using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    public Transform player;
    public Text scoreText;
    private int maxScore;

	// Update is called once per frame
	void Update () {
        player.position.x.
        scoreText.text = player.position.x.ToString("0");
	}
}
