using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float minSpeed;

    [SerializeField]
    private float maxSpeed;

    private Rigidbody2D rb;
    private SpriteRenderer spr;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        spr = GetComponent<SpriteRenderer>();
    }

    // Start is called before the first frame update
    void Start()
    {
        float speed = Random.Range(minSpeed, maxSpeed);
        rb.velocity = speed * Vector2.down;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LateUpdate()
    {
        float sprHeight = spr.bounds.size.y;
        float positiveCameraYBound = GameManager.Instance.MainCameraHeight / 2 + sprHeight;

        if (transform.position.y < -positiveCameraYBound)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Bullet"))
        {
            if (collision.gameObject.CompareTag("Bullet"))
            {
                GameManager.Instance.OnEnemyKilled(this);
            }

            Destroy(gameObject);
        }
    }
}
