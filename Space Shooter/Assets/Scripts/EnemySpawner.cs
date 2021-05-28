using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private float baseSpawnDelaySeconds;

    [SerializeField]
    private GameObject enemy;

    [SerializeField]
    private Text testTimeText;

    private float enemyHeight;
    private float enemyXExtents;

    private float spawnDelay;
    private float initTime;
    private float totalElapsedTime;

    private const float TIME_TO_PHASE_1 = 30;
    private const float TIME_TO_PHASE_2 = 90;

    private int phaseNum;

    // Start is called before the first frame update
    void Start()
    {
        enemyHeight = enemy.GetComponent<SpriteRenderer>().bounds.size.y;
        enemyXExtents = enemy.GetComponent<SpriteRenderer>().bounds.extents.x;
        spawnDelay = baseSpawnDelaySeconds;
        initTime = Time.time;
        StartCoroutine(SpawnEnemy());
    }

    // Update is called once per frame
    void Update()
    {
        totalElapsedTime = Time.time - initTime;
        testTimeText.text = $"TIME: {totalElapsedTime}";
    }

    private IEnumerator SpawnEnemy()
    {
        while (true)
        {
            if (totalElapsedTime > TIME_TO_PHASE_1 && phaseNum != 1)
            {
                phaseNum = 1;
                spawnDelay = baseSpawnDelaySeconds / 2;
            }
            else if (totalElapsedTime > TIME_TO_PHASE_2 && phaseNum != 2)
            {
                phaseNum = 2;
                spawnDelay = baseSpawnDelaySeconds / 4;
            }

            float positiveMaxSpawnX = GameManager.Instance.MainCameraWidth / 2 - enemyXExtents;
            float spawnX = Random.Range(-positiveMaxSpawnX, positiveMaxSpawnX);
            Vector3 spawnPos = new Vector3(spawnX, GameManager.Instance.MainCameraHeight / 2 + enemyHeight);

            Instantiate(enemy, spawnPos, Quaternion.identity);

            yield return new WaitForSeconds(spawnDelay);
        }   
    }

    private void OnDestroy()
    {
        StopAllCoroutines();
    }
}
