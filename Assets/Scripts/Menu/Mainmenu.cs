using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mainmenu : MonoBehaviour
{
    GotoGame1 gotoGame1;
    public GameObject Leftfoot;
    public GameObject Rightfoot;
    public GameObject Left;
    public GameObject Right;
    public GameObject Choosecanvas;
    public bool rr,rg,rrf,rgf;
    // Start is called before the first frame update
    void Start()
    {
        gotoGame1 = GameObject.Find("Table").GetComponent<GotoGame1>();
        Choosecanvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // ChooseFoot();
        ChooseCanvas();
    }
    // void ChooseFoot()
    // {
    //     if(GameManager.Instance.leftFoot == true)
    //     {
    //         Leftfoot.SetActive(true);
    //         Rightfoot.SetActive(false);
    //     }
    //     else if(GameManager.Instance.rightFoot == true)
    //     {
    //         Leftfoot.SetActive(false);
    //         Rightfoot.SetActive(true);
    //     }
    //     else
    //     {
    //         Leftfoot.SetActive(false);
    //         Rightfoot.SetActive(false);
    //     }
    // }

    void ChooseCanvas()
    {
        if(Left.transform.childCount == 0 && Right.transform.childCount == 0)
        {
            Choosecanvas.SetActive(true);
        }
    }
}
