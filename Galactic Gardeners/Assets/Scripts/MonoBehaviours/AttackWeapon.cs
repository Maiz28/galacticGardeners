//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class AttackWeapon : MonoBehaviour
//{
//    private Animator animator;
//    private ArloWalk arloWalk; // Referencia al script de movimiento del personaje
//    //private LanzarFlecha lanzarFlecha; // Referencia al script para lanzar la flecha
//    private string animationState = "AnimationState";
//    private bool isAttacking = false;

//    void Start()
//    {
//        animator = GetComponent<Animator>();
//        arloWalk = GetComponent<ArloWalk>();
//        //lanzarFlecha = GetComponent<LanzarFlecha>();
//    }

//    void Update()
//    {
//        if (Input.GetKeyDown(KeyCode.J) && !isAttacking)
//        {
//            isAttacking = true;
//            Attack();
//        }
//    }

//    private void Attack()
//    {
//        // Establece la animación de ataque según la dirección
//        switch (arloWalk.LastDirection)
//        {
//            case ArloWalk.CharStates.walkEast:
//                animator.SetInteger(animationState, 9); // attackWeaponEast
//                //lanzarFlecha.SetControladorDisparo("ControladorDisparoEste");
//                break;
//            case ArloWalk.CharStates.walkSouth:
//                animator.SetInteger(animationState, 10); // attackWeaponSouth
//                //lanzarFlecha.SetControladorDisparo("ControladorDisparoSur");
//                break;
//            case ArloWalk.CharStates.walkWest:
//                animator.SetInteger(animationState, 11); // attackWeaponWest
//                //lanzarFlecha.SetControladorDisparo("ControladorDisparoOeste");
//                break;
//            case ArloWalk.CharStates.walkNorth:
//                animator.SetInteger(animationState, 12); // attackWeaponNorth
//                //lanzarFlecha.SetControladorDisparo("ControladorDisparoNorte");
//                break;
//        }

//        animator.SetTrigger("AttackWithBow"); // Activa el trigger de la animación de ataque

//        // Llama a la función para lanzar la flecha
//        //lanzarFlecha.Disparar();
//        isAttacking = false;
//    }
//}
