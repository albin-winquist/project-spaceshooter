using UnityEngine;
using DG.Tweening;

public class BossMovement : MonoBehaviour
{
    public float speed = 2f;
    public Vector2 minBounds;
    public Vector2 maxBounds;

    [Header("Random Ease")]
    [Range(0f, 1f)]
    public float elasticChance = 0.35f; // % of moves that use Elastic

    private bool movingRight = true;
    private bool firstMove = true;

    private void Start()
    {
        Move();
    }

    void Move()
    {
        float targetX = movingRight ? maxBounds.x : minBounds.x;
        float distance = Mathf.Abs(transform.position.x - targetX);
        float duration = distance / speed;

        Ease chosenEase;

        if (firstMove)
        {
            chosenEase = Ease.InOutSine;
            firstMove = false;
        }
        else
        {
            chosenEase = Random.value < elasticChance
                ? Ease.InOutElastic
                : Ease.InOutSine;
        }

        transform.DOMoveX(targetX, duration)
            .SetEase(chosenEase)
            .OnComplete(() =>
            {
                movingRight = !movingRight;
                Move();
            });
    }
}
