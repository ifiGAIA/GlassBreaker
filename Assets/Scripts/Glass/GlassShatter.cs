using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlassShatter : MonoBehaviour
{
    MeshRenderer meshRenderer;
    BoxCollider boxCollider;
    GotoGame1 gotoGame1;
    public GameObject explosionGlass;
    public AudioClip glassbroken;
    public AudioClip glassshatter;
    AudioSource audioSource;
    public bool gameStart;

    public GameObject glassPos;
    public GameObject knock_Position;
    public GameObject[] Objects;
    public bool canKnock = false;
    public bool spotisexist = false;
    public bool canMove = false;
    public int knockcount = 0;
    // Start is called before the first frame update
    void Start()
    {
        gotoGame1 = GameObject.Find("Table").GetComponent<GotoGame1>();
        meshRenderer = GetComponent<MeshRenderer>();
        boxCollider = GetComponent<BoxCollider>();
        explosionGlass.SetActive(false);
        audioSource = GetComponent<AudioSource>();
        glassPos = GameObject.Find("glassPos");
    }

    // Update is called once per frame
    void Update()
    {
        GlasscanKnock();
        GlassSwitch();
    }
    void GlassSwitch()
    {
        if(gotoGame1.glassChoose == GlassChoose.RR)
        {
            KnockSpot_game1();
        }
        else if(gotoGame1.glassChoose == GlassChoose.RG)
        {
            KnockSpot_game2();
        }
        else if(gotoGame1.glassChoose == GlassChoose.RRf)
        {
            KnockSpot_game3();
        }
        else if(gotoGame1.glassChoose == GlassChoose.RGf)
        {
            KnockSpot_game4();
        }
    }
    void GlassBroken()
    {
        if(canMove == true)
        {
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
    }
    void ToGame()
    {
        gameStart = true;
    }
    void GlasscanKnock()
    {
        if(gameObject.transform.position == glassPos.transform.position)
        {
            canKnock = true;
        }
    }
    public void KnockCount()
    {
        knockcount += 1;
        audioSource.PlayOneShot(glassbroken);
        if(knockcount == 5)
        {
            canMove = true;
            gotoGame1.glassisbroken = true;
        }
    }
    void KnockSpot_game1()
    {
        int Random_Objects = Random.Range(0, 0);
        
        if(spotisexist == false && knockcount<5 && canKnock == true)
        {
            Vector3 rnadomPos = new Vector3(Random.Range(-0.45f,0.45f),Random.Range(0.8f,1.8f),0.8775f);
            Instantiate(Objects[Random_Objects], rnadomPos,knock_Position.transform.rotation);
            spotisexist =true;
        }
    }
    void KnockSpot_game2()
    {
        int Random_Objects = Random.Range(0, 2);

        if(spotisexist == false && knockcount<5 && canKnock == true)
        {
            Vector3 rnadomPos = new Vector3(Random.Range(-0.45f,0.45f),Random.Range(0.8f,1.8f),0.8775f);
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
                Vector3 rnadomPos = new Vector3(Random.Range(-0.45f,0.45f),Random.Range(0.8f,1.8f),0.8775f);
                Instantiate(Objects[0], rnadomPos,knock_Position.transform.rotation);
                spotisexist =true;
            }
            else if(Random_Objects == 2)
            {
                Vector3 rnadomPos = new Vector3(Random.Range(-0.45f,0.45f),Random.Range(0.3f,0.45f),0.8775f);
                Instantiate(Objects[Random_Objects], rnadomPos,knock_Position.transform.rotation);
                spotisexist =true;
            }
        }
    }
    void KnockSpot_game4()
    {
        int Random_Objects = Random.Range(0, Objects.Length);

        if(spotisexist == false && knockcount<5 && canKnock == true)
        {
            if(Random_Objects == 0 || Random_Objects == 1)
            {
                Vector3 rnadomPos = new Vector3(Random.Range(-0.45f,0.45f),Random.Range(0.8f,1.8f),0.8775f);
                Instantiate(Objects[Random_Objects], rnadomPos,knock_Position.transform.rotation);
                spotisexist =true;
            }
            else if(Random_Objects == 2)
            {
                Vector3 rnadomPos = new Vector3(Random.Range(-0.45f,0.45f),Random.Range(0.3f,0.45f),0.8775f);
                Instantiate(Objects[Random_Objects], rnadomPos,knock_Position.transform.rotation);
                spotisexist =true;
            }
        }
    }
}
