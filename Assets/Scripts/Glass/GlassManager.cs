using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlassManager : MonoBehaviour
{
    MeshRenderer meshRenderer;
    BoxCollider boxCollider;
    public GameObject knock_Position;
    public GameObject Prefab;
    public GameObject glassPos;
    public GameObject explosionGlass;
    GlassMove glassMove;
    public bool canKnock = false;
    public bool spotisexist = false;
    public bool canMove = false;
    public int knockcount = 0;
    // Start is called before the first frame update
    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        boxCollider = GetComponent<BoxCollider>();
        glassMove = GameObject.Find("Glass").GetComponent<GlassMove>();
        explosionGlass.SetActive(false);
        glassPos = GameObject.Find("glassPos");
    }

    // Update is called once per frame
    void Update()
    {
        KnockSpot();
        GlassBroken();
        GlasscanKnock();
    }
    void GlasscanKnock()
    {
        if(gameObject.transform.position == glassPos.transform.position)
        {
            canKnock = true;
        }
    }
    void GlassBroken()
    {
        if(canMove == true)
        {
            glassMove.glassisbroken = true;
            meshRenderer.enabled = false;
            boxCollider.enabled = false;
            explosionGlass.SetActive(true);
            canMove = false;
            Invoke("DestroyGlass",10f);
        }
    }
    void DestroyGlass()
    {
        Destroy(gameObject);
    }
    public void KnockCount()
    {
        knockcount += 1;
        if(knockcount == 5)
        {
            canMove = true;
            gameObject.tag = "Untagged";
        }
    }
    void KnockSpot()
    {
        if(spotisexist == false && knockcount<5 && canKnock == true)
        {
            Vector3 rnadomPos = new Vector3(Random.Range(-0.73f,0.73f),Random.Range(0.5f,1.8f),knock_Position.transform.position.z);
            Instantiate(Prefab, rnadomPos,knock_Position.transform.rotation);
            spotisexist =true;
        }
    }
}
