using UnityEngine;
using System.Collections;


// Logic

public class GridMove : MonoBehaviour {

	private GameObject trackedObject;
	public bool[,] pino;
	public bool[,] usedBlocks;
	public SpawnScript spawnScript;

	void onTriggerEnter2D( Collider2D coll ) 
	{
		Debug.Log( "Gridin sisalla");
		trackedObject = coll.gameObject;
		// Start the tracking
	}
		

	/* Unit Tests */

	void blockIsStopped()	
	{

		// Get the copy of the blocks position and rotation

		spawnScript.allowSpawn = true;
	
		if( this.isRowFull() )
			Debug.Log("Saatiin rivi tayteen");
		else
			Debug.Log("ei tullut rivi tayteen");

	}

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

		// Old array is cleaned

		pino = new bool[5,5];


	}
	
	bool isRowFull() 
	{
		// check if there is a clean row		

		for (int y = pino.GetLength(0) - 1; y >= 0; y--)
			for (int x = 0; x < pino.GetLength(1) - 1; x++)
				if( pino[y,x] == false )
				   return false;
		
		return true;

	}


	// Use this for initialization
	void Start() 
	{
		//GameObject.FindGameObjectsWithTag("Spawn"
		resetGrid();
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		checkCollisions();
		blockIsStopped();
		
	}
}
