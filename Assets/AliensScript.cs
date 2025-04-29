using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AliensScript : MonoBehaviour
{
    public GameObject explosion;
    float speed;

    GameObject scoreUITextGO;

    void Start()
    {
        speed = 3f;

        scoreUITextGO = GameObject.FindGameObjectWithTag("ScoreTextTag");
        
    }

    void Update()
    {
        Vector2 position = transform.position;
        position = new Vector2(position.x, position.y - speed * Time.deltaTime);

        transform.position = position;

        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        if (transform.position.y < min.y)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if ((col.tag == "PlayerShipTag") || (col.tag == "PlayerBulletTag"))
        {
            PlayExplosion();

            scoreUITextGO.GetComponent<GameScoreScript>().Score += 2;

            Destroy(gameObject);
        }
    }
    void PlayExplosion()
    {
        GameObject expl = (GameObject)Instantiate(explosion);

        expl.transform.position = transform.position;
    }
}
