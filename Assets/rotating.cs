using UnityEngine;
using System.Collections;

public class rotating : MonoBehaviour {
        
        public GameObject   Block = null;
        public float        Rotation = 0.0f;
        //public Vector2  StartVelocity = new Vector2 (10, 0);
        //public float    xx ;
        
        private bool    pressed = false;
        
        // Use this for initialization
        void Start ()
        {
                if (Block == null)
                    print ("Block is null");
        }
        
        // Update is called once per frame
        void Update ()
        {
            if (pressed)
            {
                if(!(Input.GetKey (KeyCode.LeftArrow) || Input.GetKey (KeyCode.LeftArrow)))
                    pressed = false;
            }
            else
            {
                if(Input.GetKey (KeyCode.LeftArrow))
                {
                    pressed = true;
                    Rotation -= 90;
                }

                if(Input.GetKey (KeyCode.LeftArrow))
                {
                    pressed = true;

                }
            }
        }
}
