using UnityEngine;
using System.Collections;

public class PatternManager : MonoBehaviour
{
    public SpiralPattern spiral;
    public RingBurstPattern ring;
    public AimedShotPattern aimed;

    

    Coroutine currentPattern;

    public void PlayPhase1()
    {
        SwitchPattern(spiral.Fire());
    }

    public void PlayPhase2()
    {
        SwitchPattern(ring.Fire());
    }

    public void PlayPhase3()
    {
        SwitchPattern(aimed.Fire());
    }

    void SwitchPattern(IEnumerator newPattern)
    {
        if (currentPattern != null)
            StopCoroutine(currentPattern);

        currentPattern = StartCoroutine(newPattern);
    }
}
