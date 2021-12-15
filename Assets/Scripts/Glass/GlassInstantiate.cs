using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlassInstantiate : MonoBehaviour
{
    public GameObject Player;
    public Transform InitPos;
    public GameObject Prefab;
    private GameObject glass;
    public GameObject TimeCountDown;
    public int glasscount;
    public bool gamestart;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        Player.transform.position = new Vector3(0,0,0);
        // Glassinstantiate();
        gamestart = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(gamestart)
        {
            Glassinstantiate();
            gamestart = false;
        }
    }
    public void GlassReborn()
    {
        gamestart = true;
        TimeCountDown.SetActive(true);
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
