using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class SetLocalPlayer : NetworkBehaviour {
    //public int playerNumber=1;
    public GameObject PlayerPrefab;
    public GameObject Server;
    public GameObject myUnit;
    public int count=0;
	public bool ready =false;
	bool setNet= false;


    private void Start()
    {               
        if (!isLocalPlayer)
        {
            return;
        }
        if (isLocalPlayer)
        {
            if (isClient) myUnit = GameObject.Find("Player2");
            if (isServer) myUnit = GameObject.Find("Player1");
            //if (isLocalPlayer) Server = GameObject.Find("NetworkManager");
          //  CmdSpawnPlayer();
           // Server.GetComponent<ServerController>().CmdSetPlayerNumber(this.gameObject);
        }        
    }
    [Command]
    void CmdSpawnPlayer()
    {
       // GameObject go = Instantiate(PlayerPrefab);
      //  NetworkServer.SpawnWithClientAuthority(go, connectionToClient);
        //myUnit = go;
		//myUnit.transform.position = new Vector3 (-3, -3, 0);
    }
    [Command]
    void CmdMovePlayer()
    {
        if(myUnit == null)
        {
            return;
        }
        myUnit.transform.Translate(0, 1, 0);

    }
	public bool CmdGetReady()
	{
		return ready;
	}

	[Command]
	public void CmdSetReady(bool state)
	{
		ready = state;
	}
    public int GetCount()
    {
        return count;
    }

    [Command]
    public void CmdSetCount(int cnt)
    {
        count = cnt;
    }
    private void Update()
    {
        if (!isLocalPlayer)
        {
            return;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            CmdMovePlayer();
        }
        if (setNet == false)
        {
            myUnit.GetComponent<player>().SetNetworkGameobject(this.gameObject);
            if (myUnit.GetComponent<player>().netWorkId != null)
                setNet = true;
        }
    }


}
