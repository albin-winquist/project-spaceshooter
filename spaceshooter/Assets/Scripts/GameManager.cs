using UnityEngine;
using System;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int Score { get; private set; }

    public event Action<int> OnScoreChanged;
    public event Action<int> OnScoreGained;

    [SerializeField] private int scorePerSecond = 1;

    private Coroutine scoreCoroutine;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    private void Start()
    {
        scoreCoroutine = StartCoroutine(ScoreOverTime());
    }

    private IEnumerator ScoreOverTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            AddScore(scorePerSecond);
        }
    }

    public void AddScore(int amount)
    {
        Score += amount;

        OnScoreChanged?.Invoke(Score);
        OnScoreGained?.Invoke(amount);
    }
}
