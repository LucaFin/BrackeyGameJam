using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpMovement : MonoBehaviour
{
    public Vector2 StartPosition;
    public Vector2 LastPosition;
    private float time=0;
    private Vector2 offset;
    [SerializeField]
    private float speed = 0.25f;
    // Update is called once per frame
    private void Awake()
    {
        offset = transform.position-(Vector3)StartPosition;
    }
    void Update()
    {
        if (!GameManager.instance.isPaused)
        {
            
            time += Time.deltaTime * speed;
            if (time < 1)
            {
                transform.position = Vector3.Lerp(StartPosition + offset, LastPosition + offset, time);
            }
            else
            {
                time = 0;
                Vector2 NextLastPosition = StartPosition;
                StartPosition = LastPosition;
                LastPosition = NextLastPosition;
            }
        }
    }
}
