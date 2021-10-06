using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mob : MonoBehaviour
{
    public float speed;                                                                                       //s'occupe de la speed
    private Transform target;                                                                                 //On va aller chercher la position du player(ici target) dans "Transform" situé dans l'Inspector
    

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();                         //on va aller chercher grace au tag(ici Player)sur le quel on reprend sa position(x , y ,z) dans le Trasform situé dans l'Inspector
    }

    
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime); //on change la position en 2D en faisant avancer le mob en lui faisant garder une speed constante ainsi que la position du target
                                                                                                               //moveDirection?

    }
}
