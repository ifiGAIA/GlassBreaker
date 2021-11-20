using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameStartButton : MonoBehaviour
{
    Image image;
    Color imagecolor;
    public AudioClip knock;
    AudioSource audioSource;
    Timecounting timecounting;

    float time_int = 4;
    public Text time_UI;
    public bool countdown;
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
        if(countdown)
        {
            timer();
        }
        if(!countdown)
        {
            time_UI.text = " ";
        }
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
            countdown = true;
            // timecounting.gamestart = true;
        }
    }
    void timer()
    {
        time_int -= Time.deltaTime;
        int time = (int)time_int;
        time_UI.text = time.ToString();
        if (time == 0)
        {
            timecounting.gamestart = true;
            time_int = 4;
            countdown = false;
            gameObject.SetActive(false);
        }
    }
}
