using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slotmachine : MonoBehaviour
{
    BoxCollider boxCollider;
    public float glasscount;
    public float speed;
    Text glasscountText;
    Text speedText;
    public bool countresult;
    public bool speedresult;
    // Start is called before the first frame update
    void Start()
    {
        glasscountText = gameObject.transform.GetChild(1).GetComponent<Text>();
        speedText = gameObject.transform.GetChild(1).GetComponent<Text>();
        boxCollider = GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!countresult)
        {
            Screenglasscount();
        }
        if(!speedresult)
        {
            Screenspeed();
        }
    }
    void Screenglasscount()
    {
        if(gameObject.name == "Glasscount")
        {
            glasscount = Random.Range(10, 21);  
            glasscountText.text = glasscount.ToString();
        }
    }
    void Screenspeed()
    {
        if(gameObject.name == "Speed")
        {
            speed = Random.Range(3, 8);
            speedText.text = speed.ToString();
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Left_hammer" && gameObject.name == "Glasscount" || other.gameObject.tag == "Right_hammer" && gameObject.name == "Glasscount")
        {
            countresult = true;
            boxCollider.enabled = false;
        }
        else if(other.gameObject.tag == "Left_hammer" && gameObject.name == "Speed" || other.gameObject.tag == "Right_hammer" && gameObject.name == "Speed")
        {
            speedresult = true;
            boxCollider.enabled = false;
        }
    }
}
