using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] PlayerData playerData;
    [SerializeField] Collider2D colliderShiled;
    [SerializeField] GameEvent SFXDoorEvent;
    [SerializeField] GameEvent EventGameEnds;
    public float fuerzaImpulso = 10f;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            if (playerData.HasAllRemembers())
            {
                colliderShiled.enabled = false;
            }
            else 
            { 
                Rigidbody2D rbJugador = collision.gameObject.GetComponent<Rigidbody2D>();
                if (rbJugador != null)
                {
                    rbJugador.velocity = new Vector2(rbJugador.velocity.x,fuerzaImpulso);
                    SFXDoorEvent.Raise();
                    Debug.Log("Entra");
                }
            }
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            EventGameEnds.Raise();
        }
    }
}
