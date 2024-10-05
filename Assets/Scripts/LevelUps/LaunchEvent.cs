using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchEvent : MonoBehaviour
{
    public GameEvent lightEventv1;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            lightEventv1.Raise();
        }
    }
}
