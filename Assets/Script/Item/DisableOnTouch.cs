using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableOnTouch : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            AudioManager.instance?.CollectClip();
            this.gameObject.SetActive(false);
        }
    }
}
