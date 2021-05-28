using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuBtn : MonoBehaviour
{
    private void Awake()
    {
        //transform.Find("MainMenuButton").GetComponent<ButtonUO>()
    }

    public void PlayBtn()
    {
        SceneLoader.load(SceneLoader.Scene.GameScene);
    }

    public void Quit()
    {
        if (UnityEditor.EditorApplication.isPlaying)
        {
            UnityEditor.EditorApplication.isPlaying = false;
        }
        else
        {
            Application.Quit();
        }
    }
}
