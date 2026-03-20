using UnityEngine;
using System.Collections;
using DG.Tweening;

public class BossController : MonoBehaviour
{
    public int maxHealth = 1000;
    public int currentHealth;
    public int damage = 1;

    public PatternManager patternManager;

    private int phase = 1;

    private SpriteRenderer spriteRenderer;
    private Color originalColor;

    void Start()
    {
        currentHealth = maxHealth;

        spriteRenderer = GetComponentInChildren<SpriteRenderer>(); // 👈 safer for bosses
        originalColor = spriteRenderer.color;

        StartCoroutine(BossRoutine());
    }

    IEnumerator BossRoutine()
    {
        while (currentHealth > 0)
        {
            switch (phase)
            {
                case 1:
                    patternManager.PlayPhase1();
                    break;
                case 2:
                    patternManager.PlayPhase2();
                    break;
                case 3:
                    patternManager.PlayPhase3();
                    break;
            }

            yield return new WaitForSeconds(1f);
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        PlayHitEffect(); // 👈 FLASH HERE

        if (currentHealth <= maxHealth * 0.66f)
            phase = 2;

        if (currentHealth <= maxHealth * 0.33f)
            phase = 3;

        if (currentHealth <= 0f)
        {
            Die();
        }
    }

    private void PlayHitEffect()
    {
        if (spriteRenderer == null) return;

        spriteRenderer.DOKill(); // stop overlapping flashes

        spriteRenderer.color = Color.white;

        spriteRenderer
            .DOColor(originalColor, 0.5f)
            .SetEase(Ease.OutQuad);
    }

    void Die()
    {
        AudioManager.Instance.PlayExplosion(); 
        CameraShake.Instance.Shake(0.8f, 0.8f);

        Destroy(gameObject);
    }
}