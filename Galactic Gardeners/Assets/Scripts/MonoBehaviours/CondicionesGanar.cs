using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CondicionesGanar : MonoBehaviour
{
    private int totalSemillasRecolectadas = 0;
    [SerializeField]
    private ArloHealth arloHealth; // Referencia directa al script de ArloHealth.

    private void Start()
    {
        // Suscribirse al evento de recolección de semillas.
        Semillas.sumaSemilla += ActualizarSemillas;

        if (arloHealth == null)
        {
            Debug.LogError("Falta asignar el script ArloHealth en el Inspector.");
        }
    }

    private void Update()
    {
        // Verificar las condiciones de victoria y derrota.
        VerificarCondiciones();
        VerificarDerrota();
    }

    private void ActualizarSemillas(int semillas)
    {
        totalSemillasRecolectadas += semillas;
    }

    private void VerificarCondiciones()
    {
        // Revisar si no hay enemigos activos y si las semillas recolectadas son 6 o más.
        if (EnemigosRestantes() == 0 && totalSemillasRecolectadas >= 6)
        {
            Debug.Log("¡Ganaste!");
            enabled = false;
        }
    }

    private void VerificarDerrota()
    {
        // Verifica si arloHealth no es nulo y si el jugador está muerto
        if (arloHealth != null && arloHealth.GetMuerto())
        {
            Debug.Log("¡Perdiste!!");
            enabled = false; // Desactiva este script después de imprimir el mensaje
        }
        else if (arloHealth == null) // Si Arlo ha sido destruido
        {
            Debug.Log("¡Perdiste!! (Arlo destruido)");
            enabled = false; // Desactiva este script
        }
    }


    private int EnemigosRestantes()
    {
        // Obtener todos los objetos en la escena con la etiqueta "Enemy".
        return GameObject.FindGameObjectsWithTag("Enemy").Length;
    }

    private void OnDestroy()
    {
        // Desuscribirse del evento para evitar errores si el objeto es destruido.
        Semillas.sumaSemilla -= ActualizarSemillas;
    }
}
