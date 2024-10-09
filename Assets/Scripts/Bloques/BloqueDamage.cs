using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloqueDamage : MonoBehaviour
{
    public GameEvent DeadEvent;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            DeadEvent.Raise();
        }
    }
}
