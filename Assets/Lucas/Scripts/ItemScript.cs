using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemScript : MonoBehaviour
{
    public enum ItemTypes { Heal, Shield, Weapon}
    public ItemTypes itemType;
    
    // montant de l'objet ( heal and shield) 
    public float amount;
    
    public bool isCollectible;
    public GameObject weaponItem;

    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            // Vérifie si l'objet peut être collecté
            if(isCollectible)
            {
                switch(itemType)
                {
                    case ItemTypes.Heal:
                        collision.GetComponent<PlayerManager>().PlayerHeal(amount);
                        break;
                    case ItemTypes.Shield:
                        collision.GetComponent<PlayerManager>().PlayerShield(amount);
                        break;
                    case ItemTypes.Weapon:
                        //collision.GetComponent<PlayerManager>().PlayerHeal(amount);
                        break;



                }
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
