using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject playButton;
    public GameObject playerShip;
    public GameObject enemySpawner;
    public GameObject GameOver;
    public GameObject scoreUIText;

    public enum GameManagerState
    {
        Opening,
        Gameplay,
        GameOver,
    }

    GameManagerState GMState;

    void Start()
    {
        GMState = GameManagerState.Opening;
    }

    void UpdateGameManagerState()
    {
        switch(GMState)
        {
            case GameManagerState.Opening:

                GameOver.SetActive(false);

                playButton.SetActive(true);

                break;

            case GameManagerState.Gameplay:

                scoreUIText.GetComponent<GameScoreScript>().Score = 0;

                playButton.SetActive(false);

                playerShip.GetComponent<PlayerControllerScript>().Init();

                enemySpawner.GetComponent<SpawnerScript>().ScheduleEnemySpawner();

                break;

            case GameManagerState.GameOver:

                enemySpawner.GetComponent<SpawnerScript>().UnscheduleEnemySpawner();

                GameOver.SetActive(true);

                Invoke("ChangeToOpeningState", 5f);

                break;

        }
    }

    public void SetGameManagerState(GameManagerState state)
    {
        GMState = state;
        UpdateGameManagerState();
    }

    public void StartGamePlay()
    {
        GMState = GameManagerState.Gameplay;
        UpdateGameManagerState();
    }

    public void ChangeToOpeningState()
    {
        SetGameManagerState(GameManagerState.Opening);


    }
}
