using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArloHealth : MonoBehaviour
{
    [SerializeField]
    private float vida;
    [SerializeField]
    private GameObject efectoMuerte;
    private bool muerto = false; 

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
        //Instantiate(efectoMuerte, transform.position, Quaternion.identity);
        Destroy(gameObject, 0.1f);
    }

    public void AumentarVida(float cantidad)
    {
        if (muerto) return;

        vida += cantidad;
        if (vida > 5)
        {
            vida = 5; // Limita la vida al valor máximo
        }
        Debug.Log("Vida aumentada: " + vida);
    }

    public float GetVida()
    {
        return vida;
    }

    public bool GetMuerto() // Método que devuelve si el personaje está muerto
    {
        return muerto;
    }
}