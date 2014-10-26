using UnityEngine;
using System.Collections;

public class ScoreScript : MonoBehaviour {

	public int score;

	// Use this for initialization
	void Start () {
		score = 0;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public int saveScore() {
		if (PlayerPrefs.HasKey ("HighScore") == false || PlayerPrefs.GetInt("HighScore") <= score ){
			PlayerPrefs.SetInt("HighScore", score);
			return true;
		}
	}

	public void addScore(int amount) {
		score += amount;
	}
}
