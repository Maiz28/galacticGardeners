using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarraDeVida : MonoBehaviour
{
    [SerializeField]
    private ArloHealth arloHealth; // Referencia al script de salud
    [SerializeField]
    private Image barraImagen; // Imagen donde se mostrará el sprite
    [SerializeField]
    private Sprite[] estadosDeVida; // Array de sprites para las diferentes etapas de vida

    private void Start()
    {
        ActualizarBarraDeVida(); // Asegurar que la barra se inicializa correctamente
    }

    private void Update()
    {
        ActualizarBarraDeVida();
    }

    private void ActualizarBarraDeVida()
    {
        if (arloHealth.GetMuerto()) // Verifica si el personaje está muerto
        {
            barraImagen.sprite = estadosDeVida[0]; // Si está muerto, pone la barra vacía
            return;
        }

        float vida = arloHealth.GetVida();
        //Debug.Log("Valor de vida al actualizar barra: " + vida); // Verifica el valor de vida

        // Mapeo de vida (de 0 a 5) a índice del arreglo (de 0 a 4)
        int indice = Mathf.Clamp((int)(vida) - 1, 0, estadosDeVida.Length - 1);

        //Debug.Log("Índice de barra de vida seleccionado: " + indice); // Verifica el índice calculado

        barraImagen.sprite = estadosDeVida[indice];
    }


}
