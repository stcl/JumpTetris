using UnityEngine;
using System.Collections;

public class GridArray : MonoBehaviour {
	public static GameObject[,] blocks = new GameObject[6,12];
	static public float yVelocity;
	private float destroyedDropSpeed = -8F;
	static public float dropAmount;
	
	void Update() {
		DropActiveBlocks();
	}

	void DropActiveBlocks() {
		if(dropAmount > 0) {
			for(int i = 0; i < 6; i++) {
				for(int j = 0; j < 12; j++) {
					if (GridArray.blocks[i, j] != null && GridArray.blocks[i, j].GetComponent<Block>().activated == true) {
						GridArray.blocks[i, j].transform.position = new Vector3(GridArray.blocks[i, j].transform.position.x, GridArray.blocks[i, j].transform.position.y + destroyedDropSpeed*Time.deltaTime, 0); 
					}
				}
			}
			dropAmount += destroyedDropSpeed*Time.deltaTime;
			if(dropAmount < 0) {
				dropAmount = 0F;
				for(int i = 0; i < 6; i++) {
					for(int j = 0; j < 12; j++) {
						if (GridArray.blocks[i, j] != null && GridArray.blocks[i, j].GetComponent<Block>().activated == true) {
							GridArray.blocks[i, j].GetComponent<Block>().activated = false;
                        }
                    }
				}
			}
		}
	}
	
	void DropLinesOverRowY(int amount, int row) {
		for(int i = 0; i < 6; i++) {
			for(int j = row; j < 12; j++) {
				if (GridArray.blocks[i, j] != null) {
					GridArray.blocks[i, j].GetComponent<Block>().activated = true;
				}
			}
		}
	}
	
	public static void SetDropVelocity(float vel) {
		
	}
	
	public void DestroyRowsOverRowY(int amount, int row) {
		for(int i = 0; i < 6; i++) {
			for(int j = row; j < row+amount; j++) {
				Destroy(GridArray.blocks[i, j]);
				GridArray.blocks[i, j] = null;
			}
		}
		DropLinesOverRowY(amount, row+amount);
		for(int i = 0; i < 6; i++) {
			for(int j = row+amount; j < 12; j++) {
				GridArray.blocks[i, j - amount] = GridArray.blocks[i, j];
			}
		}
	}
}
