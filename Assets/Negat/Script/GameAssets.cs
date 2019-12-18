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



    #region Levels 
    [Header("Levels")]
    public LevelTexture[] levelTextures;
    [System.Serializable]
    public class LevelTexture
    {
        public int index;
        public Texture2D texture;
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
