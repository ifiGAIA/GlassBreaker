using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameDegreeOfDifficulty
{
    Simple,
    Difficulty
}
public class GameManager : Singleton<GameManager>
{
    public GameDegreeOfDifficulty gameDegreeOfDifficulty;
    public bool Foot;

    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(this);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
