using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class SaveSystem : MonoBehaviour {

    public Gamemode mode;

    public void Awake()
    {
       
       
    }
    public void OnStartServer()
    {

    }

    public void Single()
    {
        DontDestroyOnLoad(this);
        mode = Gamemode.single;
        SceneManager.LoadScene("Game");
    }
    public void Multi()
    {
        
        DontDestroyOnLoad(this);
        mode = Gamemode.multi;
        SceneManager.LoadScene("Lobby");
    }
}
