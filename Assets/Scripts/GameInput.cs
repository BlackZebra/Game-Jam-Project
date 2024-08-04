using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

public class GameInput : MonoBehaviour
{
    public static GameInput Instance { get; private set; }

    private PlayersInputActions playersInputActions;

    private void Awake()
    {
        Instance = this;
        playersInputActions = new PlayersInputActions();
        playersInputActions.Enable();
    }


    public Vector2 GetMovementVector()
    {
        Vector2 inputVector = playersInputActions.Player.Move.ReadValue<Vector2>();
        return inputVector;
    }


    public Vector3 GetMousePosition()
    {
        Vector3 mousePosition = Mouse.current.position.ReadValue();
        Debug.Log(mousePosition);
        return mousePosition;
    }
}
