using UnityEngine;
using System.Collections;

public class AimedShotPattern : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform player;
    public float fireDelay = 0.3f;

    public IEnumerator Fire()
    {
        while (true)
        {
            Vector2 dir = (player.position - transform.position).normalized;

            GameObject b = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            b.GetComponent<Bullet>().direction = dir;

            yield return new WaitForSeconds(fireDelay);
        }
    }
}
