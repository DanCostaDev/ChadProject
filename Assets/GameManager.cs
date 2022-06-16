using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameState State;
    // Start is called before the first frame update
    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        
    }
    public void UpdateGameState(GameState newState)
    {
        switch (newState)
        {
            case GameState.GameOver:
                break;
            case GameState.KeepMoving:
                break; 
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public enum GameState
    {
        GameOver,
        KeepMoving
    }
}
