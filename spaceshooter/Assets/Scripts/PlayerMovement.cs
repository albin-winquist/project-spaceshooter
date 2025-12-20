using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed = 10f;
    private Vector2 moveInput;

  
    public int maxHealth = 5;
    public int currentHealth;

    [Header("Shooting")]
    public GameObject bulletPrefab;
    public Transform firePoint;
    public Transform firePoint2;
    public float bulletSpeed = 15f;
    public float fireRate = 0.15f;    
    private float nextFireTime;
    private bool isFiring;

    public void Start()
    {
        currentHealth = maxHealth;
    }
    void Update()
    {
        MovePlayer();
        HandleShooting();
    }

    void MovePlayer()
    {
        Vector3 move = new Vector3(moveInput.x, moveInput.y, 0f) * moveSpeed * Time.deltaTime;
        transform.position += move;
    }

    
    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }

    
    public void OnShoot(InputAction.CallbackContext context)
    {
        if (context.performed)
            isFiring = true;
        else if (context.canceled)
            isFiring = false;
    }

    void HandleShooting()
    {
        if (isFiring && Time.time >= nextFireTime)
        {
            nextFireTime = Time.time + fireRate;
            Shoot();
        }

        if (isFiring)
        {
            moveSpeed = 3f;
        }
        else
        {
            moveSpeed = 7f;
        }
    }

    public void TakeDamage(int dmg)
    {
        currentHealth -= dmg;

        if (currentHealth <= 0f)
        {
            Die();
        }
    }

    void Die()
    {

        Destroy(gameObject);
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.linearVelocity = Vector2.up * bulletSpeed;

        GameObject bullet2 = Instantiate(bulletPrefab, firePoint2.position, Quaternion.identity);
        Rigidbody2D rb2 = bullet2.GetComponent<Rigidbody2D>();
        rb2.linearVelocity = Vector2.up * bulletSpeed;


    }
}
