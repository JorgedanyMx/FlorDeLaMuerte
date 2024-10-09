using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoiint : MonoBehaviour
{
    [SerializeField] PlayerData playerData;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerData.SetCheckpointPosition(transform.position);
            Destroy(transform.gameObject);
        }
    }
}
