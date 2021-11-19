using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scoreboard : MonoBehaviour
{
    public GlassMove glassMove;
    public GameObject Time;
    public int score1 = 0;
    public int score2 = 0;
    public int score3 = 0;
    private int finalscore;
    public int glasscount = 0;
    // Start is called before the first frame update
    void Start()
    {
        glassMove = glassMove.GetComponent<GlassMove>();
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
        score1 = glasscount * 10;
        if (score1 < 10)
        {
            GetComponent<Text>().text = "分數 : 0" + score1;
        }
        else if(score1 >= 10 && score1 <100)
        {
            GetComponent<Text>().text = "分數 : " + score1;
        }
        else
        {
            GetComponent<Text>().text = "  分數 : " + score1;
        }
    }
    void Scoring_Game2()
    {
        score2 = glasscount * 10;
        if (score2 < 10)
        {
            GetComponent<Text>().text = "分數 : 0" + score2;
        }
        else if(score2 >= 10 && score2 <100)
        {
            GetComponent<Text>().text = "分數 : " + score2;
        }
        else
        {
            GetComponent<Text>().text = "  分數 : " + score2;
        }
    }
    void Scoring_Game3()
    {
        score3 = glasscount * 10;
        if (score3 < 10)
        {
            GetComponent<Text>().text = "分數 : 0" + score3;
        }
        else if(score3 >= 10 && score3 <100)
        {
            GetComponent<Text>().text = "分數 : " + score3;
        }
        else
        {
            GetComponent<Text>().text = "  分數 : " + score3;
        }
    }
    void GameOver()
    {
        finalscore = score1 + score2 + score3;
        GetComponent<Text>().text = "  總分 : " + finalscore;
        Time.SetActive(false);
    }
}
