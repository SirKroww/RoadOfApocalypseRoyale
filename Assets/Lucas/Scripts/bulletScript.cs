using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletScript : MonoBehaviour
{

    float despawnTime = 3;
    public float damage;
    public bool isCritical;
    [Range(0,1)]
    public float critChance;
    public float critDamage;
    public float bulletSpeed;
    public bool isInit = false;


    Rigidbody2D rb;

    public void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();

        rb.AddForce(transform.right * bulletSpeed , ForceMode2D.Impulse);

        isCritical = Random.value < critChance ? true : false;
        if(isCritical)
        {
            damage *= critDamage;
        }
    }


    void FixedUpdate()
    {
        if(isInit)
        {
            if (despawnTime > 0)
            {
                despawnTime -= Time.fixedDeltaTime;
            }
            else
            {
                DestroyBullet();
            }
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerManager>().PlayerHit(damage);
            DestroyBullet();
        }
        else if (collision.gameObject.CompareTag("Wall"))
        {
            DestroyBullet();

        }
    }

    private void OnTrigger(Collision2D collision)
    {
        
    }


    private void DestroyBullet()
    {
        Destroy(this.gameObject);

    }


}
