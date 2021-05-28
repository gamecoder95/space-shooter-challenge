using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public Text ScoreText;
    public void Update()
    {
        ScoreText.text = "SCORE: " + GameHandler.Score.ToString();
    }
    public void Replay()
    {
        GameHandler.restartGame();
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
