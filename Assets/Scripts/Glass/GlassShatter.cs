using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlassShatter : MonoBehaviour
{
    MeshRenderer meshRenderer;
    BoxCollider boxCollider;
    public GameObject explosionGlass;
    public AudioClip glassshatter;
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        boxCollider = GetComponent<BoxCollider>();
        explosionGlass.SetActive(false);
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
            audioSource.PlayOneShot(glassshatter);
            meshRenderer.enabled = false;
            boxCollider.enabled = false;
            explosionGlass.SetActive(true);
        }
    }
}
