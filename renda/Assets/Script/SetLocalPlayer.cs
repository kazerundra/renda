using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class SetLocalPlayer : NetworkBehaviour {
    public int playerNumber=1;
    private int playerCount = 0;

 
    private void Start()
    {
        //if (isLocalPlayer)
        //{
        //    GetComponent<player>().enabled = true;
        //}
    }
 
    public void FindPlayer()
    {
    }
	
}
