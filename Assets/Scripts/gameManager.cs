using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class gameManager : MonoBehaviour
{
    public static gameManager instance;

    public Text scoreText;
    int score = 0;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        score = 0;
        updateScoreText();

    }

    public void addScore(int amount)
    {
        score += amount;
        updateScoreText();
    }

    void updateScoreText()
    {
        scoreText.text = "x " + score.ToString();
    }

}
