using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    public GameObject aliens;
    float maxRateInSecond = 5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        
    }

    void SpawnEnemy()
    {
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        GameObject enemy = (GameObject)Instantiate(aliens);
        enemy.transform.position = new Vector2(Random.Range(min.x, max.x), max.y);

        ScheduleNext();
        
    }

    void ScheduleNext()
    {
        float spawnInSec;

        if (maxRateInSecond > 1f)
        {
            spawnInSec = Random.Range(1f, maxRateInSecond);
        } else
        {
            spawnInSec = 1f;
        }
        Invoke("SpawnEnemy", spawnInSec);

    }

    void Difficulty()
    {
        if (maxRateInSecond > 1f)
        {
            --maxRateInSecond;

        }

        if (maxRateInSecond == 1f)
        {
            CancelInvoke("Difficulty");
        }
    }

    public void ScheduleEnemySpawner()
    {
        Invoke("SpawnEnemy", maxRateInSecond);
        InvokeRepeating("Difficulty", 0f, 28f);

    }

    public void UnscheduleEnemySpawner()
    {
        CancelInvoke("SpawnEnemy");
        CancelInvoke("Difficulty");
    }
}
