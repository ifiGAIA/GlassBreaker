using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GlassManager : MonoBehaviour
{
    Scene scene;
    MeshRenderer meshRenderer;
    BoxCollider boxCollider;

    public Transform[] KnockSpots;
    private GameObject KnockSpotsManager;
    public GameObject KnockSpotscollect;
    // public GameObject[] KnockSpotsManager;

    public GameObject knock_Position;
    public GameObject[] Objects;
    public GameObject Prefab;
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
        if(other.gameObject.tag == "Left_hammer" || other.gameObject.tag == "Right_hammer")
        {
            audioSource.PlayOneShot(glassknock);
        }
    }
    void GameLevelSwitch()
    {
        if(glassMove.gameLevel == GameLevel.Game1)
        {
            // KnockSpot_game1();
            KnockSpot_Game1();
            Debug.Log("第一關");
        }
        else if(glassMove.gameLevel == GameLevel.Game2)
        {
            // KnockSpot_game2();
            KnockSpot_Game2();
            Debug.Log("第二關");
        }
        else if(glassMove.gameLevel == GameLevel.Game3)
        {
            KnockSpot_game3();
            Debug.Log("第三關");
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
            Invoke("DestroyGlass",10f);
        }
    }
    void DestroyGlass()
    {
        Destroy(gameObject);
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
                Instantiate(Objects[Random_Objects], KnockSpots[2].GetChild(i).gameObject.transform.position,knock_Position.transform.rotation);
                if(i==4)
                {
                    spotisexist= true;
                }
            }
        }
        else if(spotisexist == false && canKnock == true && gameObject.name == "glass4")
        {
            for(int i=0; i<5; i++)
            {
                int Random_Objects = Random.Range(0, 0);
                Instantiate(Objects[Random_Objects], KnockSpots[3].GetChild(i).gameObject.transform.position,knock_Position.transform.rotation);
                if(i==4)
                {
                    spotisexist= true;
                }
            }
        }
        else if(spotisexist == false && canKnock == true && gameObject.name == "glass5")
        {
            for(int i=0; i<5; i++)
            {
                int Random_Objects = Random.Range(0, 0);
                Instantiate(Objects[Random_Objects], KnockSpots[4].GetChild(i).gameObject.transform.position,knock_Position.transform.rotation);
                if(i==4)
                {
                    spotisexist= true;
                }
            }
        }
        else if(spotisexist == false && canKnock == true && gameObject.name == "glass6")
        {
            for(int i=0; i<5; i++)
            {
                int Random_Objects = Random.Range(0, 0);
                Instantiate(Objects[Random_Objects], KnockSpots[5].GetChild(i).gameObject.transform.position,knock_Position.transform.rotation);
                if(i==4)
                {
                    spotisexist= true;
                }
            }
        }
        else if(spotisexist == false && canKnock == true && gameObject.name == "glass7")
        {
            for(int i=0; i<5; i++)
            {
                int Random_Objects = Random.Range(0, 0);
                Instantiate(Objects[Random_Objects], KnockSpots[6].GetChild(i).gameObject.transform.position,knock_Position.transform.rotation);
                if(i==4)
                {
                    spotisexist= true;
                }
            }
        }
        else if(spotisexist == false && canKnock == true && gameObject.name == "glass8")
        {
            for(int i=0; i<5; i++)
            {
                int Random_Objects = Random.Range(0, 0);
                Instantiate(Objects[Random_Objects], KnockSpots[7].GetChild(i).gameObject.transform.position,knock_Position.transform.rotation);
                if(i==4)
                {
                    spotisexist= true;
                }
            }
        }
        else if(spotisexist == false && canKnock == true && gameObject.name == "glass9")
        {
            for(int i=0; i<5; i++)
            {
                int Random_Objects = Random.Range(0, 0);
                Instantiate(Objects[Random_Objects], KnockSpots[8].GetChild(i).gameObject.transform.position,knock_Position.transform.rotation);
                if(i==4)
                {
                    spotisexist= true;
                }
            }
        }
        else if(spotisexist == false && canKnock == true && gameObject.name == "glass10")
        {
            for(int i=0; i<5; i++)
            {
                int Random_Objects = Random.Range(0, 0);
                Instantiate(Objects[Random_Objects], KnockSpots[9].GetChild(i).gameObject.transform.position,knock_Position.transform.rotation);
                if(i==4)
                {
                    spotisexist= true;
                }
                Debug.Log(KnockSpots[9].GetChild(i).gameObject.transform.position);
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
                Instantiate(Objects[Random_Objects], KnockSpots[0].GetChild(i).gameObject.transform.position,knock_Position.transform.rotation);
                if(i==4)
                {
                    spotisexist= true;
                }

            }
        }
        else if(spotisexist == false && canKnock == true && gameObject.name == "glass2")
        {
            for(int i=0; i<5; i++)
            {
                int Random_Objects = Random.Range(0, 2);
                Instantiate(Objects[Random_Objects], KnockSpots[1].GetChild(i).gameObject.transform.position,knock_Position.transform.rotation);
                if(i==4)
                {
                    spotisexist= true;
                }
            }
        }
        else if(spotisexist == false && canKnock == true && gameObject.name == "glass3")
        {
            for(int i=0; i<5; i++)
            {
                int Random_Objects = Random.Range(0, 2);
                Instantiate(Objects[Random_Objects], KnockSpots[2].GetChild(i).gameObject.transform.position,knock_Position.transform.rotation);
                if(i==4)
                {
                    spotisexist= true;
                }
            }
        }
        else if(spotisexist == false && canKnock == true && gameObject.name == "glass4")
        {
            for(int i=0; i<5; i++)
            {
                int Random_Objects = Random.Range(0, 2);
                Instantiate(Objects[Random_Objects], KnockSpots[3].GetChild(i).gameObject.transform.position,knock_Position.transform.rotation);
                if(i==4)
                {
                    spotisexist= true;
                }
            }
        }
        else if(spotisexist == false && canKnock == true && gameObject.name == "glass5")
        {
            for(int i=0; i<5; i++)
            {
                int Random_Objects = Random.Range(0, 2);
                Instantiate(Objects[Random_Objects], KnockSpots[4].GetChild(i).gameObject.transform.position,knock_Position.transform.rotation);
                if(i==4)
                {
                    spotisexist= true;
                }
            }
        }
        else if(spotisexist == false && canKnock == true && gameObject.name == "glass6")
        {
            for(int i=0; i<5; i++)
            {
                int Random_Objects = Random.Range(0, 2);
                Instantiate(Objects[Random_Objects], KnockSpots[5].GetChild(i).gameObject.transform.position,knock_Position.transform.rotation);
                if(i==4)
                {
                    spotisexist= true;
                }
            }
        }
        else if(spotisexist == false && canKnock == true && gameObject.name == "glass7")
        {
            for(int i=0; i<5; i++)
            {
                int Random_Objects = Random.Range(0, 2);
                Instantiate(Objects[Random_Objects], KnockSpots[6].GetChild(i).gameObject.transform.position,knock_Position.transform.rotation);
                if(i==4)
                {
                    spotisexist= true;
                }
            }
        }
        else if(spotisexist == false && canKnock == true && gameObject.name == "glass8")
        {
            for(int i=0; i<5; i++)
            {
                int Random_Objects = Random.Range(0, 2);
                Instantiate(Objects[Random_Objects], KnockSpots[7].GetChild(i).gameObject.transform.position,knock_Position.transform.rotation);
                if(i==4)
                {
                    spotisexist= true;
                }
            }
        }
        else if(spotisexist == false && canKnock == true && gameObject.name == "glass9")
        {
            for(int i=0; i<5; i++)
            {
                int Random_Objects = Random.Range(0, 2);
                Instantiate(Objects[Random_Objects], KnockSpots[8].GetChild(i).gameObject.transform.position,knock_Position.transform.rotation);
                if(i==4)
                {
                    spotisexist= true;
                }
            }
        }
        else if(spotisexist == false && canKnock == true && gameObject.name == "glass10")
        {
            for(int i=0; i<5; i++)
            {
                int Random_Objects = Random.Range(0, 2);
                Instantiate(Objects[Random_Objects], KnockSpots[9].GetChild(i).gameObject.transform.position,knock_Position.transform.rotation);
                if(i==4)
                {
                    spotisexist= true;
                }
                Debug.Log(KnockSpots[9].GetChild(i).gameObject.transform.position);
            }
        }
    }
    void KnockSpot_game1()
    {
        int Random_Objects = Random.Range(0, 0);
        
        if(spotisexist == false && knockcount<5 && canKnock == true)
        {
            Vector3 rnadomPos = new Vector3(Random.Range(-0.45f,0.45f),Random.Range(0.8f,1.8f),knock_Position.transform.position.z);
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
            Vector3 rnadomPos = new Vector3(Random.Range(-0.45f,0.45f),Random.Range(0.8f,1.8f),knock_Position.transform.position.z);
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
                Vector3 rnadomPos = new Vector3(Random.Range(-0.45f,0.45f),Random.Range(0.8f,1.8f),knock_Position.transform.position.z);
                Instantiate(Objects[Random_Objects], rnadomPos,knock_Position.transform.rotation);
                spotisexist =true;
            }
            else if(Random_Objects == 2)
            {
                Vector3 rnadomPos = new Vector3(Random.Range(-0.45f,0.45f),Random.Range(0.2f,0.4f),knock_Position.transform.position.z);
                Instantiate(Objects[Random_Objects], rnadomPos,knock_Position.transform.rotation);
                spotisexist =true;
            }
        }
    }
}
