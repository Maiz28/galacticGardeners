using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CondicionesGanar : MonoBehaviour
{
    private int totalSemillasRecolectadas = 0;
    private int plantasAdultas = 0; // Contador de plantas adultas.
    [SerializeField]
    private ArloHealth arloHealth; // Referencia directa al script de ArloHealth.
    [SerializeField]
    private Planta[] todasLasPlantas; // Referencia a todas las plantas en la escena.

    private void Start()
    {
        // Suscribirse al evento de recolección de semillas.
        Semillas.sumaSemilla += ActualizarSemillas;

        if (arloHealth == null)
        {
            Debug.LogError("Falta asignar el script ArloHealth en el Inspector.");
        }

        // Inicializar el array de plantas
        todasLasPlantas = FindObjectsOfType<Planta>();
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
        // Verificar si no hay enemigos activos, si las semillas recolectadas son 10 o más,
        // y si hay al menos 3 plantas adultas.
        if (EnemigosRestantes() == 0 && totalSemillasRecolectadas >= 10 && HayPlantasAdultas())
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

    private bool HayPlantasAdultas()
    {
        plantasAdultas = 0;
        foreach (var planta in todasLasPlantas)
        {
            if (planta.EsAdulta())
            {
                plantasAdultas++;
            }
        }
        return plantasAdultas >= 3; // Verificar si hay al menos 3 plantas adultas
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
