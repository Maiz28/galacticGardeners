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
        walkNorth = 4
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
            // No hay movimiento, deshabilitar animador y cambiar al sprite idle correspondiente
            animator.enabled = false;
            SetIdleSprite();
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
