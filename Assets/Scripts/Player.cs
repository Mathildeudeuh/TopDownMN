using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Variable pour la force d'impulsion au déplacement
    [SerializeField] public float speed;

    // Variable pour la vitesse max
    [SerializeField] public float maxSpeed;

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
       // rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnEnable()
    {
        var controls = new Controls();
        controls.Enable();
        controls.Main.Move.performed += Move_performed;
        controls.Main.Move.canceled += Move_canceled;
        controls.Main.Attack.performed += Attack_performed;
      
    }

    private void Attack_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        canAttack = true;
        animator.SetBool("Attack", true);

      //  if (direction != 0)
      //      animator.SetBool("CanWalk", true);                                                                       // test d'arret pendant l'attaque
      //  else
      //     animator.SetBool("CanWalk", false);

    }

    private void Move_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        direction = obj.ReadValue<Vector2>();

       //animator.SetFloat("Walk", CanWalk);

    }

    private void Move_canceled(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        direction = Vector2.zero;
    }

    private void FixedUpdate()
    {
        /*var moveX = Vector2.right * (direction * speed);
        var moveY = Vector2.up * (direction*  speed);

        if (moveX < maxSpeed)
        {
            body2D.AddForce(direction);
        }

        if (moveY < maxSpeed)
        {
            body2D.AddForce(direction);
        }
        //animator.SetFloat("Walk", jsp);*/

    }

    void Update()
    {
        
    }
}
