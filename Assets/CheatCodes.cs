using UnityEngine;
using System.Collections;

public class CheatCodes : MonoBehaviour {
    public  bool CheatsActive = false;
    private int  codecount = 0;

    public string CheatCode = "iddqd";

    private GameObject Submarine = null;

    // Use this for initialization
    void Start ()
    {
        Submarine = GameObject.Find ("Submarine");
    }
    
    // Update is called once per frame
    void Update ()
    {
        if (!CheatsActive)
        {
            if (codecount < CheatCode.Length)
            {
                if (Input.GetKey(CheatCode[codecount].ToString()))
                    codecount += 1;
            }
            else
            {
                CheatsActive = true;
                if(Submarine != null)
                    Submarine.animation.Play() ; //enabled = true;
           
            }
        }
    }

}


  