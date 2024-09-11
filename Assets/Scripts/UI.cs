using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreAmount;
    [SerializeField] private TextMeshProUGUI lifesAmount;
    [SerializeField] private TextMeshProUGUI highScoreAmount;

    private void Start()
    {
        GameManager.Instance.OnScoreChange += GameManager_OnScoreChange;
        GameManager.Instance.OnLifesChange += GameManager_OnLifesChange;
        RefreshUI();
    }

    private void GameManager_OnLifesChange(object sender, EventArgs e)
    {
        RefreshUI();
    }

    private void GameManager_OnScoreChange(object sender, EventArgs e)
    {
        RefreshUI();
    }

    private void RefreshUI()
    {
        scoreAmount.text = GameManager.Instance.GetScore().ToString();
        lifesAmount.text = GameManager.Instance.GetLifes().ToString();
        highScoreAmount.text = GameManager.Instance.GetHighScore().ToString();
    }
}



