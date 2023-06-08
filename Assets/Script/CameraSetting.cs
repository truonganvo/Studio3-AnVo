using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSetting : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    public float newSize = 5f; // The new size for the camera

    public void SetCameraSize()
    {
        mainCamera.orthographicSize = newSize;
    }

}
