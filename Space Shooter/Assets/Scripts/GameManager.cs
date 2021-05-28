using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance => instance;

    private float mainCameraHeight; 
    private float mainCameraWidth;

    public float MainCameraHeight => mainCameraHeight;
    public float MainCameraWidth => mainCameraWidth;

    private const int SCORE_PER_ENEMY = 100;

    #region Events

    public event EventHandler PlayerHit;
    public event EventHandler EnemyKilled;

    public void OnPlayerHit(object sender)
    {
        --NumLives;
        PlayerHit?.Invoke(sender, EventArgs.Empty);
    }

    public void OnEnemyKilled(object sender)
    {
        Score += SCORE_PER_ENEMY;
        EnemyKilled?.Invoke(sender, EventArgs.Empty);
    }

    #endregion

    private int numLives;
    public int NumLives
    {
        get => numLives;

        private set
        {
            numLives = value;

            if (numLives <= 0)
            {
                SceneManager.LoadScene("GameOverScene");
            }
        }
    }

    public int Score
    {
        get; set;
    }

    private void Awake()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);

        mainCameraHeight = 2 * Camera.main.orthographicSize;
        mainCameraWidth = Camera.main.aspect * mainCameraHeight;

        Score = 0;
        NumLives = 3;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ResetGameManager()
    {
        NumLives = 3;
        Score = 0;
    }
}
