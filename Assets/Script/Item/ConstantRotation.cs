using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstantRotation : MonoBehaviour
{
    private float degrees = 0;
    void Update()
    {
        if (!GameManager.instance.isPaused)
        {
            degrees--;
            transform.eulerAngles = Vector3.forward * degrees;
        }
    }
}
