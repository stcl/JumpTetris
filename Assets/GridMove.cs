using UnityEngine;
using System.Collections;

public class GridMove : MonoBehaviour {

	public GameObject testblock;
	public bool[,] pino;





	
	// Unit Tests

	void canStackBlocks() 
	{
		// Blocks can be on top of others

	}
	void canCollide() 
	{
		// Blocks react to others
		
	}
	void checkCollisions() 
	{
		// Grid or collider?
		
	}
	

	void resetGrid() 
	{
		// 2d array
		pino = new bool[5,5];

	}


	// Use this for initialization
	void Start () 
	{
		resetGrid();
	}
	
	// Update is called once per frame
	void Update () 
	{
		checkCollisions();
	}
}
