using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloqueDeSalto : MonoBehaviour
{
    public float fuerzaImpulso = 10f;  // Fuerza del impulso hacia arriba
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Verificar si el jugador ha colisionado con el bloque
        if (collision.gameObject.CompareTag("Player"))
        {
            Rigidbody2D rbJugador = collision.gameObject.GetComponent<Rigidbody2D>();
            // Si el jugador tiene un Rigidbody2D, aplicar un impulso hacia arriba
            if (rbJugador != null)
            {
                bool luzActiva = collision.gameObject.GetComponent<PlayerController>().luzActiva;
                if (luzActiva)
                {
                    rbJugador.velocity = new Vector2(rbJugador.velocity.x, fuerzaImpulso);
                }
            }
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        // Verificar si el jugador ha colisionado con el bloque
        if (collision.gameObject.CompareTag("Player"))
        {
            Rigidbody2D rbJugador = collision.gameObject.GetComponent<Rigidbody2D>();
            // Si el jugador tiene un Rigidbody2D, aplicar un impulso hacia arriba
            if (rbJugador != null)
            {
                bool luzActiva = collision.gameObject.GetComponent<PlayerController>().luzActiva;
                if (luzActiva)
                {
                    rbJugador.velocity = new Vector2(rbJugador.velocity.x, fuerzaImpulso);
                }
            }
        }
    }
}
