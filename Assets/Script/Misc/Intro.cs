using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Intro : MonoBehaviour
{
    [SerializeField]
    private GameObject DialogueBoxUI;
    [SerializeField]
    private DialogueTrigger dialogueTrigger;
    public Vector2 StartPosition;
    public Vector2 LastPosition;
    private float time = 0;
    private Vector2 offset;
    private float speed = 0.5f;
    private float goBack =0;
    private bool casted=false;

    // Start is called before the first frame update
    void Start()
    {
        GameManager.instance.isPaused = true;
        offset = transform.position - (Vector3)StartPosition;
        dialogueTrigger.TriggerDialogue();
    }

    // Update is called once per frame
    void Update()
    {
        if (!DialogueBoxUI.gameObject.activeInHierarchy)
        {
            GameManager.instance.isPaused = true;
            time += Time.deltaTime * speed;
            goBack += Time.deltaTime * speed;
            if (time < 1)
            {
                if (casted && transform.localScale.x<0)
                {
                    transform.localScale=new Vector3(transform.localScale.x*-1,transform.localScale.y,transform.localScale.z);    
                }
                transform.position = Vector3.Lerp(StartPosition + offset, LastPosition + offset, time);
            }
            else if (goBack<2)
            {
                time = 0;
                Vector2 NextLastPosition = StartPosition;
                StartPosition = LastPosition;
                LastPosition = NextLastPosition;
                DialogueBoxUI.gameObject.SetActive(true);
            }
            else
            {
                GameManager.instance.isPaused = false;
                GameManager.instance.SetActivateMask(false);
                Destroy(this.gameObject);
            }
        }
        else if(!casted)
        {
            InvokeRepeating(nameof(SwitchWorld), 3f,1f);
            casted = true;
        }

    }

    private void SwitchWorld()
    {
       GameManager.instance.SetActivateMask(!GameManager.instance.GetActivateMask());
    }
}
