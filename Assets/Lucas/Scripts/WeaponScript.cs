using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour
{

    public enum WeaponTypes { Heavy, Light, Shotgun}
    public WeaponTypes weaponType;
    public GameObject bulletPrefab;

    public float attackRate;


}
