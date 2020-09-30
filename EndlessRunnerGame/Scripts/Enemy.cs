using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 100;
    private float shootingTimer;
    public float shootingInterval = 1.0f;
    public float speed = 10f;
    public float hoverHeight = 6.0f;
    private float transitionHeight;
    public float hoverForce = 40.0f;
    private int moveDirection;
    private Rigidbody enemyBody;
    public float coneSize = 3f;
    public float enemyBulletSpeed = 10;
    public float rotationSpeed = 2.0f;

    [SerializeField]
    private GameObject bulletPrefab;

    private void Start()
    {
        Randomize();
        enemyBody = GetComponent<Rigidbody>();
        state = State.Entering;
        transitionHeight = 0.5f * hoverHeight;
    }

    public void Randomize()
    {
        speed = Random.Range(speed / 2, speed);
        hoverHeight = Random.Range(hoverHeight - 1, hoverHeight + 1);
        shootingInterval = Random.Range(shootingInterval / 2, shootingInterval * 1.5f);
        shootingTimer = Random.Range(shootingInterval / 2, shootingInterval * 1.5f);
        int random = (int)Random.Range(0.0f, 1.99f);
        moveDirection = random == 1 ? 1 : -1;
    }

    private State state;
    private enum State
    {
        Normal,
        Entering,
    }

    private void Update()
    {
        switch (state)
        {
            case State.Normal:
                Move();
                Shoot();
                break;
            case State.Entering:
                Enter();
                break;
        }
    }

    private void FixedUpdate()
    {
        if(state == State.Normal)
        {
            HoverMotor();
        }
    }

    private void Enter()
    {
        if(transform.position.y < transitionHeight)
        {
            enemyBody.velocity = new Vector3(moveDirection * speed, enemyBody.velocity.y, enemyBody.velocity.z);
            state = State.Normal;
        }
    }

    private void Move()
    {
        enemyBody.velocity = new Vector3(moveDirection * speed, enemyBody.velocity.y, enemyBody.velocity.z);
        transform.rotation = Quaternion.RotateTowards(transform.rotation,
            Quaternion.Euler(0.0f, 0.0f, -enemyBody.velocity.x * 2),
            rotationSpeed * Time.deltaTime);
    }

    private void Shoot()
    {
        shootingTimer -= Time.deltaTime;
        if(shootingTimer <= 0.0f)
        {
            shootingTimer = shootingInterval;
            GameObject bulletInstance = Instantiate(bulletPrefab);
            bulletInstance.transform.position = transform.position;
            bulletInstance.transform.SetParent(this.transform);
            Vector3 shootDirection = new Vector3(
                bulletInstance.transform.localPosition.x - Random.Range(-coneSize, coneSize),
                bulletInstance.transform.localPosition.y + Random.Range(-coneSize, -coneSize/10),
                bulletInstance.transform.localPosition.z - 1);
            shootDirection.Normalize();
            bulletInstance.GetComponent<Rigidbody>().velocity = shootDirection * enemyBulletSpeed;
            Destroy(bulletInstance, 10f);
        }
    }

    private void HoverMotor()
    {
        Ray ray = new Ray(transform.position, -Vector3.up);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, hoverHeight))
        {
            float proportionalHeight = (hoverHeight - hit.distance) / hoverHeight;
            Vector3 appliedHoverForce = Vector3.up * proportionalHeight * hoverForce;
            enemyBody.AddForce(appliedHoverForce, ForceMode.Acceleration);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.CompareTag("Wall") || collision.collider.CompareTag("Enemy"))
        {
            moveDirection *= -1;
        }
    }

    private void LoseHP(int amount)
    {
        this.health -= amount;
    }

    private void Die()
    {
        EnemyGenerator.enemyNumber--;
        //EKSPLOZJA
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player1Bullet"))
        {
            Destroy(other.gameObject);
            LoseHP(other.GetComponent<Bullet>().damage);
            if(health <= 0)
            {
                Die();
            }
        }
    }
}
