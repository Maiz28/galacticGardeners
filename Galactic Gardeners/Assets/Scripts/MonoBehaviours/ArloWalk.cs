using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArloWalk : MonoBehaviour
{
    public float movementSpeed = 3.0f;

    private Vector2 movement = new Vector2();
    private Rigidbody2D rb2D;
    private Animator animator;
    private SpriteRenderer spriteRenderer; // Referencia al componente SpriteRenderer
    private CharStates lastDirection; // Última dirección de movimiento

    private string animationState = "AnimationState";

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
        idleEast = 5,    // Estado idle hacia el este
        idleSouth = 6,   // Estado idle hacia el sur
        idleWest = 7,    // Estado idle hacia el oeste
        idleNorth = 8    // Estado idle hacia el norte
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
        if (movement.x > 0)
        {
            animator.enabled = true; // Habilita la animación
            animator.SetInteger(animationState, (int)CharStates.walkEast);
            lastDirection = CharStates.walkEast;
        }
        else if (movement.x < 0)
        {
            animator.enabled = true;
            animator.SetInteger(animationState, (int)CharStates.walkWest);
            lastDirection = CharStates.walkWest;
        }
        else if (movement.y > 0)
        {
            animator.enabled = true;
            animator.SetInteger(animationState, (int)CharStates.walkNorth);
            lastDirection = CharStates.walkNorth;
        }
        else if (movement.y < 0)
        {
            animator.enabled = true;
            animator.SetInteger(animationState, (int)CharStates.walkSouth);
            lastDirection = CharStates.walkSouth;
        }
        else
        {
            // No hay movimiento, usar el último estado de dirección para el idle correspondiente
            switch (lastDirection)
            {
                case CharStates.walkEast:
                    animator.SetInteger(animationState, (int)CharStates.idleEast);
                    break;
                case CharStates.walkSouth:
                    animator.SetInteger(animationState, (int)CharStates.idleSouth);
                    break;
                case CharStates.walkWest:
                    animator.SetInteger(animationState, (int)CharStates.idleWest);
                    break;
                case CharStates.walkNorth:
                    animator.SetInteger(animationState, (int)CharStates.idleNorth);
                    break;
            }
        }
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
}
