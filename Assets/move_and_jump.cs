using UnityEngine;
using System.Collections;

public class move_and_jump : MonoBehaviour {

	public Vector2  JumpVelocity =  new Vector2 (10, 10);
	public int      JumpsLeft = 2;
	public Vector2  StartVelocity = new Vector2 (10, 0);
	public float    xx ;
    
    private bool    pressed = false;

	// Use this for initialization
	void Start ()
	{
		//rigidbody2D.velocity = StartVelocity;
        //rigidbody2D.gravityScale = 0.0f;
	}

	// Update is called once per frame
	void Update ()
	{
        if (pressed)
        {
            if(!(Input.GetKey (KeyCode.Space) || Input.GetMouseButton(0)))
                pressed = false;
        }
        else
        {
            if (Input.GetKey (KeyCode.Space) || Input.GetMouseButton(0))
            {
                
                if (JumpsLeft > 0)
                {
                    print ("jump");
                    rigidbody2D.gravityScale = 1.0f;
                    rigidbody2D.velocity = JumpVelocity;
                    JumpsLeft -= 1;
                }
                pressed = true;
                
            }
        }
	}
}
