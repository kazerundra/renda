using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class player : MonoBehaviour {
    //パワー (攻撃)
    public int power;
    //シールド(ダメージを増減)
    public int shield;
    public int playerNumber;
    public float hp;
    public float hpafter;
    public GameObject hpsl;
    public Slider hpSlider;
    public GameObject gamecontroller;
    bool takedamage;
    int damage;

    // Use this for initialization
    private void Awake()
    {
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
    void Start () {
        hpSlider = hpsl.GetComponent<Slider>();
        power = 10;
        hp = 100000;
        hpSlider.maxValue = hp;
        hpSlider.value = hp;

    }
   
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
        }
        
    }

    public void TakeDamage(int dmg)
    {
        damage = dmg;
        takedamage = true;
        Debug.Log(damage);
        hpafter = hp - damage;
    }

    // Update is called once per frame
    void Update () {
        if (takedamage)
        {

            Hpreduce();
        }
       
	}
}
