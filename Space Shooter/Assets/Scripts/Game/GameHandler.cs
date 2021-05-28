using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameHandler : MonoBehaviour
{

    public Text ScoreText;
    public Text LivesText;

    public static int Score = 0;
    public static int Lives = 3;

    [SerializeField] public Transform pfEnemy;
    private EnemySpawner enemySpawner;

    // Start is called before the first frame update
    void Start()
    {
        //GameObject playerShip = new GameObject();
        //SpriteRenderer playerShipRender = playerShip.AddComponent<SpriteRenderer>();
        //playerShipRender.sprite = GameAssets.instance.PlayerShip;
        enemySpawner = gameObject.AddComponent<EnemySpawner>();

    }

    // Update is called once per frame
    void Update()
    {
        ScoreText.text = "SCORE: " + Score.ToString();
        LivesText.text = "LIVES: " + Lives.ToString();


        enemySpawner.spawnEnemies(pfEnemy);


        if(Lives == 0)
        {
            SceneLoader.load(SceneLoader.Scene.GameOverScene);
            //restartGame();
        }
    }

    public static void restartGame()
    {
        Score = 0;
        Lives = 3;
        EnemySpawner.startTime = Time.time;
        Bullet.isOrginal = true;
    }
}
