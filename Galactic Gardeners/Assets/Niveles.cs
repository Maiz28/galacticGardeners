using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Niveles : MonoBehaviour
{
    public void nivel1()
    {
        // Asegúrate de que el nombre de la escena esté correctamente especificado
        SceneManager.LoadScene(4);
    }
    public void nivel2()
    {
        // Asegúrate de que el nombre de la escena esté correctamente especificado
        SceneManager.LoadScene(5);
    }

    public void nivel3()
    {
        // Asegúrate de que el nombre de la escena esté correctamente especificado
        SceneManager.LoadScene(6);
    }
    public void menuprincipal()
    {
        // Asegúrate de que el nombre de la escena esté correctamente especificado
        SceneManager.LoadScene(0);
    }

    public void jugarnivel2()
    {
        // Asegúrate de que el nombre de la escena esté correctamente especificado
        SceneManager.LoadScene(2);
    }
    public void jugarnivel1()
    {
        // Asegúrate de que el nombre de la escena esté correctamente especificado
        SceneManager.LoadScene(1);
    }


    public void mapa()
    {
        // Asegúrate de que el nombre de la escena esté correctamente especificado
        SceneManager.LoadScene(3);
    }

}
