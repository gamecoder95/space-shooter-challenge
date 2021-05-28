using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    private Vector2 gridPosition;
    public int moveSpeed = 50;

    private static bool isOrginal = true;
    public Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("Enemy is awake");
        //transform.position = new Vector3(transform.position.x, transform.position.y);
    }
    public void Setup(Vector3 mooveDir)
    {
        gameObject.SetActive(true);
        transform.position = new Vector3(transform.position.x, transform.position.y);
        rb = GetComponent<Rigidbody2D>();
        //Destroy(gameObject, timeToLive);

        moveSpeed = Random.Range(5, 10);
    }

    // Update is called once per frame
    void Update()
    {
        if (!isOrginal)
        {
            gameObject.SetActive(true);
            rb.velocity = new Vector3(0, -1) * moveSpeed;
        }
        else
        {
            gameObject.SetActive(false);
            isOrginal = false;
        }
    }

    //destroy the enemy if it goes off screen
    private void OnBecameInvisible()
    {
        if (gameObject != null)
        {
            if (!isOrginal)
            {
                Destroy(gameObject, 0);
            }
        }
    }

    public void gotHitByBullet()
    {
        //Debug.Log("Enemy ship got hit");
        GameHandler.Score += 100;
        Destroy(gameObject);

    }

    public void gotHitByPlayer()
    {
        GameHandler.Lives -= 1;
        Destroy(gameObject);
    }
}
