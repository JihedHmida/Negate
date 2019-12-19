using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameAssets : MonoBehaviour
{
    static GameAssets _Instance;
    public static GameAssets Instance
    {
        get
        {
            if (!_Instance)
            {
                _Instance = (Instantiate(Resources.Load("GameAssets")) as GameObject).GetComponent<GameAssets>();
            }
            return _Instance;
        }
    }



    #region LevelPack 
    [Header("Level Pack")]
    public LevelPack[] levelPack;

    [System.Serializable]
    public class LevelPack
    {
        public int index;
        public Texture2D[] levelTextures;

    }

    #endregion

    #region Sounds 
    [Header("Sound")]
    public SoundAudioClip[] soundAudioClips;
    [System.Serializable]
    public class SoundAudioClip
    {
        public SoundManager.Sound sound;
        public AudioClip audioClip;
    }
    #endregion

}
