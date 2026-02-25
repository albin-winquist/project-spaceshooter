using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public Vector2 direction;
    

    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerMovement>().TakeDamage(1);
            gameObject.SetActive(false);
            CameraShake.Instance.Shake(0.2f, 0.3f);
        }
    }

    void OnBecameInvisible()
    {
        gameObject.SetActive(false);
    }
}
