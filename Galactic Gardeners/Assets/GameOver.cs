using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class GameOver : MonoBehaviour
{

    [SerializeField] private GameObject gameOver;

    public ArloHealth arloHealth;

    public void ReiniciarNivel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Debug.Log("Reiniciando nivel...");
    }

    public void IrMenuPrincipal()
    {
        Time.timeScale = 1f; // Asegura que el tiempo no esté pausado
        SceneManager.LoadScene(0); // Carga la escena del menú principal
        // Asegúrate de que el nombre "MenuPrincipal" coincida exactamente con el nombre de tu escena en Unity.
    }

}
