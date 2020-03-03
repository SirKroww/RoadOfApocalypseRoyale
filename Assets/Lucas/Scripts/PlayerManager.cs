using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    
    public float currentLife;
    public float maxHealth;
    public float currentShield;
    public float maxShield;
    

    void Awake()
    {
        currentLife = maxHealth;
        currentShield = maxShield;
    }


    void PlayerDeath()
    {
        print("Game Over");
        Destroy(gameObject);
        // gérer la mort du joueur
    }

    public void PlayerHit(float damage)
    {
        // Passe d'abord les dégâts sur le shield puis la vie si aucun shield
        if (currentShield > 0)
        {
            currentShield -= damage;

            // si les dégâts infligés sont supérieur à la vie actuel du shield alors le reste de dégâts vont sur la vie
            if (currentShield < 0)
            {
                currentLife -= Mathf.Abs(currentShield);
                currentShield = 0;
            }
        }
        else
        {
            currentLife -= damage;
            if(currentLife < 0)
            {
                currentLife = 0;
                PlayerDeath();
            }
        }
        

        print(string.Format("current Life: {0} \n current Shield : {1}", currentLife, currentShield));
    }


    public void PlayerHeal(float healAmount)
    {
        currentLife += healAmount;
        // Evite le surplus de vie
        if (currentLife > maxHealth)
        {
            currentLife = maxHealth;
        }
    }

    public void PlayerShield(float shieldAmount)
    {
        currentShield += shieldAmount;
        // Evite le surplus de shield
        if (currentShield > maxShield)
        {
            currentShield = maxShield;
        }
    }

}
