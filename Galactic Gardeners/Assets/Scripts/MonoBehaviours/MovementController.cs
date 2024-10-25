using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    public float movementSpeed = 3.0f;
    public Sprite idleEastSprite;   // Sprite para idle mirando al este
    public Sprite idleSouthSprite;  // Sprite para idle mirando al sur
    public Sprite idleWestSprite;   // Sprite para idle mirando al oeste
    public Sprite idleNorthSprite;  // Sprite para idle mirando al norte

    private Vector2 movement = new Vector2();
    private Rigidbody2D rb2D;
    private Animator animator;
    private SpriteRenderer spriteRenderer; // Referencia al componente SpriteRenderer
    private CharStates lastDirection; // Última dirección de movimiento

    private string animationState = "AnimationState";

    enum CharStates
    {
        walkEast = 1,
        walkSouth = 2,
        walkWest = 3,
        walkNorth = 4,
        attackEast = 5,
        attackSouth = 6,
        attackWest = 7,
        attackNorth = 8,
        attackBowEast = 9,
        attackBowSouth = 10,
        attackBowWest = 11,
        attackBowNorth = 12
    }

    // Propiedad pública para almacenar la última dirección
    public int LastDirection { get; private set; } = (int)CharStates.walkSouth;

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        UpdateState();
        CheckForAttacks();
    }

    private void UpdateState()
    {
        if (movement.x > 0)
        {
            animator.enabled = true; // Habilita la animación
            animator.SetInteger(animationState, (int)CharStates.walkEast);
            LastDirection = (int)CharStates.walkEast;
        }
        else if (movement.x < 0)
        {
            animator.enabled = true;
            animator.SetInteger(animationState, (int)CharStates.walkWest);
            LastDirection = (int)CharStates.walkWest;
        }
        else if (movement.y > 0)
        {
            animator.enabled = true;
            animator.SetInteger(animationState, (int)CharStates.walkNorth);
            LastDirection = (int)CharStates.walkNorth;
        }
        else if (movement.y < 0)
        {
            animator.enabled = true;
            animator.SetInteger(animationState, (int)CharStates.walkSouth);
            LastDirection = (int)CharStates.walkSouth;
        }
        else
        {
            // No hay movimiento, deshabilitar animador y cambiar al sprite idle correspondiente
            animator.enabled = false;
            SetIdleSprite();
        }
    }

    private void CheckForAttacks()
    {
        if (Input.GetKeyDown(KeyCode.Space)) // Ataque sin arma
        {
            Debug.Log("Ataque sin arma detectado");
            AttackWithoutWeapon();
        }
        else if (Input.GetKeyDown(KeyCode.J)) // Cambia esto por la tecla 'J' para el ataque con arco
        {
            Debug.Log("Ataque con arco detectado");
            AttackWithBow();
        }
    }

    private void AttackWithoutWeapon()
    {
        switch (LastDirection)
        {
            case (int)CharStates.walkEast:
                animator.SetInteger(animationState, (int)CharStates.attackEast);
                break;
            case (int)CharStates.walkSouth:
                animator.SetInteger(animationState, (int)CharStates.attackSouth);
                break;
            case (int)CharStates.walkWest:
                animator.SetInteger(animationState, (int)CharStates.attackWest);
                break;
            case (int)CharStates.walkNorth:
                animator.SetInteger(animationState, (int)CharStates.attackNorth);
                break;
        }
        animator.SetTrigger("AttackWithoutWeapon");
    }

    private void AttackWithBow()
    {
        switch (LastDirection)
        {
            case (int)CharStates.walkEast:
                animator.SetInteger(animationState, (int)CharStates.attackBowEast);
                break;
            case (int)CharStates.walkSouth:
                animator.SetInteger(animationState, (int)CharStates.attackBowSouth);
                break;
            case (int)CharStates.walkWest:
                animator.SetInteger(animationState, (int)CharStates.attackBowWest);
                break;
            case (int)CharStates.walkNorth:
                animator.SetInteger(animationState, (int)CharStates.attackBowNorth);
                break;
        }
        animator.SetTrigger("AttackWithBow");
    }

    private void FixedUpdate()
    {
        MoveCharacter();
    }

    private void MoveCharacter()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        movement.Normalize();
        rb2D.velocity = movement * movementSpeed;
    }

    // Método para cambiar el sprite a la imagen idle correspondiente
    private void SetIdleSprite()
    {
        switch (lastDirection)
        {
            case CharStates.walkEast:
                spriteRenderer.sprite = idleEastSprite;
                break;
            case CharStates.walkSouth:
                spriteRenderer.sprite = idleSouthSprite;
                break;
            case CharStates.walkWest:
                spriteRenderer.sprite = idleWestSprite;
                break;
            case CharStates.walkNorth:
                spriteRenderer.sprite = idleNorthSprite;
                break;
        }
    }
}
