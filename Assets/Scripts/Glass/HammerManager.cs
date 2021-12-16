using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class HammerManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "CanKnock" && gameObject.name == "Knockspot_Left")
        {
            gameObject.tag = "Left_hammer";
        }
        else if(other.gameObject.name == "CanKnock" && gameObject.name == "Knockspot_Right")
        {
            gameObject.tag = "Right_hammer";
        }
        else if(other.gameObject.name == "CanKnock" && gameObject.name == "boots_Left")
        {
            gameObject.tag = "Left_foot";
        }
        else if(other.gameObject.name == "CanKnock" && gameObject.name == "boots_Right")
        {
            gameObject.tag = "Right_foot";
        }
    }    
}
