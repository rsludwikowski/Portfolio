using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int health = 100;
    public int playerIndex = 1;
    public float speed = 10;
    public float hoverHeight = 3.5f;
    public float hoverForce = 60.0f;
    public float rotationSpeed = 2.0f;
    private float shootingTimer;
    public float shootingInterval = 1.0f;
    private float dodgeTimer;
    private float dodgeDuration;
    private float currentDodgeTime = 0;
    public float dodgeInterval = 2.0f;
    public float dodgeLength = 4.0f;
    public float dodgeSpeed = 30;
    public bool merging = false;
    private Rigidbody playerBody;

    [SerializeField]
    private Transform gunPlacedPosition;
    [SerializeField]
    private Transform gunShootAtPosition;
    [SerializeField]
    private GameObject bulletPrefab;
    public float bulletSpeed = 10f;

    private void Start()
    {
        dodgeDuration = dodgeLength / dodgeSpeed;
        shootingTimer = shootingInterval;
        dodgeTimer = dodgeInterval;
        playerBody = GetComponent<Rigidbody>();
        state = State.Normal;
        currentDodgeTime = 0;
    }

    private State state;
    private enum State
    {
        Normal,
        Dodging,
    }

    private void Update()
    {
        switch (state)
        {
            case State.Normal:
                PlayerMovement(playerIndex);
                PlayerShoot(playerIndex);
                PlayerMerge(playerIndex);
                CheckPlayerDodge(playerIndex);
                break;
            case State.Dodging:
                Dodge();
                break;
        }
    }

    private void FixedUpdate()
    {
        HoverMotor();
    }

    private void PlayerMovement(int index)
    {
        float horizontal = Input.GetAxis("Horizontal" + index);
        float vertical = Input.GetAxis("Vertical" + index);
        Vector3 axisMovement = new Vector3(horizontal * Time.deltaTime, 0.0f, vertical * Time.deltaTime);
        axisMovement.Normalize();
        axisMovement *= speed;
        Vector3 movement = new Vector3(axisMovement.x, playerBody.velocity.y, axisMovement.z);
        playerBody.velocity = movement;
        //turning
        transform.rotation = Quaternion.RotateTowards(transform.rotation,
            Quaternion.Euler(0.0f, 0.0f, -playerBody.velocity.x / 2),
            rotationSpeed * Time.deltaTime);
    }

    private void PlayerShoot(int index)
    {
        shootingTimer -= Time.deltaTime;
        if(Input.GetAxis("Shoot" + index) > 0.0f)
        {
            if(shootingTimer <= 0.0f)
            {
                Shoot();
                shootingTimer = shootingInterval;
            }
        }
    }

    private void Shoot()
    {
        GameObject bulletInstance = Instantiate(bulletPrefab);
        bulletInstance.transform.position = gunPlacedPosition.position;
        bulletInstance.transform.SetParent(null);
        Vector3 shootingDirection = gunShootAtPosition.position - gunPlacedPosition.position;
        shootingDirection.Normalize();
        bulletInstance.GetComponent<Rigidbody>().velocity = shootingDirection * bulletSpeed;
        Destroy(bulletInstance, 10.0f);
    }

    private void CheckPlayerDodge(int index)
    {
        dodgeTimer -= Time.deltaTime;
        if (Input.GetAxis("Dodge" + index) > 0.0f)
        {
            if (dodgeTimer <= 0.0f)
            {
                Debug.Log("player" + playerIndex + " is dodging");
                dodgeTimer = dodgeInterval;
                state = State.Dodging;
            }
        }
    }

    private void Dodge()
    {
        currentDodgeTime += Time.deltaTime;
        int direction = playerBody.velocity.x > 0 ? 1 : -1;
        float anglePerDeltaTime = 360 / dodgeDuration * direction * Time.deltaTime;
        float movePerDeltaTime = dodgeLength / dodgeDuration * direction * Time.deltaTime;
        transform.Translate(new Vector3(movePerDeltaTime, 0.0f, 0.0f), Space.World);
        transform.Rotate(0.0f, 0.0f, -anglePerDeltaTime);
        if(currentDodgeTime >= dodgeDuration)
        {
            state = State.Normal;
            currentDodgeTime = 0;
        }
    }

    private void PlayerMerge(int index)
    {
        if (Input.GetAxis("Merge" + index) > 0.0f)
        {
            merging = true;
            Debug.Log("Player " + index + " is merging");
        }
        else
        {
            merging = false;
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
            playerBody.AddForce(appliedHoverForce, ForceMode.Acceleration);
        }
    }

    private void LoseHP(int amount)
    {
        this.health -= amount;
    }

    private void Die()
    {
        //EKSPLOZJA
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("EnemyBullet"))
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
