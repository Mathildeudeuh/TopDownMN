using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mob : MonoBehaviour
{
    // Tableau pour les points de spawn
    public GameObject[] spawnPoints;

    // Points de départ des ennemis
    public GameObject spawnPoint;
    
    // Tableau pour les ennemis
    public GameObject[] ennemies;
    
    // Ennemis
    public GamoObject ennemie;


    public float speed;                                                                                       //s'occupe de la speed
    private Transform target;                                                                                 //On va aller chercher la position du player(ici target) dans "Transform" situé dans l'Inspector
    //private GameObject spawnZone;
    //public int randomspawn;

    // public float spawnTime = 1.5f; 
    //[SerializeField] public GameObject spawnpoint;
    //







    public GameObject mobPrefab;
    public GameObject[] mobPrefabs;
    public float Radius = 1;








    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();                         //on va aller chercher grace au tag(ici Player)sur le quel on reprend sa position(x , y ,z) dans le Trasform situé dans l'Inspector
                                                                                                               //  spawnZone = GameObject.FindGameObjectWithTag("SpawnZone");

        /*Instantiate(ennemies[0]);
        Instantiate(ennemies[1]);
        Instantiate(ennemies[2]);

        Instantiate(spawnPoints[0]);
        Instantiate(spawnPoints[1]);
        Instantiate(spawnPoints[2]);
        Instantiate(spawnPoints[3]);*/


    }


    private void FirstIteration()
    {
        foreach(var ennemie in ennemies)
        {
            Instantiate(ennemie);
        }

        foreach(var spawnPoint in spawnPoints)
        {
            Instantiate(spawnPoint);
        }
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

    void SpawnObjectAtRandom()
    {
        Vector3 randomPos = Random.insideUnitCircle * Radius;                                //
    }




    void Awake()
    {
        Invoke("SpawnNext", 2f);
    }
  /*  void SpawnNext()
    {
        GameObject newBox = Instantiate(spawnpoint);                                         //
        newBox.transform.position = new Vector3();                                            //
    }*/


    // public Cell()
    //{
    //     var coinFlip = Random.Range(0, 2);
    //    IsTaken = coinFlip == 1;
    // }
}
