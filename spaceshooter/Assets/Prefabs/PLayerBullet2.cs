using UnityEngine;

public class PLayerBullet2 : MonoBehaviour
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
           

            BossMovementNoVFX boss2 = other.GetComponent<BossMovementNoVFX>();
            boss2.TakeDamage(2);

            Vector3 hitPos = other.ClosestPoint(transform.position);

           

            gameObject.SetActive(false);
        }
    }

    void OnBecameInvisible()
    {
        gameObject.SetActive(false);
    }
}