using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class DialogueManager : MonoBehaviour
{
    public GameObject Dialogue;
    public TMP_Text NameText;
    public TMP_Text DialogueText;
    public Queue<string> sentences = new Queue<string>();
    private string LastSentence ="";
    // Start is called before the first frame update
    internal void StartDialogue(Dialogue dialogue)
    {
        GameManager.instance.isPaused = true;
        NameText.text = dialogue.name;
        sentences.Clear();
        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }
        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (LastSentence.Equals(DialogueText.text))
        {
            if (sentences.Count == 0)
            {
                EndDialogue();
                return;
            }
            LastSentence = sentences.Dequeue();
            StartCoroutine(TypeSentences(LastSentence));
        }
    }

    private IEnumerator TypeSentences(string sentence)
    {
        DialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            DialogueText.text += letter;
            yield return null;
        }
    }

    private void EndDialogue()
    {
        GameManager.instance.isPaused = false;
        Dialogue.SetActive(false);
        return;
    }
}
