using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Smartphone : MonoBehaviour
{
    public AudioClip phonecall;
    AudioSource audioSource;
    AudioSource Ring;
    public GameObject Phone;
    public GameObject phone;
    public GameObject call;
    public bool gamestart;
    public bool nophoneCall;
    MeshRenderer meshRenderer;
    // Start is called before the first frame update
    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        audioSource = GetComponent<AudioSource>();
        Ring = Phone.GetComponent<AudioSource>();
        Invoke("GameStart",2f);
        call.SetActive(false);
        // material2 = GetComponent<MeshRenderer>().materials[2];
    }

    // Update is called once per frame
    void Update()
    {
        if(Phone.transform.childCount == 0)
        {
            Ring.Stop();
            gamestart = true;
        }
        PhoneCall();
    }
    void GameStart()
    {
        meshRenderer.enabled = false;
        Ring.Play();
    }
    void PhoneCall()
    {
        if(gamestart == true && nophoneCall == false)
        {
            audioSource.PlayOneShot(phonecall);
            call.SetActive(true);
            phone.SetActive(false);
            Invoke("StartScreen",13f);
            nophoneCall = true;
        }
    }
    void StartScreen()
    {
        meshRenderer.enabled = true;
        call.SetActive(false);
        phone.SetActive(false);
    }
}
