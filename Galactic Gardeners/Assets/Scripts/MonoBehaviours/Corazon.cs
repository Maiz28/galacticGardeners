using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Corazon : MonoBehaviour
{
    [SerializeField]
    private float cantidadVida = 1f; // Cantidad de vida que se a�ade al recoger el coraz�n

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Aseg�rate de que el jugador tenga la etiqueta "Player"
        {
            ArloHealth arloHealth = other.GetComponent<ArloHealth>();
            if (arloHealth != null)
            {
                arloHealth.AumentarVida(cantidadVida); // Aumenta la vida del personaje
                Destroy(gameObject); // Destruye el coraz�n despu�s de recogerlo
            }
        }
    }
}
