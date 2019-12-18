using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour
{
    public static GameHandler Instance = null;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;

        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
        Initialization();
    }

     public static void Initialization()
    {
        SoundManager.Initialize();
        LevelManager.Initialize();
    }
    public static void RestValues()
    {
        GamePlayManager.is2D = true;
        AtoBEnemy.graphicIndex = 50;
    }

    void Start()
    {

    }

    void Update()
    {

    }
}
