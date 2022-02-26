using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TriggerFireTrap : MonoBehaviour
{
    [SerializeField,Min(3f)]
    private float cooldown = 3f;
    private bool ready = true;
    private Animator animator;
    private void Awake()
    {
        animator=GetComponent<Animator>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if(Physics2D.RaycastAll(transform.position, transform.up, 1f).Where(e => e.transform.gameObject.CompareTag("Player")).Count() == 1)
            {
                if (ready)
                {
                    ready = false;
                    animator.SetTrigger("Fire");
                    Invoke(nameof(SetReadyToFire),cooldown);
                }
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
            animator.enabled = false;
            GameManager.instance.isPaused= true;
            Invoke(nameof(Death), 0.5f);
        }
    }

    private void Death()
    {
        GameManager.instance.Death();
    }
    private void SetReadyToFire()
    {
        ready = true;
    }
}
