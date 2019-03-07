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
    [SerializeField] private GameObject gameUICanvas;
    [SerializeField] private Image scoreBar;
    [SerializeField] private TextMeshProUGUI currentLevel;
    [SerializeField] private TextMeshProUGUI nextLevel;

    [Header("Main Menu")]
    [SerializeField] private GameObject mainMenuCanvas;

    [Header("Transition")]
    [SerializeField] private GameObject transitionScreenCanvas;
    [SerializeField] private TextMeshProUGUI victoryText;


    public void InitializeInGameUI(int _currentLevel)
    {
        currentLevel.text = _currentLevel.ToString();
        nextLevel.text = (_currentLevel + 1).ToString();
        UpdateScoreBar(0);
        gameUICanvas.SetActive(true);
    }

    public void HideGameUI()
    {
        gameUICanvas.SetActive(false);
    }

    public void UpdateScoreBar(float percentage)
    {
        scoreBar.fillAmount = percentage;
    }

    public void SetMainMenuVisibility(bool state)
    {
        mainMenuCanvas.SetActive(state);
    }

    public void SetTransitionUI(bool victory)
    {
        if (victory)
        {
            victoryText.text = "Tap to continue !";
        }
        else
        {
            victoryText.text = "Tap to retry !";
        }

        transitionScreenCanvas.SetActive(true);
    }

    public void HideTransitionUI()
    {
        transitionScreenCanvas.SetActive(false);
    }
}
