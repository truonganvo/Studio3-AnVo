using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] private GameObject[] waypoints;
    private int currentWayPoint = 0;

    [SerializeField] private float speed = 2f;
    [SerializeField] Vector3 initialScale; // Initial scale of the player object, make sure to set this into player character current scale

    private void Update()
    {
        if (Vector2.Distance(waypoints[currentWayPoint].transform.position, transform.position) < 0.1f)
        {
            currentWayPoint++;
            if (currentWayPoint >= waypoints.Length)
            {
                currentWayPoint = 0;
            }
        }
        transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWayPoint].transform.position, Time.deltaTime * speed);
    }

    //Moving SideWay
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.transform.localScale = initialScale; //Freeze Player scale
            collision.gameObject.transform.SetParent(transform);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.transform.SetParent(null);
        }
    }
}
