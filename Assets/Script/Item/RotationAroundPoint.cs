using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationAroundPoint : MonoBehaviour
{
    [SerializeField]
    private GameObject targetPosition;
    [SerializeField, Min(1)]
    private float speed;

    // Update is called once per frame
    void Update()
    {
        if(!GameManager.instance.isPaused)
        transform.RotateAround(targetPosition.transform.position,Vector3.forward,Time.deltaTime * speed);
    }
}
