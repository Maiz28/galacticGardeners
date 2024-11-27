using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public Transform pointA; // Primer punto de patrulla (oeste).
    public Transform pointB; // Segundo punto de patrulla (este).
    public float speed = 2f; // Velocidad de movimiento del enemigo.
    private Vector3 targetPosition; // Posici�n actual objetivo.
    private bool movingToPointB = true; // Direcci�n inicial (hacia el punto B).

    void Start()
    {
        // Comenzar movi�ndose hacia el primer punto objetivo.
        targetPosition = pointB.position;
    }

    void Update()
    {
        // Mover al enemigo hacia la posici�n objetivo.
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        // Verificar si lleg� al objetivo.
        if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
        {
            // Cambiar direcci�n y objetivo.
            movingToPointB = !movingToPointB;
            targetPosition = movingToPointB ? pointB.position : pointA.position;

            // Voltear el sprite del enemigo.
            Flip();
        }
    }

    void Flip()
    {
        // Invertir la escala en X para voltear el sprite.
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}
