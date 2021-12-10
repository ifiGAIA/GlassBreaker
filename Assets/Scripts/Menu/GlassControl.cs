using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GlassControl : MonoBehaviour
{
    GotoGame1 gotoGame1;
    Image image;
    Color imagecolor;
    public AudioClip knock;
    AudioSource audioSource;
    BoxCollider boxCollider;

    // Start is called before the first frame update
    void Start()
    {
        gotoGame1 = GameObject.Find("Table").GetComponent<GotoGame1>();
        boxCollider = GetComponent<BoxCollider>();
        image = gameObject.transform.GetChild(0).GetComponent<Image>();
        imagecolor = image.color;
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Left_hammer" || other.gameObject.tag == "Right_hammer")
        {
            imagecolor.a = 0.8f;
            image.color = new Color(image.color.r,image.color.g,image.color.b,imagecolor.a);
            audioSource.PlayOneShot(knock);
        }
        if(other.gameObject.tag == "Left_hammer" && gameObject.name == "1" || other.gameObject.tag == "Right_hammer" && gameObject.name == "1")
        {
            gotoGame1.ChooseGlass_RR();
        }
        else if(other.gameObject.tag == "Left_hammer" && gameObject.name == "2" || other.gameObject.tag == "Right_hammer" && gameObject.name == "2")
        {
            gotoGame1.ChooseGlass_RG();
        }
        else if(other.gameObject.tag == "Left_hammer" && gameObject.name == "3" || other.gameObject.tag == "Right_hammer" && gameObject.name == "3")
        {
            gotoGame1.ChooseGlass_RRf();
        }
        else if(other.gameObject.tag == "Left_hammer" && gameObject.name == "4" || other.gameObject.tag == "Right_hammer" && gameObject.name == "4")
        {
            gotoGame1.ChooseGlass_RGf();
        }
    }
    void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Left_hammer" || other.gameObject.tag == "Right_hammer")
        {
            imagecolor.a = 0.4f;
            image.color = new Color(image.color.r,image.color.g,image.color.b,imagecolor.a);
        }
    }
}
