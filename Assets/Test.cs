using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Test : NetworkBehaviour {
    public int playerNumber = 0;
    //has authority itu yg server jadinya buat tentuin nomor gk bs.

	// Use this for initialization
	void Start () {
        if (hasAuthority)
        {
            playerNumber = 1;
            transform.position = new Vector3(-3, -3, 0);
        }
        else
        {
            playerNumber = 2;
            transform.position = new Vector3(3, 3, 0);
        } 
       
		
	}
	
	// Update is called once per frame
	void Update () {       
        if (hasAuthority)
        {
            
            if (Input.GetKeyDown(KeyCode.Space))
            {
                this.transform.Translate(0, 1, 0);
            }
        }


    }
}
