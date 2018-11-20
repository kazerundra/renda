using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class SetLocalPlayer : NetworkBehaviour {
    public int playerNumber=1;
    public GameObject PlayerPrefab;
    GameObject myUnit;



 
    private void Start()
    {
              
        if (!isLocalPlayer)
        {
            return;
        }
        if (isLocalPlayer)
        {         
            CmdSpawnPlayer();           
        }
        
    }
    [Command]
    void CmdSpawnPlayer()
    {
        GameObject go = Instantiate(PlayerPrefab);
        NetworkServer.SpawnWithClientAuthority(go, connectionToClient);
        myUnit = go;
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

    public void FindPlayer()
    {
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
    }


}
