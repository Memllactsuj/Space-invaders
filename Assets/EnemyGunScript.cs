using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGunScript : MonoBehaviour
{
    public GameObject fireball;
    void Start()
    {
        Invoke("FireEnemyBullet", 1f);
    }

    void Update()
    {
        
    }

    // to fire enemy bullet
    void FireEnemyBullet()
    {
        GameObject ship = GameObject.Find("racket");
        if (ship != null) // !dead
        {
            GameObject bullet = (GameObject)Instantiate(fireball);

            bullet.transform.position = transform.position;

            Vector2 direction = ship.transform.position - bullet.transform.position; // compute bullet's direction towards the ship

            bullet.GetComponent<FireballScript>().setDirection(direction);
        }

    }
}
