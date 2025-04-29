using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControllerScript : MonoBehaviour
{
    public GameObject GameManagerGO;

    public float speed;
    public GameObject racket;
    public GameObject shootPos1;
    public GameObject shootPos2;
    public GameObject explosion;

   // public Text LivesUIText;
    const int maxLives = 3;
    int lives;

    public void Init()
    {
        lives = maxLives;

        //LivesUIText.text = lives.ToString();
        transform.position = new Vector2(0, 0);

        gameObject.SetActive(true);
    }

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            GameObject bullet01 = (GameObject)Instantiate(racket);
            bullet01.transform.position = shootPos1.transform.position;

            GameObject bullet02 = (GameObject)Instantiate(racket);
            bullet02.transform.position = shootPos2.transform.position;
        }
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        Vector2 direction = new Vector2(x, y).normalized;

        Move(direction);
    }

    void Move(Vector2 direction)
    {
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        max.x = max.x - 0.225f;
        min.x = min.x + 0.225f;

        max.y = max.y - 0.225f;
        min.y = min.y + 0.225f;

      
        Vector2 pos = transform.position;
        pos += direction * speed * Time.deltaTime;


        pos.x = Mathf.Clamp(pos.x, min.x, max.x);
        pos.y = Mathf.Clamp(pos.y, min.y, max.y);

        transform.position = pos;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if ((col.tag == "EnemyShipTag") || (col.tag == "EnemyBulletTag"))
        {
            PlayExplosion();

            --lives;

            //LivesUIText.text = lives.ToString();
            if (lives == 0)
            {
                GameManagerGO.GetComponent<GameManager>().SetGameManagerState(GameManager.GameManagerState.GameOver);

                gameObject.SetActive(false);
                //Destroy(gameObject);

            }
        }
    }
    void PlayExplosion()
    {
        GameObject expl = (GameObject)Instantiate(explosion);

        expl.transform.position = transform.position;
    }
}


