using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    // Variable pour la force d'impulsion au déplacement
    [SerializeField] public float speed;

    // Variable pour les contrôles
    public Controls controls;

    // Varaible pour le déplacement
    private Vector2 direction;

    // Varaible pour attaquer
    public bool canAttack = false;

    // Variable pour le rigid body
    private Rigidbody2D body2D;

    // Variable pour les sprites
    private SpriteRenderer spriteRenderer;

    // Variable pour les animation
    private Animator animator;
    

    void Start()
    {
        // boyd2D se réfère au component RigidBody2D
        body2D = GetComponent<Rigidbody2D>();

        // animator se réfère au component Animator
        animator = GetComponent<Animator>();

        // sripteRenderer se réfère au component SpriteRenderer
        spriteRenderer = GetComponent<SpriteRenderer>();
        
    }

    // Contrôles
    private void OnEnable()
    {
        var controls = new Controls();
        controls.Enable();
        //controls.Main.Move.performed += Move_performed;
        //controls.Main.Move.canceled += Move_canceled;
        controls.Main.Attack.performed += Attack_performed;
        controls.Main.Attack.canceled += Attack_canceled;
    }


    private void Attack_performed(InputAction.CallbackContext obj)
    {
        // Le bouléen qui permet l'attaque passe en true
        canAttack = true;

        // L'animation d'attaque se lance
        Debug.Log("J'ATTAQUE MAIS CA SE VOIT PAS LA");

       if (direction == Vector2.zero)
        {
        animator.SetBool("CanAttack", true);
        }
    }

    private void Attack_canceled(InputAction.CallbackContext obj)
    {
        animator.SetBool("CanAttack", false);
    }

    private void FixedUpdate()
    {
        body2D.MovePosition(body2D.position + direction * speed * Time.deltaTime);
        //var move = new Vector2(direction.x * speed, direction.y * speed);
    }


        void Update()
    {
        direction.x = Input.GetAxisRaw("Horizontal");
        animator.SetFloat("Horizontal", direction.x);

        direction.y = Input.GetAxisRaw("Vertical");
        animator.SetFloat("Vertical", direction.y);

        animator.SetFloat("CanWalk", direction.sqrMagnitude);
    }
}

/*
    private void Move_performed(InputAction.CallbackContext obj)
    {
        // direction prend la valeur du vecteur de l'objet
        //directionX = obj.ReadValue<float>();
        //directionY = obj.ReadValue<float>();
        //diection = obj.ReadVlue<Vector2>();

        // L'animation de marche se lance
        animator.SetFloat("CanWalk", 0.3f);

        Debug.Log("J'AVANCE MAIS CA SE VOIT PAS NON PLUS");
    }

    private void Move_canceled(InputAction.CallbackContext obj)
    {
        // direction prend la valeur de zéro
        direction.x = 0;
        direction.y = 0;
        //direction = Vector2.zero;

    }*/
