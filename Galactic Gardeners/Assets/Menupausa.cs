using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menupausa : MonoBehaviour
{
    [SerializeField] private GameObject botonPausa;
    [SerializeField] private GameObject menuPausa;

    public void Pausa()
    {
        Time.timeScale = 0f; // Pausa el juego
        botonPausa.SetActive(false); // Oculta el botón de pausa
        menuPausa.SetActive(true);  // Muestra el menú de pausa
    }

    public void Reanudar()
    {
        Time.timeScale = 1f; // Reanuda el juego
        botonPausa.SetActive(true); // Muestra el botón de pausa
        menuPausa.SetActive(false); // Oculta el menú de pausa
    }

    public void Reiniciar()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;

    }

    public void IrMenuPrincipal()
    {
        Time.timeScale = 1f; // Asegura que el tiempo no esté pausado
        SceneManager.LoadScene(0); // Carga la escena del menú principal
        // Asegúrate de que el nombre "MenuPrincipal" coincida exactamente con el nombre de tu escena en Unity.
    }

    public void quitar()
    {
        // Asegúrate de que el nombre de la escena esté correctamente especificado
        SceneManager.LoadScene(4);
    }

    public void nivel1()
    {
        // Asegúrate de que el nombre de la escena esté correctamente especificado
        SceneManager.LoadScene(1);
    }
    public void nivel2()
    {
        // Asegúrate de que el nombre de la escena esté correctamente especificado
        SceneManager.LoadScene(2);
    }
    public void nivel3()
    {
        // Asegúrate de que el nombre de la escena esté correctamente especificado
        SceneManager.LoadScene(6);
    }



}
