using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameLevel
{
    Game1,//紅
    Game2,//紅綠
    Game3,//紅綠腳
    Game4,//紅腳
    GameOver
}
public enum GameDegreeOfDifficulty
{
    Simple,
    Difficulty
}
public class GlassMove : MonoBehaviour
{
    GlassInstantiate glassInstantiate;
    public Timecounting timecounting;
    public Scoreboard scoreboard;
    public GameLevel gameLevel;
    public GameDegreeOfDifficulty gameDegreeOfDifficulty;
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

    public GameObject Lefthand_game1;
    public GameObject Lefthand_game2;
    public GameObject Righthand_game1;
    public GameObject Righthand_game2;
    
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
        if(gameLevel == GameLevel.Game1 || gameLevel == GameLevel.Game3)
        {
            Lefthand_game1.SetActive(true);
            Righthand_game1.SetActive(true);
            Lefthand_game2.SetActive(false);
            Righthand_game2.SetActive(false);
        }
        else
        {
            Lefthand_game1.SetActive(false);
            Righthand_game1.SetActive(false);
            Lefthand_game2.SetActive(true);
            Righthand_game2.SetActive(true);
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
        if(gameDegreeOfDifficulty == GameDegreeOfDifficulty.Simple)
        {
            if(noglass)//時間到或是玻璃打完
            {
                if(gameLevel == GameLevel.Game1)
                {
                    Invoke("GlassReborn",gameswitchTime);
                }
                else if(gameLevel == GameLevel.Game2)
                {
                    Invoke("GlassReborn",gameswitchTime);
                }
                timecounting.gamestart = false;
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
        else if(gameDegreeOfDifficulty == GameDegreeOfDifficulty.Difficulty)
        {
            if(noglass)//時間到或是玻璃打完
            {
                if(gameLevel == GameLevel.Game3)
                {
                    Invoke("GlassReborn",gameswitchTime);
                }
                else if(gameLevel == GameLevel.Game4)
                {
                    Invoke("GlassReborn",gameswitchTime);
                }
                timecounting.gamestart = false;
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
        // if(noglass)//時間到或是玻璃打完
        // {
        //     if(gameLevel == GameLevel.Game1)
        //     {
        //         Invoke("GlassReborn",gameswitchTime);
        //     }
        //     else if(gameLevel == GameLevel.Game2)
        //     {
        //         Invoke("GlassReborn",gameswitchTime);
        //     }
        //     else if(gameLevel == GameLevel.Game3)
        //     {
        //         Invoke("GlassReborn",gameswitchTime);
        //     }
        //     timecounting.gamestart = false;
        //     noglass = false;
        // }
        // if(timecounting.second == 0)
        // {
        //     timesUp = true;
        // }
        // if(timecounting.gamestart == true)
        // {
        //     glassaudio = false;
        // }
    }
    void GlassReborn()
    {
        if(gameDegreeOfDifficulty == GameDegreeOfDifficulty.Simple)
        {
            if(gameLevel == GameLevel.Game1)
            {
                gameLevel = GameLevel.Game2;
                glassInstantiate.GlassReborn();
                timecounting.ReTime();
                scoreboard.glasscount = 0;
            }
            else if(gameLevel == GameLevel.Game2)
            {
                gameLevel = GameLevel.GameOver;
            }
        }
        else if(gameDegreeOfDifficulty == GameDegreeOfDifficulty.Difficulty)
        {
            if(gameLevel == GameLevel.Game3)
            {
                gameLevel = GameLevel.Game4;
                glassInstantiate.GlassReborn();
                timecounting.ReTime();
                scoreboard.glasscount = 0;
            }
            else if(gameLevel == GameLevel.Game4)
            {
                gameLevel = GameLevel.GameOver;
            }
        }
        // if(gameLevel == GameLevel.Game1)
        // {
        //     gameLevel = GameLevel.Game2;
        //     glassInstantiate.GlassReborn();
        //     timecounting.ReTime();
        //     scoreboard.glasscount = 0;
        // }
        // else if(gameLevel == GameLevel.Game2)
        // {
        //     gameLevel = GameLevel.Game3;
        //     glassInstantiate.GlassReborn();
        //     timecounting.ReTime();
        //     scoreboard.glasscount = 0;
        // }
        // else if(gameLevel == GameLevel.Game3)
        // {
        //     gameLevel = GameLevel.GameOver;
        // }
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
