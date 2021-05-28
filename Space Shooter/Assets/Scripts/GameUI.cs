using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    [SerializeField]
    private Text scoreText;

    [SerializeField]
    private Text livesText;

    // Start is called before the first frame update
    void Start()
    {
        GameManager.Instance.PlayerHit += OnPlayerHit;
        GameManager.Instance.EnemyKilled += OnEnemyKilled;

        SetScoreText(GameManager.Instance.Score);
        SetLivesText(GameManager.Instance.NumLives);
    }

    private void OnEnemyKilled(object sender, System.EventArgs e)
    {
        SetScoreText(GameManager.Instance.Score);
    }

    private void OnPlayerHit(object sender, System.EventArgs e)
    {
        SetLivesText(GameManager.Instance.NumLives);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDestroy()
    {
        GameManager.Instance.PlayerHit -= OnPlayerHit;
        GameManager.Instance.EnemyKilled -= OnEnemyKilled;
    }

    private void SetScoreText(int score)
    {
        scoreText.text = $"SCORE: {score}";
    }

    private void SetLivesText(int numLives)
    {
        livesText.text = $"LIVES: {numLives}";
    }
}
