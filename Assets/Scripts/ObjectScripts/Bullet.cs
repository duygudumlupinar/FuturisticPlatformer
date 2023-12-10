using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage = 25;
    public float speed = 20f;
    private Rigidbody2D rb;
    public GameObject impactEffect;

    void Start()
    {
        rb= GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Enemy")
        {
            collision.GetComponent<Enemy>().TakeDamage(damage);
            collision.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            if(collision.gameObject.name != "Effy")
            {
                collision.GetComponent<EnemyController>().enemyState = EnemyState.ATTACK;
            }
            Instantiate(impactEffect, transform.position, Quaternion.identity);
        }

        if (collision.tag != "Bullet")
        {
            Destroy(gameObject);
        }
    }
}
