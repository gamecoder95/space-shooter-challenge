using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float speed;

    [SerializeField]
    private float fireDelay;

    [SerializeField]
    private GameObject bullet;

    private float hAxis;
    private bool canFire;

    private float bulletHeight;

    private Rigidbody2D rb;
    private SpriteRenderer spr;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        spr = GetComponent<SpriteRenderer>();

        canFire = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        bulletHeight = bullet.GetComponent<SpriteRenderer>().bounds.size.y;
    }

    private void FixedUpdate()
    {
        rb.velocity = hAxis * speed * Vector2.right;
    }

    // Update is called once per frame
    void Update()
    {
        hAxis = Input.GetAxisRaw("Horizontal");

        if (Input.GetKey(KeyCode.Space) && canFire)
        {
            Vector3 bulletSpawnPos = transform.position + (spr.bounds.extents.y + bulletHeight / 2 + 0.05f) * Vector3.up; // the 0.05f is a little offset
            Instantiate(bullet, bulletSpawnPos, Quaternion.identity); // fire bullet
            canFire = false;
            StartCoroutine(FireDelay());
        }
    }

    private void LateUpdate()
    {
        float xExtents = spr.bounds.extents.x;
        float positiveCameraXBound = GameManager.Instance.MainCameraWidth / 2 - xExtents;

        if (rb.position.x < -positiveCameraXBound)
        {
            rb.position = transform.position = new Vector2(-positiveCameraXBound, rb.position.y);
        }
        else if (rb.position.x > positiveCameraXBound)
        {
            rb.position = transform.position = new Vector2(positiveCameraXBound, rb.position.y);
        }
    }

    private IEnumerator FireDelay()
    {
        yield return new WaitForSeconds(fireDelay);
        canFire = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Only collision possible for player is an enemy.
        GameManager.Instance.OnPlayerHit(this);
    }
}
