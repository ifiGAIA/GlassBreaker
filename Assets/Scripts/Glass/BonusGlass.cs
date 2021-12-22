using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusGlass : MonoBehaviour
{
    MeshRenderer meshRenderer;
    BoxCollider boxCollider;
    public AudioClip glassbroken;
    AudioSource audioSource;

    public GameObject explosionGlass; 
    public bool glassisbroken;
    public float speed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        boxCollider = GetComponent<BoxCollider>();
        audioSource = GetComponent<AudioSource>();
        explosionGlass.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        GlassBroken();
        GlassMove();
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Left_hammer" || other.gameObject.tag == "Right_hammer" || other.gameObject.tag == "Left_foot" || other.gameObject.tag == "Right_foot")
        {
            glassisbroken = true;
            other.gameObject.tag = "Untagged";
        }
        else if(other.gameObject.name == "glassRecycle")
        {
            Destroy(gameObject);
        }
    }
    void GlassBroken()
    {
        if(glassisbroken == true)
        {
            audioSource.PlayOneShot(glassbroken);
            meshRenderer.enabled = false;
            boxCollider.enabled = false;
            explosionGlass.SetActive(true);
            glassisbroken = false;
            Invoke("DestroyGlass",2f);
        }
    }
    void DestroyGlass()
    {
        Destroy(gameObject);
    }
    void GlassMove()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime, Space.World);
    }
}
