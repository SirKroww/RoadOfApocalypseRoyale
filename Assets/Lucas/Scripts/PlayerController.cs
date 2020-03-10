using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{


    public float acceleration;
    public float steering;
    private Rigidbody2D rb;
    private float xInput;
    private float yInput;
    private float direction;
    private float directionRightAngle;
    public Transform playerCam;
    public float maxSpeed;

    bool canFire = true;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void Update()
    {
        GetInput();
    }

    void FixedUpdate()
    {
        RotateCar();
        Move();
        CamFollow();
        if(Input.GetButton("Fire1"))
        {
            PlayerShoot();
        }

    }

    public void CamFollow()
    {
        Vector3 newPos = new Vector3(transform.position.x, transform.position.y, transform.position.z - 50);
        // Pour le lock de la camera si besoin
        //Vector3 newRot = new Vector3(playerCam.transform.eulerAngles.x, playerCam.transform.eulerAngles.y, transform.eulerAngles.z);
        //playerCam.transform.eulerAngles = newRot;
        playerCam.transform.position = newPos;
        
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        rb.angularVelocity = 0;

    }

    IEnumerator PlayerFiring(WeaponScript currentWeapon)
    {
        GameObject bulletInstance = Instantiate(currentWeapon.GetComponent<WeaponScript>().bulletPrefab, currentWeapon.transform.position, currentWeapon.transform.rotation);
        bulletInstance.GetComponent<bulletScript>().Shooter = this.gameObject;
        canFire = false;
        yield return new WaitForSeconds(currentWeapon.attackRate);
        canFire = true;

    }

    public void PlayerShoot()
    {
        WeaponScript currentWeapon = this.GetComponent<PlayerManager>().currentWeapon;
        if (currentWeapon && canFire)
        {
            StartCoroutine(PlayerFiring(currentWeapon));
        }



    }



    public void GetInput()
    {
        xInput = -Input.GetAxis("Horizontal");
        yInput = Input.GetAxis("Vertical");
        direction = Vector2.Dot(rb.velocity, rb.GetRelativeVector(Vector2.up));

    }

    private void Move()
    {
        Vector2 speed = transform.up * (yInput * acceleration);
        //rb.AddForce(speed);
        rb.velocity = speed;
        
    }

    private void RotateCar()
    {
        if (direction >= 0.0f)
        {
            rb.rotation += xInput * steering * (rb.velocity.magnitude / 3.5f);
        }
        else
        {
            rb.rotation -= xInput * steering * (rb.velocity.magnitude / 3.5f);
        }

        Vector2 forward = new Vector2(0.0f, 0.5f);
        if (rb.angularVelocity > 0)
        {
            directionRightAngle = -90;
        }
        else
        {
            directionRightAngle = 90;
        }

        Vector2 rightAngleFromForward = Quaternion.AngleAxis(directionRightAngle, Vector3.forward) * forward;

        float driftForce = Vector2.Dot(rb.velocity, rb.GetRelativeVector(rightAngleFromForward.normalized));

        Vector2 relativeForce = (rightAngleFromForward.normalized * -1.0f) * (driftForce * 10.0f);

        rb.AddForce(rb.GetRelativeVector(relativeForce));

    }

}
