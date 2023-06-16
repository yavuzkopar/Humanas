using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScorePool : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI[] texts;
    [SerializeField] TextMeshProUGUI totalScoreText;
    [SerializeField] TextMeshProUGUI endGameScoreText;
    int totalScore;
    int poolIndex;
    void Start()
    {
        FindObjectOfType<EatingCounter>().OnFeeded += ScorePool_OnFeeded; 
    }

    private void ScorePool_OnFeeded(int score)
    {
        int calcualatedScore = CalculateScore(score);
        ScorePopUp(calcualatedScore);
        IncreasePool();

        WriteTotalScore(calcualatedScore);
    }

    private void ScorePopUp(int calcualatedScore)
    {
        texts[poolIndex].text = calcualatedScore.ToString();
        texts[poolIndex].gameObject.SetActive(true);
    }

    private void IncreasePool()
    {
        poolIndex++;
        if (poolIndex > 9)
            poolIndex = 0;
    }

    private static int CalculateScore(int score)
    {
        return score * score * 10;
    }

    private void WriteTotalScore(int current)
    {
        totalScore += current;
        totalScoreText.text = totalScore.ToString();
        endGameScoreText.text = "SKOR    " + totalScore.ToString();
        ScoreGlobal.Instance.GlobalScore += current;
    }
}
