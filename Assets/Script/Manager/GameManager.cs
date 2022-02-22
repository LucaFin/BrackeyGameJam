using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField]
    private GameObject SpriteMask;
    // Start is called before the first frame update
    void Start()
    {
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
}
