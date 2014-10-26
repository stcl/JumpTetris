using UnityEngine;
using System.Collections;

public class move_and_jump : MonoBehaviour {

	public float  JumpVelocityY = 10f;
	public float  JumpVelocityX;
	public int      JumpsLeft = 2;
	public Vector2  StartVelocity = new Vector2 (10, 0);
	public float    CheatDownSpeed = 20f ;

    public GameObject GameOBJ_Scripts = null;

    private bool    pressed = false;
    public bool    GoingDown = false;
    private CheatCodes cheats = null;

	// Use this for initialization
	void Start ()
	{

        if (GameOBJ_Scripts == null)
        {
            GameOBJ_Scripts = GameObject.Find("Scripts");
        }

        if (GameOBJ_Scripts != null)
        {
            cheats = GameOBJ_Scripts.GetComponent<CheatCodes>();
        }
        print (cheats);
		//rigidbody2D.velocity = StartVelocity;
        //rigidbody2D.gravityScale = 0.0f;
        GoingDown = false;
	}

	// Update is called once per frame
	void Update ()
	{
        if (Input.GetKeyDown (KeyCode.Space) || Input.GetMouseButton (0))
        {
        
            if (JumpsLeft > 0)
            {
                print ("jump");
                rigidbody2D.gravityScale = 1.0f;
                JumpVelocityX = rigidbody2D.velocity.x;
                rigidbody2D.velocity = new Vector2 (JumpVelocityX, JumpVelocityY);
                JumpsLeft -= 1;
            }
            pressed = true;
        
        }

        if (Input.GetKeyDown (KeyCode.DownArrow))
        {
        //if(cheats != null)
            //if(cheats.CheatsActive)
            //{
                //print ("cheats actve");
            rigidbody2D.velocity = new Vector2 (0, -CheatDownSpeed); //rigidbody2D.velocity.y);
            GoingDown = true;
			rigidbody2D.gravityScale = 1.0f;
        //}
        }
    }
}
