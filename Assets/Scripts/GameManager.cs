using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField] private Transform ballPrefab;
    [SerializeField] private Transform brickPrefab;

    public event EventHandler OnScoreChange;
    public event EventHandler OnLifesChange;
    public event EventHandler NarrowPaddle;

    private Transform ball;

    private float score = 0f;
    private int lifes = 3;
    private float ballSpeed = 5f;

    public float xStart = -9.5f;
    public float yStart = 4.5f;
    public float xShift = 2.0f;
    public float yShift = 1.0f;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        SpawnBall();

        // Create bricks and take 8 rnd colors


        for (int i = 0; i < 8; i++)
        {
            brickPrefab.GetComponent<SpriteRenderer>().color = new Color(UnityEngine.Random.Range(0f, 1f), UnityEngine.Random.Range(0f, 1f), UnityEngine.Random.Range(0f, 1f));
            for (int j = 0; j < 10; j++)
            {
                Instantiate(brickPrefab, new Vector2(xStart + xShift * j, yStart - yShift * i), Quaternion.identity);
            }
        }
    }

    private void Ball_OnBallDestroy(object sender, System.EventArgs e)
    {
        lifes--;
        OnLifesChange?.Invoke(this, EventArgs.Empty);
        Debug.Log("Lifes: " + lifes);
        if (lifes > 0)
        {
            SpawnBall();
        }
        else
        {
            GameOver();
        }
    }

    private void Ball_OnBrickDestroy(object sender, System.EventArgs e)
    {
        score++;
        OnScoreChange?.Invoke(this, EventArgs.Empty);
        Debug.Log("Score: " + score);
        ballSpeed = ballSpeed * 1.01f;
        ball.GetComponent<Ball>().SetSpeed(ballSpeed);
    }

    private void SpawnBall()
    {

        ball = Instantiate(ballPrefab, Vector2.zero, Quaternion.identity);
        ball.GetComponent<Ball>().OnBrickDestroy += Ball_OnBrickDestroy;
        ball.GetComponent<Ball>().OnBallDestroy += Ball_OnBallDestroy;
        ball.GetComponent<Ball>().OnCeilingTouched += Ball_OnCeilingTouched;
    }

    private void Ball_OnCeilingTouched(object sender, EventArgs e)
    {
        NarrowPaddle?.Invoke(this, EventArgs.Empty);
    }

    public float GetScore()
    {
        return score;
    }

    public int GetLifes()
    {
        return lifes;
    }

    private void GameOver()
    {
        int existingHighScore = PlayerPrefs.GetInt("Highscore", 0);
        if (score > existingHighScore)
        {
            PlayerPrefs.SetInt("Highscore", (int)score);
        }
        
    }

    public int GetHighScore()
    {
        return PlayerPrefs.GetInt("Highscore", 0);
    }





}

