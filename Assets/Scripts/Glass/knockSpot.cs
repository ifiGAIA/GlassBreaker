using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class knockSpot : MonoBehaviour
{
    GlassManager Glass;
    KnockSpotManager knockSpotManager;
    Transform Glasscrack;
    GlassMove glassMove;
    private GameObject crack;
    public GameObject[] Objects;

    // Start is called before the first frame update
    void Start()
    {
        Glass = GameObject.FindWithTag("glass").gameObject.GetComponent<GlassManager>();
        knockSpotManager = GameObject.FindWithTag("KnockSpotManager").gameObject.GetComponent<KnockSpotManager>();

        glassMove = GameObject.Find("Glass").GetComponent<GlassMove>();
        Glasscrack = GameObject.FindWithTag("glasscrack").gameObject.transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void DestroyGlass()
    {
        Destroy(gameObject);
    }
    void OnTriggerEnter(Collider other)
    {
        int Random_Objects = Random.Range(0, Objects.Length);
        if(glassMove.gameLevel == GameLevel.Game1)
        {
            if(other.gameObject.tag == "Left_hammer" || other.gameObject.tag == "Right_hammer")
            {
                crack = Instantiate(Objects[Random_Objects], new Vector3(gameObject.transform.position.x,gameObject.transform.position.y,0.964f),Quaternion.Euler(0f,0.0f,0.0f));
                crack.transform.parent = Glasscrack;

                // Glass.spotisexist=false;
                knockSpotManager.KnockSpot();
                Glass.KnockCount();

                gameObject.GetComponent<CapsuleCollider>().enabled = false;
                gameObject.GetComponentInChildren<Light>().enabled = false;
                // Destroy(gameObject);
                // Debug.Log("紅色");
            }
        }
        else if(glassMove.gameLevel == GameLevel.Game2)
        {
            if(other.gameObject.tag == "Left_hammer" && gameObject.tag == "red")
            {
                crack = Instantiate(Objects[Random_Objects], new Vector3(gameObject.transform.position.x,gameObject.transform.position.y,0.964f),Quaternion.Euler(0f,0.0f,0.0f));
                crack.transform.parent = Glasscrack;

                // Glass.spotisexist=false;
                knockSpotManager.KnockSpot();
                Glass.KnockCount();

                gameObject.GetComponent<CapsuleCollider>().enabled = false;
                gameObject.GetComponentInChildren<Light>().enabled = false;
                // Destroy(gameObject);
                // Debug.Log("紅色");
            }
            else if(other.gameObject.tag == "Right_hammer" && gameObject.tag == "green")
            {
                crack = Instantiate(Objects[Random_Objects], new Vector3(gameObject.transform.position.x,gameObject.transform.position.y,0.964f),Quaternion.Euler(0f,0.0f,0.0f));
                crack.transform.parent = Glasscrack;

                // Glass.spotisexist=false;
                knockSpotManager.KnockSpot();
                Glass.KnockCount();

                gameObject.GetComponent<CapsuleCollider>().enabled = false;
                gameObject.GetComponentInChildren<Light>().enabled = false;
                // Destroy(gameObject);
                // Debug.Log("綠色");
            }
        }
        else if(glassMove.gameLevel == GameLevel.Game3)
        {
            if(other.gameObject.tag == "Left_hammer" && gameObject.tag == "red")
            {
                crack = Instantiate(Objects[Random_Objects], new Vector3(gameObject.transform.position.x,gameObject.transform.position.y,0.964f),Quaternion.Euler(0f,0.0f,0.0f));
                crack.transform.parent = Glasscrack;

                // Glass.spotisexist=false;
                knockSpotManager.KnockSpot();
                Glass.KnockCount();

                gameObject.GetComponent<CapsuleCollider>().enabled = false;
                gameObject.GetComponentInChildren<Light>().enabled = false;
                // Destroy(gameObject);
                // Debug.Log("紅色");
            }
            else if(other.gameObject.tag == "Right_hammer" && gameObject.tag == "green")
            {
                crack = Instantiate(Objects[Random_Objects], new Vector3(gameObject.transform.position.x,gameObject.transform.position.y,0.964f),Quaternion.Euler(0f,0.0f,0.0f));
                crack.transform.parent = Glasscrack;

                // Glass.spotisexist=false;
                knockSpotManager.KnockSpot();
                Glass.KnockCount();

                gameObject.GetComponent<CapsuleCollider>().enabled = false;
                gameObject.GetComponentInChildren<Light>().enabled = false;
                // Destroy(gameObject);
                // Debug.Log("綠色");
            }
            else if(other.gameObject.tag == "foot" && gameObject.tag == "purple")
            {
                crack = Instantiate(Objects[Random_Objects], new Vector3(gameObject.transform.position.x,gameObject.transform.position.y,0.964f),Quaternion.Euler(0f,0.0f,0.0f));
                crack.transform.parent = Glasscrack;
                
                // Glass.spotisexist=false;
                knockSpotManager.KnockSpot();
                Glass.KnockCount();

                gameObject.GetComponent<CapsuleCollider>().enabled = false;
                gameObject.GetComponentInChildren<Light>().enabled = false;
                // Destroy(gameObject);
                // Debug.Log("紫色");
            }
        }
    }
    void OnMouseDown()
    {
        int Random_Objects = Random.Range(0, Objects.Length);
        crack = Instantiate(Objects[Random_Objects], gameObject.transform.position,Quaternion.Euler(0f,0.0f,0.0f));
        crack.transform.parent = Glasscrack;
        // Glass.spotisexist=false;
        knockSpotManager.KnockSpot();
        Glass.KnockCount();
        // Destroy(gameObject);
        gameObject.GetComponent<CapsuleCollider>().enabled = false;
        gameObject.GetComponentInChildren<Light>().enabled = false;
    }
}
