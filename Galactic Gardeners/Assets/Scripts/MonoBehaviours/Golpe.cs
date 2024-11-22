using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Golpe : MonoBehaviour
{
    [SerializeField]
    private float da�o;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            Debug.Log("Golpe a enemigo");
            other.GetComponent<Enemy>().TomarDa�o(da�o);
        }
    }
}
