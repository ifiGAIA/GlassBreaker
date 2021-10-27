using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlassMove : MonoBehaviour
{
    public bool moveistrue = false;
    private float PosZ;
    private Vector3 finalPos;
    public bool glassisbroken = false; 
    public float speed = 5f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(glassisbroken == true)
        {
            //什麼時候moveistrue false->true
            finalPos = new Vector3(transform.position.x,transform.position.y,transform.position.z-1);
            moveistrue = true;
            glassisbroken = false;
        }
        if(moveistrue == true)
        {
            Move();
        }
    }
    public void Move()
    {
        //從現在位置往前移動到目的地+1
        // PosZ += Time.deltaTime*-1;
        // PosZ -= 1;
        // transform.position = new Vector3(transform.position.x,transform.position.y,PosZ);
        
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position,finalPos,step);
        // moveistrue = false;
        // if(transform.position == finalPos)
        // {
        //     Debug.Log("近來沒");
        //     moveistrue = false;
        // }
    }
}
