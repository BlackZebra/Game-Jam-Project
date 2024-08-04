using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem.LowLevel;

public class Player : MonoBehaviour
{
    public static Player Instanse { get; private set; }

    [SerializeField] private float movingSpeed = 5f;

    private Rigidbody2D rb;

    private float minMovementSpeed = 0.1f;
    private bool isRunning = false;

    // Start is called before the first frame update
    private void Awake()
    {
        Instanse = this;
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        HandleMovement();
    }

    private void HandleMovement()
    {
        Vector2 inputVector = GameInput.Instance.GetMovementVector();

        inputVector.Normalize();

        rb.MovePosition(rb.position + inputVector * (movingSpeed * Time.fixedDeltaTime));

        if (Mathf.Abs(inputVector.x) > minMovementSpeed || Mathf.Abs(inputVector.x) > minMovementSpeed)
        {
            isRunning = true;
        }
        else
        {
            isRunning = false;
        }
    }

    public bool IsRunning()
    {
        return isRunning;
    }

    public Vector3 GetPlayerScreenPosition()
    {
        Vector3 playerScreenPosition = Camera.main.WorldToScreenPoint(transform.position);
        return playerScreenPosition;
    }
}
