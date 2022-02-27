using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private int Life = 5;
    [SerializeField]
    private float RepulsionForce=100;
    [SerializeField]
    private DialogueTrigger dialogueTriggerIntro;
    [SerializeField]
    private DialogueTrigger dialogueTriggerEnd;
    [SerializeField]
    private GameObject dialogueBoxIntro;
    [SerializeField]
    private GameObject dialogueBoxEnd;
    [SerializeField]
    private Image image;
    private int maxLife;

    private bool EndGame = false;

    private void Start()
    {
        maxLife = Life;
        dialogueBoxIntro.SetActive(true);
        dialogueTriggerIntro.TriggerDialogue();
        StartCoroutine("StartingStop");
    }

    private IEnumerator StartingStop()
    {
        yield return new WaitForSeconds(0.1f);
        GameManager.instance.isPaused = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {
            image.fillAmount -= 0.2f;
            if (Life == 1)
            {
                Death();
            }
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(-1,0.1f)*RepulsionForce,ForceMode2D.Impulse);
            Life--;
        }
    }

    private void Death()
    {
        GameManager.instance.isPaused = true;
        dialogueBoxEnd.SetActive(true);
        dialogueTriggerEnd.TriggerDialogue();
        EndGame = true;
    }

    private void Update()
    {
        if (EndGame)
        {
            if (!dialogueBoxEnd.activeInHierarchy)
            {
                SceneManager.LoadScene("Level99");
            }
        }
    }
}
