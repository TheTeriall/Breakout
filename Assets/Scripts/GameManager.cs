using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Transform ballPrefab;
    [SerializeField] private Transform brickPrefab;

    private Transform ball;

    private float score = 0f;
    private int lifes = 3;
    private float ballSpeed = 5f;

    public float xStart = -9.5f;
    public float yStart = 4.5f;
    public float xShift = 2.0f;
    public float yShift = 1.0f;

    private void Start()
    {
        SpawnBall();

        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                Instantiate(brickPrefab, new Vector2(xStart + xShift * j, yStart - yShift * i), Quaternion.identity);
            }
        }
    }

    private void Ball_OnBallDestroy(object sender, System.EventArgs e)
    {
        lifes--;
        Debug.Log("Lifes: " + lifes);
        if (lifes > 0)
        {
            SpawnBall();
        }
        else
        {
            Debug.Log("Game Over");
        }
    }

    private void Ball_OnBrickDestroy(object sender, System.EventArgs e)
    {
        score++;
        Debug.Log("Score: " + score);
        ballSpeed += 0.5f;
        ball.GetComponent<Ball>().SetSpeed(ballSpeed);
    }

    private void SpawnBall()
    {

        ball = Instantiate(ballPrefab, Vector2.zero, Quaternion.identity);
        ball.GetComponent<Ball>().OnBrickDestroy += Ball_OnBrickDestroy;
        ball.GetComponent<Ball>().OnBallDestroy += Ball_OnBallDestroy;
    }

    //private void DestroyAllBricks()
    //{
    //    GameObject[] bricks = GameObject.FindGameObjectsWithTag("Brick");
    //    foreach (GameObject brick in bricks)
    //    {
    //        Destroy(brick);
    //    }
    //}

    //private void Update()
    //{
    //    // Spawn 8 rows of bricks with 10 bricks in each row and make the bricks distance to each other variable




    //    // Destroy all bricks again when pressing the space key

    //    if (Input.GetKeyDown(KeyCode.Space))
    //    {
    //        DestroyAllBricks();
    //    }





}

