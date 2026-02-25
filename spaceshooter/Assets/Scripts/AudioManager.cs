using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [Header("Audio Sources")]
    public AudioSource sfxSource;
    public AudioSource musicSource;

    [Header("SFX Clips")]
    public AudioClip shootClip;
    public AudioClip enemyHitClip;
    public AudioClip explosionClip;
    public AudioClip playerHitClip;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    // Generic SFX player
    public void PlaySFX(AudioClip clip, float volume = 1f)
    {
        sfxSource.pitch = Random.Range(0.85f, 0.95f);
        sfxSource.PlayOneShot(clip, volume);
    }

    // Specific helpers (optional but clean)
    public void PlayShoot() => PlaySFX(shootClip, 0.4f);
    public void PlayEnemyHit() => PlaySFX(enemyHitClip, 0.6f);
    public void PlayExplosion() => PlaySFX(explosionClip, 1f);
    public void PlayPlayerHit() => PlaySFX(playerHitClip, 0.8f);
}