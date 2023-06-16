using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TotalScoreMenuText : MonoBehaviour
{
    private void OnEnable()
    {
        if(PlayerPrefs.HasKey(ScoreGlobal.SCORE_KEY))
        {
            GetComponent<TextMeshProUGUI>().text = ScoreGlobal.Instance.GlobalScore.ToString();
        }
    }
}
