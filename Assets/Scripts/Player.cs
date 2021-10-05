using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Variable pour se déplacer
    [SerializeField] public float speed;

    // Variable pour la vitsse max
    [SerializeField] public float maxSpeed;

    // Variable pour l'attaque
    [SerializeField] public bool attack;

    // Variable pour les contrôles
    public Controls controls;


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
        throw new System.NotImplementedException();
    }

    private void Move_canceled(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        throw new System.NotImplementedException();
    }

    private void Move_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        throw new System.NotImplementedException();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
