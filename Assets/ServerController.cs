using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine;

public class ServerController : NetworkBehaviour {
    public GameObject setPlayer1;
    public GameObject setPlayer2;
    [Command]
    public void CmdSetPlayerNumber(GameObject player)
    {
        if (setPlayer1 == null)
        {
            setPlayer1 = player;
        }
        else
        {
            setPlayer2 = player;
        }
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
