using UnityEngine;

public class BossMovement : MonoBehaviour
{
    public float speed = 2f;
    public Vector2 minBounds;
    public Vector2 maxBounds;

    void Update()
    {
        float x = Mathf.PingPong(Time.time * speed, maxBounds.x - minBounds.x) + minBounds.x;
        transform.position = new Vector2(x, transform.position.y);
    }
}
