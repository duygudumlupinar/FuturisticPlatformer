using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class FriendEnemy : MonoBehaviour
{
    private bool isFacingRight = true;
    private float timer;
    private bool isAttacking = false;

    public GameObject gun;
    public GameObject bulletPrefab;
    public Transform firePoint;
    public Transform target;

    void Update()
    {
        Vector2 direction = target.position - transform.position;
        if ((isFacingRight && direction.x < 0) || (!isFacingRight && direction.x > 0))
        {
            isFacingRight = !isFacingRight;
            transform.Rotate(0f, 180f, 0f);
        }
        if(isAttacking)
        {
            Attack();
        }
    }

    public void Attack()
    {
        gun.SetActive(true);
        isAttacking = true;

        timer += Time.deltaTime;

        if (timer > 2)
        {
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            timer = 0;
        }
    }
}
