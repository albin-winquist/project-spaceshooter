using UnityEngine;
using DG.Tweening;

public class CameraShake : MonoBehaviour
{
    public static CameraShake Instance;

    private Transform camTransform;
    private Vector3 originalPos;

    private void Awake()
    {
        Instance = this;
        camTransform = transform;
        originalPos = camTransform.localPosition;
    }

    public void Shake(float duration, float strength, int vibrato = 20, float randomness = 90f)
    {
        camTransform.DOShakePosition(duration, strength, vibrato, randomness)
            .OnComplete(() => camTransform.localPosition = originalPos);
    }
}