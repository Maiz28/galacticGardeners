using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    [SerializeField]
    private Transform controladorDañoGolpe; // Controlador que contiene el script de Golpe y el collider

    private Animator animator;  // Referencia al Animator del personaje
    private ArloWalk arloWalk;  // Referencia al script ArloWalk para obtener la última dirección

    // Triggers para las animaciones de ataque
    private string attackNorthTrigger = "AttackNorth";
    private string attackSouthTrigger = "AttackSouth";
    private string attackEastTrigger = "AttackEast";
    private string attackWestTrigger = "AttackWest";

    private void Start()
    {
        // Obtener referencias a los componentes necesarios
        animator = GetComponent<Animator>();
        arloWalk = GetComponent<ArloWalk>();

        // Asegurarse de que el collider del golpe esté desactivado al inicio
        controladorDañoGolpe.gameObject.SetActive(false);

        if (animator == null)
        {
            Debug.LogError("No se encontró el componente Animator en el personaje.");
        }

        if (arloWalk == null)
        {
            Debug.LogError("No se encontró el script ArloWalk en el personaje.");
        }
    }

    private void Update()
    {
        // Verificamos si se presiona el botón de ataque
        if (Input.GetButtonDown("Fire1"))
        {
            // Activar la animación de ataque dependiendo de la última dirección del personaje
            ActivarAnimacionAtaque(arloWalk.LastDirection);

            // Activar el collider del golpe por un breve periodo
            StartCoroutine(ActivarGolpe());
        }
    }

    private void ActivarAnimacionAtaque(ArloWalk.CharStates ultimaDireccion)
    {
        // Activar el trigger de animación según la dirección del personaje
        switch (ultimaDireccion)
        {
            case ArloWalk.CharStates.walkNorth:
                Debug.Log("Activando animación de ataque hacia el norte.");
                animator.SetTrigger(attackNorthTrigger);
                break;
            case ArloWalk.CharStates.walkSouth:
                Debug.Log("Activando animación de ataque hacia el sur.");
                animator.SetTrigger(attackSouthTrigger);
                break;
            case ArloWalk.CharStates.walkEast:
                Debug.Log("Activando animación de ataque hacia el este.");
                animator.SetTrigger(attackEastTrigger);
                break;
            case ArloWalk.CharStates.walkWest:
                Debug.Log("Activando animación de ataque hacia el oeste.");
                animator.SetTrigger(attackWestTrigger);
                break;
            default:
                Debug.LogWarning("Dirección no válida para atacar.");
                break;
        }
    }

    // Coroutine para activar el collider del golpe temporalmente
    private IEnumerator ActivarGolpe()
    {
        // Activar el collider del golpe
        controladorDañoGolpe.gameObject.SetActive(true);

        // Esperar un breve momento (ajusta el tiempo según lo necesario)
        yield return new WaitForSeconds(0.2f);

        // Desactivar el collider del golpe
        controladorDañoGolpe.gameObject.SetActive(false);
    }
}
