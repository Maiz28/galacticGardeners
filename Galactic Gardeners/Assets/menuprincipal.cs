using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour
{
    public void Jugar()
    {
        // Asegúrate de que el nombre de la escena esté correctamente especificado
        SceneManager.LoadScene(4);
    }

    public void Salir()
    {
        Debug.Log("Salir...");
        Application.Quit();
    }
    public void mapa()
    {
        // Asegúrate de que el nombre de la escena esté correctamente especificado
        SceneManager.LoadScene(3);
    }

}
