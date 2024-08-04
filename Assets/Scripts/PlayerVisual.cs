using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerVisual : MonoBehaviour
{
    private Animator animator;
    private SpriteRenderer spriteRenderer;

    private const string IS_RUNNING = "IsRunning";

    private void Awake()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        animator.SetBool(IS_RUNNING, Player.Instanse.IsRunning());
        AdjustPlayerFacingDirection();
    }

    public Vector3 GetMousePosition()
    {
        Vector3 mousePosition = Mouse.current.position.ReadValue();
        return mousePosition;
    }

    private void AdjustPlayerFacingDirection()
    {
        Vector3 mousePos = GameInput.Instance.GetMousePosition();
        Vector3 playerPos = Player.Instanse.GetPlayerScreenPosition();

        if (mousePos.x < playerPos.x)
        {
            spriteRenderer.flipX = true;
        }
        else
        {
            spriteRenderer.flipX = false;
        }
    }
}
