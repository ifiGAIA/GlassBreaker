using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlassInstantiate : MonoBehaviour
{
    public Transform InitPos;
    public GameObject Prefab;
    private GameObject glass;
    public int glasscount;
    // Start is called before the first frame update
    void Start()
    {
        Glassinstantiate();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void Glassinstantiate()
    {
        for(int i=0; i<glasscount; i++)
        {
            Vector3 glassPos = new Vector3(InitPos.position.x, InitPos.position.y, InitPos.position.z+(float)i);
            glass = Instantiate(Prefab, glassPos,InitPos.rotation);//生成
            glass.transform.parent = gameObject.transform;//生成物parent=富物件
            glass.name = "glass" + (i+1).ToString();
            
        }
    }
}
