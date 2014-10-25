using UnityEngine;
using System.Collections;

public class Collides : MonoBehaviour {
	private int[] topBlockColumn = new int[] {0, 0, 0, 0, 0, 0};
	private int[] collidersBottomColumn = new int[] {11, 11, 11, 11, 11, 11};
	private int dropAmount = 11;
	float yVelocity;
	
	void Update() {

	}
	
	void OnCollisionEnter2D () {
		yVelocity = GetComponent<Rigidbody2D>().velocity.y;
		CheckTopBlockColumn();
		foreach(Transform child in transform) {
			child.position = new Vector3(Mathf.RoundToInt(child.position.x - 0.5F), Mathf.RoundToInt(child.position.y - 0.5F), 0);
			if (child.position.x >= 0 && child.position.y >= 0) {
				Debug.Log((int)child.position.x + ", " + (int)child.position.y);
				GridArray.blocks[(int)child.position.x, (int)child.position.y] = child.gameObject;
				if ((int)child.position.y < collidersBottomColumn[(int)child.position.x]) {
					collidersBottomColumn[(int)child.position.x] = (int)child.position.y;
				}
				child.position = new Vector3(child.position.x + 0.5F, child.position.y + 0.5F, 0);
				child.GetComponent<Block>().activated = true;
			}
		}
		transform.DetachChildren();
        Destroy(gameObject);
		for(int i = 0; i < 6; i++) {
			Debug.Log(collidersBottomColumn[i] - topBlockColumn[i] + " " + collidersBottomColumn[i] + " " + topBlockColumn[i]);
			if(collidersBottomColumn[i] - topBlockColumn[i] < dropAmount) {
				dropAmount = collidersBottomColumn[i] - topBlockColumn[i];
			}
		}
		Debug.Log(dropAmount);
		GridArray.dropAmount = dropAmount;
		GridArray.yVelocity = yVelocity;
	}
	
	void CheckTopBlockColumn() {
		for(int i = 0; i < 6; i++) {
			for(int j = 0; j < 12; j++) {
				if (GridArray.blocks[i, j] != null) {
					topBlockColumn[i] = j;
				}
			}
		}
	}
	
}
