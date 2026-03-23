using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [Header("Audio Sources")]
    public AudioSource sfxSource;
    public AudioSource musicSource;

    [Header("Music")]
    public AudioClip backgroundMusic;

    [Header("SFX Clips")]
    public AudioClip shootClip;
    public AudioClip sunClip;
    public AudioClip enemyHitClip;
    public AudioClip explosionClip;
    public AudioClip playerHitClip;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        PlayMusic(backgroundMusic);
        PlaySun();
    }
    public void PlayMusic(AudioClip musicClip)
    {
        if (musicClip == null) return;

        musicSource.clip = musicClip;
        musicSource.loop = true;
        musicSource.Play();
    }

    public void StopMusic()
    {
        musicSource.Stop();
    }

    // Generic SFX player
    public void PlaySFX(AudioClip clip, float volume = 1f)
    {
        sfxSource.pitch = Random.Range(0.85f, 1.05f);
        sfxSource.PlayOneShot(clip, volume);
    }

    // Specific helpers (optional but clean)
    public void PlayShoot() => PlaySFX(shootClip, 0.15f);
    public void PlaySun() => PlaySFX(sunClip, 0.7f);
    public void PlayEnemyHit() => PlaySFX(enemyHitClip, 0.14f);
    public void PlayExplosion() => PlaySFX(explosionClip, 1f);
    public void PlayPlayerHit() => PlaySFX(playerHitClip, 1.3f);
}