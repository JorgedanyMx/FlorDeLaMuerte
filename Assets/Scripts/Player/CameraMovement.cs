using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform objetoASeguir;  // El GameObject que la c�mara va a seguir (por ejemplo, el jugador)
    public Vector3 offset;  // Offset para la posici�n de la c�mara
    [SerializeField] float distanciaMinima = 2f;  // Distancia m�nima desde el centro de la c�mara para que esta siga al objeto
    [SerializeField] float suavidadMovimiento = 0.3f;  // Suavidad del movimiento (a menor valor, m�s r�pido sigue la c�mara)
    private Vector3 velocidadActual;  // Velocidad actual usada por SmoothDamp
    private void LateUpdate()
    {
        SeguirObjeto();
    }
    void SeguirObjeto()
    {
        // Calcular la posici�n objetivo de la c�mara con el offset aplicado
        Vector3 posicionObjetivo = objetoASeguir.position + offset;

        //float distanciaObjetoCamara = Vector2.Distance(objetoASeguir.position,transform.position);
        float distanciaObjetoCamara = Mathf.Abs(objetoASeguir.position.x - transform.position.x);

        if (distanciaObjetoCamara > distanciaMinima)
        {
            Vector3 nuevaPosicion = new Vector3(posicionObjetivo.x, transform.position.y, transform.position.z);
            transform.position = Vector3.SmoothDamp(transform.position, nuevaPosicion, ref velocidadActual, suavidadMovimiento);
        }
    }
}
