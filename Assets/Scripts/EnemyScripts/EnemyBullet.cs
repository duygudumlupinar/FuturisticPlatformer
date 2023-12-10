using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public int damage = 30;
    public float speed = 10f;
    private Rigidbody2D rb;
    public GameObject impactEffect;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<PlayerHealth>().TakeDamage(damage);
            Instantiate(impactEffect, transform.position, Quaternion.identity);
        }
        
        if(collision.tag != "Bullet")
        {
            Destroy(gameObject);
        }
    }
}
