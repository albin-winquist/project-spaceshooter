using UnityEngine;
using System.Collections;

public class AimedShotPattern : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform player;

    public float fireDelay = 0.15f;
    public int bulletsPerRing = 24;

    private float baseRotation = 0f;
    private float rotationSpeed = 20f;

    public IEnumerator Fire()
    {
        yield return new WaitForSeconds(1f);

        while (true)
        {
            Vector2 aimDir = (player.position - transform.position).normalized;
            float aimAngle = Mathf.Atan2(aimDir.y, aimDir.x) * Mathf.Rad2Deg;

            for (int i = 0; i < bulletsPerRing; i++)
            {
                float angle = (360f / bulletsPerRing) * i;
                float finalAngle = angle + baseRotation + aimAngle;

                Vector2 dir = new Vector2(
                    Mathf.Cos(finalAngle * Mathf.Deg2Rad),
                    Mathf.Sin(finalAngle * Mathf.Deg2Rad)
                );

                GameObject bullet = Instantiate(
                    bulletPrefab,
                    transform.position,
                    Quaternion.identity
                );

                CurvingBullet cb = bullet.GetComponent<CurvingBullet>();
                cb.Init(dir);

                cb.speed = Random.Range(5f, 8f);
                cb.curveStrength = Random.Range(1.5f, 3.5f);
                cb.curveFrequency = Random.Range(3f, 6f);
            }

            baseRotation += rotationSpeed * Time.deltaTime;
            rotationSpeed += 0.5f; // ramps difficulty 🔥

            yield return new WaitForSeconds(fireDelay);
        }
    }
}
