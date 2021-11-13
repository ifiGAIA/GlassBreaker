using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockSpotManager : MonoBehaviour
{
    public Transform Knock;
    // public GameObject[] KnockSpots;
    public bool start;
    public bool knocking;
    public bool spot1;
    public bool spot2;
    public bool spot3;
    public bool spot4;
    public bool spot5;

    // Start is called before the first frame update
    void Start()
    {
        start = true;
        spot1 = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(start)
        {
            for(int i=1; i<=4;i++)
            {
                Knock.GetChild(i).gameObject.GetComponentInChildren<Light>().enabled = false;
                Knock.GetChild(i).gameObject.GetComponent<CapsuleCollider>().enabled = false;
            }
        }
        if(knocking)
        {
            KnockSpot();
            knocking = false;
        }
        // KnockSpot();
        SpotManager();
    }
    void SpotManager()
    {
        if(spot1 == true)
        {
            Knock.GetChild(0).gameObject.GetComponentInChildren<Light>().enabled = true;
            Knock.GetChild(0).gameObject.GetComponent<CapsuleCollider>().enabled = true;
        }
        if(spot2 == true)
        {
            Knock.GetChild(1).gameObject.GetComponentInChildren<Light>().enabled = true;
            Knock.GetChild(1).gameObject.GetComponent<CapsuleCollider>().enabled = true;
        }
        if(spot3 == true)
        {
            Knock.GetChild(2).gameObject.GetComponentInChildren<Light>().enabled = true;
            Knock.GetChild(2).gameObject.GetComponent<CapsuleCollider>().enabled = true;
        }
        if(spot4 == true)
        {
            Knock.GetChild(3).gameObject.GetComponentInChildren<Light>().enabled = true;
            Knock.GetChild(3).gameObject.GetComponent<CapsuleCollider>().enabled = true;
        }
        if(spot5 == true)
        {
            Knock.GetChild(4).gameObject.GetComponentInChildren<Light>().enabled = true;
            Knock.GetChild(4).gameObject.GetComponent<CapsuleCollider>().enabled = true;
        }
    }
    public void KnockSpot()
    {
        if(spot1 == true)
        {
            spot2 = true;
            spot1 = false;
            start = false;
        }
        else if(spot2 == true && start == false)
        {
            spot3 = true;
            spot2 = false;
        }
        else if(spot3 == true && spot2 == false)
        {
            spot4 = true;
            spot3 = false;
        }
        else if(spot4 == true && spot3 == false)
        {
            spot5 = true;
            spot4 = false;
        }
        else if(spot5 == true && spot4 == false)
        {
            start = true;
            spot1 = true;
            spot2 = false;
            spot3 = false;
            spot4 = false;
            spot5 = false;
            Invoke("Destroyspot",0.5f);
        }
    }
    void Destroyspot()
    {
        for(int i=0; i<=5; i++)
        {
            Destroy(Knock.GetChild(i).gameObject);
        }
    }
}
