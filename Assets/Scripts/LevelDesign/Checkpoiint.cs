using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoiint : MonoBehaviour
{
    [SerializeField] PlayerData playerData;
    [SerializeField] GameObject goCheckpoint;
    [SerializeField] Collider2D colliderTrigger;
    AudioSource audioSource;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (goCheckpoint != null)
        {
            goCheckpoint.SetActive(false);
            audioSource.enabled = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerData.SetCheckpointPosition(transform.position);
            if (goCheckpoint != null)
            {
                goCheckpoint.SetActive(true);
            }
            else
            {
                Destroy(gameObject, 2f);
            }
            if (colliderTrigger != null)
            {
                colliderTrigger.enabled = false;
                audioSource.enabled = true;
            }
        }
    }
}
