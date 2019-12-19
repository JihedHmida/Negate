using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LevelLoaderManager : MonoBehaviour
{
    public int level;
    public int pack;

    public static LevelLoaderManager Instance = null;

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

        DontDestroyOnLoad(this);
    }

}
