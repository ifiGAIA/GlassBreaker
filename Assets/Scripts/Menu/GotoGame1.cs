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
    public GameObject[] Dumbbellset;
    public GameObject transparentWall;

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
        Signcanvas2.SetActive(false);
        transparentWall.SetActive(true);
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
        if(practicecount == 2)
        {
            Invoke("CanExplore",2f);
        }
    }
    void CanExplore()
    {
        transparentWall.SetActive(false);
    }
    void PracticeisDone()
    {
        practicecount += 1;
        if(practicecount == 2)
        {
            Signcanvas2.SetActive(true);
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Grabbable")
        {
            GotoStandby();
        }
    }
    void GotoStandby()
    {
        SceneManager.LoadScene("StandbyScenes");
        Destroy(hammer_Left);
        Destroy(hammer_Right);
        Destroy(Phone);
        Destroy(Handler);
        for(int i=0; i<=Dumbbellset.Length; i++)
        {
            Destroy(Dumbbellset[i]);
        }
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
