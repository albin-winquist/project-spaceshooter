using UnityEngine;
using System.Collections;

public class BossController : MonoBehaviour
{
    public int maxHealth = 1000;
    public int currentHealth;
    public int damage = 1;

    public PatternManager patternManager;

    private int phase = 1;

    void Start()
    {
        currentHealth = maxHealth;
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

        if (currentHealth <= maxHealth * 0.66f)
            phase = 2;

        if (currentHealth <= maxHealth * 0.33f)
            phase = 3;

        if (currentHealth <= 0f)
        {
            Die();
        }
    }

    void Die()
    {
       
        Destroy(gameObject);
    }
}
