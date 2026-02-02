using UnityEngine;

public class CurvingBullet : MonoBehaviour
{
    public float speed = 6f;
    public float curveStrength = 2f;
    public float curveFrequency = 4f;

    private Vector2 direction;
    private float time;

    public void Init(Vector2 dir)
    {
        direction = dir.normalized;
    }

    void Update()
    {
        time += Time.deltaTime;

        float curve = Mathf.Sin(time * curveFrequency) * curveStrength;
        Vector2 curvedDir = Quaternion.Euler(0, 0, curve) * direction;

        transform.position += (Vector3)(curvedDir * speed * Time.deltaTime);
    }
}
