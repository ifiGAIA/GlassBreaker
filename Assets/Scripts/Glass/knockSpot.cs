using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class knockSpot : MonoBehaviour
{
    GlassManager Glass;
    // GameObject[] Glass;
    // Start is called before the first frame update
    void Start()
    {
        Glass = GameObject.FindWithTag("glass").gameObject.GetComponent<GlassManager>();
        // Glass = GameObject.FindGameObjectsWithTag("glass"); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "hammer" && gameObject.tag == "red")
        {
            Glass.spotisexist=false;
            Glass.KnockCount();
            Destroy(gameObject);
            Debug.Log("紅色");
        }
        else if(other.gameObject.tag == "hammer" && gameObject.tag == "green")
        {
            Glass.spotisexist=false;
            Glass.KnockCount();
            Destroy(gameObject);
            Debug.Log("綠色");
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
