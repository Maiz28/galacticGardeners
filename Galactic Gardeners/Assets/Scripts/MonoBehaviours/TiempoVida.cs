using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiempoVida : MonoBehaviour
{
    [SerializeField] private float tiempoVida;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, tiempoVida);
    }

}
