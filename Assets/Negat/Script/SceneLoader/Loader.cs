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

    public static void Load(Scene scene, int index)
    {
        GameHandler.RestValues();

        onLoaderCallBack = () =>
        {
            SceneManager.LoadScene(scene.ToString());
            LevelLoaderManager.Instance.index = index;
        };
        SceneManager.LoadScene(Scene.LoadingScene.ToString());
    }

    public static void LoadGameScene(int index)
    {
        GameHandler.RestValues();

        onLoaderCallBack = () =>
        {
            SceneManager.LoadScene(Scene.GameScene.ToString());
            LevelLoaderManager.Instance.index = index;
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
