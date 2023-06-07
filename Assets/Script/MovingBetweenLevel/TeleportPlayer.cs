using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportPlayer : MonoBehaviour
{
    [SerializeField] private GameObject tpPoints;
    [SerializeField] private Camera mainCamera;
    [SerializeField] private GameObject timer;


    public Vector3 targetPosition; // The target position for the camera
    public float moveSpeed = 5f; // The speed at which the camera moves
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            collision.transform.position = tpPoints.transform.position;
            mainCamera.transform.position = Vector3.Lerp(transform.position, targetPosition, moveSpeed * Time.deltaTime);
            timer.SetActive(true);
        }
    }
}
