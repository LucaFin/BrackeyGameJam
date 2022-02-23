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
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rb = player.GetComponent<Rigidbody2D>();
    }

    public void Jump(InputAction.CallbackContext callbackContext)
    {
        if (callbackContext.performed && IsGrounded && !GameManager.instance.GetActivateMask())
        {
            rb.AddForce(Vector2.up * playerStats.JumpForce, ForceMode2D.Impulse);
        }
    }

    public void Movement(InputAction.CallbackContext callbackContext)
    {
        if (callbackContext.performed)
        {
            rb.velocity = callbackContext.ReadValue<Vector2>()*playerStats.Speed;
        }
        if (callbackContext.canceled)
        {
            rb.velocity = new Vector2(0,rb.velocity.y);
        }
    }

    public void RealWorld(InputAction.CallbackContext callbackContext)
    {
        GameManager.instance.SetActivateMask(callbackContext.performed);
    }

    private void Update()
    {
        IsGrounded = Physics2D.RaycastAll(player.transform.position, Vector2.down, 0.66f).Length > 1 ||
            Physics2D.RaycastAll(player.transform.position+Vector3.left*0.5f, Vector2.down, 0.66f).Length>1 ||
            Physics2D.RaycastAll(player.transform.position+Vector3.right*0.5f, Vector2.down, 0.66f).Length>1;
        if (GameManager.instance.GetActivateMask())
        {
            rb.constraints = RigidbodyConstraints2D.FreezeRotation | RigidbodyConstraints2D.FreezePositionX;
        }
        else
        {
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        }
    }
}
