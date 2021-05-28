using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBtnManager : MonoBehaviour
{
    public void MainMenuBtn()
    {
        SceneLoader.load(SceneLoader.Scene.MainMenuScene);
    }

    public void GameOver()
    {
        SceneLoader.load(SceneLoader.Scene.GameOverScene);
    }
}
