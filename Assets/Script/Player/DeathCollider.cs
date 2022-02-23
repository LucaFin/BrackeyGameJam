using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathCollider : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameManager.instance.isPaused = true;
            collision.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
            GameManager.instance.SetActivateMask(true);
            Invoke(nameof(Death), 0.5f);
        }
    }

    private void Death()
    {
        GameManager.instance.Death();
    }
}
