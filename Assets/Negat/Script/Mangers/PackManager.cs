using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PackManager : MonoBehaviour
{
    private static bool isInit = false;
    private static Dictionary<int, Texture2D[]> packDictionary;

    public static void Initialize()
    {
        if (!isInit)
        {
            GetPackGameAssets();
            isInit = true;
        }
    }

    public static void GetPackGameAssets()
    {
        packDictionary = new Dictionary<int, Texture2D[]>();
        foreach (GameAssets.LevelPack levelPack in GameAssets.Instance.levelPack)
        {
            packDictionary.Add(levelPack.index, levelPack.levelTextures);
        }
    }

    public static int PacksCount()
    {
        return packDictionary.Count;
    }
  

    public static Texture2D[] GetPack(int index)
    {
        if (packDictionary.ContainsKey(index))
        {
            return packDictionary[index];
        }
        Debug.LogWarning("No Pack With index of  " + index + "is found!!");
        return null;
    }
}
