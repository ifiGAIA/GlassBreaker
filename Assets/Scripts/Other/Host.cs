using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Host : MonoBehaviour
{
    public Timecounting timecounting;
    public AudioClip gameStart;
    public AudioClip MiddleSound;
    AudioSource audioSource;
    public bool middle;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        timecounting = timecounting.GetComponent<Timecounting>();
        Invoke("GameStart",3f);
    }

    // Update is called once per frame
    void Update()
    {
        Middle();
    }
    void GameStart()
    {
        audioSource.PlayOneShot(gameStart);
    }
    void Middle()
    {
        if(GameManager.Instance.gameDegreeOfDifficulty == GameDegreeOfDifficulty.Simple)
        {
            if(timecounting.second == 30 && !middle)
            {
                audioSource.PlayOneShot(MiddleSound);
                middle = true;
            }
        }
        else if(GameManager.Instance.gameDegreeOfDifficulty == GameDegreeOfDifficulty.Difficulty)
        {
            if(timecounting.second == 40 && !middle)
            {
                audioSource.PlayOneShot(MiddleSound);
                middle = true;
            }
        }
    }
    public void Reload()
    {
        if(GameManager.Instance.gameDegreeOfDifficulty == GameDegreeOfDifficulty.Simple)
        {
            if(timecounting.gamestart == false && middle)
            {
                middle = false;
            }
        }
        else if(GameManager.Instance.gameDegreeOfDifficulty == GameDegreeOfDifficulty.Difficulty)
        {
            if(timecounting.gamestart == false && middle)
            {
                middle = false;
            }
        }
    }
}
