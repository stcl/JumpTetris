using UnityEngine;
using System.Collections;


// Logical representation and handling

public class GridMove : MonoBehaviour {

	private GameObject trackedObject;
	public bool[,] pino;
	public bool[,] usedBlocks;
	public SpawnScript spawnScript;
	public bool gridNotEmpty;

	public Vector3 bottomPosition;
	public Vector3 bottom = new Vector3(0f,0f,0f); // Magic number!
    public Vector3 currentPos;
	public GameObject currentBlock;
	public ArrayList allBlocks = new ArrayList();
	
	public GameObject bottomWall;
	public GameObject rightWall;
	
	
	/* The current blocks are gathered to arraylist */
	void OnTriggerEnter2D(Collider2D coll) 
	{
		Debug.Log( "Gridin sisalla");
		trackedObject = coll.gameObject;

		currentBlock = trackedObject;
		allBlocks.Add( currentBlock );

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
		allBlocks.Remove ( trackedObject );
	}

	// Do the bottom and left check here probably....
	void OnCollisionEnter2D( Collision2D other )
	{
	
	}


	
	/* Move block from parent to grid - spawn new one */

	void stopTheBlock()	
	{
		// Get the copy of the blocks position and rotation
        // find the right block from scene/pool/parent and move

		currentPos = currentBlock.transform.position;
		int gridPosX = Mathf.RoundToInt ( currentPos.x );

		// change coordinates to grid
		Debug.Log("STOPPING THIS: " + currentPos );

		pino[ gridPosX, 0 ] = true;

		printGrid();	//Debug

		currentBlock = null;
		//currentBlock = GameObject.FindGameObjectsWithTag<>();
			
		spawnScript.allowSpawn = true;

		if( this.isRowFull() )
			Debug.Log("Saatiin rivi tayteen");
		else
			Debug.Log("ei tullut rivi tayteen");

	}



	/* Bottom and left + with each other*/
	void checkCollisions()
	{
		// check if on the bottom
		// Iterate through arraylist
		foreach( GameObject block in allBlocks ) 
		{
			this.currentPos = block.transform.position;

			Debug.Log("Should be 3 times");

			currentBlock = block;

			if( currentPos.y <= bottom.y )
				stopTheBlock();
		}
	}
	

	void resetGrid() 
	{
		// Old array is cleaned
		pino = new bool[3,3];
		gridNotEmpty = false;

	}

	// Not working correctly
	bool isRowFull() 
	{
		// check if there is a clean row by going different rows		

		for( int y = pino.GetLength(0) - 1; y >= 0; y--)
			for( int x = 0; x < pino.GetLength(1) - 1; x++) {
				if( pino[x,y] == false )
				   return false;
			}
		return true;

	}

	// Debug
	void printGrid() 
	{
		for( int y = 0; y <= pino.GetLength(0) - 1; y++)
			for( int x = 0; x < pino.GetLength(1) - 1; x++)
				Debug.Log ( "GRID: " + pino[ y,x ] );
	}



	bool moveBlockToGrid() { return true; }
	
	void canStackBlocks() { }
	
	void checkNextBlock() 
	{
        // Blocks react to others       
	}
		
	void spawnToLowerRight() {}    
    

	// Use this for initialization
	void Start() 
	{
		//GameObject.FindGameObjectsWithTag("Spawn"
		resetGrid();
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		printGrid();
		//currentPos = transform.position();
		if( gridNotEmpty && currentBlock != null)
			checkCollisions();


		//blockIsStopped();
		
	}
}
