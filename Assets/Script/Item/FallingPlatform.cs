using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Invoke(nameof(StartFalling), 1f);
        }
    }

    private void StartFalling()
    {

        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 1;
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
    }
}
