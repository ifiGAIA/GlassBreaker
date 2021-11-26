using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlassShatter : MonoBehaviour
{
    MeshRenderer meshRenderer;
    SphereCollider sphereCollider;
    GotoGame1 gotoGame1;
    public GameObject explosionGlass;
    public AudioClip glassshatter;
    AudioSource audioSource;
    public bool gameStart;
    // Start is called before the first frame update
    void Start()
    {
        gotoGame1 = GameObject.Find("Table").GetComponent<GotoGame1>();
        meshRenderer = GetComponent<MeshRenderer>();
        sphereCollider = GetComponent<SphereCollider>();
        explosionGlass.SetActive(false);
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void DestroyGlass()
    {
        Destroy(gameObject);
    }
    void ToGame()
    {
        gameStart = true;
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Left_hammer" && gameObject.name == "glass_red")
        {
            audioSource.PlayOneShot(glassshatter);
            meshRenderer.enabled = false;
            sphereCollider.enabled = false;
            explosionGlass.SetActive(true);
            gotoGame1.glassred = true;
            Invoke("DestroyGlass",5f);
        }
        if(other.gameObject.tag == "Right_hammer" && gameObject.name == "glass_green")
        {
            audioSource.PlayOneShot(glassshatter);
            meshRenderer.enabled = false;
            sphereCollider.enabled = false;
            explosionGlass.SetActive(true);
            gotoGame1.glassgreen = true;
            Invoke("DestroyGlass",5f);
        }
        if(other.gameObject.tag == "foot" && gameObject.name == "glass_purple")
        {
            audioSource.PlayOneShot(glassshatter);
            meshRenderer.enabled = false;
            sphereCollider.enabled = false;
            explosionGlass.SetActive(true);
            gotoGame1.glasspurple = true;
            Invoke("DestroyGlass",5f);
        }
        if(other.gameObject.tag == "Left_hammer" && gameObject.name == "glass_togame" || other.gameObject.tag == "Right_hammer" && gameObject.name == "glass_togame" || other.gameObject.tag == "foot" && gameObject.name == "glass_togame")
        {
            audioSource.PlayOneShot(glassshatter);
            meshRenderer.enabled = false;
            sphereCollider.enabled = false;
            explosionGlass.SetActive(true);
            Invoke("ToGame",5f);
        }
    }
}
