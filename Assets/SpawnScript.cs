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
	public Vector2 spawnVelocity;
	public int nextBlock;
	// Use this for initialization



	void Start () {
		spawnVelocityX = 5f;
		spawnVelocity = new Vector2 (spawnVelocityX, 0f);
		nextBlock = Random.Range(1,7);
		spawnBlock();
	}

	//public int randomNumber() 
	//{
	//	return Random.Range(1,7);
	//}


	public void spawnBlock()
	{

		switch( nextBlock ) 
		{
		case 1:
			Spawn(block1);
			break;
		case 2:
			Spawn(block2);
			break;
		case 3:
			Spawn(block3);
        break;
		case 4:
			Spawn(block4);
			break;
		case 5:
        Spawn(block5);
        break;
		case 6:
			Spawn(block6);
        break;
		}
		nextBlock = Random.Range(1,7);
	}

	// Update is called once per frame
	void Update () {
		
		if (spawnVelocityX <= 15f) {
			spawnVelocityX += 0.02f * Time.deltaTime;
			spawnVelocity = new Vector2(spawnVelocityX, 0f);
		}

	}

	private void Spawn(GameObject block) {
		GameObject spawnedBlock = Instantiate (block) as GameObject; 
		spawnedBlock.transform.position = spawnArea.transform.position;
		spawnedBlock.rigidbody2D.velocity = spawnVelocity;
		nextBlock = Random.Range(1,7);
	}
}
