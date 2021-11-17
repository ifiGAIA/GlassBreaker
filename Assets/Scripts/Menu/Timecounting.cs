using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timecounting : MonoBehaviour
{
    float timer_f = 60f;
    int timer_i = 0;
    int minute = 0;
    int second = 0;
    // Update is called once per frame
    void Update()
    {
        timer_f -= Time.deltaTime;
        timer_i = (int)timer_f;
        turn_time();
        Second();
        //印出時間動作
        // if (minute < 10) 
        // {
            
        //     if (second < 10)
        //     {
        //         GetComponent<Text>().text = "秒數:0" + minute + ":0" + second;
        //     }
        //     else 
        //     {
        //         GetComponent<Text>().text = "秒數:0" + minute + ":" + second;
        //     }
        // }
        // else 
        // {
        //     if (second < 10)
        //     {
        //         GetComponent<Text>().text = "秒數:" + minute + ":0" + second;
        //     }
        //     else
        //     {
        //         GetComponent<Text>().text = "秒數:" + minute + ":" + second;
        //     }
        // }
    }
    void Second()
    {
        if (second < 10 && second > 0)
        {
            GetComponent<Text>().text = "秒數 : 0" + second;
        }
        else if(second >=10)
        {
            GetComponent<Text>().text = "秒數 : " + second;
        }
        else
        {
            GetComponent<Text>().text = "秒數 : 00";
        }

    }
    void turn_time() 
    {
        minute = timer_i / 60;
        second = timer_i %60;
    }
}
