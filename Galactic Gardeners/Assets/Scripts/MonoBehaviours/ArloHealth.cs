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

    public void TomarDa�o(float da�o2)
    {
        vida -= da�o2;
        if (vida <= 0)
        {
            Muerte();
        }
    }

    private void Muerte()
    {
        muerto = true;
        Instantiate(efectoMuerte, transform.position, Quaternion.identity);
        Destroy(gameObject);
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