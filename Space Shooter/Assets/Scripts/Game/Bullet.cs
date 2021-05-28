using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Bullet : MonoBehaviour
{
    //private int timeToLive = 5;
    private Vector3 shootDir;
    public float moveSpeed = 1f;

    public  static bool isOrginal = true;
    public Rigidbody2D rb;

    public void Setup(Vector3 shootDir)
    {
        gameObject.SetActive(true);
        //this.shootDir = shootDir;
        transform.position = new Vector3(transform.position.x, transform.position.y);
        rb = GetComponent<Rigidbody2D>();
        //Destroy(gameObject, timeToLive);
    }

    private void Update()
    {

        if(!isOrginal)
        {
            gameObject.SetActive(true);


            //Debug.Log(transform.position.x.ToString() + " " + transform.position.y.ToString());
            rb.velocity = new Vector3(0, 1) * moveSpeed;
        }
        else
        {
            gameObject.SetActive(false);
            isOrginal = false;
        }


    }

    //destroy the bullet if it goes off screen
    private void OnBecameInvisible()
    {
        if(gameObject != null)
        {
            if(!isOrginal)
            {
                Destroy(gameObject, 0);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("Bullet found collison");
        EnemyAI enemy = collision.GetComponent<EnemyAI>();
        if (collision.GetComponent<EnemyAI>() != null)
        {
            //Debug.Log("Enemy got hit");
            enemy.gotHitByBullet();
            Destroy(gameObject);
        }
    }
}
