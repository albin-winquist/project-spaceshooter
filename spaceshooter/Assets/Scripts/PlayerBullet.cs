using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    public float speed;
    public Vector2 direction;


    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Boss"))
        {
            other.GetComponent<BossController>().TakeDamage(2);
            gameObject.SetActive(false);
        }
    }

    void OnBecameInvisible()
    {
        gameObject.SetActive(false);
    }
}
