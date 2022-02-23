using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    [SerializeField]
    private int Nextlevel = 0; 
    private GameObject[] Collectable;

    private void Awake()
    {
        Collectable = GameObject.FindGameObjectsWithTag("Collectable");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && (Collectable.Where(c => c.activeInHierarchy).Count() == 0))
        {
            SceneManager.LoadScene($"Level{Nextlevel}");
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && (Collectable.Where(c => c.activeInHierarchy).Count() == 0))
        {
            SceneManager.LoadScene($"Level{Nextlevel}");
        }
    }

}
