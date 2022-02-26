using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FollowMouse : MonoBehaviour
{
    [SerializeField]
    private Camera mainCamera;

    // Update is called once per frame
    void Update()
    {
        Vector3 mouseposition = mainCamera.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        mouseposition.z = 0f;
        transform.position = mouseposition;
    }
}