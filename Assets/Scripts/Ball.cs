using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed = 5f;
    private Vector2 movementDirection;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        movementDirection = GetRandomVector();
        rb.velocity = movementDirection * speed;
    }

    Vector2 GetRandomVector()
    {
        Vector2[] possibleVectors = new Vector2[]
        {
            new Vector2(1, -1),
            new Vector2(-1, -1)
        };

        int randomIndex = UnityEngine.Random.Range(0, possibleVectors.Length);

        return possibleVectors[randomIndex];
    }

    //When the ball collides with the paddle then change the direction of the ball depending on where it hits the paddle

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Paddle"))
        {
            float hitPosition = (transform.position.x - collision.transform.position.x) / collision.collider.bounds.size.x;
            Vector2 direction = new Vector2(hitPosition, 1).normalized;
            rb.velocity = direction * speed;
        }
    }
}
