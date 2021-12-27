using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonus : MonoBehaviour
{
    public GlassMove glassMove;
    public Transform[] InitPos;
    public GameObject Prefab;
    private GameObject glass;
    public GameObject B_CanKnock;
    public GameObject CanKnock;
    public int glasscount;
    public int brokenglass;
    public bool bonusTime;
    public bool bonusstart;
    public AudioClip bonusSound;
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        glassMove = glassMove.GetComponent<GlassMove>();
        audioSource = GetComponent<AudioSource>();
        B_CanKnock.SetActive(false);
        CanKnock.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if(glassMove.gameLevel == GameLevel.Bonus)
        {
            bonusTime = true;
        }
        if(bonusTime && !bonusstart)
        {
            Glassinstantiate();
            audioSource.PlayOneShot(bonusSound);
            bonusstart = true;
            B_CanKnock.SetActive(true);
            CanKnock.SetActive(false);
        }
    }
    public void GlassCount()
    {
        //多少玻璃被打碎
        brokenglass += 1;
    }
    void Glassinstantiate()
    {
        if(GameManager.Instance.gameDegreeOfDifficulty == GameDegreeOfDifficulty.Simple)
        {
            for(int i=0; i<glasscount; i++)
            {
                int Random_Pos = Random.Range(0, 2);
                Vector3 glassPos = new Vector3(InitPos[Random_Pos].position.x, InitPos[Random_Pos].position.y, InitPos[Random_Pos].position.z+(float)i*3);
                glass = Instantiate(Prefab, glassPos,InitPos[Random_Pos].rotation);//生成
                glass.transform.parent = gameObject.transform;//生成物parent=富物件
                glass.name = "glass" + (i+1).ToString();
            }
        }
        else if(GameManager.Instance.gameDegreeOfDifficulty == GameDegreeOfDifficulty.Difficulty)
        {
            for(int i=0; i<glasscount; i++)
            {
                int Random_Pos = Random.Range(0, InitPos.Length);
                Vector3 glassPos = new Vector3(InitPos[Random_Pos].position.x, InitPos[Random_Pos].position.y, InitPos[Random_Pos].position.z+(float)i*2);
                glass = Instantiate(Prefab, glassPos,InitPos[Random_Pos].rotation);//生成
                glass.transform.parent = gameObject.transform;//生成物parent=富物件
                glass.name = "glass" + (i+1).ToString();
            }
        }
    }
}
