using UnityEngine;

public class MovementController : MonoBehaviour
{
    public float movementSpeed = 3.0f; // Velocidad de movimiento
    public Transform player; // Referencia al jugador

    private Vector2 movement = new Vector2();
    private Rigidbody2D rb2D;
    private Animator animator;
    private SpriteRenderer spriteRenderer; // Referencia al componente SpriteRenderer
    private CharStates lastDirection; // Última dirección de movimiento

    private string animationState = "AnimationState"; // Parámetro para las animaciones

    public CharStates LastDirection
    {
        get { return lastDirection; }
    }

    public enum CharStates
    {
        walkEast = 1,
        walkSouth = 2,
        walkWest = 3,
        walkNorth = 4,
        idle = 5 // Estado Idle
    }

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        lastDirection = CharStates.walkSouth; // Dirección inicial (sur)
    }

    void Update()
    {
        UpdateState();
    }

    private void UpdateState()
    {
        // Actualizamos el movimiento para asegurarnos de que la animación cambie según la dirección del movimiento
        if (movement.x > 0 && Mathf.Abs(movement.x) > Mathf.Abs(movement.y))
        {
            animator.enabled = true; // Habilita la animación
            animator.SetInteger(animationState, (int)CharStates.walkEast);
            lastDirection = CharStates.walkEast;
        }
        else if (movement.x < 0 && Mathf.Abs(movement.x) > Mathf.Abs(movement.y))
        {
            animator.enabled = true;
            animator.SetInteger(animationState, (int)CharStates.walkWest);
            lastDirection = CharStates.walkWest;
        }
        else if (movement.y > 0 && Mathf.Abs(movement.y) > Mathf.Abs(movement.x))
        {
            animator.enabled = true;
            animator.SetInteger(animationState, (int)CharStates.walkNorth);
            lastDirection = CharStates.walkNorth;
        }
        else if (movement.y < 0 && Mathf.Abs(movement.y) > Mathf.Abs(movement.x))
        {
            animator.enabled = true;
            animator.SetInteger(animationState, (int)CharStates.walkSouth);
            lastDirection = CharStates.walkSouth;
        }
        else
        {
            // Aquí va Idle
            animator.SetInteger(animationState, (int)CharStates.idle);
        }
    }

    private void FixedUpdate()
    {
        // Llamamos a la función para hacer que el enemigo persiga al jugador
        PursuePlayer();
    }

    private void PursuePlayer()
    {
        if (player != null)
        {
            // Calculamos la dirección hacia el jugador
            Vector2 direction = (player.position - transform.position).normalized;
            movement = direction; // Asignamos la dirección al movimiento

            // Movemos al enemigo
            rb2D.velocity = movement * movementSpeed;
        }
    }
}
