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

    //生成玻璃
    public Transform InitPos;
    public GameObject Prefab;
    public bool glassisbroken;
    // Start is called before the first frame update
    void Start()
    {
        glassisbroken = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(glassisbroken)
        {
            Glassinstantiate();
        }
    }
    void ToGame()
    {
        SceneManager.LoadScene("TestScenes");
    }
    void Glassinstantiate()
    {
        Vector3 glassPos = new Vector3(InitPos.position.x, InitPos.position.y, InitPos.position.z);
        Instantiate(Prefab, glassPos,InitPos.rotation);//生成
        glassisbroken = false;
    }
}
