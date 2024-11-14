using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flecha : MonoBehaviour
{
    [SerializeField]
    private float velocidad;

    [SerializeField]
    private float daño;

    private Vector2 direccion;

    private void Start()
    {
        // Busca el componente ArloWalk en la escena y obtiene la última dirección
        ArloWalk arloWalk = FindObjectOfType<ArloWalk>();

        if (arloWalk != null)
        {
            // Establece la dirección y orientación de la flecha basada en la última dirección de Arlo
            EstablecerDireccionYRotacion(arloWalk.LastDirection);
        }
        else
        {
            Debug.LogWarning("No se encontró el componente ArloWalk en la escena.");
        }
    }

    private void EstablecerDireccionYRotacion(ArloWalk.CharStates ultimaDireccion)
    {
        switch (ultimaDireccion)
        {
            case ArloWalk.CharStates.walkNorth:
                direccion = Vector2.up;
                transform.rotation = Quaternion.identity; // Sin rotación
                break;

            case ArloWalk.CharStates.walkSouth:
                direccion = Vector2.down;
                transform.rotation = Quaternion.identity; // Sin rotación
                GetComponent<SpriteRenderer>().flipY = true; // Flip en Y
                break;

            case ArloWalk.CharStates.walkEast:
                direccion = Vector2.right;
                transform.rotation = Quaternion.Euler(0, 0, -90); // Rotación de -90 grados en Z
                break;

            case ArloWalk.CharStates.walkWest:
                direccion = Vector2.left;
                transform.rotation = Quaternion.Euler(0, 0, 90); // Rotación de 90 grados en Z
                break;

            default:
                Debug.LogWarning("La dirección de la flecha no está definida.");
                break;
        }
    }

    private void Update()
    {
        // Mueve la flecha en la dirección establecida
        transform.Translate(direccion * velocidad * Time.deltaTime, Space.World);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            Debug.Log("Flecha colisionó con el enemigo");
            other.GetComponent<Enemy>().TomarDaño(daño);
            Destroy(gameObject);
        }
    }
}
