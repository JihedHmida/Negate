using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public static class LevelManager
{
    private static Texture2D[] levelTextures;




    public static void GetTextures(int pack)
    {
        levelTextures = PackManager.GetPack(pack);

    }
    public static int TextureCount()
    {
        return levelTextures.Length ;
    }
    public static Texture2D GetTexture2D(int level)
    {
        if (levelTextures.Length > 0)
        {
            return levelTextures[level];
        }
        Debug.LogWarning("No Texture With index of  " + level + "is found!!");
        return null;
    }




}
