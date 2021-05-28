using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameAssets : MonoBehaviour
{
    public static GameAssets instance;

    public Sprite PlayerShip;

    public Sprite Bullet;

    public Sprite EnemyShip;


    private void Awake()
    {
        instance = this;
    }

}
