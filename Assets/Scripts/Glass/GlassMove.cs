using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameLevel
{
    Game1,
    Game2,
    Game3
}
public class GlassMove : MonoBehaviour
{
    public GameLevel gameLevel;
    public bool moveistrue = false;
    private float PosZ;
    private Vector3 finalPos;
    public bool glassisbroken = false; 
    public float speed = 5f;

    public bool TimesUp;
    public bool noglass;
    
    // Start is called before the first frame update
    void Start()
    {
        // gameLevel = GameLevel.Game1;
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
        // GameLevelSwitch();
    }
    void GameLevelSwitch()
    {
        if(TimesUp || noglass)//時間到或是玻璃打完
        {
            gameLevel = GameLevel.Game2;
        }
        else if(TimesUp || noglass)//時間到或是玻璃打完
        {
            gameLevel = GameLevel.Game3;
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
