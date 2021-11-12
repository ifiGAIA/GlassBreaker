using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockSpotManager : MonoBehaviour
{
    public Transform Knock;
    public bool start;
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
                Knock.GetChild(i).gameObject.SetActive(false);
            }
        }
        KnockSpot();
        SpotManager();
    }
    void SpotManager()
    {
        if(spot1 == true)
        {
            Knock.GetChild(0).gameObject.SetActive(true);
        }
        if(spot2 == true)
        {
            Knock.GetChild(1).gameObject.SetActive(true);
        }
        if(spot3 == true)
        {
            Knock.GetChild(2).gameObject.SetActive(true);
        }
        if(spot4 == true)
        {
            Knock.GetChild(3).gameObject.SetActive(true);
        }
        if(spot5 == true)
        {
            Knock.GetChild(4).gameObject.SetActive(true);
        }
    }
    void KnockSpot()
    {
        if(spot1 == false)
        {
            spot2 = true;
            start = false;
        }
        else if(spot2 == false)
        {
            spot3 = true;
        }
        else if(spot3 == false)
        {
            spot4 = true;
        }
        else if(spot4 == false)
        {
            spot5 = true;
        }
        else if(spot5 == false)
        {
            start = true;
        }
    }
}
