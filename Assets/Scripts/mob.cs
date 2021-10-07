using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mob : MonoBehaviour
{
    public float speed;                                                                                       //s'occupe de la speed
    private Transform target;                                                                                 //On va aller chercher la position du player(ici target) dans "Transform" situé dans l'Inspector
    private GameObject spawnZone;
    public int randomspawn;


    public GamoObject ennemie;
    public GameObject[] ennemies;
   // public float spawnTime = 1.5f; 

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();                         //on va aller chercher grace au tag(ici Player)sur le quel on reprend sa position(x , y ,z) dans le Trasform situé dans l'Inspector
      //  spawnZone = GameObject.FindGameObjectWithTag("SpawnZone");

        Instantiate(ennemies[0]);
        Instantiate(ennemies[1]);
        Instantiate(ennemies[2]);

    }

    Vector3 Spawn()
    {
        int spawnIndex = Random.Range (0 ,2 );                                   
        Instantiate(ennemies[spawnIndex]);
        //obj.tag.Equals("pool");
        return transform.TransformPoint(Random.insideUnitCircle); 
    }

    
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime); //on change la position en 2D en faisant avancer le mob en lui faisant garder une speed constante ainsi que la position du target
        var evil = Random.Range(0, 2); 
        
    }

    
   

   // public Cell()
   //{
    //     var coinFlip = Random.Range(0, 2);
     //    IsTaken = coinFlip == 1;
   // }
}
