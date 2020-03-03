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
    public float turretCritChance;
    public float turretCritDamage;




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
            bulletInstance.GetComponent<bulletScript>().damage = turretDamage;
            bulletInstance.GetComponent<bulletScript>().critChance = turretCritChance;
            bulletInstance.GetComponent<bulletScript>().bulletSpeed = turretBulletSpeed;
            bulletInstance.GetComponent<bulletScript>().critDamage = turretCritDamage;
            bulletInstance.GetComponent<bulletScript>().isInit = true;
            yield return new WaitForSeconds(attackRate);
        }
        
    }
}
