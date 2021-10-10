using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
//using UnityEngine.UI;

public class Player : MonoBehaviour
{
    // Variable pour la force d'impulsion au d�placement
    [SerializeField] private float speed;

    [SerializeField] public int health;

    [SerializeField] public int healthToLose;

    //[SerializeField] private Text pv;

    // Variable pour les contr�les
    public Controls controls;

    // Varaible pour le d�placement
    public Vector2 direction;

    // Varaible pour attaquer
    public bool canAttack = false;

    // Variable pour le rigid body
    private Rigidbody2D body2D;

    // Variable pour les animation
    public Animator animator;


    void Start()
    {
        // boyd2D se r�f�re au component RigidBody2D
        body2D = GetComponent<Rigidbody2D>();

        // animator se r�f�re au component Animator
        animator = GetComponent<Animator>();
    }


    // Contr�les
    private void OnEnable()
    {
        var controls = new Controls();
        controls.Enable();
        controls.Main.Attack.performed += Attack_performed;
        controls.Main.Attack.canceled += Attack_canceled;
    }


    void Update()
    {
        // La valeur de la variable direction se r�f�re � l'axe X (horizontalement)
        direction.x = Input.GetAxisRaw("Horizontal");
        // On indique l'orientation horizontale de l'animation
        //animator.SetFloat("Horizontal", direction.x);

        // La valeur de la variable direction se r�f�re � l'axe Y (verticalement)
        direction.y = Input.GetAxisRaw("Vertical");
        // On indique l'orientation verticale de l'animation
        //animator.SetFloat("Vertical", direction.y);

        // L'animation de marche se lance
        animator.SetFloat("CanWalk", direction.sqrMagnitude);

        Sword();

    }



    private void Attack_performed(InputAction.CallbackContext obj)
    {
        // Le boul�en qui permet l'attaque passe en true
        canAttack = true;

        // Si la la valeur de la direction est �gale � z�ro
        if (direction == Vector2.zero)
        {
            // L'animation d'attaque se lance
            animator.SetBool("CanAttack", true);
        }
    }


    private void Attack_canceled(InputAction.CallbackContext obj)
    {
        // L'animation d'attaque ne se lance pas si on n'appuie pas sur le bouton
        animator.SetBool("CanAttack", false);
    }


    private void FixedUpdate()
    {
        // On r�cup�re la position du Rigid Body, on l'additionne � la valeur de la variable direction multipli�e par la vitesse et le temps �coul� depuis la derni�re frame
        body2D.MovePosition(body2D.position + direction * speed * Time.deltaTime);


        //var move = new Vector2(direction.x * speed, direction.y * speed);
    }

    private void LoseHealth2()
    {
        health = health - healthToLose;
        Debug.Log(health);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ennemy"))
        {
            LoseHealth2();
        }
    }

    public void Sword()
    {
        if (direction.x == 1 || direction.x == -1)
        {
            animator.SetFloat("Horizontal", direction.x);
        }

        else if (direction.y == 1 || direction.y == -1)
        {
            animator.SetFloat("Vertical", direction.y);
        }
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
        // direction prend la valeur de z�ro
        direction.x = 0;
        direction.y = 0;
        //direction = Vector2.zero;

    }*/
