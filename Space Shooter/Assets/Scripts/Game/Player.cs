using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Vector2 gridPosition;
    Rigidbody2D rb;

    public float moveSpeed = 10f;
    private float lastMove;
    private float lastShoot;
    private double cameraBuffer = 0.05;
    private char keyDown;
    private float moveDelay = 0;
    private float shootDelay = 0.25f;
    private bool shootKeyDown;

    private void Awake()
    {
        gridPosition = new Vector2(-50, -40);
        rb = GetComponent<Rigidbody2D>();
        
    }

    private void Update()
    {

        Vector3 camPos = Camera.main.WorldToViewportPoint(transform.position);

        //Debug.Log("Player x is" + gridPosition.x);
        //Debug.Log("Cam x is" + camPos.x);

        //Debug.Log(lastMove.ToString());

        getMovementBuffer();

        //checkMove();

        move();

        checkSoot();
    }


    public void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("Player collided with a " + collision.name);

        EnemyAI enemy = collision.GetComponent<EnemyAI>();
        if (collision.GetComponent<EnemyAI>() != null)
        {
            //Debug.Log("Enemy got hit");
            enemy.gotHitByPlayer();
        }


    }



    private void getMovementBuffer()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
        {
                keyDown = 'L';
        }
        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
        {
                keyDown = 'R';
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.A))
        {
                keyDown = ' ';
        }
        if (Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.D))
        {
                keyDown = ' ';
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            shootKeyDown = true;
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            shootKeyDown = false;
        }


    }

    private void checkMove()
    {
        Vector3 camPos = Camera.main.WorldToViewportPoint(transform.position);

        if (Time.time.CompareTo(lastMove) == 1)
        {
            if (camPos.x > cameraBuffer)
            {
                if (keyDown == 'L')
                {
                    gridPosition.x -= moveSpeed;
                    lastMove = Time.time;
                    lastMove += moveDelay;
                }
            }
            if (camPos.x < (1 - cameraBuffer))
            {
                if (keyDown == 'R')
                {
                    gridPosition.x += moveSpeed;
                    lastMove = Time.time;
                    lastMove += moveDelay;
                }
            }
            transform.position = new Vector3(gridPosition.x, gridPosition.y);
        }
    }

    private void move()
    {
        float xMov = Input.GetAxisRaw("Horizontal");

        rb.velocity = new Vector3(xMov, rb.velocity.y) * moveSpeed;
    }


    [SerializeField] private Transform pfbullet;
    private void checkSoot()
    {
        if (Time.time.CompareTo(lastShoot) == 1 )
        {
            if (shootKeyDown)
            {
                //Debug.Log("bullet was shot");
                //Vector2 playerPos = new Vector2(gridPosition.x, -35);

                Vector2 otherPos = new Vector2(transform.position.x, transform.position.y);
                Transform bulletTransform = Instantiate(pfbullet, otherPos, Quaternion.identity);
                bulletTransform.GetComponent<Bullet>().Setup(otherPos.normalized);





                //Debug.Log(lastShoot);
                lastShoot = Time.time;
                lastShoot += shootDelay;
                //Debug.Log(lastShoot);
            }
        }
    }

}
