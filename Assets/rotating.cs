using UnityEngine;
using System.Collections;

public class rotating : MonoBehaviour {
        

        public float        Rotation = 0.0f;
        //public Vector2  StartVelocity = new Vector2 (10, 0);
        //public float    xx ;
        
        private bool    pressed = false;
        
        // Use this for initialization
        void Start ()
        {

        }
        
        // Update is called once per frame
        void Update ()
        {
            if (pressed)
            {
                if(!(Input.GetKey (KeyCode.LeftArrow) || Input.GetKey (KeyCode.RightArrow)))
                    pressed = false;
            }
            else
            {
                if(Input.GetKey (KeyCode.LeftArrow))
                {
                    //print ("Left");
                    pressed = true;
                    Rotation -= 90;
                    if(Rotation < 0)    
                        Rotation += 360;
                    Quaternion rot = Quaternion.AngleAxis(Rotation, Vector3.back);
                                print (rot);
                    transform.rotation = rot;

                }

                if(Input.GetKey (KeyCode.RightArrow))
                {
                    //print ("Right");
                    pressed = true;
                    Rotation += 90;

                    if(Rotation > 360)
                        Rotation -= 360;
                    Quaternion rot = Quaternion.AngleAxis(Rotation, Vector3.back);
                                print (rot);

                    transform.rotation = rot;

                }

                


            }
        }
}




