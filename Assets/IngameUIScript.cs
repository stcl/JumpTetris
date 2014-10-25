using UnityEngine;
using System.Collections;

public class IngameUIScript : MonoBehaviour {
	public int score;
	private Vector2 scoreDimensions;
	private Vector2 gameOverDimensions;
	private Vector2 newRecordDimensions;
	public GUIStyle mediumFontStyle;
	public GUIStyle bigFontStyle;
	public float screenHeight;
	public float screenWidth;
	private float buttonWidth;
	private float buttonHeight;
	public bool gameOver;
	public bool newRecord;

	// Use this for initialization
	void Start () {
		score = 0;
		screenHeight = Screen.height;
		screenWidth = Screen.width;
		mediumFontStyle.fontSize = Screen.width / 20;
		bigFontStyle.fontSize = Screen.width / 15;
		scoreDimensions = mediumFontStyle.CalcSize (new GUIContent(score.ToString ()));
		gameOverDimensions = bigFontStyle.CalcSize (new GUIContent("Game Over!"));
		newRecordDimensions = bigFontStyle.CalcSize (new GUIContent("High Score!"));
		buttonHeight = screenHeight / 10f;
		buttonWidth = screenWidth / 5f;
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnGUI() {
		scoreDimensions = mediumFontStyle.CalcSize (new GUIContent(score.ToString ()));
		GUI.Label (new Rect (Screen.width / 2f - scoreDimensions.x /2f, scoreDimensions.y * 0.3f, scoreDimensions.x, scoreDimensions.y), score.ToString(), mediumFontStyle);
		if (gameOver) {
			if (newRecord == false) {
			GUI.Label (new Rect (Screen.width / 2f - gameOverDimensions.x /2f, scoreDimensions.y * 1.5f, gameOverDimensions.x, gameOverDimensions.y), "Game Over!", bigFontStyle);
			}
			else {
				GUI.Label (new Rect (Screen.width / 2f - newRecordDimensions.x /2f, scoreDimensions.y * 1.5f, newRecordDimensions.x, newRecordDimensions.y), "High Score!", bigFontStyle);
			}
			if (GUI.Button (new Rect (Screen.width / 2 - buttonWidth / 2,  screenHeight / 2f - buttonHeight /2f, buttonWidth, buttonHeight), "Try again")) {
				Application.LoadLevel (Application.loadedLevelName);
			}
				}
	}

	public void GameOver() {
		gameOver = true;
		if (PlayerPrefs.HasKey ("HighScore") == false || PlayerPrefs.GetInt("HighScore") <= score ){
			PlayerPrefs.SetInt("HighScore", score);
			newRecord = true;
				}
		}

	public void addScore(int amount) {
		score += amount;
	}

}
