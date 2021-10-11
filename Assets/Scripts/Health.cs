using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // On r�cup�re les �l�ments publiques du script Player
        var damagePlayer = FindObjectOfType<Player>();

        // On exc�cute la fonction LoseHealthPlayer
        damagePlayer.LoseHealthPlayer();

        // On ex�cute la fonction Sword du script Player
        //collision.CompareTag = "Sword";
        damagePlayer.Sword();

    }
}
