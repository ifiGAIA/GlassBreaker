using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlassShatterKnock : MonoBehaviour
{
    GlassShatter Glass;
    Transform Glasscrack;
    private GameObject crack;
    public GameObject[] Objects;
    GotoGame1 gotoGame1;

    // Start is called before the first frame update
    void Start()
    {
        Glass = GameObject.FindWithTag("glass").gameObject.GetComponent<GlassShatter>();
        Glasscrack = GameObject.FindWithTag("glasscrack").gameObject.transform;
        gotoGame1 = GameObject.Find("Table").GetComponent<GotoGame1>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other)
    {
        int Random_Objects = Random.Range(0, Objects.Length);
        if(gotoGame1.glassChoose == GlassChoose.RR)
        {
            if(other.gameObject.tag == "Left_hammer" || other.gameObject.tag == "Right_hammer")
            {
                crack = Instantiate(Objects[Random_Objects], new Vector3(gameObject.transform.position.x,gameObject.transform.position.y,0.964f),Quaternion.Euler(0f,0.0f,0.0f));
                crack.transform.parent = Glasscrack;

                Glass.spotisexist=false;
                Glass.KnockCount();
                other.gameObject.tag = "Untagged";
                Destroy(gameObject);
            }
        }
        else if(gotoGame1.glassChoose == GlassChoose.RG)
        {
            if(other.gameObject.tag == "Left_hammer" && gameObject.tag == "red")
            {
                crack = Instantiate(Objects[Random_Objects], new Vector3(gameObject.transform.position.x,gameObject.transform.position.y,0.964f),Quaternion.Euler(0f,0.0f,0.0f));
                crack.transform.parent = Glasscrack;

                Glass.spotisexist=false;
                Glass.KnockCount();
                other.gameObject.tag = "Untagged";
                Destroy(gameObject);
            }
            else if(other.gameObject.tag == "Right_hammer" && gameObject.tag == "green")
            {
                crack = Instantiate(Objects[Random_Objects], new Vector3(gameObject.transform.position.x,gameObject.transform.position.y,0.964f),Quaternion.Euler(0f,0.0f,0.0f));
                crack.transform.parent = Glasscrack;

                Glass.spotisexist=false;
                Glass.KnockCount();
                other.gameObject.tag = "Untagged";
                Destroy(gameObject);
            }
        }
        else if(gotoGame1.glassChoose == GlassChoose.RRf)
        {
            if(other.gameObject.tag == "Left_hammer" && gameObject.tag == "red"|| other.gameObject.tag == "Right_hammer" && gameObject.tag == "red")
            {
                crack = Instantiate(Objects[Random_Objects], new Vector3(gameObject.transform.position.x,gameObject.transform.position.y,0.964f),Quaternion.Euler(0f,0.0f,0.0f));
                crack.transform.parent = Glasscrack;

                Glass.spotisexist=false;
                Glass.KnockCount();
                other.gameObject.tag = "Untagged";
                Destroy(gameObject);
            }
            else if(other.gameObject.tag == "foot" && gameObject.tag == "purple")
            {
                crack = Instantiate(Objects[Random_Objects], new Vector3(gameObject.transform.position.x,gameObject.transform.position.y,0.964f),Quaternion.Euler(0f,0.0f,0.0f));
                crack.transform.parent = Glasscrack;
                
                Glass.spotisexist=false;
                Glass.KnockCount();
                other.gameObject.tag = "Untagged";
                Destroy(gameObject);
            }
            else if(other.gameObject.tag == "foot" && gameObject.tag == "yellow")
            {
                crack = Instantiate(Objects[Random_Objects], new Vector3(gameObject.transform.position.x,gameObject.transform.position.y,0.964f),Quaternion.Euler(0f,0.0f,0.0f));
                crack.transform.parent = Glasscrack;
                
                Glass.spotisexist=false;
                Glass.KnockCount();
                other.gameObject.tag = "Untagged";
                Destroy(gameObject);
            }
        }
        else if(gotoGame1.glassChoose == GlassChoose.RGf)
        {
            if(other.gameObject.tag == "Left_hammer" && gameObject.tag == "red")
            {
                crack = Instantiate(Objects[Random_Objects], new Vector3(gameObject.transform.position.x,gameObject.transform.position.y,0.964f),Quaternion.Euler(0f,0.0f,0.0f));
                crack.transform.parent = Glasscrack;

                Glass.spotisexist=false;
                Glass.KnockCount();
                other.gameObject.tag = "Untagged";
                Destroy(gameObject);
            }
            else if(other.gameObject.tag == "Right_hammer" && gameObject.tag == "green")
            {
                crack = Instantiate(Objects[Random_Objects], new Vector3(gameObject.transform.position.x,gameObject.transform.position.y,0.964f),Quaternion.Euler(0f,0.0f,0.0f));
                crack.transform.parent = Glasscrack;

                Glass.spotisexist=false;
                Glass.KnockCount();
                other.gameObject.tag = "Untagged";
                Destroy(gameObject);
            }
            else if(other.gameObject.tag == "foot" && gameObject.tag == "purple")
            {
                crack = Instantiate(Objects[Random_Objects], new Vector3(gameObject.transform.position.x,gameObject.transform.position.y,0.964f),Quaternion.Euler(0f,0.0f,0.0f));
                crack.transform.parent = Glasscrack;
                
                Glass.spotisexist=false;
                Glass.KnockCount();
                other.gameObject.tag = "Untagged";
                Destroy(gameObject);
            }
            else if(other.gameObject.tag == "foot" && gameObject.tag == "yellow")
            {
                crack = Instantiate(Objects[Random_Objects], new Vector3(gameObject.transform.position.x,gameObject.transform.position.y,0.964f),Quaternion.Euler(0f,0.0f,0.0f));
                crack.transform.parent = Glasscrack;
                
                Glass.spotisexist=false;
                Glass.KnockCount();
                other.gameObject.tag = "Untagged";
                Destroy(gameObject);
            }
        }
    }
}
