using UnityEngine;
using System.Collections;

public class RingBurstPattern : MonoBehaviour
{
    public GameObject bulletPrefab;
    public int bulletCount = 24;
    public float burstDelay = 1.2f;

    public IEnumerator Fire()
    {
        while (true)
        {
            for (int i = 0; i < bulletCount; i++)
            {
                float angle = i * (360f / bulletCount);
                Vector2 dir = Quaternion.Euler(0, 0, angle) * Vector2.up;

                GameObject b = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
                b.GetComponent<Bullet>().direction = dir;
            }

            yield return new WaitForSeconds(burstDelay);
        }
    }
}
