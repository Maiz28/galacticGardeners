using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float vida;

    [SerializeField] private GameObject efectoMuerte;

    [SerializeField]
    private float daño;

    public float intervaloDaño = 1.0f;
    private float tiempoTranscurrido = 0f;

    public void TomarDaño(float daño)
    {
        vida -= daño;
        if (vida <= 0)
        {
            Muerte();
        }
    }

    private void Muerte()
    {
        Instantiate(efectoMuerte, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Aplica daño inicial al entrar en contacto.
            other.GetComponent<ArloHealth>().TomarDaño(daño);
            tiempoTranscurrido = 0f; // Reinicia el temporizador.
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Incrementa el tiempo transcurrido mientras el jugador permanece colisionando.
            tiempoTranscurrido += Time.deltaTime;

            if (tiempoTranscurrido >= intervaloDaño)
            {
                // Aplica daño si se cumple el intervalo de tiempo.
                other.GetComponent<ArloHealth>().TomarDaño(daño);
                tiempoTranscurrido = 0f; // Reinicia el temporizador.
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Reinicia el temporizador al salir de la colisión.
            tiempoTranscurrido = 0f;
        }
    }
}