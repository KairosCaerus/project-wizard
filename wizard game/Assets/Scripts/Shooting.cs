using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform firePt;
    public GameObject bulletPrefab;

    public float force = 20f;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            Fire();
        }
    }

    void Fire()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePt.position, firePt.rotation);
        Rigidbody2D rBody = bullet.GetComponent<Rigidbody2D>();
        rBody.AddForce(firePt.up * force, ForceMode2D.Impulse);
    }
}
