using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mob : MonoBehaviour
{
    public float speed;                                                           //s'occupe de la speed
    private Transform target;                                                          //transforme la position du mob
    

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();             //on declare aue la target est avec le tag Player sur le quel on reprend sa position
    }

    
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime); //on change la position en 2D en faisant avancer le mob en lui faisant garder une speed constante
                                                                                                               //moveDirection?

    }
}
