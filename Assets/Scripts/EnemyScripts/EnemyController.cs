using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public enum EnemyState
{
    NORMAL,
    ATTACK
}

public class EnemyController : MonoBehaviour
{
    [SerializeField] AudioClip shootSound;

    public EnemyState enemyState;
    private float speed = 4f;
    private Transform target;
    private bool isFacingRight;
    private float timer;
    private Transform currentPoint;
    private Rigidbody2D rb;
    private AudioSource audioSource;

    public Transform firePoint;
    public Transform pointA;
    public Transform pointB;
    public GameObject bulletPrefab;
    public GameObject eyeLight;

    void Start()
    {
        pointA.parent = null; 
        pointB.parent = null;
        rb = GetComponent<Rigidbody2D>();
        enemyState = EnemyState.NORMAL;
        target = GameObject.FindWithTag("Player").transform;
        isFacingRight = true;
        currentPoint = pointB;
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

        if (enemyState == EnemyState.NORMAL)
        {
            // PATROLLING START
            Vector2 point = currentPoint.position - transform.position;
            if(currentPoint == pointB)
            {
                rb.velocity = new Vector2(speed, 0f);
            }
            else
            {
                rb.velocity = new Vector2(-speed, 0f);
            }

            if(Vector2.Distance(transform.position, currentPoint.position) < 0.4f && currentPoint == pointB)
            {
                currentPoint = pointA;
            }
            if(Vector2.Distance(transform.position, currentPoint.position) < 0.4f && currentPoint == pointA)
            {
                currentPoint = pointB;
            }

            // PATROLLING END

            if(Vector2.Distance(transform.position, target.position) < 2f)
            {
                rb.velocity = Vector2.zero;
                enemyState = EnemyState.ATTACK;
            }
        }
        else
        {
            timer += Time.deltaTime;
            eyeLight.SetActive(true);
            audioSource.Play();

            if (timer > 1)
            {
                audioSource.PlayOneShot(shootSound);
                Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
                timer = 0;
            }
        }
    }
}
