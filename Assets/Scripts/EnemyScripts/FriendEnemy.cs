using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class FriendEnemy : MonoBehaviour
{
    [SerializeField] AudioClip shootSound;

    private bool isFacingRight = true;
    private float timer;
    private bool isAttacking = false;
    private AudioSource audioSource;

    public GameObject gun;
    public GameObject bulletPrefab;
    public Transform firePoint;
    public Transform target;
    public EnemyState enemyState;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

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

        if (timer > 1)
        {
            audioSource.PlayOneShot(shootSound);
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            timer = 0;
        }
    }
}
