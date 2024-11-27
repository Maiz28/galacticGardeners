using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArloHealth : MonoBehaviour
{
    [SerializeField]
    private float vida;
    [SerializeField]
    private GameObject efectoMuerte;

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
        Instantiate(efectoMuerte, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}