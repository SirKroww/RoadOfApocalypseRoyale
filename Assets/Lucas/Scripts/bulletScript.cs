using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletScript : MonoBehaviour
{

    public float despawnTime = 3;
    public float damage;
    public float bulletSpeed;
    public bool isInit = false;
    public GameObject Shooter;


    Rigidbody2D rb;

    public void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();

        rb.AddForce(transform.up * bulletSpeed , ForceMode2D.Impulse);

        
    }


    void FixedUpdate()
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && Shooter != collision.gameObject)
        {
            collision.gameObject.GetComponent<PlayerManager>().PlayerHit(damage);
            DestroyBullet();
        }
        else if (collision.gameObject.CompareTag("Wall"))
        {
            DestroyBullet();

        }
    }




    private void DestroyBullet()
    {
        Destroy(this.gameObject);

    }


}
