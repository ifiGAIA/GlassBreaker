using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scoreboard : MonoBehaviour
{
    public GlassMove glassMove;
    public GameObject Time;
    public int numberofbrokenglass1;
    public int numberofbrokenglass2;
    public int time1;
    public int time2;
    private int finalscore;
    public int glasscount = 0;
    public AudioClip gameover;
    AudioSource audioSource;
    private bool gameOver;
    // Start is called before the first frame update
    void Start()
    {
        glassMove = glassMove.GetComponent<GlassMove>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(glassMove.gameLevel == GameLevel.Game1)
        {
            Scoring_Game1();
        }
        else if(glassMove.gameLevel == GameLevel.Game2)
        {
            Scoring_Game2();
        }
        else if(glassMove.gameLevel == GameLevel.Game3)
        {
            Scoring_Game3();
        }
        else if(glassMove.gameLevel == GameLevel.Game4)
        {
            Scoring_Game4();
        }
        else if(glassMove.gameLevel == GameLevel.GameOver)
        {
            GameOver();
        }
    }
    public void ScoreAdd()
    {
        glasscount += 1;
    }
    void Scoring_Game1()
    {
        time1 = 60 - Time.GetComponent<Timecounting>().second;
        // score1 = glasscount * 10;
        if (glasscount < 10)
        {
            GetComponent<Text>().text = "擊碎玻璃數 : 0" + glasscount;
        }
        else if(glasscount == 10)
        {
            GetComponent<Text>().text = "擊碎玻璃數 : " + glasscount;
        }
        numberofbrokenglass1 = glasscount;
    }
    void Scoring_Game2()
    {
        time2 = 60 - Time.GetComponent<Timecounting>().second;
        // score2 = glasscount * 10;
        if (glasscount < 10)
        {
            GetComponent<Text>().text = "擊碎玻璃數 : 0" + glasscount;
        }
        else if(glasscount == 10)
        {
            GetComponent<Text>().text = "擊碎玻璃數 : " + glasscount;
        }
        numberofbrokenglass2 = glasscount;
    }
    void Scoring_Game3()
    {
        time1 = 60 - Time.GetComponent<Timecounting>().second;
        // score1 = glasscount * 10;
        if (glasscount < 10)
        {
            GetComponent<Text>().text = "擊碎玻璃數 : 0" + glasscount;
        }
        else if(glasscount == 10)
        {
            GetComponent<Text>().text = "擊碎玻璃數 : " + glasscount;
        }
        numberofbrokenglass1 = glasscount;
    }
    void Scoring_Game4()
    {
        time2 = 60 - Time.GetComponent<Timecounting>().second;
        // score2 = glasscount * 10;
        if (glasscount < 10)
        {
            GetComponent<Text>().text = "擊碎玻璃數 : 0" + glasscount;
        }
        else if(glasscount == 10)
        {
            GetComponent<Text>().text = "擊碎玻璃數 : " + glasscount;
        }
        numberofbrokenglass2 = glasscount;
    }
    void GameOver()
    {
        if(GameManager.Instance.gameDegreeOfDifficulty == GameDegreeOfDifficulty.Simple)
        {
            finalscore = time1 + time2;
            GetComponent<Text>().fontSize = 100;
            GetComponent<Text>().text = "擊碎玻璃總數 : " + (numberofbrokenglass1+numberofbrokenglass2);
            Time.GetComponent<Text>().fontSize = 150;
            Time.GetComponent<Text>().text = "總秒數 : " + finalscore;
            if(gameOver == false)
            {
                audioSource.PlayOneShot(gameover);
                gameOver = true;
            }
        }
        else if(GameManager.Instance.gameDegreeOfDifficulty == GameDegreeOfDifficulty.Difficulty)
        {
            finalscore = time1 + time2;
            GetComponent<Text>().fontSize = 100;
            GetComponent<Text>().text = "擊碎玻璃總數 : " + (numberofbrokenglass1+numberofbrokenglass2);
            Time.GetComponent<Text>().fontSize = 150;
            Time.GetComponent<Text>().text = "總秒數 : " + finalscore;
            if(gameOver == false)
            {
                audioSource.PlayOneShot(gameover);
                gameOver = true;
            }
        }
        // finalscore = score1 + score2 + score3;
        // GetComponent<Text>().text = " ";
        // Time.GetComponent<Text>().fontSize = 150;
        // Time.GetComponent<Text>().text = "  總分 : " + finalscore;
        // if(gameOver == false)
        // {
        //     audioSource.PlayOneShot(gameover);
        //     gameOver = true;
        // }
    }
}
