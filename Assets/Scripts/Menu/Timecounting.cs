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
    public AudioSource audioSource;
    public Host host;
    // Start is called before the first frame update
    void Start()
    {
        host = host.GetComponent<Host>();
        if(GameManager.Instance.gameDegreeOfDifficulty == GameDegreeOfDifficulty.Simple)
        {
            timer_F = 60;
            GetComponent<Text>().text = "秒數 : 60";
        }
        else if(GameManager.Instance.gameDegreeOfDifficulty == GameDegreeOfDifficulty.Difficulty)
        {
            timer_F = 80;
            GetComponent<Text>().text = "秒數 : 80";
        }
        gamestart = false;
        timer_f = timer_F;
        timer_i = timer_I;
        audioSource = GetComponent<AudioSource>();
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
        if(Input.GetKeyDown(KeyCode.A))
        {
            gamestart = true;
            audioSource.Play();
        }
    }
    public void TimeSound()
    {
        audioSource.Play();
    }
    void Second()
    {
        if (second < 10 && second > 0)
        {
            GetComponent<Text>().text = "秒數 : 0" + second;
            audioSource.volume = 1;
        }
        else if(second >=10)
        {
            GetComponent<Text>().text = "秒數 : " + second;
        }
        else
        {
            GetComponent<Text>().text = "秒數 : 60";
            audioSource.Stop();
        }
    }
    public void ReTime()
    {
        gamestart = false;
        timer_f = timer_F;
        timer_i = timer_I;
        if(GameManager.Instance.gameDegreeOfDifficulty == GameDegreeOfDifficulty.Simple)
        {
            GetComponent<Text>().text = "秒數 : 60";
        }
        else if(GameManager.Instance.gameDegreeOfDifficulty == GameDegreeOfDifficulty.Difficulty)
        {
            GetComponent<Text>().text = "秒數 : 80";
        }
        host.Reload();
    }
    
    void turn_time() 
    {
        minute = timer_i / 80;
        second = timer_i % 80;
    }
}
