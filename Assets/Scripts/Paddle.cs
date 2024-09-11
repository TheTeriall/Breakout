using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class Paddle : MonoBehaviour
{
    private BreakoutInput breakoutInput;
    private float speed = 10f;
    private Vector2 direction;
    private float minX = -9.5f;
    private float maxX = 9.5f;

    private void Start()
    {
        GameManager.Instance.NarrowPaddle += GameManager_NarrowPaddle;
    }

    private void GameManager_NarrowPaddle(object sender, System.EventArgs e)
    {
        // Make the paddle 5 % narrower on x
        transform.localScale = new Vector3(transform.localScale.x * 0.95f, transform.localScale.y, transform.localScale.z);
    }

    private void OnEnable()
    {
        breakoutInput.Enable();
        breakoutInput.Player.MoveLeft.performed += MoveLeft_performed;
        breakoutInput.Player.MoveRight.performed += MoveRight_performed;
        breakoutInput.Player.MoveLeft.canceled += MoveLeft_canceled;
        breakoutInput.Player.MoveRight.canceled += MoveRight_canceled;
    }

    private void MoveRight_canceled(InputAction.CallbackContext obj)
    {
        direction = new Vector2(0, 0);
    }

    private void MoveLeft_canceled(InputAction.CallbackContext obj)
    {
        direction = new Vector2(0, 0);
    }

    private void MoveRight_performed(InputAction.CallbackContext obj)
    {
        direction = new Vector2(1, 0);
    }

    private void MoveLeft_performed(InputAction.CallbackContext obj)
    {
        direction = new Vector2(-1, 0);
    }

    private void Awake()
    {
        breakoutInput = new BreakoutInput();

    }

    private void Update()
    {
        Vector2 movement = direction * speed * Time.deltaTime;
        transform.Translate(movement);
        Vector2 clampedPosition = transform.position;
        clampedPosition.x = Mathf.Clamp(clampedPosition.x, minX, maxX);
        transform.position = clampedPosition;
    }
}
