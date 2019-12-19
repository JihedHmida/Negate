using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class Loader
{
    public enum Scene
    {
        LoadingScene,
        MainScene,
        LevelScene,
        GameScene,
        PackScene,

    }
    public static Action onLoaderCallBack;

    public static void Load(Scene scene)
    {
        GameHandler.RestValues();
        onLoaderCallBack = () =>
        {
            SceneManager.LoadScene(scene.ToString());
        };
        SceneManager.LoadScene(Scene.LoadingScene.ToString());
    }

    public static void LoadGameScene(int pack, int level)
    {
        GameHandler.RestValues();

        onLoaderCallBack = () =>
        {
            SceneManager.LoadScene(Scene.GameScene.ToString());
            LevelLoaderManager.Instance.level = level;
            LevelLoaderManager.Instance.pack = pack;

        };
        SceneManager.LoadScene(Scene.LoadingScene.ToString());
    }

    public static void LoadPackScene(int index)
    {
        onLoaderCallBack = () =>
        {
            SceneManager.LoadScene(index + 3);
            LevelManager.GetTextures(index);
        };
        SceneManager.LoadScene(Scene.LoadingScene.ToString());

    }
    public static void LoaderCallBack()
    {
        if (onLoaderCallBack != null)
        {
            onLoaderCallBack();
            onLoaderCallBack = null;
        }
    }
}
