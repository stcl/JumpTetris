using UnityEngine;
using System.Collections;

public class Collides : MonoBehaviour {
	private int[] topBlockColumn = new int[] {0, 0, 0, 0, 0, 0};
	private int[] collidersBottomColumn = new int[] {11, 11, 11, 11, 11, 11};
	private int dropAmount = 11;
	public IngameUIScript inGameUIScript;
	public SpawnScript spawnScript;
	float yVelocity;
	
	void Start() {
		inGameUIScript = GameObject.Find("Scripts").GetComponent<IngameUIScript>();
		spawnScript = GameObject.Find("Scripts").GetComponent<SpawnScript>();
	}
	
	void OnCollisionEnter2D () {
		yVelocity = GetComponent<Rigidbody2D>().velocity.y; // not used currently
		CheckTopBlockColumn();
		collidersBottomColumn = new int[] {11, 11, 11, 11, 11, 11};
		foreach(Transform child in transform) {
			child.position = new Vector3(Mathf.RoundToInt(child.position.x - 0.5F), Mathf.RoundToInt(child.position.y - 0.5F), 0);
			if (child.position.x >= 0 && child.position.y >= 0 && child.position.x < 6 && child.position.y < 12) {
				Debug.Log((int)child.position.x + ", " + (int)child.position.y);
				GridArray.blocks[(int)child.position.x, (int)child.position.y] = child.gameObject;
				if ((int)child.position.y < collidersBottomColumn[(int)child.position.x]) {
					collidersBottomColumn[(int)child.position.x] = (int)child.position.y;
				}
				child.position = new Vector3(child.position.x + 0.5F, child.position.y + 0.5F, 0);
				child.GetComponent<Block>().activated = true;
			}
		}
		spawnScript.spawnBlock();
		inGameUIScript.updateNextBlock();
		transform.DetachChildren();
        Destroy(gameObject);
	
		for(int i = 0; i < 6; i++) {
			Debug.Log( "HOW MUCH: " + i + " " + (collidersBottomColumn[i] - topBlockColumn[i]) );
			if(collidersBottomColumn[i] - topBlockColumn[i] < dropAmount) {
								//Debug.Log( "HOW MUCH: " + dropAmount );
				dropAmount = collidersBottomColumn[i] - topBlockColumn[i];


				if( dropAmount < 0 )
					dropAmount = 0;
			}
		}
	
		//for( int i=0; i<6; i++ )
		//	Debug.Log( "BOTTOM: " + collidersBottomColumn[i] );

		for(int i = 0; i < 6; i++) {
			for(int j = 0; j < 12; j++) {
				if(dropAmount != 0 && GridArray.blocks[i, j] != null && GridArray.blocks[i,j].GetComponent<Block>().activated == true) {
					Debug.Log ("J:" + j + "DROP: " + dropAmount);

					GridArray.blocks[i, j-dropAmount+1] = GridArray.blocks[i, j];
					//Destroy(GridArray.blocks[i, j]);
					GridArray.blocks[i, j] = null;
				}
			}
		}
		Debug.Log(dropAmount);
		GridArray.dropAmount = dropAmount;
		GridArray.yVelocity = yVelocity;
	}
	
	void CheckTopBlockColumn() {
		topBlockColumn = new int[] {0, 0, 0, 0, 0, 0};
		for(int i = 0; i < 6; i++) {
			for(int j = 0; j < 12; j++) {
				if (GridArray.blocks[i, j] != null) {
					topBlockColumn[i] = j;
				}
			}
		}
	}
	
}
