using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    GameObject bullet;

    bool fired;
    
    public Transform firePt;
    public GameObject bulletPrefab;

    public float cooldownTime;
    public float cooldownStartTime;
    public float bulletTime;
    public float bulletStartTime;
    public float force = 20f;

    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            if(cooldownTime <= 0)
            {
                Fire();
                cooldownTime = cooldownStartTime;
                fired = true;
            }
        }

        cooldownTime -= Time.deltaTime;

        if(fired)
        {
            bulletTime -= Time.deltaTime;
        }

        if(bulletTime <= 0)
        {
            Destroy(bullet);
            fired = false;
            bulletTime = bulletStartTime;
        }
    }

    void Fire()
    {
        bullet = Instantiate(bulletPrefab, firePt.position, firePt.rotation);
        Rigidbody2D rBody = bullet.GetComponent<Rigidbody2D>();
        rBody.AddForce(firePt.up * force, ForceMode2D.Impulse);
    }
}
