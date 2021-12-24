using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameLevel
{
    Game1,//紅
    Game2,//紅綠
    Game3,//紅綠腳
    Game4,//紅腳
    Bonus,
    GameOver
}
public class GlassMove : MonoBehaviour
{
    GlassInstantiate glassInstantiate;
    public Timecounting timecounting;
    public Scoreboard scoreboard;
    public GameLevel gameLevel;
    // public GameDegreeOfDifficulty gameDegreeOfDifficulty;
    public bool moveistrue = false;
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

    public GameObject Lefthand;
    public GameObject Righthand;

    public GameObject Leftfoot;
    public GameObject Rightfoot;
    
    // Start is called before the first frame update
    void Start()
    {
        glassInstantiate = GameObject.Find("Glass").GetComponent<GlassInstantiate>();
        timecounting = timecounting.GetComponent<Timecounting>();
        scoreboard = scoreboard.GetComponent<Scoreboard>();
        audioSource = GetComponent<AudioSource>();
        if(GameManager.Instance.gameDegreeOfDifficulty == GameDegreeOfDifficulty.Simple)
        {
            gameLevel = GameLevel.Game1;
        }
        else if(GameManager.Instance.gameDegreeOfDifficulty == GameDegreeOfDifficulty.Difficulty)
        {
            gameLevel = GameLevel.Game3;
        }
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
        ChooseFootHammer();
        Glassisnone();
        GameLevelSwitch();
    }
    void ChooseFootHammer()
    {
        if(GameManager.Instance.Foot == true)
        {
            Leftfoot.SetActive(true);
            Rightfoot.SetActive(true);
        }
        else
        {
            Leftfoot.SetActive(false);
            Rightfoot.SetActive(false);
        }

        if(gameLevel == GameLevel.Game1 || gameLevel == GameLevel.Game3)
        {
            Righthand.transform.GetChild(0).GetChild(0).GetComponent<Light>().color = Color.red;
        }
        else if(gameLevel == GameLevel.Bonus)
        {
            Lefthand.transform.GetChild(0).GetChild(0).GetComponent<Light>().enabled = false;
            Righthand.transform.GetChild(0).GetChild(0).GetComponent<Light>().enabled = false;
        }
        else
        {
            Righthand.transform.GetChild(0).GetChild(0).GetComponent<Light>().color = Color.green;
        }
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
        if(GameManager.Instance.gameDegreeOfDifficulty == GameDegreeOfDifficulty.Simple)
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
                timecounting.audioSource.Stop();
                noglass = false;
            }
            if(timecounting.second == 0)
            {
                timesUp = true;
                glasscount = 0;
            }
            else
            {
                timesUp = false;
            }
            if(timecounting.gamestart == true)
            {
                glassaudio = false;
            }
        }
        else if(GameManager.Instance.gameDegreeOfDifficulty == GameDegreeOfDifficulty.Difficulty)
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
                timecounting.audioSource.Stop();
                noglass = false;
            }
            if(timecounting.second == 0)
            {
                timesUp = true;
                glasscount = 0;
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
        if(GameManager.Instance.gameDegreeOfDifficulty == GameDegreeOfDifficulty.Simple)
        {
            if(gameLevel == GameLevel.Game1)
            {
                gameLevel = GameLevel.Game2;
                timecounting.ReTime();
                glassInstantiate.GlassReborn();
                scoreboard.glasscount = 0;
            }
            else if(gameLevel == GameLevel.Game2)
            {
                gameLevel = GameLevel.Bonus;//加Bonus
            }
        }
        else if(GameManager.Instance.gameDegreeOfDifficulty == GameDegreeOfDifficulty.Difficulty)
        {
            if(gameLevel == GameLevel.Game3)
            {
                gameLevel = GameLevel.Game4;
                timecounting.ReTime();
                glassInstantiate.GlassReborn();
                scoreboard.glasscount = 0;
            }
            else if(gameLevel == GameLevel.Game4)
            {
                gameLevel = GameLevel.Bonus;
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
