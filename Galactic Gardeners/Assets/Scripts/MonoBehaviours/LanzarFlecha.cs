using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanzarFlecha : MonoBehaviour
{
    [SerializeField]
    private Transform controladorDisparo;  // Ubicación desde donde se lanza la flecha
    [SerializeField]
    private GameObject flecha;  // Prefab de la flecha
    private Animator animator;  // Referencia al Animator del jugador
    private ArloWalk arloWalk;  // Referencia al script ArloWalk para obtener la última dirección

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
            Debug.LogError("No se encontró el componente Animator en el jugador.");
        }

        if (arloWalk == null)
        {
            Debug.LogError("No se encontró el script ArloWalk en el jugador.");
        }
    }

    void Update()
    {
        // Verificamos si la tecla de disparo (por ejemplo, "Fire1") es presionada
        if (Input.GetButtonDown("Fire1"))
        {
            // Activar la animación de disparo dependiendo de la última dirección del jugador
            ActivarAnimacionDisparo(arloWalk.LastDirection);

            // Llamamos a la Coroutine para esperar a que termine la animación
            StartCoroutine(EsperarYDisparar());
        }
    }

    private void ActivarAnimacionDisparo(ArloWalk.CharStates ultimaDireccion)
    {
        // Verificamos la dirección en la que el jugador está mirando y activamos el trigger correspondiente
        switch (ultimaDireccion)
        {
            case ArloWalk.CharStates.walkNorth:
                Debug.Log("Activando animación de disparo hacia el norte.");
                animator.SetTrigger(shootNorthTrigger);
                break;
            case ArloWalk.CharStates.walkSouth:
                Debug.Log("Activando animación de disparo hacia el sur.");
                animator.SetTrigger(shootSouthTrigger);
                break;
            case ArloWalk.CharStates.walkEast:
                Debug.Log("Activando animación de disparo hacia el este.");
                animator.SetTrigger(shootEastTrigger);
                break;
            case ArloWalk.CharStates.walkWest:
                Debug.Log("Activando animación de disparo hacia el oeste.");
                animator.SetTrigger(shootWestTrigger);
                break;
            default:
                Debug.LogWarning("Dirección no válida para disparar.");
                break;
        }
    }

    // Coroutine para esperar a que termine la animación y luego disparar
    private IEnumerator EsperarYDisparar()
    {
        // Esperar hasta que la animación de disparo haya comenzado (puedes ajustar esto según la duración de la animación)
        yield return new WaitForSeconds(0.5f);  // Ajusta este tiempo según la duración de la animación

        // Disparar la flecha después de que la animación se haya activado
        Disparar();
    }

    private void Disparar()
    {
        // Instanciamos la flecha en la posición y rotación del controlador de disparo
        Instantiate(flecha, controladorDisparo.position, controladorDisparo.rotation);
    }
}
