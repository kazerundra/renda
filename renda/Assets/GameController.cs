using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum Phase { battle, attack,charge,guard,special};

public class GameController : MonoBehaviour {

    GameObject player1;
    GameObject player2;
    int player;
    //メニューボタン
    GameObject menuUi;
    //連打ボタン
    GameObject button;
    //リトライボタン
    GameObject restart;
    GameObject rendaText;
    //連打あとのテクスト
    Text instruct;
    //現在のパワー
    GameObject powerText;
    Text pwrText;
    //連打出来る
    bool gamestart;
    //バトルメニューの表示
    bool battleStart;
    //何回押した
    int[] count = new int[2];

   

    private void Awake()
    {
        button = GameObject.Find("Renda");
        restart = GameObject.Find("restart");
        rendaText = GameObject.Find("Instruct");
        powerText = GameObject.Find("PowerText");
        menuUi = GameObject.Find("MenuUi");
        player1 = GameObject.Find("player1");
        player2 = GameObject.Find("player2");

    }

    // Use this for initialization
    void Start () {
        restart.SetActive(false);
        gamestart = false;
        button.GetComponent<Button>().interactable = false;
        rendaText.GetComponent<Text>().text = "ready";
        instruct = rendaText.GetComponent<Text>();
        pwrText = powerText.GetComponent<Text>();
        battleStart = false;
        button.gameObject.SetActive(false);
    }

    void StartBattle(Phase phase)
    {
        button.gameObject.SetActive(true);
        StartCoroutine(RendaStart(phase));
    }
    public void ChrgStart()
    {
        StartCoroutine(RendaStart(Phase.charge));
    }
    public void Guard()
    {
        StartCoroutine(RendaStart(Phase.guard));
    }
    public void Finish()
    {
        StartCoroutine(RendaStart(Phase.special));
    }

    public void Attack()
    {
        StartCoroutine(RendaStart(Phase.attack));
    }
    //ゲームを始まる
    private IEnumerator RendaStart(Phase phase)
    {
        menuUi.SetActive(false);
        button.gameObject.SetActive(true);
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
        //パワーを上げる
        if(phase == Phase.charge)
        {
            if (player == 1)
            {
                count[0] *= 100;
                instruct.fontSize = 20;
                instruct.text = "パワーが\n" + count.ToString() + "アップ";
                player1.GetComponent<player>().power += count[0];
                pwrText.text = player1.GetComponent<player>().power.ToString();
                count[0] = 0;
            }
            else
            {
                count[1] *= 100;
                instruct.fontSize = 20;
                instruct.text = "パワーが\n" + count.ToString() + "アップ";
                player2.GetComponent<player>().power += count[0];
                pwrText.text = player2.GetComponent<player>().power.ToString();
                count[1] = 0;
            }
           
        }else if(phase == Phase.guard)
        {
            if (player == 1)
            {
                count[0] *= 100;
                instruct.fontSize = 20;
                instruct.text = "パワーが\n" + count.ToString() + "アップ";
                player1.GetComponent<player>().power += count[0];
                pwrText.text = player1.GetComponent<player>().power.ToString();
                count[0] = 0;
            }
            else
            {
                count[1] *= 100;
                instruct.fontSize = 20;
                instruct.text = "パワーが\n" + count.ToString() + "アップ";
                player2.GetComponent<player>().power += count[0];
                pwrText.text = player2.GetComponent<player>().power.ToString();
                count[1] = 0;
            }
        }else if (phase == Phase.attack)
        {

        }
        else if (phase == Phase.special)
        {

        }
        yield return new WaitForSeconds(5.0f);
        instruct.fontSize = 50;
        button.gameObject.SetActive(false);
        menuUi.SetActive(true);

    }
	
    //ボタン押せばcount増やす
    public void PushButton()
    {
        if(player == 1)
        {
            count[0] += 1;
        }
        else
        {
            count[1] += 1;
        }
       
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
