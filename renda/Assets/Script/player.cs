using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class player : MonoBehaviour {
    //パワー (攻撃)
    public float power;
    //シールド(ダメージを増減)
    public float shield;
    public int playerNumber;
    public float hp;
    public float hpafter;
    public GameObject hpsl;
    public Slider hpSlider;
    public GameObject gamecontroller;
    bool takedamage;
    public float damage;


    private void Awake()
    {
        playerNumber = GetComponent<SetLocalPlayer>().playerNumber;
        gamecontroller = GameObject.Find("GameController");
        if (playerNumber == 1)
        {
            hpsl = GameObject.Find("HpSlider");
        }
        else
        {
            hpsl = GameObject.Find("HpSlider2");
        }

    }
    void Start()
    {

        hpSlider = hpsl.GetComponent<Slider>();
        power = 10;
        hp = 50000;
        hpSlider.maxValue = hp;
        hpSlider.value = hp;
        shield = 0;

    }



    //uiにHPが受けた時下がる
    private void Hpreduce()
    {
       if (hp >hpafter )
        {
            hp -= 5000.0f * Time.deltaTime;
            hpSlider.value = hp;

        }
        else
        {
            takedamage = false;
            damage = 0;
            hp = hpafter;
            hpSlider.value = hpafter;
            hpafter = 0;            
            if (hp <= 0) SceneManager.LoadScene("GameOver");
        }
        
    }
    //パワーを下げる
    // power マイナス　100%-連打% *power
    public void ReducePower(float percent)
    {
        power -= (((100-percent) / 100) * power);
    }

    //ダメージ受ける
    public void TakeDamage(int dmg)
    {
        damage = dmg - shield;        
        if (damage < 0) damage = 0;        
        takedamage = true;
        Debug.Log( "player" + playerNumber+ "take "+ damage);
        hpafter = hp - damage;
        shield = 0;
    }

    // Update is called once per frame
    void Update () {
        if (takedamage)
        {

            Hpreduce();
        }
       
	}
}
