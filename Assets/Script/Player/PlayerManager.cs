using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerManager : MonoBehaviour
{
    private GameObject player;
    [SerializeField]
    private PlayerStats playerStats;
    private Rigidbody2D rb;
    private bool IsGrounded=true;
    private float ScaleOffset = 0;
    public PlayerInputActions controls;
    private int IsMoving=0;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        ScaleOffset = player.transform.localScale.x / 5;
        rb = player.GetComponent<Rigidbody2D>();

        controls = new PlayerInputActions();
        controls.Enable();
        controls.Player.Movement.started += ctx => StartMovement(ctx.ReadValue<Vector2>());
        controls.Player.Movement.canceled += ctx => CancelMovement(ctx.ReadValue<Vector2>());
        controls.Player.Jump.started += ctx => StartJump();
        controls.Player.RealWorld.started += ctx => GameManager.instance.SetActivateMask(true);
        controls.Player.RealWorld.canceled += ctx => GameManager.instance.SetActivateMask(false);
        controls.Player.Restart.started += ctx => GameManager.instance.Death();
    }

    private void Update()
    {
        IsGrounded = Physics2D.RaycastAll(player.transform.position, Vector2.down, 0.8f * ScaleOffset).Length > 1 ||
            Physics2D.RaycastAll(player.transform.position + Vector3.left * 0.1f, Vector2.down, 0.8f * ScaleOffset).Length > 1 ||
            Physics2D.RaycastAll(player.transform.position + Vector3.right * 0.1f, Vector2.down, 0.8f * ScaleOffset).Length > 1;
        if (GameManager.instance.GetActivateMask())
        {
            rb.constraints = RigidbodyConstraints2D.FreezeRotation | RigidbodyConstraints2D.FreezePositionX;
        }
        else
        {
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        }
        if (GameManager.instance.isPaused)
        {
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
        }
        if (IsMoving == 0)
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }
    }

    private void StartJump()
    {
        if (this != null)
        {
            if (IsGrounded && !GameManager.instance.GetActivateMask() && !GameManager.instance.isPaused)
            {
                AudioManager.instance?.JumpClip();
                rb.velocity = new Vector2(rb.velocity.x, 0);
                rb.AddForce(Vector2.up * playerStats.JumpForce, ForceMode2D.Impulse);
            }
        }
    }

    private void CancelMovement(Vector2 vector2)
    {
        if (this != null)
        {
            IsMoving--;
            rb.velocity = new Vector2(0, rb.velocity.y);
        }
    }

    private void StartMovement(Vector2 direction)
    {

        if (this != null)
        {
            IsMoving++;
            rb.velocity = new Vector2(direction.x * playerStats.Speed, rb.velocity.y);
            if (direction.x < 0)
            {
                player.transform.localScale = new Vector3(Mathf.Abs(player.transform.localScale.x) * -1, player.transform.localScale.y, player.transform.localScale.z);
            }
            else
            {
                player.transform.localScale = new Vector3(Mathf.Abs(player.transform.localScale.x), player.transform.localScale.y, player.transform.localScale.z);
            }
        }
    }
   
}
