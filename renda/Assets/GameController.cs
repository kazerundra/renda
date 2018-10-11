using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    //連打ボタン
    GameObject button;
    //リトライボタン
    GameObject restart;
    GameObject text;
    Text instruct;
    //連打出来る
    bool gamestart;
    //何回押した
    int count;
    private void Awake()
    {
        button = GameObject.Find("Renda");
        restart = GameObject.Find("restart");
        text = GameObject.Find("Instruct");
    }

    // Use this for initialization
    void Start () {
        restart.SetActive(false);
        gamestart = false;
        button.GetComponent<Button>().interactable = false;
        text.GetComponent<Text>().text = "ready";
        instruct = text.GetComponent<Text>();
        StartCoroutine(GameStart());
	}

    //ゲームを始まる
    private IEnumerator GameStart()
    {
        instruct.text = "3";
        yield return new WaitForSeconds(1.0f);
        instruct.text = "2";
        yield return new WaitForSeconds(1.0f);
        instruct.text = "1";
        yield return new WaitForSeconds(1.0f);
        instruct.text = "GO";
        gamestart = true;
        yield return new WaitForSeconds(5.0f);
        gamestart = false;
        instruct.text = "戦闘力:\n " + count.ToString();
        restart.SetActive(true);
    }
	
    //ボタン押せばcount増やす
    public void PushButton()
    {
        count += 200;
    }
    //リスタートゲーム
    public void Restart()
    {
        count = 0;
        StartCoroutine(GameStart());
        restart.SetActive(false);
    }

    // Update is called once per frame
    void Update () {
        //リトライボタンを押せるかどうか
        if (gamestart)
        {
            button.GetComponent<Button>().interactable = true;
        } else
        {
            button.GetComponent<Button>().interactable = false;
        }
		
	}
}
