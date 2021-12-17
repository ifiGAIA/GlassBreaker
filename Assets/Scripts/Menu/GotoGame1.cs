using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public enum GlassChoose
{
    RR,//紅
    RG,//紅綠
    RRf,//紅腳
    RGf//紅綠腳
}
public class GotoGame1 : MonoBehaviour
{
    public GlassChoose glassChoose;
    public GameObject hammer_Left;
    public GameObject hammer_Right;
    public GameObject Phone;
    public GameObject Handler;
    public GameObject Teleport;

    public GameObject Signcanvas2;
    private float i;
    public float fadspeed = 0.1f;

    public bool glassred;
    public bool glassgreen;
    public bool glasspurple;
    public bool glassfinish;
    public int glasscount;
    public bool glassreload;
    public int practicecount;

    //生成玻璃
    public Transform InitPos;
    public GameObject Prefab;
    public bool glassisbroken;
    public bool canKnockglass;
    // Start is called before the first frame update
    void Start()
    {
        canKnockglass = false;
        glassisbroken = true;
        if(GameManager.Instance.gameDegreeOfDifficulty == GameDegreeOfDifficulty.Simple)
        {
            GameManager.Instance.Foot = false;
        }
        else if(GameManager.Instance.gameDegreeOfDifficulty == GameDegreeOfDifficulty.Difficulty)
        {
            GameManager.Instance.Foot = true;
        }
        // Teleport.SetActive(false);
        Signcanvas2.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        ChooseHammer();
        // ChooseGlass();
        if(canKnockglass)
        {
            if(glassisbroken)
            {
                Glassinstantiate();
            }
        }
    }
    void PracticeisDone()
    {
        practicecount += 1;
        if(practicecount == 2)
        {
            Teleport.SetActive(true);
            Signcanvas2.SetActive(true);
            // Invoke("Fade", 15f);
        }
    }
    void Fade()
    {
        i -= fadspeed*Time.deltaTime;
        if(i<=0)
        {
            i=0;
        }
        Signcanvas2.transform.GetChild(0).GetComponent<Image>().color = new Color(1, 1, 1, i);
        Signcanvas2.transform.GetChild(1).GetComponent<Text>().color = new Color(1, 1, 1, i);
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Grabbable")
        {
            Invoke("ToGame",2f);
        }
    }
    void ToGame()
    {
        Destroy(hammer_Left);
        Destroy(hammer_Right);
        Destroy(Phone);
        Destroy(Handler);
        SceneManager.LoadScene("TestScenes");
    }
    public void ChooseGlass_RR()
    {
        glassChoose = GlassChoose.RR;
        if(canKnockglass)
        {
            glassreload = true;
        }
        glassisbroken = true;
        canKnockglass = true;
    }
    public void ChooseGlass_RG()
    {
        glassChoose = GlassChoose.RG;
        if(canKnockglass)
        {
            glassreload = true;
        }
        glassisbroken = true;
        canKnockglass = true;
    }
    public void ChooseGlass_RRf()
    {
        glassChoose = GlassChoose.RRf;
        if(canKnockglass)
        {
            glassreload = true;
        }
        glassisbroken = true;
        canKnockglass = true;
    }
    public void ChooseGlass_RGf()
    {
        glassChoose = GlassChoose.RGf;
        if(canKnockglass)
        {
            glassreload = true;
        }
        glassisbroken = true;
        canKnockglass = true;
    }
    public void ChooseHammer()
    {
        if(glassChoose == GlassChoose.RR || glassChoose == GlassChoose.RRf)
        {
            hammer_Right.transform.GetChild(0).GetChild(0).GetComponent<Light>().color = Color.red;
        }
        else
        {
            hammer_Right.transform.GetChild(0).GetChild(0).GetComponent<Light>().color = Color.green;
        }
    }
    public void GlassCount()
    {
        glasscount += 1;
        if(glasscount == 3)
        {
            canKnockglass = false;
            PracticeisDone();
            glasscount = 0;
        }
    }
    void Glassinstantiate()
    {
        Vector3 glassPos = new Vector3(InitPos.position.x, InitPos.position.y, InitPos.position.z);
        Instantiate(Prefab, glassPos,InitPos.rotation);//生成
        glassisbroken = false;
        Debug.Log("999");
    }
}
