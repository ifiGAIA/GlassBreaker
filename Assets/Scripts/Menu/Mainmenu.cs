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
    public GameObject[] Chooseglass;
    // Start is called before the first frame update
    void Start()
    {
        gotoGame1 = GameObject.Find("Table").GetComponent<GotoGame1>();
        Choosecanvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        ChooseFoot();
        ChooseCanvas();
    }
    void ChooseFoot()
    {
        if(GameManager.Instance.Foot == true)
        {
            Chooseglass[0].SetActive(false);
            Chooseglass[1].SetActive(false);
            Chooseglass[2].SetActive(true);
            Chooseglass[3].SetActive(true);
            Leftfoot.SetActive(true);
            Rightfoot.SetActive(true);
        }
        else
        {
            Chooseglass[0].SetActive(true);
            Chooseglass[1].SetActive(true);
            Chooseglass[2].SetActive(false);
            Chooseglass[3].SetActive(false);
            Leftfoot.SetActive(false);
            Rightfoot.SetActive(false);
        }
    }

    void ChooseCanvas()
    {
        if(Left.transform.childCount == 0 && Right.transform.childCount == 0)
        {
            Choosecanvas.SetActive(true);
        }
    }
}
