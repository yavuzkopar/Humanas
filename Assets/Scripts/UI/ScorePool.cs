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
        int total = score * score * 10;
        Debug.Log("klljlklk");
        texts[poolIndex].text = total.ToString();
        texts[poolIndex].gameObject.SetActive(true);
        poolIndex++;
        if(poolIndex >3)
            poolIndex= 0;
        totalScore += total;
        totalScoreText.text = totalScore.ToString();
        endGameScoreText.text = "SKOR    " + totalScore.ToString();
    }
}
