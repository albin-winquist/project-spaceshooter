using UnityEngine;
using DG.Tweening;

public class PlanetRotator : MonoBehaviour
{
    [Header("Rotation Settings")]
    public Vector3 rotationAxis = Vector3.up;
    public float rotationDuration = 20f; // seconds for one full rotation

    [Header("Randomization")]
    public bool randomizeAxis = true;
    public bool randomizeSpeed = true;
    public Vector2 speedRange = new Vector2(10f, 40f);
    public bool randomStartOffset = true;

    private void Start()
    {
        Vector3 axis = rotationAxis;
        float duration = rotationDuration;

        if (randomizeAxis)
        {
            axis = Random.onUnitSphere;
        }

        if (randomizeSpeed)
        {
            duration = Random.Range(speedRange.x, speedRange.y);
        }

        if (randomStartOffset)
        {
            transform.Rotate(axis * Random.Range(0f, 360f), Space.World);
        }

        transform
            .DORotate(axis * 360f, duration, RotateMode.WorldAxisAdd)
            .SetEase(Ease.Linear)
            .SetLoops(-1);
    }
}
