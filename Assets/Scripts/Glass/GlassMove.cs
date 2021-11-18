using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameLevel
{
    Game1,
    Game2,
    Game3,
    GameOver
}
public class GlassMove : MonoBehaviour
{
    GlassInstantiate glassInstantiate;
    public Timecounting timecounting;
    public Scoreboard scoreboard;
    public GameLevel gameLevel;
    public bool moveistrue = false;
    private float PosZ;
    private Vector3 finalPos;
    public bool glassisbroken = false; 
    public float speed = 5f;

    public bool timesUp;
    public bool noglass;

    public int glasscount = 0;
    public float gameswitchTime = 0f;

    public AudioClip glassshatter;
    AudioSource audioSource;
    private bool glassaudio;
    
    // Start is called before the first frame update
    void Start()
    {
        glassInstantiate = GameObject.Find("Glass").GetComponent<GlassInstantiate>();
        timecounting = timecounting.GetComponent<Timecounting>();
        scoreboard = scoreboard.GetComponent<Scoreboard>();
        audioSource = GetComponent<AudioSource>();
        // gameLevel = GameLevel.Game1;
    }

    // Update is called once per frame
    void Update()
    {
        if(glassisbroken == true)
        {
            //什麼時候moveistrue false->true
            finalPos = new Vector3(transform.position.x,transform.position.y,transform.position.z-1);
            moveistrue = true;
            glassisbroken = false;
        }
        if(moveistrue == true)
        {
            Move();
        }
        Glassisnone();
        GameLevelSwitch();
    }
    public void Glassshatter()
    {
        if(glassaudio == false)
        {
            audioSource.PlayOneShot(glassshatter);
            noglass = true;
            glassaudio = true;
        }
    }
    public void GlassCount()
    {
        //多少玻璃被打碎
        glasscount += 1;
        scoreboard.ScoreAdd();
    }
    void Glassisnone()
    {
        if(glasscount == 10)
        {
            noglass = true;
            glasscount = 0;
        }
    }
    void GameLevelSwitch()
    {
        if(noglass)//時間到或是玻璃打完
        {
            if(gameLevel == GameLevel.Game1)
            {
                gameLevel = GameLevel.Game2;
                Invoke("GlassReborn",gameswitchTime);
            }
            else if(gameLevel == GameLevel.Game2)
            {
                gameLevel = GameLevel.Game3;
                Invoke("GlassReborn",gameswitchTime);
            }
            else if(gameLevel == GameLevel.Game3)
            {
                gameLevel = GameLevel.GameOver;
            }
            noglass = false;
        }
        if(timecounting.second == 0)
        {
            timesUp = true;
        }
        if(timecounting.gamestart == true)
        {
            glassaudio = false;
        }
    }
    void GlassReborn()
    {
        glassInstantiate.GlassReborn();
    }
    public void Move()
    {
        //從現在位置往前移動到目的地+1
        // PosZ += Time.deltaTime*-1;
        // PosZ -= 1;
        // transform.position = new Vector3(transform.position.x,transform.position.y,PosZ);
        
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position,finalPos,step);
        // moveistrue = false;
        // if(transform.position == finalPos)
        // {
        //     Debug.Log("近來沒");
        //     moveistrue = false;
        // }
    }
}
