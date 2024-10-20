using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_follow : MonoBehaviour
{
    public Transform objetoASeguir;  // El GameObject que la cámara va a seguir (por ejemplo, el jugador)
    public Vector3 offset;  // Offset para la posición de la cámara
    private GameObject Player;

 
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        // Vector3 posicionObjetivo = objetoASeguir.position;

        // Vector3 nuevaPosicion = new Vector3(posicionObjetivo.x, transform.position.y, transform.position.z) + offset;

        this.transform.position = (Player.transform.position);
    }
    public void SecondPartLEvel()
    {
        offset = new Vector3(-offset.x, offset.y, offset.z);
    }

}
