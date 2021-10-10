using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //var damageMobs = FindObjetcOfType<Mob>();

        //damageMobs.LoseHealth1();

        var damagePlayer = FindObjectOfType<Player>();
        // VOIR AVEC LES TAGS

        damagePlayer.LoseHealth2();
    }
}
