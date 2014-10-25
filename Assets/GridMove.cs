using UnityEngine;
using System.Collections;


// Logic

public class GridMove : MonoBehaviour {

	private GameObject trackedObject;
	public bool[,] pino;
	public bool[,] usedBlocks;
	public SpawnScript spawnScript;
	public bool gridNotEmpty;

	public Vector3 bottomPosition;
	public Vector3 currentPos;
	public GameObject currentBlock;
	
	public GameObject bottomWall;
	public GameObject rightWall;
	

	void OnTriggerEnter2D(Collider2D coll) 
	{
		Debug.Log( "Gridin sisalla");
		trackedObject = coll.gameObject;

		currentBlock = trackedObject;

		Debug.Log( currentBlock.transform.position );

		gridNotEmpty = true;
		// Start the tracking
		// Make the left wall concrete

	}


	// If bounces out (left) Back or dead?
	void OnTriggerExit2D( Collider2D coll ) 
	{
		Debug.Log( "Bumbed out of grid");
		trackedObject = coll.gameObject;
		// Stop the tracking
	}




	/* Turn the block static and spawn new one*/

	void stopTheBlock()	
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

	void checkNextBlock() 
	{
		// Blocks react to others
		
	}

	void checkCollisions()
	{
		// check if on the bottom
		this.currentPos = currentBlock.transform.position;
		Vector3 bottom = this.bottomWall;

		if( currentPos == bottom )
			this.stopTheBlock();


	}
	

	void resetGrid() 
	{

		// Old array is cleaned
		pino = new bool[5,5];
		gridNotEmpty = false;

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
		//currentPos = transform.position();
		if( gridNotEmpty )
			checkCollisions();


		//blockIsStopped();
		
	}
}
