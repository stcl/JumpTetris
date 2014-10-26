using UnityEngine;
using System.Collections;

public class Block : MonoBehaviour {
	public bool activated = false;
    public bool drop = false;

    public Vector3 speed = new Vector3(0,8,0);


    
    void Update() {
        if (drop)
        {
            transform.position -= speed * Time.deltaTime;

            if (transform.position.y < - 2f)
            {
                Destroy (gameObject);
            }
        }
    }

}
