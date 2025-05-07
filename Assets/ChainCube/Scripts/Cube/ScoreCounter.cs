using UnityEngine;
using TMPro;

public class ScoreCounter : MonoBehaviour
{
    public static ScoreCounter Instance { get; private set; }

    public TextMeshProUGUI textMesh;

    public long Score { get; private set; }
    private long maxScore;

    private const string MaxScoreKey = "MaxScore";

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    private void Start()
    {
        maxScore = PlayerPrefs.GetInt(MaxScoreKey, 0);
        UpdateText();
    }

    public void AddScore(int amount)
    {
        Score += amount;

        if (Score > maxScore)
        {
            maxScore = Score;
            PlayerPrefs.SetInt(MaxScoreKey, (int)maxScore);
            PlayerPrefs.Save();
        }

        UpdateText();
        Debug.Log($"+{amount} очков. Общий: {Score}. Рекорд: {maxScore}");
    }

    private void UpdateText()
    {
        if (textMesh != null)
            textMesh.text = $"SCORE: {Score}\nMAX: {maxScore}";
    }
}
