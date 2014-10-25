using UnityEngine;
using System.Collections;

public class CheatCodes : MonoBehaviour {
    public  bool CheatsActive = false;
    private int  codecount = 0;

    public string CheatCode = "iddqd";

    // Use this for initialization
    void Start () {
        
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
                CheatsActive = true;

        }
    }
}


