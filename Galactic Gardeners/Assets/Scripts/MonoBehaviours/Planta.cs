using UnityEngine;

public class Planta : MonoBehaviour
{
    public Sprite[] fases; // 0: pequeña, 1: mediana, 2: grande, 3: muerta
    public float tiempoCrecimiento = 8f;
    public float tiempoParaMorir = 5f;
    public LayerMask capaCuarzo; // Asignar la layer Cuarzo en el inspector

    private SpriteRenderer spriteRenderer;
    private int faseActual = 0;
    private float timerCrecimiento;
    private float timerCuarzo;
    private bool cuarzoPresente = false;
    private bool esMuerta = false;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        CambiarSprite();
        timerCrecimiento = tiempoCrecimiento;
    }

    private void Update()
    {
        if (esMuerta) return;

        if (cuarzoPresente)
        {
            // Incrementar el temporizador del cuarzo
            timerCuarzo += Time.deltaTime;

            // Verificar si el cuarzo ha estado presente el tiempo suficiente para matar la planta
            if (timerCuarzo >= tiempoParaMorir)
            {
                MatarPlanta();
            }
        }
        else
        {
            // Reducir el temporizador de crecimiento solo si no hay cuarzo presente
            timerCrecimiento -= Time.deltaTime;

            // Si el temporizador llega a 0, avanzar a la siguiente fase (pero no más allá de fase 3)
            if (timerCrecimiento <= 0 && faseActual < 2) // Fase 2 es grande
            {
                Crecer();
                timerCrecimiento = tiempoCrecimiento; // Reiniciar el temporizador de crecimiento
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (EsCuarzo(collision.gameObject))
        {
            cuarzoPresente = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (EsCuarzo(collision.gameObject))
        {
            cuarzoPresente = false;
            timerCuarzo = 0; // Reiniciar el temporizador del cuarzo
        }
    }

    private void Crecer()
    {
        faseActual++;
        CambiarSprite();

        // Detener la aparición de cuarzos si la planta alcanza su fase grande
        if (faseActual == 2)
        {
            StartCoroutine(DetenerCuarzos());
        }
    }

    private void CambiarSprite()
    {
        spriteRenderer.sprite = fases[faseActual];
    }

    private void MatarPlanta()
    {
        esMuerta = true;
        spriteRenderer.sprite = fases[3]; // Sprite de planta muerta
    }

    private System.Collections.IEnumerator DetenerCuarzos()
    {
        yield return new WaitForSeconds(3f);
        ControladorCuarzosPlantas.Instance.DetenerAparicionCuarzos();
    }

    private bool EsCuarzo(GameObject objeto)
    {
        // Verificar si el objeto pertenece a la layer Cuarzo
        return (capaCuarzo.value & (1 << objeto.layer)) != 0;
    }
}
