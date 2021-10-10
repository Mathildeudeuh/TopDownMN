using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobsMgr : MonoBehaviour
{
  /*  // Tableau pour les points de spawn
    public GameObject[] spawnPoints;

    // Points de d�part des ennemis
    public GameObject spawnPoint;

    // Tableau pour les ennemis
    public GameObject[] ennemies;*/

    public GamoObject ennemie;                  // Ennemis

    public GameObject[] ennemies;               //tableau dans inspector

    private List<GameObject> spawnPoints;       //liste spawnPoints

    public float mobSpeed;                     // speed dans inspector

    public float speed;                        //speed dans inspector
    
    public GameObject Target;                  // reference to player 

    private Transform target;                  //nommer target    



    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();           //on va aller chercher grace au tag(ici Player)sur le quel on reprend sa position(x , y ,z) dans le Trasform situ� dans l'Inspector
        spawnPoints = new List<GameObject>();                                                    //ajouter dans la liste les mobs

        
        for (int i = 0; i < ennemies.Length; i++)             //i= 0 , i est plus petit que enemies; on ajoute i de 1 a chaque fois
        {
            GameObject g = Instantiate(ennemies[i]);          //instantiate "ennemies" 
            g.transform.position = GetRandSpawnPosition();    //
           
        }                                                                                                       

    }

    private Vector2 GetRandSpawnPosition()                 //On fais spawn dans différentes positions grâce a xp xs yp ys
    {
        float xp = transform.position.x;                    //xposition
        float xs = transform.lossyScale.x;                  //xscale
        float yp = transform.position.y;                    //yposition
        float ys = transform.lossyScale.y;                  //yscale

        return new Vector3(Random.Range(xp - xs, xp + xs), Random.Range(yp - ys, yp + ys), 0);        //Random.Range avec xp xs yp ys
    }

    /*private void FirstIteration()
    {
        foreach (var ennemie in ennemies)
        {
            Instantiate(ennemie);
        }

        foreach (var spawnPoint in spawnPoints)
        {
            Instantiate(spawnPoint);
        }
    }*/

    Vector3 Spawn()
    {
        int spawnIndex = Random.Range(0, 2);
        Instantiate(ennemies[spawnIndex]);                          //Instantiate les ennemis du tableau spawnIndex
        return transform.TransformPoint(Random.insideUnitCircle);   //mettre un random dans le cercle (insideUnitCircle)
    }


    void Update()
    {

        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime); //on change la position en 2D en faisant avancer le mob en lui faisant garder une speed constante ainsi que la position du target
        Transform targetPosition = target.GetComponent<Transform>();
        for (int i = 0; i < spawnPoints.Count; i++)
        {
            spawnPoints[i].transform.position = Vector2.MoveTowards(spawnPoints[i].transform.position, targetPosition.position, mobSpeed * Time.deltaTime);
        }

    }

   /* void SpawnObjectAtRandom()
    {
        Vector3 randomPos = Random.insideUnitCircle * Radius;              ?                  //
    }*/



}

