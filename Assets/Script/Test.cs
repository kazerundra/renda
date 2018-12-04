using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Test : NetworkBehaviour {
    public int playerNumber = 0;
	public GameObject playerObject;
	public GameObject netWorkId;
    //has authority itu yg server jadinya buat tentuin nomor gk bs.
	public void setNetworkGameobject(GameObject go)
	{
		netWorkId = go;
	}
		

    public override void OnStartClient()
    {
        if (hasAuthority)
        {
            playerNumber = 1;
            transform.position = new Vector3(-3, 0, 0);
            playerObject = GameObject.Find("Player1");
			Debug.Log (netWorkId);
			//playerObject.GetComponent<player>().setPlayerId(netWorkId) ;
            playerObject.GetComponentInChildren<Camera>().enabled = true;
        }
        else
        {
            playerNumber = 2;
            transform.position = new Vector3(3, 0, 0);
            playerObject = GameObject.Find("Player2");
            playerObject.GetComponentInChildren<Camera>().enabled = false;
        }
//        Log("Call OnStartClient.: " + gameObject.GetInstanceID(), "yellow");
//        Log("isClient = " + isClient, "yellow");
//        Log("isServer = " + isServer, "yellow");
//        Log("hasAuthority = " + hasAuthority, "yellow");
    }

    public override void OnStartServer ()
    {
        if (hasAuthority)
        {
            playerNumber = 1;
            transform.position = new Vector3(-3, 0, 0);
            playerObject = GameObject.Find("Player1");
			Debug.Log (netWorkId);
			//playerObject.GetComponent<player>().setPlayerId(netWorkId) ;
            playerObject.GetComponentInChildren<Camera>().enabled = true;
        }
        else
        {
            playerNumber = 2;
            transform.position = new Vector3(3, 0, 0);
            playerObject = GameObject.Find("Player2");
            playerObject.GetComponentInChildren<Camera>().enabled = false;
        }
        Log("Call OnStartServer.: " + gameObject.GetInstanceID(),"purple");
        Log("isClient = " + isClient, "purple");
        Log("isServer = " + isServer, "purple");
        Log("hasAuthority = " + hasAuthority, "purple");
    }

    public override void OnStartAuthority()
    {
        Log("Call OnStartAuthority.: " + gameObject.GetInstanceID(), "cyan");
        Log("isClient = " + isClient, "cyan");
        Log("isServer = " + isServer, "cyan");
        Log("hasAuthority = " + hasAuthority, "cyan");

        playerNumber = 1;
        transform.position = new Vector3(-3, 0, 0);
		playerObject = GameObject.Find("Player1");
		Debug.Log (netWorkId);
		//playerObject.GetComponent<player>().setPlayerId(netWorkId) ;
        playerObject.GetComponentInChildren<Camera>().enabled = true;   
	}

    public void Log ( string text, string color )
    {
        Debug.Log(string.Format("<color={0}>{1}</color>", color, text));
    }

    // Use this for initialization
    void Start () {
		//if (hasAuthority || isServer)
  //      {
  //          playerNumber = 1;
  //          transform.position = new Vector3(-3, 0, 0);
		//	playerObject = GameObject.Find ("Player1");
		//	playerObject.GetComponentInChildren<Camera> ().enabled = true;
		//}else
  //      {
  //          playerNumber = 2;
  //          transform.position = new Vector3(3, 0, 0);
		//	playerObject = GameObject.Find ("Player2");
		//	playerObject.GetComponentInChildren<Camera> ().enabled = false;
  //      } 
       
		
	}
	
	// Update is called once per frame
	void Update () {       
        if (hasAuthority)
        {
            
            if (Input.GetKeyDown(KeyCode.Space))
            {
                this.transform.Translate(0, 1, 0);
            }
            if (Input.GetKeyDown(KeyCode.Tab))
            {
                this.transform.Translate(0, -1, 0);
            }
        }


    }
}
