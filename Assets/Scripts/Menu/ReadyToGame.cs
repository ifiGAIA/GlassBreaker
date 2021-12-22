using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReadyToGame : MonoBehaviour
{
    public GameObject Leftfoot;
    public GameObject Rightfoot;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("GotoGame",5f);
    }

    // Update is called once per frame
    void Update()
    {
        ChooseFoot();
    }
    void ChooseFoot()
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
    }
    void GotoGame()
    {
        SceneManager.LoadScene("TestScenes");
    }
}
