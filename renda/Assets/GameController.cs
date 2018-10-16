using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum Phase { battle, attack,charge,guard};

public class GameController : MonoBehaviour {

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
    int count;
    //パワー (攻撃)
    int power;

    private void Awake()
    {
        button = GameObject.Find("Renda");
        restart = GameObject.Find("restart");
        rendaText = GameObject.Find("Instruct");
        powerText = GameObject.Find("PowerText");
        menuUi = GameObject.Find("MenuUi");

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
        power =10;

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
            count *= 100;
            instruct.fontSize = 20;
            instruct.text = "パワーが\n" + count.ToString() + "アップ";
            power += count;
            pwrText.text = power.ToString(); 
            count = 0;
        }
        yield return new WaitForSeconds(5.0f);
        instruct.fontSize = 50;
        button.gameObject.SetActive(false);
        menuUi.SetActive(true);

    }
	
    //ボタン押せばcount増やす
    public void PushButton()
    {
        count += 1;
    }
    //リスタートゲーム
    //public void Restart()
    //{
    //    count = 0;
    //    StartCoroutine(RendaStart());
    //    restart.SetActive(false);
    //}

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
