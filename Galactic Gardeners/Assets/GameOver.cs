using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class GameOver : MonoBehaviour
{
    [SerializeField] private GameObject gameOver; // El objeto de la UI del Game Over
    public ArloHealth arloHealth; // Referencia al script ArloHealth

    private void Start()
    {
        if (arloHealth == null)
        {
            // Si no tienes asignada la referencia de arloHealth en el inspector, la encontramos en el juego
            arloHealth = GameObject.FindWithTag("ArloHealth").GetComponent<ArloHealth>();
        }

        if (arloHealth != null)
        {
            // Suscribirse al evento de muerte del jugador
            arloHealth.MuerteJugador += ActivarMenu;
        }
        else
        {
            Debug.LogError("No se encontró el componente ArloHealth en el jugador.");
        }
    }

    // Este método se llama cuando se dispara el evento MuerteJugador
    public void ActivarMenu(object sender, EventArgs e)
    {
        // Activamos el menú de Game Over
        gameOver.SetActive(true);
        Time.timeScale = 0f; // Pausamos el juego para que no siga funcionando
    }

    public void ReiniciarNivel()
    {
        // Reinicia la escena actual
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Debug.Log("Reiniciando nivel...");
        Time.timeScale = 1f; // Asegura que el tiempo se reanude después de reiniciar
    }

    public void IrMenuPrincipal()
    {
        // Regresa al menú principal (escena 0)
        Time.timeScale = 1f; // Asegura que el tiempo se reanude antes de cambiar de escena
        SceneManager.LoadScene(0);
    }

    private void OnDestroy()
    {
        // Desuscribirse del evento de muerte para evitar errores si el objeto es destruido
        if (arloHealth != null)
        {
            arloHealth.MuerteJugador -= ActivarMenu;
        }
    }
}
