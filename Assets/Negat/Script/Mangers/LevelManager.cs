using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public static class LevelManager
{
    private static bool isInit = false;
    private static Dictionary<int, Texture2D> textureLevelDictionary;

    public static void Initialize()
    {
        if (!isInit)
        {
            GetTextureGameAssets();
            isInit = true;
        }
    }

    public static Texture2D GetTexture2D(int index)
    {
        if (textureLevelDictionary.ContainsKey(index))
        {
            return textureLevelDictionary[index];
        }
        Debug.LogWarning("No Texture With index of  " + index + "is found!!");
        return null;
    }

    public static void GetTextureGameAssets()
    {
        textureLevelDictionary = new Dictionary<int, Texture2D>();
        foreach (GameAssets.LevelTexture levelTexture in GameAssets.Instance.levelTextures)
        {
            textureLevelDictionary.Add(levelTexture.index, levelTexture.texture);
        }
    }



}
