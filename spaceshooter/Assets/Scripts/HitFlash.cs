using UnityEngine;
using DG.Tweening;

public class Boss : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private Color originalColor;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalColor = spriteRenderer.color;
    }

    public void OnHit()
    {
        spriteRenderer.DOKill(); // stop overlapping tweens

        spriteRenderer.color = Color.white;

        spriteRenderer.DOColor(originalColor, 0.08f)
            .SetEase(Ease.OutQuad);
    }
}