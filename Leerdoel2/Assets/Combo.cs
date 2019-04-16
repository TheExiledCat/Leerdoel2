using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Combo : MonoBehaviour
{
    string[] quotes=new string[3];
    Text t;
    public int combo = 0;
    float timer = 0;
    public Image slider;
    public Text noti;

    void Start()
    {
        quotes[0] = "NICE COMBO";
        quotes[1] = "KEEP IT GOING";
        quotes[2] = "SPEED UP TIME";
        t = GetComponent<Text>();
        Death.OnCombo += IncreaseMulti;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > 0)
        {
            timer--;
        }
        t.text = "Multiplier: " + "\n" + combo + "X";
        slider.fillAmount = timer /2/100;
        if (timer == 0)
        {
            combo = 0;
        }
        if (combo % 5== 0&&combo!=0&&timer==199){
            noti.text = quotes[Random.Range(0,3)];
            GetComponent<AudioSource>().Play();
            Invoke("DisableText", 2f);
        }
    }
    void IncreaseMulti()
    {
        combo++;
        timer = 200;
        
    }
    void DisableText()
    {
        noti.text = "";
    }
    
}
