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
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rb = player.GetComponent<Rigidbody2D>();
    }

    public void Jump(InputAction.CallbackContext callbackContext)
    {
        if (callbackContext.performed)
        {
            rb.AddForce(Vector2.up * playerStats.JumpForce, ForceMode2D.Impulse);
        }
    }
}
