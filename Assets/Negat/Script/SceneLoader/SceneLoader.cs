using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{
    public void LoadLevelScene()
    {
        Loader.Load(Loader.Scene.PackScene);
    }


}
