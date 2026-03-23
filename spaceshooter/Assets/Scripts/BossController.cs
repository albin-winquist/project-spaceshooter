using UnityEngine;
using System.Collections;
using DG.Tweening;

public class BossController : MonoBehaviour
{
    public int maxHealth = 1000;
    public int currentHealth;
    public int damage = 1;
    public GameObject explosionEffectPrefab;

    public PatternManager patternManager;

    private int phase = 1;
    private bool isDying = false;

    private SpriteRenderer spriteRenderer;
    private Color originalColor;

    void Start()
    {

        currentHealth = maxHealth;

        spriteRenderer = GetComponentInChildren<SpriteRenderer>(); 
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

        PlayHitEffect(); 


        if (currentHealth <= maxHealth * 0.66f)
            phase = 2;

        if (currentHealth <= maxHealth * 0.33f)
            phase = 3;

        if (currentHealth <= 0f && !isDying)
        {
            StartCoroutine(FinalPhase());
        }
    }

    private void PlayHitEffect()
    {
        AudioManager.Instance.PlayEnemyHit();
        if (spriteRenderer == null) return;

        spriteRenderer.DOKill(); 

        spriteRenderer.color = Color.white;

        spriteRenderer
            .DOColor(originalColor, 0.5f)
            .SetEase(Ease.OutQuad);
    }

    IEnumerator FinalPhase()
    {


        isDying = true;
        patternManager.GetComponentInChildren<AimedShotPattern>().EnableFinalPhase();

        spriteRenderer.DOColor(Color.red, 0.2f).SetLoops(-1, LoopType.Yoyo);

       
        patternManager.SetFinalPhase(true);

      
        CameraShake.Instance?.Shake(1.5f, 0.5f);

      
        yield return new WaitForSeconds(5f);

       
        spriteRenderer.DOKill();
        spriteRenderer.color = originalColor;

     
        Die();
    }

    void Die()
    {
        StopAllCoroutines();
        patternManager.StopAllCoroutines();
        AudioManager.Instance.PlayExplosion(); 
        CameraShake.Instance.Shake(5.5f, 1.1f);
        StartCoroutine(WinSequence());

       
    }

    IEnumerator WinSequence()
    {
                
        yield return new WaitForSeconds(1.2f);
        Instantiate(explosionEffectPrefab);
        CameraShake.Instance.Shake(0.3f, 1.9f);
        yield return new WaitForSeconds(0.5f);
        MenuManager.Instance.OpenMenu();

        Destroy(gameObject);
    }
}