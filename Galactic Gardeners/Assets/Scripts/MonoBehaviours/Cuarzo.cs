using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cuarzo : MonoBehaviour
{
    // Referencia al prefab del cuarzo
    public GameObject cuarzoPrefab;

    // Lista de posiciones donde el cuarzo puede aparecer
    private Vector2[] posiciones = new Vector2[]
    {
        new Vector2(-0.641f, 0.341f),
        new Vector2(-0.072f, 0.341f),
        new Vector2(-0.664f, -0.38f),
        new Vector2(-0.074f, -0.38f),
        new Vector2(-0.643f, -0.979f),
        new Vector2(-0.078f, -0.979f)
    };

    // Tiempo entre apariciones
    public float tiempoAparicion = 5f;

    private void Start()
    {
        // Iniciar la corutina para aparecer el cuarzo cada cierto tiempo
        StartCoroutine(AparecerCuarzo());
    }

    private IEnumerator AparecerCuarzo()
    {
        while (true)
        {
            // Esperar el tiempo definido
            yield return new WaitForSeconds(tiempoAparicion);

            // Elegir una posición aleatoria de la lista
            Vector2 posicionAleatoria = posiciones[Random.Range(0, posiciones.Length)];

            // Crear una instancia del cuarzo en la posición aleatoria
            Instantiate(cuarzoPrefab, new Vector3(posicionAleatoria.x, posicionAleatoria.y, 0), Quaternion.identity);
        }
    }
}
