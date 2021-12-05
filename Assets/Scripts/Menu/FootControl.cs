using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FootControl : MonoBehaviour
{
    Image image;
    Color imagecolor;
    public AudioClip knock;
    AudioSource audioSource;
    BoxCollider boxCollider;
    // Start is called before the first frame update
    void Start()
    {
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
    }
    void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Left_hammer" || other.gameObject.tag == "Right_hammer")
        {
            imagecolor.a = 0.4f;
            image.color = new Color(image.color.r,image.color.g,image.color.b,imagecolor.a);
        }
        if(gameObject.name == "Leftfoot")
        {
            GameManager.Instance.leftFoot = true;
            GameManager.Instance.rightFoot = false;
        }
        else if(gameObject.name == "Rightfoot")
        {
            GameManager.Instance.leftFoot = false;
            GameManager.Instance.rightFoot = true;
        }
    }
}
