using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    public static GameManager instance;

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
            DontDestroyOnLoad(gameObject);
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
