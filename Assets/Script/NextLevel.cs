using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    private bool unlock=true;
    [SerializeField]
    private int Nextlevel = 0;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Player") && unlock)
        {
            SceneManager.LoadScene($"Level{Nextlevel}");
        }
    }

    public void SetUnlock(bool unlocked)
    {
        unlock = unlocked;
    }
}
