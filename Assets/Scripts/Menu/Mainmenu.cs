using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mainmenu : MonoBehaviour
{
    GotoGame1 gotoGame1;
    Text signtext;
    public GameObject Leftfoot;
    public GameObject Rightfoot;
    public GameObject Left;
    public GameObject Right;
    public GameObject Choosecanvas;
    public GameObject Signcanvas;
    public GameObject[] Chooseglass;
    // Start is called before the first frame update
    void Start()
    {
        gotoGame1 = GameObject.Find("Table").GetComponent<GotoGame1>();
        signtext = gameObject.transform.GetChild(0).GetChild(2).GetComponent<Text>();
        Choosecanvas.SetActive(false);
        Signcanvas.SetActive(false);
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
            signtext.text = "4. 請注意槌子以及鐵靴的顏色並完成兩種模式";
        }
        else
        {
            Chooseglass[0].SetActive(true);
            Chooseglass[1].SetActive(true);
            Chooseglass[2].SetActive(false);
            Chooseglass[3].SetActive(false);
            Leftfoot.SetActive(false);
            Rightfoot.SetActive(false);
            signtext.text = "4. 請注意槌子的顏色並完成兩種模式";
        }
    }

    void ChooseCanvas()
    {
        if(Left.transform.childCount == 0 && Right.transform.childCount == 0)
        {
            Choosecanvas.SetActive(true);
            Signcanvas.SetActive(true);
        }
    }
}
