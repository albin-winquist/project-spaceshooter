using UnityEngine;
using System.Collections.Generic;

public class BulletPool : MonoBehaviour
{
    public static BulletPool Instance;

    public GameObject bulletPrefab;
    public int poolSize = 500;

    Queue<GameObject> pool = new Queue<GameObject>();

    void Awake()
    {
        Instance = this;

        for (int i = 0; i < poolSize; i++)
        {
            GameObject b = Instantiate(bulletPrefab);
            b.SetActive(false);
            pool.Enqueue(b);
        }
    }

    public GameObject GetBullet()
    {
        GameObject b = pool.Dequeue();
        b.SetActive(true);
        pool.Enqueue(b);
        return b;
    }
}
