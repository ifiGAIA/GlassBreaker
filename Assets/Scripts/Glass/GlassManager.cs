using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GlassManager : MonoBehaviour
{
    Scene scene;
    MeshRenderer meshRenderer;
    BoxCollider boxCollider;

    //10個指定位置
    public Transform[] KnockSpots;
    public Transform[] KnockSpots_G3;
    private GameObject KnockSpotsManager;
    public GameObject KnockSpotscollect;

    public GameObject knock_Position;
    public GameObject[] Objects;
    public GameObject crack;
    public GameObject glassPos;
    public GameObject explosionGlass;
    GlassMove glassMove;
    public bool canKnock = false;
    public bool spotisexist = false;
    public bool canMove = false;
    public int knockcount = 0;

    public AudioClip glassbroken;
    public AudioClip glassshatter;
    public AudioClip glassknock;
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        scene = SceneManager.GetActiveScene();
        meshRenderer = GetComponent<MeshRenderer>();
        boxCollider = GetComponent<BoxCollider>();
        glassMove = GameObject.Find("Glass").GetComponent<GlassMove>();
        explosionGlass.SetActive(false);
        glassPos = GameObject.Find("glassPos");

        KnockSpotscollect = GameObject.Find("KnockSpotscollect");

        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        GlassBroken();
        GlasscanKnock();
        GameLevelSwitch();
        TimesUp();
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Left_hammer" || other.gameObject.tag == "Right_hammer")
        {
            audioSource.PlayOneShot(glassknock);
        }
    }
    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "hammer")
        {
            audioSource.PlayOneShot(glassknock);
        }
    }
    void GameLevelSwitch()
    {
        if(glassMove.gameLevel == GameLevel.Game1 && glassMove.timecounting.gamestart == true)
        {
            // KnockSpot_game1();
            KnockSpot_Game1();
            // Debug.Log("第一關");
        }
        else if(glassMove.gameLevel == GameLevel.Game2 && glassMove.timecounting.gamestart == true)
        {
            // KnockSpot_game2();
            KnockSpot_Game2();
            // Debug.Log("第二關");
        }
        else if(glassMove.gameLevel == GameLevel.Game3 && glassMove.timecounting.gamestart == true)
        {
            // KnockSpot_game3();
            KnockSpot_Game3();
            // Debug.Log("第三關");
        }
    }
    void TimesUp()
    {
        if(glassMove.timesUp == true)
        {
            meshRenderer.enabled = false;
            boxCollider.enabled = false;
            explosionGlass.SetActive(true);
            Invoke("DestroyGlass",5f);
            glassMove.Glassshatter();
            KnockSpotscollect.GetComponent<KnockSpotManager>().Destroyspot();
        }
    }

    void GlasscanKnock()
    {
        if(gameObject.transform.position == glassPos.transform.position)
        {
            canKnock = true;
        }
    }
    void GlassBroken()
    {
        if(canMove == true)
        {
            glassMove.glassisbroken = true;
            audioSource.PlayOneShot(glassshatter);
            meshRenderer.enabled = false;
            boxCollider.enabled = false;
            explosionGlass.SetActive(true);
            canMove = false;
            Invoke("DestroyGlass",5f);
        }
    }
    void DestroyGlass()
    {
        Destroy(gameObject);
        glassMove.timesUp = false;
    }
    public void KnockCount()
    {
        knockcount += 1;
        audioSource.PlayOneShot(glassbroken);
        if(knockcount == 5)
        {
            canMove = true;
            gameObject.tag = "Untagged";
            crack.gameObject.tag = "Untagged";
            crack.SetActive(false);
            glassMove.GlassCount();
        }
    }
    void KnockSpot_Game1()
    {
        // int Random_Objects = Random.Range(0, 2);
        if(spotisexist == false && canKnock == true && gameObject.name == "glass1")
        {
            for(int i=0; i<5; i++)
            {
                int Random_Objects = Random.Range(0, 0);
                KnockSpotsManager = Instantiate(Objects[Random_Objects], KnockSpots[0].GetChild(i).gameObject.transform.position,knock_Position.transform.rotation);
                if(i==4)
                {
                    spotisexist= true;
                }
                KnockSpotsManager.transform.parent = KnockSpotscollect.transform;
                KnockSpotsManager.name = "knockSpot" + (i+1).ToString();
            }
        }
        else if(spotisexist == false && canKnock == true && gameObject.name == "glass2")
        {
            for(int i=0; i<5; i++)
            {
                int Random_Objects = Random.Range(0, 0);
                KnockSpotsManager = Instantiate(Objects[Random_Objects], KnockSpots[1].GetChild(i).gameObject.transform.position,knock_Position.transform.rotation);
                if(i==4)
                {
                    spotisexist= true;
                }
                KnockSpotsManager.transform.parent = KnockSpotscollect.transform;
            }
        }
        else if(spotisexist == false && canKnock == true && gameObject.name == "glass3")
        {
            for(int i=0; i<5; i++)
            {
                int Random_Objects = Random.Range(0, 0);
                KnockSpotsManager = Instantiate(Objects[Random_Objects], KnockSpots[2].GetChild(i).gameObject.transform.position,knock_Position.transform.rotation);
                if(i==4)
                {
                    spotisexist= true;
                }
                KnockSpotsManager.transform.parent = KnockSpotscollect.transform;
            }
        }
        else if(spotisexist == false && canKnock == true && gameObject.name == "glass4")
        {
            for(int i=0; i<5; i++)
            {
                int Random_Objects = Random.Range(0, 0);
                KnockSpotsManager = Instantiate(Objects[Random_Objects], KnockSpots[3].GetChild(i).gameObject.transform.position,knock_Position.transform.rotation);
                if(i==4)
                {
                    spotisexist= true;
                }
                KnockSpotsManager.transform.parent = KnockSpotscollect.transform;
            }
        }
        else if(spotisexist == false && canKnock == true && gameObject.name == "glass5")
        {
            for(int i=0; i<5; i++)
            {
                int Random_Objects = Random.Range(0, 0);
                KnockSpotsManager = Instantiate(Objects[Random_Objects], KnockSpots[4].GetChild(i).gameObject.transform.position,knock_Position.transform.rotation);
                if(i==4)
                {
                    spotisexist= true;
                }
                KnockSpotsManager.transform.parent = KnockSpotscollect.transform;
            }
        }
        else if(spotisexist == false && canKnock == true && gameObject.name == "glass6")
        {
            for(int i=0; i<5; i++)
            {
                int Random_Objects = Random.Range(0, 0);
                KnockSpotsManager = Instantiate(Objects[Random_Objects], KnockSpots[5].GetChild(i).gameObject.transform.position,knock_Position.transform.rotation);
                if(i==4)
                {
                    spotisexist= true;
                }
                KnockSpotsManager.transform.parent = KnockSpotscollect.transform;
            }
        }
        else if(spotisexist == false && canKnock == true && gameObject.name == "glass7")
        {
            for(int i=0; i<5; i++)
            {
                int Random_Objects = Random.Range(0, 0);
                KnockSpotsManager = Instantiate(Objects[Random_Objects], KnockSpots[6].GetChild(i).gameObject.transform.position,knock_Position.transform.rotation);
                if(i==4)
                {
                    spotisexist= true;
                }
                KnockSpotsManager.transform.parent = KnockSpotscollect.transform;
            }
        }
        else if(spotisexist == false && canKnock == true && gameObject.name == "glass8")
        {
            for(int i=0; i<5; i++)
            {
                int Random_Objects = Random.Range(0, 0);
                KnockSpotsManager = Instantiate(Objects[Random_Objects], KnockSpots[7].GetChild(i).gameObject.transform.position,knock_Position.transform.rotation);
                if(i==4)
                {
                    spotisexist= true;
                }
                KnockSpotsManager.transform.parent = KnockSpotscollect.transform;
            }
        }
        else if(spotisexist == false && canKnock == true && gameObject.name == "glass9")
        {
            for(int i=0; i<5; i++)
            {
                int Random_Objects = Random.Range(0, 0);
                KnockSpotsManager = Instantiate(Objects[Random_Objects], KnockSpots[8].GetChild(i).gameObject.transform.position,knock_Position.transform.rotation);
                if(i==4)
                {
                    spotisexist= true;
                }
                KnockSpotsManager.transform.parent = KnockSpotscollect.transform;
            }
        }
        else if(spotisexist == false && canKnock == true && gameObject.name == "glass10")
        {
            for(int i=0; i<5; i++)
            {
                int Random_Objects = Random.Range(0, 0);
                KnockSpotsManager = Instantiate(Objects[Random_Objects], KnockSpots[9].GetChild(i).gameObject.transform.position,knock_Position.transform.rotation);
                if(i==4)
                {
                    spotisexist= true;
                }
                KnockSpotsManager.transform.parent = KnockSpotscollect.transform;
            }
        }
    }
    void KnockSpot_Game2()
    {
        // int Random_Objects = Random.Range(0, 2);
        if(spotisexist == false && canKnock == true && gameObject.name == "glass1")
        {
            for(int i=0; i<5; i++)
            {
                int Random_Objects = Random.Range(0, 2);
                KnockSpotsManager = Instantiate(Objects[Random_Objects], KnockSpots[0].GetChild(i).gameObject.transform.position,knock_Position.transform.rotation);
                if(i==4)
                {
                    spotisexist= true;
                }
                KnockSpotsManager.transform.parent = KnockSpotscollect.transform;
            }
        }
        else if(spotisexist == false && canKnock == true && gameObject.name == "glass2")
        {
            for(int i=0; i<5; i++)
            {
                int Random_Objects = Random.Range(0, 2);
                KnockSpotsManager = Instantiate(Objects[Random_Objects], KnockSpots[1].GetChild(i).gameObject.transform.position,knock_Position.transform.rotation);
                if(i==4)
                {
                    spotisexist= true;
                }
                KnockSpotsManager.transform.parent = KnockSpotscollect.transform;
            }
        }
        else if(spotisexist == false && canKnock == true && gameObject.name == "glass3")
        {
            for(int i=0; i<5; i++)
            {
                int Random_Objects = Random.Range(0, 2);
                KnockSpotsManager = Instantiate(Objects[Random_Objects], KnockSpots[2].GetChild(i).gameObject.transform.position,knock_Position.transform.rotation);
                if(i==4)
                {
                    spotisexist= true;
                }
                KnockSpotsManager.transform.parent = KnockSpotscollect.transform;
            }
        }
        else if(spotisexist == false && canKnock == true && gameObject.name == "glass4")
        {
            for(int i=0; i<5; i++)
            {
                int Random_Objects = Random.Range(0, 2);
                KnockSpotsManager = Instantiate(Objects[Random_Objects], KnockSpots[3].GetChild(i).gameObject.transform.position,knock_Position.transform.rotation);
                if(i==4)
                {
                    spotisexist= true;
                }
                KnockSpotsManager.transform.parent = KnockSpotscollect.transform;
            }
        }
        else if(spotisexist == false && canKnock == true && gameObject.name == "glass5")
        {
            for(int i=0; i<5; i++)
            {
                int Random_Objects = Random.Range(0, 2);
                KnockSpotsManager = Instantiate(Objects[Random_Objects], KnockSpots[4].GetChild(i).gameObject.transform.position,knock_Position.transform.rotation);
                if(i==4)
                {
                    spotisexist= true;
                }
                KnockSpotsManager.transform.parent = KnockSpotscollect.transform;
            }
        }
        else if(spotisexist == false && canKnock == true && gameObject.name == "glass6")
        {
            for(int i=0; i<5; i++)
            {
                int Random_Objects = Random.Range(0, 2);
                KnockSpotsManager = Instantiate(Objects[Random_Objects], KnockSpots[5].GetChild(i).gameObject.transform.position,knock_Position.transform.rotation);
                if(i==4)
                {
                    spotisexist= true;
                }
                KnockSpotsManager.transform.parent = KnockSpotscollect.transform;
            }
        }
        else if(spotisexist == false && canKnock == true && gameObject.name == "glass7")
        {
            for(int i=0; i<5; i++)
            {
                int Random_Objects = Random.Range(0, 2);
                KnockSpotsManager = Instantiate(Objects[Random_Objects], KnockSpots[6].GetChild(i).gameObject.transform.position,knock_Position.transform.rotation);
                if(i==4)
                {
                    spotisexist= true;
                }
                KnockSpotsManager.transform.parent = KnockSpotscollect.transform;
            }
        }
        else if(spotisexist == false && canKnock == true && gameObject.name == "glass8")
        {
            for(int i=0; i<5; i++)
            {
                int Random_Objects = Random.Range(0, 2);
                KnockSpotsManager = Instantiate(Objects[Random_Objects], KnockSpots[7].GetChild(i).gameObject.transform.position,knock_Position.transform.rotation);
                if(i==4)
                {
                    spotisexist= true;
                }
                KnockSpotsManager.transform.parent = KnockSpotscollect.transform;
            }
        }
        else if(spotisexist == false && canKnock == true && gameObject.name == "glass9")
        {
            for(int i=0; i<5; i++)
            {
                int Random_Objects = Random.Range(0, 2);
                KnockSpotsManager = Instantiate(Objects[Random_Objects], KnockSpots[8].GetChild(i).gameObject.transform.position,knock_Position.transform.rotation);
                if(i==4)
                {
                    spotisexist= true;
                }
                KnockSpotsManager.transform.parent = KnockSpotscollect.transform;
            }
        }
        else if(spotisexist == false && canKnock == true && gameObject.name == "glass10")
        {
            for(int i=0; i<5; i++)
            {
                int Random_Objects = Random.Range(0, 2);
                KnockSpotsManager = Instantiate(Objects[Random_Objects], KnockSpots[9].GetChild(i).gameObject.transform.position,knock_Position.transform.rotation);
                if(i==4)
                {
                    spotisexist= true;
                }
                KnockSpotsManager.transform.parent = KnockSpotscollect.transform;
            }
        }
    }
    void KnockSpot_Game3()
    {
        // int Random_Objects = Random.Range(0, 2);
        if(spotisexist == false && canKnock == true && gameObject.name == "glass1")
        {
            KnockSpotsManager = Instantiate(Objects[0], KnockSpots_G3[0].GetChild(0).gameObject.transform.position,knock_Position.transform.rotation);
            KnockSpotsManager.transform.parent = KnockSpotscollect.transform;
            KnockSpotsManager = Instantiate(Objects[2], KnockSpots_G3[0].GetChild(1).gameObject.transform.position,knock_Position.transform.rotation);
            KnockSpotsManager.transform.parent = KnockSpotscollect.transform;
            KnockSpotsManager = Instantiate(Objects[1], KnockSpots_G3[0].GetChild(2).gameObject.transform.position,knock_Position.transform.rotation);
            KnockSpotsManager.transform.parent = KnockSpotscollect.transform;
            KnockSpotsManager = Instantiate(Objects[2], KnockSpots_G3[0].GetChild(3).gameObject.transform.position,knock_Position.transform.rotation);
            KnockSpotsManager.transform.parent = KnockSpotscollect.transform;
            KnockSpotsManager = Instantiate(Objects[0], KnockSpots_G3[0].GetChild(4).gameObject.transform.position,knock_Position.transform.rotation);
            KnockSpotsManager.transform.parent = KnockSpotscollect.transform;

            spotisexist= true;
        }
        else if(spotisexist == false && canKnock == true && gameObject.name == "glass2")
        {
            KnockSpotsManager = Instantiate(Objects[0], KnockSpots_G3[1].GetChild(0).gameObject.transform.position,knock_Position.transform.rotation);
            KnockSpotsManager.transform.parent = KnockSpotscollect.transform;
            KnockSpotsManager = Instantiate(Objects[2], KnockSpots_G3[1].GetChild(1).gameObject.transform.position,knock_Position.transform.rotation);
            KnockSpotsManager.transform.parent = KnockSpotscollect.transform;
            KnockSpotsManager = Instantiate(Objects[1], KnockSpots_G3[1].GetChild(2).gameObject.transform.position,knock_Position.transform.rotation);
            KnockSpotsManager.transform.parent = KnockSpotscollect.transform;
            KnockSpotsManager = Instantiate(Objects[2], KnockSpots_G3[1].GetChild(3).gameObject.transform.position,knock_Position.transform.rotation);
            KnockSpotsManager.transform.parent = KnockSpotscollect.transform;
            KnockSpotsManager = Instantiate(Objects[0], KnockSpots_G3[1].GetChild(4).gameObject.transform.position,knock_Position.transform.rotation);
            KnockSpotsManager.transform.parent = KnockSpotscollect.transform;

            spotisexist= true;
        }
        else if(spotisexist == false && canKnock == true && gameObject.name == "glass3")
        {
            KnockSpotsManager = Instantiate(Objects[0], KnockSpots_G3[2].GetChild(0).gameObject.transform.position,knock_Position.transform.rotation);
            KnockSpotsManager.transform.parent = KnockSpotscollect.transform;
            KnockSpotsManager = Instantiate(Objects[2], KnockSpots_G3[2].GetChild(1).gameObject.transform.position,knock_Position.transform.rotation);
            KnockSpotsManager.transform.parent = KnockSpotscollect.transform;
            KnockSpotsManager = Instantiate(Objects[1], KnockSpots_G3[2].GetChild(2).gameObject.transform.position,knock_Position.transform.rotation);
            KnockSpotsManager.transform.parent = KnockSpotscollect.transform;
            KnockSpotsManager = Instantiate(Objects[2], KnockSpots_G3[2].GetChild(3).gameObject.transform.position,knock_Position.transform.rotation);
            KnockSpotsManager.transform.parent = KnockSpotscollect.transform;
            KnockSpotsManager = Instantiate(Objects[0], KnockSpots_G3[2].GetChild(4).gameObject.transform.position,knock_Position.transform.rotation);
            KnockSpotsManager.transform.parent = KnockSpotscollect.transform;

            spotisexist= true;
        }
        else if(spotisexist == false && canKnock == true && gameObject.name == "glass4")
        {
            KnockSpotsManager = Instantiate(Objects[0], KnockSpots_G3[3].GetChild(0).gameObject.transform.position,knock_Position.transform.rotation);
            KnockSpotsManager.transform.parent = KnockSpotscollect.transform;
            KnockSpotsManager = Instantiate(Objects[2], KnockSpots_G3[3].GetChild(1).gameObject.transform.position,knock_Position.transform.rotation);
            KnockSpotsManager.transform.parent = KnockSpotscollect.transform;
            KnockSpotsManager = Instantiate(Objects[1], KnockSpots_G3[3].GetChild(2).gameObject.transform.position,knock_Position.transform.rotation);
            KnockSpotsManager.transform.parent = KnockSpotscollect.transform;
            KnockSpotsManager = Instantiate(Objects[2], KnockSpots_G3[3].GetChild(3).gameObject.transform.position,knock_Position.transform.rotation);
            KnockSpotsManager.transform.parent = KnockSpotscollect.transform;
            KnockSpotsManager = Instantiate(Objects[0], KnockSpots_G3[3].GetChild(4).gameObject.transform.position,knock_Position.transform.rotation);
            KnockSpotsManager.transform.parent = KnockSpotscollect.transform;

            spotisexist= true;
        }
        else if(spotisexist == false && canKnock == true && gameObject.name == "glass5")
        {
            KnockSpotsManager = Instantiate(Objects[0], KnockSpots_G3[4].GetChild(0).gameObject.transform.position,knock_Position.transform.rotation);
            KnockSpotsManager.transform.parent = KnockSpotscollect.transform;
            KnockSpotsManager = Instantiate(Objects[2], KnockSpots_G3[4].GetChild(1).gameObject.transform.position,knock_Position.transform.rotation);
            KnockSpotsManager.transform.parent = KnockSpotscollect.transform;
            KnockSpotsManager = Instantiate(Objects[1], KnockSpots_G3[4].GetChild(2).gameObject.transform.position,knock_Position.transform.rotation);
            KnockSpotsManager.transform.parent = KnockSpotscollect.transform;
            KnockSpotsManager = Instantiate(Objects[2], KnockSpots_G3[4].GetChild(3).gameObject.transform.position,knock_Position.transform.rotation);
            KnockSpotsManager.transform.parent = KnockSpotscollect.transform;
            KnockSpotsManager = Instantiate(Objects[0], KnockSpots_G3[4].GetChild(4).gameObject.transform.position,knock_Position.transform.rotation);
            KnockSpotsManager.transform.parent = KnockSpotscollect.transform;

            spotisexist= true;
        }
        else if(spotisexist == false && canKnock == true && gameObject.name == "glass6")
        {
            KnockSpotsManager = Instantiate(Objects[0], KnockSpots_G3[5].GetChild(0).gameObject.transform.position,knock_Position.transform.rotation);
            KnockSpotsManager.transform.parent = KnockSpotscollect.transform;
            KnockSpotsManager = Instantiate(Objects[2], KnockSpots_G3[5].GetChild(1).gameObject.transform.position,knock_Position.transform.rotation);
            KnockSpotsManager.transform.parent = KnockSpotscollect.transform;
            KnockSpotsManager = Instantiate(Objects[1], KnockSpots_G3[5].GetChild(2).gameObject.transform.position,knock_Position.transform.rotation);
            KnockSpotsManager.transform.parent = KnockSpotscollect.transform;
            KnockSpotsManager = Instantiate(Objects[2], KnockSpots_G3[5].GetChild(3).gameObject.transform.position,knock_Position.transform.rotation);
            KnockSpotsManager.transform.parent = KnockSpotscollect.transform;
            KnockSpotsManager = Instantiate(Objects[0], KnockSpots_G3[5].GetChild(4).gameObject.transform.position,knock_Position.transform.rotation);
            KnockSpotsManager.transform.parent = KnockSpotscollect.transform;

            spotisexist= true;
        }
        else if(spotisexist == false && canKnock == true && gameObject.name == "glass7")
        {
            KnockSpotsManager = Instantiate(Objects[0], KnockSpots_G3[6].GetChild(0).gameObject.transform.position,knock_Position.transform.rotation);
            KnockSpotsManager.transform.parent = KnockSpotscollect.transform;
            KnockSpotsManager = Instantiate(Objects[2], KnockSpots_G3[6].GetChild(1).gameObject.transform.position,knock_Position.transform.rotation);
            KnockSpotsManager.transform.parent = KnockSpotscollect.transform;
            KnockSpotsManager = Instantiate(Objects[1], KnockSpots_G3[6].GetChild(2).gameObject.transform.position,knock_Position.transform.rotation);
            KnockSpotsManager.transform.parent = KnockSpotscollect.transform;
            KnockSpotsManager = Instantiate(Objects[2], KnockSpots_G3[6].GetChild(3).gameObject.transform.position,knock_Position.transform.rotation);
            KnockSpotsManager.transform.parent = KnockSpotscollect.transform;
            KnockSpotsManager = Instantiate(Objects[0], KnockSpots_G3[6].GetChild(4).gameObject.transform.position,knock_Position.transform.rotation);
            KnockSpotsManager.transform.parent = KnockSpotscollect.transform;

            spotisexist= true;
        }
        else if(spotisexist == false && canKnock == true && gameObject.name == "glass8")
        {
            KnockSpotsManager = Instantiate(Objects[0], KnockSpots_G3[7].GetChild(0).gameObject.transform.position,knock_Position.transform.rotation);
            KnockSpotsManager.transform.parent = KnockSpotscollect.transform;
            KnockSpotsManager = Instantiate(Objects[2], KnockSpots_G3[7].GetChild(1).gameObject.transform.position,knock_Position.transform.rotation);
            KnockSpotsManager.transform.parent = KnockSpotscollect.transform;
            KnockSpotsManager = Instantiate(Objects[1], KnockSpots_G3[7].GetChild(2).gameObject.transform.position,knock_Position.transform.rotation);
            KnockSpotsManager.transform.parent = KnockSpotscollect.transform;
            KnockSpotsManager = Instantiate(Objects[2], KnockSpots_G3[7].GetChild(3).gameObject.transform.position,knock_Position.transform.rotation);
            KnockSpotsManager.transform.parent = KnockSpotscollect.transform;
            KnockSpotsManager = Instantiate(Objects[0], KnockSpots_G3[7].GetChild(4).gameObject.transform.position,knock_Position.transform.rotation);
            KnockSpotsManager.transform.parent = KnockSpotscollect.transform;

            spotisexist= true;
        }
        else if(spotisexist == false && canKnock == true && gameObject.name == "glass9")
        {
            KnockSpotsManager = Instantiate(Objects[0], KnockSpots_G3[8].GetChild(0).gameObject.transform.position,knock_Position.transform.rotation);
            KnockSpotsManager.transform.parent = KnockSpotscollect.transform;
            KnockSpotsManager = Instantiate(Objects[2], KnockSpots_G3[8].GetChild(1).gameObject.transform.position,knock_Position.transform.rotation);
            KnockSpotsManager.transform.parent = KnockSpotscollect.transform;
            KnockSpotsManager = Instantiate(Objects[1], KnockSpots_G3[8].GetChild(2).gameObject.transform.position,knock_Position.transform.rotation);
            KnockSpotsManager.transform.parent = KnockSpotscollect.transform;
            KnockSpotsManager = Instantiate(Objects[2], KnockSpots_G3[8].GetChild(3).gameObject.transform.position,knock_Position.transform.rotation);
            KnockSpotsManager.transform.parent = KnockSpotscollect.transform;
            KnockSpotsManager = Instantiate(Objects[0], KnockSpots_G3[8].GetChild(4).gameObject.transform.position,knock_Position.transform.rotation);
            KnockSpotsManager.transform.parent = KnockSpotscollect.transform;

            spotisexist= true;
        }
        else if(spotisexist == false && canKnock == true && gameObject.name == "glass10")
        {
            KnockSpotsManager = Instantiate(Objects[0], KnockSpots_G3[9].GetChild(0).gameObject.transform.position,knock_Position.transform.rotation);
            KnockSpotsManager.transform.parent = KnockSpotscollect.transform;
            KnockSpotsManager = Instantiate(Objects[2], KnockSpots_G3[9].GetChild(1).gameObject.transform.position,knock_Position.transform.rotation);
            KnockSpotsManager.transform.parent = KnockSpotscollect.transform;
            KnockSpotsManager = Instantiate(Objects[1], KnockSpots_G3[9].GetChild(2).gameObject.transform.position,knock_Position.transform.rotation);
            KnockSpotsManager.transform.parent = KnockSpotscollect.transform;
            KnockSpotsManager = Instantiate(Objects[2], KnockSpots_G3[9].GetChild(3).gameObject.transform.position,knock_Position.transform.rotation);
            KnockSpotsManager.transform.parent = KnockSpotscollect.transform;
            KnockSpotsManager = Instantiate(Objects[0], KnockSpots_G3[9].GetChild(4).gameObject.transform.position,knock_Position.transform.rotation);
            KnockSpotsManager.transform.parent = KnockSpotscollect.transform;

            spotisexist= true;
        }
    }
    void KnockSpot_game1()
    {
        int Random_Objects = Random.Range(0, 0);
        
        if(spotisexist == false && knockcount<5 && canKnock == true)
        {
            Vector3 rnadomPos = new Vector3(Random.Range(-0.45f,0.45f),Random.Range(0.8f,1.8f),-0.1225f);
            Instantiate(Objects[Random_Objects], rnadomPos,knock_Position.transform.rotation);
            spotisexist =true;
            Debug.Log(rnadomPos);
        }
    }
    void KnockSpot_game2()
    {
        int Random_Objects = Random.Range(0, 2);

        if(spotisexist == false && knockcount<5 && canKnock == true)
        {
            Vector3 rnadomPos = new Vector3(Random.Range(-0.45f,0.45f),Random.Range(0.8f,1.8f),-0.1225f);
            Debug.Log(Random_Objects);
            Instantiate(Objects[Random_Objects], rnadomPos,knock_Position.transform.rotation);
            spotisexist =true;
        }
    }
    void KnockSpot_game3()
    {
        int Random_Objects = Random.Range(0, Objects.Length);

        if(spotisexist == false && knockcount<5 && canKnock == true)
        {
            if(Random_Objects == 0 || Random_Objects == 1)
            {
                Vector3 rnadomPos = new Vector3(Random.Range(-0.45f,0.45f),Random.Range(0.8f,1.8f),-0.1225f);
                Instantiate(Objects[Random_Objects], rnadomPos,knock_Position.transform.rotation);
                spotisexist =true;
            }
            else if(Random_Objects == 2)
            {
                Vector3 rnadomPos = new Vector3(Random.Range(-0.45f,0.45f),Random.Range(0.3f,0.4f),-0.1225f);
                Instantiate(Objects[Random_Objects], rnadomPos,knock_Position.transform.rotation);
                spotisexist =true;
                Debug.Log(rnadomPos);
            }
        }
    }
}
