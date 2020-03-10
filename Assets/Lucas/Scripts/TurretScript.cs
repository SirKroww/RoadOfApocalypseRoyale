using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretScript : MonoBehaviour
{
    public float attackRate;
    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    public bool Firing;
    GameObject bulletInstance;

    public float turretDamage;
    public float turretBulletSpeed;




    // Start is called before the first frame update
    void Start()
    {
        //DEBUG
        canFire(true);

        
    }

    void canFire(bool state)
    {
        Firing = state ? true : false;
        if(Firing)
        {
            StartCoroutine(TurretFiring());
        }
        else
        {
            StopCoroutine(TurretFiring());
        }
    }


    IEnumerator TurretFiring()
    {
        while(Firing)
        {
            bulletInstance = Instantiate(bulletPrefab, bulletSpawn.transform.position, bulletSpawn.transform.rotation);
            yield return new WaitForSeconds(attackRate);
        }
        
    }
}
