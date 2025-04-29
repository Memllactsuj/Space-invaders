using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballScript : MonoBehaviour
{
    float speed;
    Vector2 direction;
    bool isReady;

    void Awake() // default values
    {
        speed = 8f;
        isReady = false;
    }
    void Start()
    {
        
    }

    public void setDirection(Vector2 _direction)
    {
        direction = _direction.normalized; // to get unit vector
        isReady = true;


    }

    void Update()
    {
        if (isReady)
        {
            Vector2 position = transform.position;

            position += direction * speed * Time.deltaTime;

            transform.position = position;

            // remove fireball from the scene

            Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0)); // top left
            Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1)); // top right

            //if outside the screen

            if ((transform.position.x < min.x) || (transform.position.x > max.x) ||
                (transform.position.y < min.y) || (transform.position.y > max.y))
            {
                Destroy(gameObject);
            }
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "PlayerShipTag")
        {
            Destroy(gameObject);
        }
    }
}
