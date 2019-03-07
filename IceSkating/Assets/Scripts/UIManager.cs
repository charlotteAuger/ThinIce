using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    private void Awake()
    {
        if (Instance == null) { Instance = this; }
        else if (Instance != this) { Destroy(gameObject); }

    }

    [Header("Score and Level")]
    [SerializeField] private GameObject GameUICanvas;
    [SerializeField] private Image scoreBar;
    [SerializeField] private TextMeshProUGUI currentLevel;
    [SerializeField] private TextMeshProUGUI nextLevel;

    public void InitializeInGameUI(int _currentLevel)
    {
        currentLevel.text = _currentLevel.ToString();
        nextLevel.text = (_currentLevel + 1).ToString();
        UpdateScoreBar(0);
        GameUICanvas.SetActive(true);
    }

    public void HideGameUI()
    {
        GameUICanvas.SetActive(false);
    }

    public void UpdateScoreBar(float percentage)
    {
        scoreBar.fillAmount = percentage;
    }
}
