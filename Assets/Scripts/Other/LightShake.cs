using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightShake : MonoBehaviour
{
    public Timecounting timecounting;
    public GameObject Light;
    public GameObject normalLight;
    public GameObject[] streetLight;
    // private GameObject Ceilling;
    // MeshRenderer meshRenderer;
    Light lightshake;
    // Material white;
    // Material red;
    private float shake;
    public bool isshake;
    // Start is called before the first frame update
    void Start()
    {
        lightshake = Light.GetComponent<Light>();
        timecounting = timecounting.GetComponent<Timecounting>();
        // meshRenderer = Ceilling.GetComponent<MeshRenderer>();
        // white = meshRenderer.materials[0];
        // red = meshRenderer.materials[1];
    }

    // Update is called once per frame
    void Update()
    {
        if(timecounting.second < 10 && timecounting.second > 0)
        {
            isshake = true;
        }
        else 
        {
            isshake = false;
        }
        if(timecounting.gamestart == false)
        {
            lightshake.color = normalLight.GetComponent<Light>().color;
            // meshRenderer.material = white;
            for(int i=0; i<=5; i++)
            {
                streetLight[i].GetComponent<Light>().color = normalLight.GetComponent<Light>().color;
            }
        }
        if(isshake)
        {
            Shaking();
        }
        else
        {
            lightshake.color = normalLight.GetComponent<Light>().color;
            // meshRenderer.material = white;
            for(int i=0; i<=5; i++)
            {
                streetLight[i].GetComponent<Light>().color = normalLight.GetComponent<Light>().color;
            }
        }
    }
    void Shaking()
    {
        shake += Time.deltaTime;
        if(shake % 1 > 0.5f)
        {
            lightshake.color = normalLight.GetComponent<Light>().color;
            // meshRenderer.material = white;
            for(int i=0; i<=5; i++)
            {
                streetLight[i].GetComponent<Light>().color = normalLight.GetComponent<Light>().color;
            }
        }
        else
        {
            lightshake.color = Color.red;
            // meshRenderer.material = red;
            for(int i=0; i<=5; i++)
            {
                streetLight[i].GetComponent<Light>().color = Color.red;
            }
        }
    }
}
