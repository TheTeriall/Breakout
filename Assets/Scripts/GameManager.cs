using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Transform ballPrefab;
    [SerializeField] private Transform brickPrefab;

    public float xStart = -9.5f;
    public float yStart = 4.5f;
    public float xShift = 2.0f;
    public float yShift = 1.0f;

    private void Start()
    {
        Instantiate(ballPrefab, Vector2.zero, Quaternion.identity);

        

        

        
    }

    private void DestroyAllBricks()
    {
        GameObject[] bricks = GameObject.FindGameObjectsWithTag("Brick");
        foreach (GameObject brick in bricks)
        {
            Destroy(brick);
        }
    }

    private void Update()
    {
        // Spawn 8 rows of bricks with 10 bricks in each row and make the bricks distance to each other variable

        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                Instantiate(brickPrefab, new Vector2(xStart + xShift * j, yStart - yShift * i), Quaternion.identity);
            }
        }

 
        // Destroy all bricks again when pressing the space key
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            DestroyAllBricks();
        }
       
        



    }
}
