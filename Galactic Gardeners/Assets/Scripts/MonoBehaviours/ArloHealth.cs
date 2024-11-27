using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ArloHealth : MonoBehaviour
{
    [SerializeField]
    private float vida;
    [SerializeField]
    private GameObject efectoMuerte;
    private bool muerto = false;
    public event EventHandler MuerteJugador;

    public void TomarDaño(float daño2)
    {
        vida -= daño2;
        if (vida <= 0 && !muerto)
        {
            Muerte();
        }
    }

    private void Muerte()
    {
        muerto = true;
        Instantiate(efectoMuerte, transform.position, Quaternion.identity);
        Destroy(gameObject, 0.1f);
    }

    public void AumentarVida(float cantidad)
    {
        if (muerto) return;

        vida += cantidad;
        if (vida > 5)
        {
            vida = 5; // Limita la vida al valor m�ximo
        }
        Debug.Log("Vida aumentada: " + vida);
    }

    public float GetVida()
    {
        return vida;
    }

    public bool GetMuerto() // M�todo que devuelve si el personaje est� muerto
    {
        return muerto;
    }
}