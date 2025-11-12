using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed = 10f;
    private Vector2 moveInput;

    [Header("Shooting")]
    public GameObject bulletPrefab;
    public Transform firePoint;       // where bullets spawn
    public float bulletSpeed = 15f;
    public float fireRate = 0.15f;    // seconds between shots
    private float nextFireTime;
    private bool isFiring;
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

    // Called by Player Input "Move" Unity Event
    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }

    // Called by Player Input "Shoot" Unity Event
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
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.linearVelocity = Vector2.up * bulletSpeed;
    }
}
