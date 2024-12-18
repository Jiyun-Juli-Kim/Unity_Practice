using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class ScoreUI : MonoBehaviour
{
    private TextMeshProUGUI _scoreText;
    void Start()
    {
        _scoreText = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        _scoreText.text = "Score : " + GameManager.Instance.Score.ToString();
    }
}
