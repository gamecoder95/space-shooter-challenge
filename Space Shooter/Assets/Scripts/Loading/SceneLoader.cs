using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class SceneLoader 
{
    public enum Scene
    {
        GameScene,
        LoadingScene,
        MainMenuScene,
        GameOverScene,
    }

    private static Action onLoaderCallback;

    public static void load(Scene scene)
    {
        //Set the action to load the scene
        onLoaderCallback = () => {
            SceneManager.LoadScene(scene.ToString());
        };

        //Load the loading scene while the acutal scene is loading
        SceneManager.LoadScene(Scene.LoadingScene.ToString());
    }

    public static void LoaderCallback()
    {
        //if this is the first do nothing, so the loading scene can load before the real scene
        if(onLoaderCallback != null)
        {
            onLoaderCallback();
            onLoaderCallback = null;
        }
    }
}
