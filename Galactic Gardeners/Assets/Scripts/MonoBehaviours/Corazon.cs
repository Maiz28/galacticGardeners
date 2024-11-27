using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Corazon : MonoBehaviour
{
    [SerializeField]
    private float cantidadVida = 1f; // Cantidad de vida que se añade al recoger el corazón

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Asegúrate de que el jugador tenga la etiqueta "Player"
        {
            ArloHealth arloHealth = other.GetComponent<ArloHealth>();
            if (arloHealth != null)
            {
                arloHealth.AumentarVida(cantidadVida); // Aumenta la vida del personaje
                Destroy(gameObject); // Destruye el corazón después de recogerlo
            }
        }
    }
}
