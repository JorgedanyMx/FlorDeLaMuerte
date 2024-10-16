using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform objetoASeguir;  // El GameObject que la cámara va a seguir (por ejemplo, el jugador)
    public Vector3 offset;  // Offset para la posición de la cámara
    [SerializeField] float suavidadMovimiento = 0.3f;  // Suavidad del movimiento (a menor valor, más rápido sigue la cámara)
    private Vector3 velocidadActual;  // Velocidad actual usada por SmoothDamp
    [SerializeField]private float multispeed;
    private void LateUpdate()
    {
        SeguirObjeto();
    }
    void SeguirObjeto()
    {
        Vector3 posicionObjetivo = objetoASeguir.position;
        float distanciaObjetoCamara = Vector2.Distance(new Vector2(transform.position.x, transform.position.y),new Vector2(objetoASeguir.position.x, objetoASeguir.position.y));
        multispeed = distanciaObjetoCamara;
        Vector3 nuevaPosicion = new Vector3(posicionObjetivo.x, posicionObjetivo.y, transform.position.z) + offset;

        if (distanciaObjetoCamara > 6f)
        {
            transform.position = Vector3.SmoothDamp(transform.position, nuevaPosicion, ref velocidadActual, suavidadMovimiento / 5f);
        }
        else
        {
            transform.position = Vector3.SmoothDamp(transform.position, nuevaPosicion, ref velocidadActual, suavidadMovimiento);
        }
    }
    public void SecondPartLEvel()
    {
        offset = new Vector3(-offset.x, offset.y, offset.z);
    }
}
