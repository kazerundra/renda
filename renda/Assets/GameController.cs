using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum Phase { battle, attack,charge,guard,special};
public enum Gamemode {single, multi };

public class GameController : MonoBehaviour {


    public Gamemode mode = Gamemode.single;
    public GameObject player1;
    public GameObject player2;
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
    GameObject powerText2;

    //コマンドセレクトのTEXT
    GameObject actionText1;
    GameObject actionText2;

    Text pwrText;
    Text pwrText2;
    //連打出来る
    bool gamestart;
    //何回押した
    int[] count = new int[2];
    //プレイヤーがコマンド入力しましたか
    public bool ready1, ready2;
    bool allready;



   

    private void Awake()
    {
        button = GameObject.Find("Renda");
        restart = GameObject.Find("restart");
        rendaText = GameObject.Find("Instruct");
        powerText = GameObject.Find("PowerText");
        powerText2 = GameObject.Find("PowerText2");
        menuUi = GameObject.Find("MenuUi");
        player1 = GameObject.Find("Player1");
        player2 = GameObject.Find("Player2");
        actionText1 = GameObject.Find("Action");
        actionText2 = GameObject.Find("Action2");
    }

    // Use this for initialization
    void Start () {
        player = 1;
        count[0] = 0;
        count[1] = 0;

        //restart.SetActive(false);
        gamestart = false;
        button.GetComponent<Button>().interactable = false;
        rendaText.GetComponent<Text>().text = "ready";
        instruct = rendaText.GetComponent<Text>();
        pwrText = powerText.GetComponent<Text>();
        pwrText2= powerText2.GetComponent<Text>();
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
    //テクストを変更
    public void ActionChange(Phase phase)
    {
        GameObject acttxt;
        if (player == 1)
        {
            acttxt = actionText1;
            if (phase == Phase.attack) acttxt.GetComponent<Text>().text = "攻撃";
            else if (phase == Phase.guard) acttxt.GetComponent<Text>().text = "ガード";
            else if (phase == Phase.charge) acttxt.GetComponent<Text>().text = "チャージ";
            else if (phase == Phase.special) acttxt.GetComponent<Text>().text = "必殺";
        } else
        {
            acttxt = actionText2;
            if (phase == Phase.attack) acttxt.GetComponent<Text>().text = "攻撃";
            else if (phase == Phase.guard) acttxt.GetComponent<Text>().text = "ガード";
            else if (phase == Phase.charge) acttxt.GetComponent<Text>().text = "チャージ";
            else if (phase == Phase.special) acttxt.GetComponent<Text>().text = "必殺";
        }
    }
    private void AiBattle(int random)
    {
       
        //攻撃
        if (random == 1)
        {
            ready2 = true;            
            count[1] *= 2;
            instruct.fontSize = 20;
            //instruct.text = "パワーが\n" + count.ToString() + "アップ";
            float damage = (player2.GetComponent<player>().power * count[1]) / 100;
            int Dmg = (int)damage;
            player1.GetComponent<player>().TakeDamage(Dmg);
            count[1] = 0;
        }//チャージ
        else if (random == 2)
        {
            ready2 = true;
            count[1] *= 100;
            instruct.fontSize = 20;
            //instruct.text = "パワーが\n" + count[1].ToString() + "アップ";
            player2.GetComponent<player>().power += count[1];
            pwrText2.text = player2.GetComponent<player>().power.ToString();
            count[1] = 0;
           
        }//ガード
        else if (random == 3)
        {            
            ready2 = true;          
            count[1] *= 200;
            instruct.fontSize = 20;           
            player2.GetComponent<player>().shield += count[1] + player2.GetComponent<player>().power;
            count[1] = 0;
        }//必殺
        else if (random == 4)
        {
            if (player == 2)
            {
                ready2 = true;         
                float percent = count[0];
                count[1] *= 2;
                count[1] += 100;
                instruct.fontSize = 20;
                //instruct.text = "パワーが\n" + count.ToString() + "アップ";
                float damage = (player2.GetComponent<player>().power * count[1]) / 100;
                int Dmg = (int)damage;
                player1.GetComponent<player>().TakeDamage(Dmg);
                Debug.Log(Dmg);
                count[1] = 0;
                player1.GetComponent<player>().ReducePower(percent);
                pwrText.text = ((int)player2.GetComponent<player>().power).ToString();
            }
        }
    }


    //バトル開始
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
        //チャージの場合
        if(phase == Phase.charge)
        {            
            if (player == 1)
            {
                ready1 = true;
                while (allready == false)
                {
                    yield return null;
                }
                count[0] *= 100;
                instruct.fontSize = 20;
                instruct.text = "パワーが\n" + count[0].ToString() + "アップ";
                player1.GetComponent<player>().power += count[0];
                pwrText.text = player1.GetComponent<player>().power.ToString();
                Debug.Log(player1.GetComponent<player>().power);
                count[0] = 0;
            }
            else
            {
                ready2 = true;
                while (allready == false)
                {
                    yield return null;
                }
                count[1] *= 100;
                instruct.fontSize = 20;
                instruct.text = "パワーが\n" + count[1].ToString() + "アップ";
                player2.GetComponent<player>().power += count[0];
                pwrText2.text = player2.GetComponent<player>().power.ToString();
                count[1] = 0;
            }

           
        }else if(phase == Phase.guard) //ガードの場合
        {
            if (player == 1)
            {
                count[0] *= 200;
                player1.GetComponent<player>().shield += count[0] + player1.GetComponent<player>().power;
                count[0] = 0;
                ready1 = true;
                while (allready == false)
                {
                    yield return null;
                }
                instruct.fontSize = 20;
                instruct.text = "ガード";

            }
            else
            {
                count[1] *= 200;    
                player2.GetComponent<player>().shield += count[1] + player2.GetComponent<player>().power;
                count[1] = 0;
                ready2 = true;
                while (allready == false)
                {
                    yield return null;
                }
                instruct.fontSize = 20;
                instruct.text = "ガード";
            }
        }else if (phase == Phase.attack) //攻撃の場合
        {
            if (player == 1)
            {
                ready1 = true;
                while (allready == false)
                {
                    yield return null;
                }
                count[0] *=2;
                instruct.fontSize = 20;
                //instruct.text = "パワーが\n" + count.ToString() + "アップ";
                float damage = ((player1.GetComponent<player>().power* count[0])/100);
                int Dmg = (int)damage;
                player2.GetComponent<player>().TakeDamage(Dmg);
                count[0] = 0;
            }
            else
            {
                ready2 = true;
                while (allready == false)
                {
                    yield return null;
                }
                count[1] *= 2;
                instruct.fontSize = 20;
                //instruct.text = "パワーが\n" + count.ToString() + "アップ";
                float damage = (player2.GetComponent<player>().power * count[0]) / 100;
                int Dmg = (int)damage;
                player1.GetComponent<player>().TakeDamage(Dmg);
                count[1] = 0;
            }
        }
        else if (phase == Phase.special) //必殺技の場合
        {
            if (player == 1)
            {
                ready1 = true;
                while (allready == false)
                {
                    yield return null;
                }
                float percent = count[0];
                count[0] *=2;
                count[0] += 100;
                instruct.fontSize = 20;
                //instruct.text = "パワーが\n" + count.ToString() + "アップ";
                float damage = (player1.GetComponent<player>().power * count[0]) / 100;
                int Dmg = (int)damage;
                player2.GetComponent<player>().TakeDamage(Dmg);
                Debug.Log(Dmg);
                count[0] = 0;
                player1.GetComponent<player>().ReducePower(percent);
                pwrText.text = ((int)player1.GetComponent<player>().power).ToString();

            }
            else
            {
                if (player == 2)
                {
                    ready2 = true;
                    while (allready == false)
                    {
                        yield return null;
                    }
                    float percent = count[0];
                    count[1] *= 2;
                    count[1] += 100;
                    instruct.fontSize = 20;
                    //instruct.text = "パワーが\n" + count.ToString() + "アップ";
                    float damage = (player2.GetComponent<player>().power * count[0]) / 100;
                    int Dmg = (int)damage;
                    player1.GetComponent<player>().TakeDamage(Dmg);
                    Debug.Log(Dmg);
                    count[1] = 0;
                    player1.GetComponent<player>().ReducePower(percent);
                    pwrText.text = ((int)player2.GetComponent<player>().power).ToString();
                }
            }
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
           // Debug.Log(count[0]);
        }
        else
        {
            count[1] += 1;
        }
       
    }
  
