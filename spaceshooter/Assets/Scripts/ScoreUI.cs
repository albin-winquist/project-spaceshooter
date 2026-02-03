using UnityEngine;
using TMPro;
using DG.Tweening;

public class ScoreUI : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public float countDuration = 0.4f;

    private int displayedScore;
    private Tween countTween;

    private void Start()
    {
        displayedScore = 0;
        scoreText.text = " ";

        GameManager.Instance.OnScoreChanged += AnimateScore;
        GameManager.Instance.OnScoreGained += PunchScore;
    }

    void AnimateScore(int newScore)
    {
        countTween?.Kill();

        countTween = DOTween.To(
            () => displayedScore,
            x =>
            {
                displayedScore = x;
                scoreText.text = " " + displayedScore;
            },
            newScore,
            countDuration
        ).SetEase(Ease.OutCubic);
    }

    void PunchScore(int amount)
    {
        scoreText.transform.DOPunchScale(
            Vector3.one * 0.25f,
            0.2f,
            8,
            1f
        );
    }

    private void OnDestroy()
    {
        if (GameManager.Instance == null) return;

        GameManager.Instance.OnScoreChanged -= AnimateScore;
        GameManager.Instance.OnScoreGained -= PunchScore;
    }
}
