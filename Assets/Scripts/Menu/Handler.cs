using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Handler : MonoBehaviour
{
    public GameObject handlerPos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(gameObject.transform.position != handlerPos.transform.position)
        {
            gameObject.transform.position = handlerPos.transform.position;
        }
    }
}
