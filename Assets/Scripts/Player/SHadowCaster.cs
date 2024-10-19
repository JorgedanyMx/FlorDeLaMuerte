using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SHadowCaster : MonoBehaviour
{
    public GameObject shadowIMG; // La imagen de la sombra que queremos ajustar
    public LayerMask sueloLayer; // Layer para detectar el suelo
    public float maxShadowDistance = 10f; // Distancia m�xima a la que la sombra ser� m�s grande
    public float minShadowSize = 0.2f; // Tama�o m�nimo de la sombra
    public float maxShadowSize = 1f; // Tama�o m�ximo de la sombra

    void Update()
    {
        ShadowCast();
    }

    void ShadowCast()
    {
        // Lanzar un Raycast hacia abajo buscando el layer "suelo"
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, maxShadowDistance, sueloLayer);

        if (hit.collider != null)
        {
            // Si colisiona con el suelo, mueve la sombra a la posici�n del impacto
            if(!shadowIMG.active)shadowIMG.SetActive(true);
            Vector2 shadowPosition = new Vector2(hit.point.x, hit.point.y);
            shadowIMG.transform.position = shadowPosition;

            // Calcular la distancia desde el objeto hasta el suelo
            float distanceToGround = hit.distance;

            // Escalar la sombra seg�n la distancia al suelo
            float shadowScale = Mathf.Lerp(minShadowSize, maxShadowSize,  1f/ distanceToGround);
            shadowIMG.transform.localScale = new Vector3(shadowScale, shadowScale/4f, 1f);
        }
        else
        {
            // Si no colisiona con el suelo, opcionalmente puedes desactivar la sombra
            shadowIMG.SetActive(false);
        }
    }
}
