using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GlassManager : MonoBehaviour
{
    Scene scene;
    MeshRenderer meshRenderer;
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
    // Start is called before the first frame update
    void Start()
    {
        scene = SceneManager.GetActiveScene();
        meshRenderer = GetComponent<MeshRenderer>();
        glassMove = GameObject.Find("Glass").GetComponent<GlassMove>();
        explosionGlass.SetActive(false);
        glassPos = GameObject.Find("glassPos");
    }

    // Update is called once per frame
    void Update()
    {
        GlassBroken();
        GlasscanKnock();
        if(scene.name == ("Game1"))
        {
            KnockSpot_game1();
        }
        else if(scene.name == ("TestScenes"))
        {
            KnockSpot_game2();
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
            meshRenderer.enabled = false;
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
        int Random_Objects = Random.Range(0, Objects.Length);

        if(spotisexist == false && knockcount<5 && canKnock == true)
        {
            Vector3 rnadomPos = new Vector3(Random.Range(-0.73f,0.73f),Random.Range(0.5f,1.8f),knock_Position.transform.position.z);
            Instantiate(Objects[Random_Objects], rnadomPos,knock_Position.transform.rotation);
            spotisexist =true;
        }
    }
    void KnockSpot_game3()
    {
        int Random_Objects = Random.Range(0, Objects.Length);

        if(spotisexist == false && knockcount<5 && canKnock == true)
        {
            Vector3 rnadomPos = new Vector3(Random.Range(-0.73f,0.73f),Random.Range(0.0f,0.5f),knock_Position.transform.position.z);
            Instantiate(Objects[Random_Objects], rnadomPos,knock_Position.transform.rotation);
            spotisexist =true;
        }
    }
}
