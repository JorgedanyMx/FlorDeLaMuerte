using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SHadowCaster : MonoBehaviour
{
    public GameObject shadowIMG; // La imagen de la sombra que queremos ajustar
    public LayerMask sueloLayer; // Layer para detectar el suelo
    public float maxShadowDistance = 10f; // Distancia máxima a la que la sombra será más grande
    public float minShadowSize = 0.2f; // Tamaño mínimo de la sombra
    public float maxShadowSize = 1f; // Tamaño máximo de la sombra

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
            // Si colisiona con el suelo, mueve la sombra a la posición del impacto
            if(!shadowIMG.active)shadowIMG.SetActive(true);
            Vector2 shadowPosition = new Vector2(hit.point.x, hit.point.y);
            shadowIMG.transform.position = shadowPosition;

            // Calcular la distancia desde el objeto hasta el suelo
            float distanceToGround = hit.distance;

            // Escalar la sombra según la distancia al suelo
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
