using UnityEngine;
using System.Collections;

public class SpawnScript : MonoBehaviour {
	public GameObject block1;
	public GameObject block2;
	public GameObject block3;
	public GameObject block4;
	public GameObject block5;
	public GameObject block6;
	public Texture block1sprite;
	public Texture block2sprite;
	public Texture block3sprite;
	public Texture block4sprite;
	public Texture block5sprite;
	public Texture block6sprite;

	public GameObject spawnArea;
	public float spawnVelocityX;
	public bool allowSpawn;
	private Vector2 spawnVelocity;
	private int nextBlock;
	// Use this for initialization
	void Start () {
		allowSpawn = true;
		spawnVelocityX = 5f;
		spawnVelocity = new Vector2 (spawnVelocityX, 0f);
		nextBlock = Random.Range(1,7);
	}
	
	void OnGUI () {
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
	}

	// Update is called once per frame
	void Update () {
		if (spawnVelocityX <= 15f) {
			spawnVelocityX += 0.02f * Time.deltaTime;
			spawnVelocity = new Vector2(spawnVelocityX, 0f);
				}

		if (allowSpawn) {

			if (nextBlock == 1) {
				Spawn(block1);
			}
			else if (nextBlock == 2) {
				Spawn(block2);
			}
			else if (nextBlock == 3) {
				Spawn(block3);
			}
			else if (nextBlock == 4) {
				Spawn(block4);
			}
			else if (nextBlock == 5) {
				Spawn(block5);
			}
			else if (nextBlock == 6) {
				Spawn(block6);
			}
				}
	}

	void Spawn(GameObject block) {
		allowSpawn = false;
		GameObject spawnedBlock = Instantiate (block) as GameObject; 
		spawnedBlock.transform.position = spawnArea.transform.position;
		spawnedBlock.rigidbody2D.velocity = spawnVelocity;
		nextBlock = Random.Range(1,7);
		}
}
