using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    public bool glassred;
    public bool glassgreen;
    public bool glasspurple;
    public bool glassfinish;
    public int glasscount;
    public bool glassreload;

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
    void ToGame()
    {
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
            // Lefthand_game1.SetActive(true);
            // Righthand_game1.SetActive(true);
            // Lefthand_game2.SetActive(false);
            // Righthand_game2.SetActive(false);
            hammer_Right.transform.GetChild(0).GetChild(0).GetComponent<Light>().color = Color.red;
        }
        else
        {
            // Lefthand_game1.SetActive(false);
            // Righthand_game1.SetActive(false);
            // Lefthand_game2.SetActive(true);
            // Righthand_game2.SetActive(true);
            hammer_Right.transform.GetChild(0).GetChild(0).GetComponent<Light>().color = Color.green;
        }
    }
    public void GlassCount()
    {
        glasscount += 1;
        if(glasscount == 3)
        {
            canKnockglass = false;
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