    // Update is called once per frame
    void Update () {
        if(mode == Gamemode.single)
        {
            if(ready1 == true)
            {
                int random;
                if (player2.GetComponent<player>().power < 10000 &&player2.GetComponent<player>().power >5000)
                {
                    if(player1.GetComponent<player>().power < 6000)
                    {
                        random = Random.Range(1, 2);
                    }
                    else
                    {
                        random = Random.Range(1, 3);
                    }                    
                    count[1] = Random.Range(20, 40);
                    Debug.Log(random +" npc");
                    AiBattle(random);
                }
                else if (player2.GetComponent<player>().power < 5000)
                {
                    count[1] = Random.Range(40, 60);
                    random = 2;
                    Debug.Log(random + "npc");
                    AiBattle(random);
                }
                else
                {
                    if (player1.GetComponent<player>().power < 6000)
                    {
                        random = Random.Range(1, 4);
                        if(random == 3)
                        {
                            random = Random.Range(1, 2);
                        }
                    }
                    else
                    {
                        random = Random.Range(1, 4);
                    }
                    random = Random.Range(1, 4);
                    count[1] = Random.Range(25, 60);
                    Debug.Log(random+ "npc");
                    AiBattle(random);
                }                
                ready2 = true;
            }
        }
        if (ready1 && ready2)
        {
            allready = true;
            ready1 = false;
            ready2 = false;
        }
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
