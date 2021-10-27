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
        if(other.gameObject.tag == "hammer")
        {
            Glass.spotisexist=false;
            Glass.KnockCount();
            Destroy(gameObject);
        }
    }
    void OnMouseDown()
    {
        Glass.spotisexist=false;
        Glass.KnockCount();
        Destroy(gameObject);
    }
}
