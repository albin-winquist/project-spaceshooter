using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int Score { get; private set; }

    public event Action<int> OnScoreChanged;
    public event Action<int> OnScoreGained;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public void AddScore(int amount)
    {
        Score += amount;

        OnScoreChanged?.Invoke(Score);
        OnScoreGained?.Invoke(amount);
    }
}
