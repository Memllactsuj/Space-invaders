using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameScoreScript : MonoBehaviour
{
    Text scoreTextUI;
    int score;

    public int Score
    {
        get
        {
            return this.score;
        }

        set
        {
            this.score = value;
            UpdateScoreUI();
        }
    }
    void Start()
    {
        scoreTextUI = GetComponent<Text>();
    }

    void UpdateScoreUI()
    {
        string scoreStr = string.Format("{0:000}", score);
        scoreTextUI.text = scoreStr;
    }

}
