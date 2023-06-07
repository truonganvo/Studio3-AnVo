using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayer : MonoBehaviour
{
    [SerializeField] private Vector2 respawnPoint;
    [SerializeField] private GameObject playerPrefab;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            Destroy(collision.gameObject);
            StartCoroutine("Restart");
        }
    }

    private IEnumerator Restart()
    {
        yield return new WaitForSeconds(2f);
        GameObject spawnPrefab = Instantiate(playerPrefab, respawnPoint, Quaternion.identity);
    }

}
