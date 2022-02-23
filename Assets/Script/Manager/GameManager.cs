using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField]
    private GameObject SpriteMask;

    public bool isPaused { get; internal set; }

    void Start()
    { 
        isPaused = false;
        instance = this;
    }

    public void SetActivateMask(bool EnableMask)
    {
        SpriteMask.SetActive(EnableMask);
    }

    public bool GetActivateMask()
    {
        return SpriteMask.activeInHierarchy;
    }

    public void Death()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
