using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class knockSpot : MonoBehaviour
{
    GlassManager Glass;
    GlassMove glassMove;
    // Start is called before the first frame update
    void Start()
    {
        Glass = GameObject.FindWithTag("glass").gameObject.GetComponent<GlassManager>();
        glassMove = GameObject.Find("Glass").GetComponent<GlassMove>();
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
        if(glassMove.gameLevel == GameLevel.Game1)
        {
            if(other.gameObject.tag == "Left_hammer" || other.gameObject.tag == "Right_hammer")
            {
                Glass.spotisexist=false;
                Glass.KnockCount();
                Destroy(gameObject);
                // Invoke("DestroyGlass",1f);
                Debug.Log("紅色");
            }
        }
        else if(glassMove.gameLevel == GameLevel.Game2)
        {
            if(other.gameObject.tag == "Left_hammer" && gameObject.tag == "red")
            {
                Glass.spotisexist=false;
                Glass.KnockCount();
                Destroy(gameObject);
                Debug.Log("紅色");
            }
            else if(other.gameObject.tag == "Right_hammer" && gameObject.tag == "green")
            {
                Glass.spotisexist=false;
                Glass.KnockCount();
                Destroy(gameObject);
                Debug.Log("綠色");
            }
        }
        else if(glassMove.gameLevel == GameLevel.Game3)
        {
            if(other.gameObject.tag == "Left_hammer" && gameObject.tag == "red")
            {
                Glass.spotisexist=false;
                Glass.KnockCount();
                Destroy(gameObject);
                Debug.Log("紅色");
            }
            else if(other.gameObject.tag == "Right_hammer" && gameObject.tag == "green")
            {
                Glass.spotisexist=false;
                Glass.KnockCount();
                Destroy(gameObject);
                Debug.Log("綠色");
            }
            else if(other.gameObject.tag == "foot" && gameObject.tag == "purple")
            {
                Glass.spotisexist=false;
                Glass.KnockCount();
                Destroy(gameObject);
                Debug.Log("紫色");
            }
        }
    }
    void OnMouseDown()
    {
        if(gameObject.tag == "red")
        {
            Debug.Log("紅色");
        }
        if(gameObject.tag == "green")
        {
            Debug.Log("綠色");
        }
        Glass.spotisexist=false;
        Glass.KnockCount();
        Destroy(gameObject);
    }
}
