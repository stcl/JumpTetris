using UnityEngine;
using System.Collections;
using System.Collections.Generic;


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
	
	//public List<List<Vector2>> allBlocks = new List<List<Vector2>>();
	public ArrayList allBlocks = new ArrayList();
	public ArrayList nonMovingBlocks = new ArrayList();
	
	public GameObject bottomWall;
	public GameObject rightWall;
	
	
	/* The current blocks are gathered to arraylist */
	void OnCollisionEnter2D(Collision2D coll) 
	{
	
		Debug.Log( "Gridin sisalla");

		Collider2D colli = coll.collider;
		trackedObject = colli.gameObject.transform.parent.gameObject;
		currentBlock = trackedObject;
		//allBlocks.Add( currentBlock );

		//Debug.Log( currentBlock.transform.position );

		gridNotEmpty = true;
		colli = null;

		moveToGrid( currentBlock );
	
		// Start the tracking
		// Make the left wall concrete

	}


	void moveToGrid( GameObject block ) 
	{
		Transform indi;

		ArrayList blockPart = new ArrayList();

		Debug.Log( block.transform.childCount );

		for( int i=0; i < block.transform.childCount; i++ )
		{
			//Debug.Log( "Changing: " + i );

			indi = block.transform.GetChild( i );
			int gridPosX = Mathf.RoundToInt( indi.transform.position.x );
			int gridPosY = Mathf.RoundToInt( indi.transform.position.y );

			Debug.Log( "Grid X: " + gridPosX + " Y: " + gridPosY);

			pino[ gridPosX, gridPosY ] = true;

			//blockPart.Add( new Vector2( gridPosX, gridPosY ) );

			printGrid();
		
		}

		allBlocks.Add( block );

	}





	// If bounces out (left) Back or dead?
	void OnTriggerExit2D( Collider2D coll ) 
	{
		Debug.Log( "Bumbed out of grid");
		trackedObject = coll.gameObject;

		// Stop the tracking
		//allBlocks.Remove ( trackedObject );
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

			Debug.Log("Should come 3 times");

			currentBlock = block;	// probably useless...

			//Debug.Log( currentPos );

			if( currentPos.y <= bottom.y )
				stopTheBlock();
		}
	}
	

	void resetGrid() 
	{
		// Old array is cleaned
		pino = new bool[4,10];
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

	//void 

	// Use this for initialization
	void Start() 
	{
		//GameObject.FindGameObjectsWithTag("Spawn"
		resetGrid();
		
	}

	IEnumerator Counter(){
		while (true) {
			Debug.Log("ODOTA");
			yield return new WaitForSeconds (0.50F);
		}
	}
	
	void moveAllBlocks()
	{
		StartCoroutine( Counter() );

		Transform point;

		//Vector3 pos = a.transform.position;
		//a.gameObject.transform.position = new Vector3( pos.x, pos.y + 1, pos.z );

	
		//Debug.Log( allBlocks.ToString() );


		foreach( GameObject blockParts in allBlocks ) 
		{

			Debug.Log( "AAAA: " + blockParts.ToString() );

			//colli.gameObject.transform.parent.gameObject;
			Vector3 pos = blockParts.transform.position;
			blockParts.gameObject.transform.position = new Vector3( pos.x, pos.y + 1, pos.z );

			for( int i=0; i< blockParts.transform.childCount; i++ )
			{
				point =	blockParts.transform.GetChild(i);
				//pino[ (int)point.x, (int)point.y ] = false;
				pino[ 0,0] = false;

				//point.y -= 1;
				//allBlocks[i] = new GameObject 	// cheat!
				//block.transform = block.transform.position.y - 1;
				// update pino
				//pino[(int)point.x, (int)point.y - 1 ] = true;
				// check blocks collision from nearby
			}
		}
		 

	}


	// Update is called once per frame
	void Update () 
	{
		if( this.gridNotEmpty )
			moveAllBlocks();

		//printGrid();
		//currentPos = transform.position();
		//if( gridNotEmpty && currentBlock != null)
			//checkCollisions();


		//blockIsStopped();
		
	}
}
