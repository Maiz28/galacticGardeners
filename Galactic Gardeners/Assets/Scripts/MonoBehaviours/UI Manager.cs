using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    private int totalSemillas;
    [SerializeField] private TMP_Text textoSemillas;

    private void Start()
    {
        Semillas.sumaSemilla += SumarSemillas;
    }

    private void SumarSemillas(int semilla)
    {
        totalSemillas += semilla;
        textoSemillas.text = totalSemillas.ToString();
    }

}
