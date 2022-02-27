using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    [SerializeField]
    private DialogueManager dialogueManager;
    public Dialogue dialogue;
    // Start is called before the first frame update
    public void TriggerDialogue()
    {
        dialogueManager.StartDialogue(dialogue);
    }
}
