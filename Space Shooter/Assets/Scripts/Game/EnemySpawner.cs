using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class EnemySpawner : MonoBehaviour
{


    private float lastSpawn;
    private float spawnDelay = 1f;
    private const float SECOUND_PHASE_DELAY = 30; //to be 30
    private const float THIRD_PHASE_DELAY = 90; //to be 90

    private const float SECOUND_PHASE_SPEED = 0.5f;
    private const float THIRD_PHASE_SPEED = 0.25f;

    private const float SPAWNHEIGHT = 55;

    public static float startTime;

    private static Vector2 screenBounds;
    private static Vector2 lowerXBound;
    private static Vector2 upperXBound;

    private void Start()
    {
        startTime = Time.time;
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height));

        lowerXBound = Camera.main.ScreenToWorldPoint(new Vector3(0,0));
        upperXBound = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width,0));

        //Debug.Log(screenBounds.y.ToString());
        //Debug.Log("Between " + lowerXBound.x.ToString() + " And " + upperXBound.x.ToString());

    }

    public  void spawnEnemies(Transform pfEnemy)
    {
        //Vector3 viewPos = pfEnemy.position;
        //viewPos.x = Mathf.Clamp(viewPos.x, screenBounds.x, screenBounds.x - 1);
        //Debug.Log(viewPos.x + " " +  screenBounds.x.ToString() + " " + (screenBounds.x - 1).ToString() );




        if (Time.time.CompareTo(lastSpawn) == 1)
        {

            float xPos = Random.Range(lowerXBound.x, upperXBound.x);
            float yPos = screenBounds.y;


            //Debug.Log(xPos.ToString()  + ',' + yPos.ToString());


            Vector2 spawnPos = new Vector2(xPos, yPos);
            Transform ememyTransform = Instantiate(pfEnemy, spawnPos, Quaternion.identity);
            ememyTransform.GetComponent<EnemyAI>().Setup(spawnPos.normalized);



            lastSpawn = Time.time;
            lastSpawn += spawnDelay;
        }

        if (Time.time.CompareTo(startTime + SECOUND_PHASE_DELAY) == 1 && spawnDelay > SECOUND_PHASE_SPEED)
        {
            spawnDelay = SECOUND_PHASE_SPEED;
        }
        if (Time.time.CompareTo(startTime + THIRD_PHASE_DELAY) == 1 && spawnDelay > THIRD_PHASE_SPEED)
        {
            spawnDelay = THIRD_PHASE_SPEED;
        }

        //Debug.Log(startTime);
        //Debug.Log(spawnDelay);
    }
}
