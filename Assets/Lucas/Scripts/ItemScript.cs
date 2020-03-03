using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemScript : MonoBehaviour
{

    // montant de l'objet ( heal, shield, ammos ) 
    public float amount;
    public bool isCollectible;

    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            // Vérifie si l'objet peut être collecté
            if(isCollectible)
            {
                collision.GetComponent<PlayerManager>().PlayerHeal(amount);
                Destroy(this.gameObject);
            }
            else
            {
                // peut être utilisé pour les repoussements ( explosion, eclatage de face contre un mur à pleine vitesse etc )
                //Vector2 retour = collision.GetComponent<Rigidbody2D>().velocity;
                //collision.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                //collision.GetComponent<Rigidbody2D>().AddForce(-retour, ForceMode2D.Impulse);
            }
        }
    }
}
