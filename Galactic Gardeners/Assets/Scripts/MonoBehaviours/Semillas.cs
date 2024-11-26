using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Semillas : MonoBehaviour
{
    public delegate void SumaSemilla(int semilla);
    public static event SumaSemilla sumaSemilla;

    [SerializeField] private int cantidadSemillas;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (sumaSemilla != null)
            {
                SumarSemilla();
                Destroy(this.gameObject);
            }

        }
    }

    private void SumarSemilla()
    {
        sumaSemilla(cantidadSemillas);
    }
}