using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    // Variable pour la force d'impulsion au déplacement
    [SerializeField] public float speed;

    // Variable pour la vitesse max
    [SerializeField] public float maxSpeed;

    // Variable pour les contrôles
    public Controls controls;

    // Varaible pour le déplacement
    private float directionX;
    private float directionY;
    //private float dirction;

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
        controls.Main.Move.performed += Move_performed;
        controls.Main.Move.canceled += Move_canceled;
        controls.Main.Attack.performed += Attack_performed;
      
    }

    private void Attack_performed(InputAction.CallbackContext obj)
    {
        // Le bouléen qui permet l'attaque passe en true
        canAttack = true;

        // L'animation d'attaque se lance
        animator.SetBool("CanAttack", true);
        Debug.Log("J'ATTAQUE MAIS CA SE VOIT PAS LA");

        /*if (direction != 0)
        animator.SetBool("CanWalk", true);                                                                       // inferieur ou egal ))test d'arret pendant l'attaque
        else
        animator.SetBool("CanWalk", false);*/

    }


    private void Move_performed(InputAction.CallbackContext obj)
    {
        // direction prend la valeur du vecteur de l'objet
        directionX = obj.ReadValue<float>();
        directionY = obj.ReadValue<float>();
        //diection = obj.ReadVlue<Vector2>();

        // L'animation de marche se lance
        animator.SetFloat("CanWalk", 0.3f);

        Debug.Log("J'AVANCE MAIS CA SE VOIT PAS NON PLUS");
    }

    private void Move_canceled(InputAction.CallbackContext obj)
    {
        // direction prend la valeur de zéro
        directionX = 0;
        directionY = 0;
        //direction = Vector2.zero;
    }

    private void FixedUpdate()
    {
       var move = new Vector2(directionX * speed, directionY * speed);
       // var moveY = Vector2.up * (direction*  speed);
       // var moveX = Mathf.Abs(body2D.velocity.x * speed);

        if (body2D.velocity.sqrMagnitude <= maxSpeed)
        {
            body2D.AddForce(move);
        }

        // if (body2D < maxSpeed)
        //{
        //    body2D.AddForce(direction);
        //}
        //animator.SetFloat("Walk", jsp);*/

    }

    void Update()
    {
        //directionX = Input.GetAxisRaw("Horizontal");
        //directionY = Input.GetAxisRaw("Vertical");
    }
}
