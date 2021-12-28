using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bonus : MonoBehaviour
{
    public Slotmachine Glasscount_S;
    public Slotmachine Speed_S;
    public GlassMove glassMove;
    public Transform[] InitPos;
    public GameObject Prefab;
    private GameObject glass;
    public GameObject B_CanKnock;
    public GameObject CanKnock;
    public GameObject SlotMachine;
    public GameObject GlassManager;
    public int glasscount;
    public int brokenglass;
    public bool bonusTime;
    public bool bonusstart;
    public bool bonuschoose;
    public bool bonusready;
    public AudioClip bonusSound;
    public AudioClip Ready;
    AudioSource audioSource;

    float time_int = 4;
    public Text time_UI;
    public bool countdown;
    // Start is called before the first frame update
    void Start()
    {
        glassMove = glassMove.GetComponent<GlassMove>();
        audioSource = GetComponent<AudioSource>();
        B_CanKnock.SetActive(false);
        CanKnock.SetActive(true);
        Glasscount_S = Glasscount_S.GetComponent<Slotmachine>();
        Speed_S = Speed_S.GetComponent<Slotmachine>();
        SlotMachine.transform.GetChild(0).gameObject.SetActive(false);
        SlotMachine.transform.GetChild(1).gameObject.SetActive(false);
        SlotMachine.transform.GetChild(2).gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(glassMove.gameLevel == GameLevel.Bonus && !bonuschoose)
        {
            SlotMachine.transform.GetChild(0).gameObject.SetActive(true);
            SlotMachine.transform.GetChild(1).gameObject.SetActive(true);
            audioSource.PlayOneShot(bonusSound);
            bonuschoose = true;
            // bonusTime = true;
        }
        if(bonusTime && !bonusstart)
        {
            Glassinstantiate();
            // audioSource.PlayOneShot(bonusSound);
            bonusstart = true;
            B_CanKnock.SetActive(true);
            CanKnock.SetActive(false);
        }
        if(Glasscount_S.countresult == true && Speed_S.speedresult == true && !bonusready)
        {
            // bonusTime = true;
            countdown = true;
            audioSource.PlayOneShot(Ready);
            SlotMachine.transform.GetChild(0).gameObject.SetActive(false);
            SlotMachine.transform.GetChild(1).gameObject.SetActive(false);
            SlotMachine.transform.GetChild(2).gameObject.SetActive(true);
            bonusready = true;
        }

        if(countdown)
        {
            timer();
        }
        if(!countdown)
        {
            time_UI.text = " ";
        }
    }
    void timer()
    {
        time_int -= Time.deltaTime;
        int time = (int)time_int;
        time_UI.text = time.ToString();
        if (time == 0)
        {
            time_UI.text = "GO!";
            Invoke("BonusStart",2f);
        }
    }
    void BonusStart()
    {
        countdown = false;
        bonusTime = true;
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
            for(int i=0; i<Glasscount_S.glasscount; i++)
            {
                int Random_Pos = Random.Range(0, 2);
                Vector3 glassPos = new Vector3(InitPos[Random_Pos].position.x, InitPos[Random_Pos].position.y, InitPos[Random_Pos].position.z+(float)i*3);
                glass = Instantiate(Prefab, glassPos,InitPos[Random_Pos].rotation);//生成
                glass.transform.parent = GlassManager.transform;//生成物parent=富物件
                glass.name = "glass" + (i+1).ToString();
            }
        }
        else if(GameManager.Instance.gameDegreeOfDifficulty == GameDegreeOfDifficulty.Difficulty)
        {
            for(int i=0; i<Glasscount_S.glasscount; i++)
            {
                int Random_Pos = Random.Range(0, InitPos.Length);
                Vector3 glassPos = new Vector3(InitPos[Random_Pos].position.x, InitPos[Random_Pos].position.y, InitPos[Random_Pos].position.z+(float)i*2);
                glass = Instantiate(Prefab, glassPos,InitPos[Random_Pos].rotation);//生成
                glass.transform.parent = GlassManager.transform;//生成物parent=富物件
                glass.name = "glass" + (i+1).ToString();
            }
        }
    }
}
