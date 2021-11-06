using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GlassManager : MonoBehaviour
{
    Scene scene;
    MeshRenderer meshRenderer;
    BoxCollider boxCollider;
    public GameObject knock_Position;
    public GameObject[] Objects;
    public GameObject Prefab;
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
    void GameLevelSwitch()
    {
        if(glassMove.gameLevel == GameLevel.Game1)
        {
            KnockSpot_game1();
            Debug.Log("第一關");
        }
        else if(glassMove.gameLevel == GameLevel.Game2)
        {
            KnockSpot_game2();
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
        }
    }
    void KnockSpot_game1()
    {
        int Random_Objects = Random.Range(0, 0);

        if(spotisexist == false && knockcount<5 && canKnock == true)
        {
            Vector3 rnadomPos = new Vector3(Random.Range(-0.73f,0.73f),Random.Range(0.5f,1.8f),knock_Position.transform.position.z);
            Instantiate(Objects[Random_Objects], rnadomPos,knock_Position.transform.rotation);
            spotisexist =true;
        }
    }
    void KnockSpot_game2()
    {
        int Random_Objects = Random.Range(0, 2);

        if(spotisexist == false && knockcount<5 && canKnock == true)
        {
            Vector3 rnadomPos = new Vector3(Random.Range(-0.73f,0.73f),Random.Range(0.5f,1.8f),knock_Position.transform.position.z);
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
                Vector3 rnadomPos = new Vector3(Random.Range(-0.73f,0.73f),Random.Range(0.5f,1.8f),knock_Position.transform.position.z);
                Instantiate(Objects[Random_Objects], rnadomPos,knock_Position.transform.rotation);
                spotisexist =true;
            }
            else if(Random_Objects == 2)
            {
                Vector3 rnadomPos = new Vector3(Random.Range(-0.73f,0.73f),Random.Range(0.2f,0.4f),knock_Position.transform.position.z);
                Instantiate(Objects[Random_Objects], rnadomPos,knock_Position.transform.rotation);
                spotisexist =true;
            }
        }
    }
}
