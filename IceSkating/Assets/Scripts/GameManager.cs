﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private SaveScript saveScript;

    private float currentScore;
    private LevelData currentLevel;
    [SerializeField] private LevelList levelList;
    private GameObject player;
    private IceCuttingTrail trail;

    public delegate void PowerUpEvent(float amount);
    public PowerUpEvent TrailUp;

    private void Awake()
    {
        if (Instance == null) { Instance = this; }
        else if (Instance != this) { Destroy(gameObject); }

        saveScript = new SaveScript();
        int levelID = saveScript.GetSavedLevel();
        currentLevel = levelList.levels[levelID];        
    }

   

    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private Transform playerSpawn;

    public void GainPoints(float amount)
    {
        currentScore += amount;
        UIManager.Instance.UpdateScoreBar(currentScore / currentLevel.scoreGoal);
        CheckVictory();
    }

    public void StartGame()
    {
        player = Instantiate(playerPrefab, playerSpawn.position, Quaternion.identity);
        trail = player.GetComponentInChildren<IceCuttingTrail>();
    }

    private void CheckVictory()
    {
        if (currentScore >= currentLevel.scoreGoal)
        {
            EndGame(true);
        }
    }

    public void EndGame(bool playerWins)
    {
        //Deactivate player input and movement
    }

    public void IncrementLevel()
    {
        int newLevelID = Mathf.Min(currentLevel.id + 1, levelList.levels.Length);
        saveScript.SaveLevel(newLevelID);
        currentLevel = levelList.levels[newLevelID];
    }

    public void LoadLevel()
    {

    }
}
