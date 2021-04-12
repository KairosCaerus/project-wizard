using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public float speed;
    public float stopDistance;
    public float fleeDistance;
    public float evadeSpeed;
    public float evadeDistance;

    public Transform player;
    public Transform bullet;
    //public GameObject bulletPrefab;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if(Vector2.Distance(transform.position, player.position) > stopDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        } else if(Vector2.Distance(transform.position, player.position) < stopDistance && Vector2.Distance(transform.position, player.position) > fleeDistance)
        {
            transform.position = this.transform.position;
        } else if(Vector2.Distance(transform.position, player.position) < fleeDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, -speed * Time.deltaTime);
        }

        bullet = GameObject.FindGameObjectWithTag("Projectile").transform;

        if (Vector2.Distance(transform.position, bullet.position) < evadeDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, bullet.position, -evadeSpeed * Time.deltaTime);
        } 
    }
}
