using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuButton : MonoBehaviour
{
    Image image;
    Color imagecolor;
    public AudioClip knock;
    AudioSource audioSource;
    Timecounting timecounting;
    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
        imagecolor = image.color;
        audioSource = GetComponent<AudioSource>();
        timecounting = GameObject.Find("Time").GetComponent<Timecounting>();
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
    }
    void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Left_hammer" || other.gameObject.tag == "Right_hammer")
        {
            imagecolor.a = 0.4f;
            image.color = new Color(image.color.r,image.color.g,image.color.b,imagecolor.a);
            timecounting.gamestart = true;
        }
    }
}
