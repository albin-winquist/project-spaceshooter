using UnityEngine;
using System.Collections;

public class SpiralPattern : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float fireRate = 0.05f;
    public float rotationSpeed = 10f;

    float angle;

    public IEnumerator Fire()
    {
        while (true)
        {
            float rad = angle * Mathf.Deg2Rad;
            Vector2 dir = new Vector2(Mathf.Cos(rad), Mathf.Sin(rad));

            GameObject b = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            b.GetComponent<Bullet>().direction = dir;

            angle += rotationSpeed;
            yield return new WaitForSeconds(fireRate);
        }
    }
}
