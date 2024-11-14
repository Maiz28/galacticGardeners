using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanzarFlecha : MonoBehaviour
{
    [SerializeField]
    private Transform controladorDisparo;  // Ubicaci�n desde donde se lanza la flecha
    [SerializeField]
    private GameObject flecha;  // Prefab de la flecha
    private Animator animator;  // Referencia al Animator del jugador
    private ArloWalk arloWalk;  // Referencia al script ArloWalk para obtener la �ltima direcci�n

    // Definimos los triggers para las animaciones de disparo
    private string shootNorthTrigger = "ShootNorth";
    private string shootSouthTrigger = "ShootSouth";
    private string shootEastTrigger = "ShootEast";
    private string shootWestTrigger = "ShootWest";

    void Start()
    {
        // Obtener referencias a los componentes necesarios
        animator = GetComponent<Animator>();
        arloWalk = GetComponent<ArloWalk>();

        if (animator == null)
        {
            Debug.LogError("No se encontr� el componente Animator en el jugador.");
        }

        if (arloWalk == null)
        {
            Debug.LogError("No se encontr� el script ArloWalk en el jugador.");
        }
    }

    void Update()
    {
        // Verificamos si la tecla de disparo (por ejemplo, "Fire1") es presionada
        if (Input.GetButtonDown("Fire1"))
        {
            // Activar la animaci�n de disparo dependiendo de la �ltima direcci�n del jugador
            ActivarAnimacionDisparo(arloWalk.LastDirection);

            // Llamamos a la Coroutine para esperar a que termine la animaci�n
            StartCoroutine(EsperarYDisparar());
        }
    }

    private void ActivarAnimacionDisparo(ArloWalk.CharStates ultimaDireccion)
    {
        // Verificamos la direcci�n en la que el jugador est� mirando y activamos el trigger correspondiente
        switch (ultimaDireccion)
        {
            case ArloWalk.CharStates.walkNorth:
                Debug.Log("Activando animaci�n de disparo hacia el norte.");
                animator.SetTrigger(shootNorthTrigger);
                break;
            case ArloWalk.CharStates.walkSouth:
                Debug.Log("Activando animaci�n de disparo hacia el sur.");
                animator.SetTrigger(shootSouthTrigger);
                break;
            case ArloWalk.CharStates.walkEast:
                Debug.Log("Activando animaci�n de disparo hacia el este.");
                animator.SetTrigger(shootEastTrigger);
                break;
            case ArloWalk.CharStates.walkWest:
                Debug.Log("Activando animaci�n de disparo hacia el oeste.");
                animator.SetTrigger(shootWestTrigger);
                break;
            default:
                Debug.LogWarning("Direcci�n no v�lida para disparar.");
                break;
        }
    }

    // Coroutine para esperar a que termine la animaci�n y luego disparar
    private IEnumerator EsperarYDisparar()
    {
        // Esperar hasta que la animaci�n de disparo haya comenzado (puedes ajustar esto seg�n la duraci�n de la animaci�n)
        yield return new WaitForSeconds(0.5f);  // Ajusta este tiempo seg�n la duraci�n de la animaci�n

        // Disparar la flecha despu�s de que la animaci�n se haya activado
        Disparar();
    }

    private void Disparar()
    {
        // Instanciamos la flecha en la posici�n y rotaci�n del controlador de disparo
        Instantiate(flecha, controladorDisparo.position, controladorDisparo.rotation);
    }
}
