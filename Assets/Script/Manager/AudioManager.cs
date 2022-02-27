using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    [SerializeField]
    private AudioClip Jump;
    [SerializeField]
    private AudioClip Death;
    [SerializeField]
    private AudioClip Collect;
    [SerializeField]
    private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        if (instance == null) {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else if (instance!=this)
        {
            DestroyImmediate(instance.gameObject); 
        }
    }

    public void JumpClip()
    {
        audioSource.clip = Jump;
        audioSource.Play();
    }

    public void DeathClip()
    {
        audioSource.clip = Death;
        audioSource.Play();
    }

    public void CollectClip()
    {

        audioSource.clip = Collect;
        audioSource.Play();
    }
}
