using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private float speed;

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
        rb.velocity = speed * Vector2.up;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void LateUpdate()
    {
        float sprHeight = spr.bounds.size.y;
        float positiveCameraYBound = GameManager.Instance.MainCameraHeight / 2 + sprHeight;

        if (transform.position.y > positiveCameraYBound)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
    }
}
