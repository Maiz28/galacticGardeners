using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flecha : MonoBehaviour
{
    [SerializeField]
    private float velocidad;

    [SerializeField]
    private float da�o;

    private Vector2 direccion;

    private void Start()
    {
        // Busca el componente ArloWalk en la escena y obtiene la �ltima direcci�n
        ArloWalk arloWalk = FindObjectOfType<ArloWalk>();

        if (arloWalk != null)
        {
            // Establece la direcci�n y orientaci�n de la flecha basada en la �ltima direcci�n de Arlo
            EstablecerDireccionYRotacion(arloWalk.LastDirection);
        }
        else
        {
            Debug.LogWarning("No se encontr� el componente ArloWalk en la escena.");
        }
    }

    private void EstablecerDireccionYRotacion(ArloWalk.CharStates ultimaDireccion)
    {
        switch (ultimaDireccion)
        {
            case ArloWalk.CharStates.walkNorth:
                direccion = Vector2.up;
                transform.rotation = Quaternion.identity; // Sin rotaci�n
                break;

            case ArloWalk.CharStates.walkSouth:
                direccion = Vector2.down;
                transform.rotation = Quaternion.identity; // Sin rotaci�n
                GetComponent<SpriteRenderer>().flipY = true; // Flip en Y
                break;

            case ArloWalk.CharStates.walkEast:
                direccion = Vector2.right;
                transform.rotation = Quaternion.Euler(0, 0, -90); // Rotaci�n de -90 grados en Z
                break;

            case ArloWalk.CharStates.walkWest:
                direccion = Vector2.left;
                transform.rotation = Quaternion.Euler(0, 0, 90); // Rotaci�n de 90 grados en Z
                break;

            default:
                Debug.LogWarning("La direcci�n de la flecha no est� definida.");
                break;
        }
    }

    private void Update()
    {
        // Mueve la flecha en la direcci�n establecida
        transform.Translate(direccion * velocidad * Time.deltaTime, Space.World);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            Debug.Log("Flecha colision� con el enemigo");
            other.GetComponent<Enemy>().TomarDa�o(da�o);
            Destroy(gameObject);
        }
    }
}
