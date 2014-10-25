using UnityEngine;
using System.Collections;

public class IngameUIScript : MonoBehaviour {
	public int score;
	public SpawnScript spawnScript;
	private Vector2 scoreDimensions;
	private Vector2 hiscoreDimensions;
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

	public Texture block1sprite;
	public Texture block2sprite;
	public Texture block3sprite;
	public Texture block4sprite;
	public Texture block5sprite;
	public Texture block6sprite;

	private int nextBlock;
	// Use this for initialization
	void Start () {
		score = 0;
		screenHeight = Screen.height;
		screenWidth = Screen.width;
		mediumFontStyle.fontSize = Screen.width / 23;
		bigFontStyle.fontSize = Screen.width / 15;
		scoreDimensions = mediumFontStyle.CalcSize (new GUIContent(score.ToString ()));
		hiscoreDimensions = mediumFontStyle.CalcSize (new GUIContent("Highscore: "+ PlayerPrefs.GetInt("HighScore").ToString()));
		gameOverDimensions = bigFontStyle.CalcSize (new GUIContent("Game Over!"));
		newRecordDimensions = bigFontStyle.CalcSize (new GUIContent("High Score!"));
		buttonHeight = screenHeight / 10f;
		buttonWidth = screenWidth / 5f;
		nextBlock = spawnScript.nextBlock;
	}
	
	// Update is called once per frame
	void Update () {
		nextBlock = spawnScript.nextBlock;
	}

	void OnGUI() {

		if (nextBlock == 1) {
			GUI.DrawTexture(new Rect(5f, 5f, 64f, 32f), block1sprite, ScaleMode.ScaleToFit);
		}
		else if (nextBlock == 2) {
			GUI.DrawTexture(new Rect(5f, 5f, 64f, 32f), block2sprite, ScaleMode.ScaleToFit);
		}
		else if (nextBlock == 3) {
			GUI.DrawTexture(new Rect(5f, 5f, 64f, 32f), block3sprite, ScaleMode.ScaleToFit);
		}
		else if (nextBlock == 4) {
			GUI.DrawTexture(new Rect(5f, 5f, 64f, 32f), block4sprite, ScaleMode.ScaleToFit);
		}
		else if (nextBlock == 5) {
			GUI.DrawTexture(new Rect(5f, 5f, 64f, 32f), block5sprite, ScaleMode.ScaleToFit);
		}
		else if (nextBlock == 6) {
			GUI.DrawTexture(new Rect(5f, 5f, 64f, 32f), block6sprite, ScaleMode.ScaleToFit);
		}

		scoreDimensions = mediumFontStyle.CalcSize (new GUIContent(score.ToString ()));
		GUI.Label (new Rect (Screen.width / 2f - scoreDimensions.x /2f, scoreDimensions.y * 0.2f, scoreDimensions.x, scoreDimensions.y), score.ToString(), mediumFontStyle);
		hiscoreDimensions = mediumFontStyle.CalcSize (new GUIContent("Highscore: "+ PlayerPrefs.GetInt("HighScore").ToString()));
		GUI.Label (new Rect (Screen.width - hiscoreDimensions.x *1.1f, hiscoreDimensions.y * 0.2f, hiscoreDimensions.x, hiscoreDimensions.y), "Highscore: "+ PlayerPrefs.GetInt("HighScore").ToString(), mediumFontStyle);
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
		saveScore (score);
		}

	public void addScore(int amount) {
		score += amount;
	}

	public void saveScore(int amount) {
		if (PlayerPrefs.HasKey ("HighScore") == false || PlayerPrefs.GetInt("HighScore") <= amount ){
			PlayerPrefs.SetInt("HighScore", amount);
			newRecord = true;
		}
	}

}
