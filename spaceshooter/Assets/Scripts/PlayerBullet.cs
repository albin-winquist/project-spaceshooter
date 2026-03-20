using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    public float speed;
    public Vector2 direction;

    public GameObject hitEffectPrefab;

    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Boss"))
        {
            BossController boss = other.GetComponent<BossController>();
            boss.TakeDamage(2);

            
            Vector3 hitPos = other.ClosestPoint(transform.position);

            Instantiate(hitEffectPrefab, hitPos, Quaternion.identity);

            gameObject.SetActive(false);
        }
    }

    void OnBecameInvisible()
    {
        gameObject.SetActive(false);
    }
}