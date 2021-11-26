using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GotoGame1 : MonoBehaviour
{
    public GameObject hammer_Left;
    public GameObject hammer_Right;
    public GameObject Glasstogame;
    public GlassShatter glassShatter;
    public bool glassred;
    public bool glassgreen;
    public bool glasspurple;
    public bool glassfinish;
    // Start is called before the first frame update
    void Start()
    {
        glassShatter = glassShatter.GetComponent<GlassShatter>();
        Glasstogame.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(glassShatter.gameStart == true)
        {
            Destroy(hammer_Left);
            Destroy(hammer_Right);
            ToGame();
        }
        if(glassred == true && glassgreen == true && glasspurple == true)
        {
            glassfinish = true;
        }
        if(glassfinish == true)
        {
            Glasstogame.SetActive(true);
        }
    }
    void ToGame()
    {
        SceneManager.LoadScene("TestScenes");
    }
}
