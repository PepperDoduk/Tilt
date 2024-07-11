using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text scoreText;
    public Transform player;

    private int score = 0;
    private float previousY;

    void Start()
    {
        scoreText.text = "" + score;

        if (player != null)
        {
            previousY = player.position.y;
        }

        InvokeRepeating("IncrementScore", 1f, 1f);
    }

    void Update()
    {
        if (player != null)
        {
            float deltaY = player.position.y - previousY;
            if (deltaY <= -1f)
            {
                score += Mathf.FloorToInt(-deltaY);
                previousY = player.position.y;
                UpdateScoreText();
            }
        }
    }

    public void AddScore(int s)
    {
        score += s;
        UpdateScoreText();
    }

    void IncrementScore()
    {
        score += 1;
        UpdateScoreText();
    }

    void UpdateScoreText()
    {
        scoreText.text = "" + score;
    }
}
