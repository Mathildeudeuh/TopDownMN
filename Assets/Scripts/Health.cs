using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // On récupère les éléments publiques du script Player
        var damagePlayer = FindObjectOfType<Player>();

        // On excécute la fonction LoseHealthPlayer
        damagePlayer.LoseHealthPlayer();

        // On exécute la fonction Sword du script Player
        //collision.CompareTag = "Sword";
        damagePlayer.Sword();

    }
}
