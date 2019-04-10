﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    Text counterText;

    public float seconds, minutes;
    [HideInInspector]
    public int points;


    // Start is called before the first frame update
    void Start()
    {
        
        counterText = GetComponent<Text>() as Text;
    }

    // Update is called once per frame
    void Update()
    {
        points++;
        minutes = (int)(Time.time / 60f);
        seconds = (int)(Time.time % 60f);
        counterText.text = "Time: "+minutes.ToString("00") + ":" + seconds.ToString("00")+"\n"+"Points: "+points;
        
        

    }
}
