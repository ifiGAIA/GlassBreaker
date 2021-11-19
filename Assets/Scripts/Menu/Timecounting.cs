using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timecounting : MonoBehaviour
{
    float timer_f = 10f;
    int timer_i = 10;
    int minute = 0;
    public int second;
    public bool gamestart;
    public float timer_F;
    private int timer_I = 10;
    // Start is called before the first frame update
    void Start()
    {
        gamestart = false;
        timer_f = timer_F;
        timer_i = timer_I;
    }
    // Update is called once per frame
    void Update()
    {
        turn_time();
        if(gamestart)
        {
            timer_f -= Time.deltaTime;
            timer_i = (int)timer_f;
            Second();
        }
        if(second == 0)
        {
            ReTime();
        }
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
            GetComponent<Text>().text = "秒數 : 60";
        }
    }
    public void ReTime()
    {
        gamestart = false;
        timer_f = timer_F;
        timer_i = timer_I;
        GetComponent<Text>().text = "秒數 : 60";
    }
    
    void turn_time() 
    {
        minute = timer_i / 60;
        second = timer_i %60;
    }
}
