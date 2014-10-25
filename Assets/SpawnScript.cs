using UnityEngine;
using System.Collections;

public class SpawnScript : MonoBehaviour {
	public GameObject block1;
	public GameObject block2;
	public GameObject block3;
	public GameObject block4;
	public GameObject block5;
	public GameObject block6;
	public GameObject spawnArea;
	public float spawnVelocityX;
	public bool allowSpawn;
	private Vector2 spawnVelocity;
	private int selectedBlock;
	// Use this for initialization
	void Start () {
		allowSpawn = true;
		spawnVelocityX = 5f;
		spawnVelocity = new Vector2 (spawnVelocityX, 0f);
	}
	
	// Update is called once per frame
	void Update () {
		if (spawnVelocityX <= 15f) {
			spawnVelocityX += 0.02f * Time.deltaTime;
			spawnVelocity = new Vector2(spawnVelocityX, 0f);
				}

		if (allowSpawn) {
			selectedBlock = Random.Range(1,7);
			if (selectedBlock == 1) {
				Spawn(block1);
			}
			else if (selectedBlock == 2) {
				Spawn(block2);
			}
			else if (selectedBlock == 3) {
				Spawn(block3);
			}
			else if (selectedBlock == 4) {
				Spawn(block4);
			}
			else if (selectedBlock == 5) {
				Spawn(block5);
			}
			else if (selectedBlock == 6) {
				Spawn(block6);
			}
				}
	}

	void Spawn(GameObject block) {
		allowSpawn = false;
		GameObject spawnedBlock = Instantiate (block) as GameObject; 
		spawnedBlock.transform.position = spawnArea.transform.position;
		spawnedBlock.rigidbody2D.velocity = spawnVelocity;
		}
}
