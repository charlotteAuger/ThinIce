using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private SaveScript saveScript;

    public float currentScore;
    public LevelData currentLevel;
    [SerializeField] private LevelList levelList;
    public GameObject player;
    private IceCuttingTrail trail;

    public delegate void PowerUpEvent(float amount);
    public PowerUpEvent TrailUp;

    private void Awake()
    {
        if (Instance == null) { Instance = this; }
        else if (Instance != this) { Destroy(gameObject); }

        saveScript = new SaveScript();
        //saveScript.DeleteSave();
        int levelID = saveScript.GetSavedLevel();
        currentLevel = levelList.levels[levelID-1];

        Screen.orientation = ScreenOrientation.Portrait;
    }

    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private Transform playerSpawn;
    public FollowTarget cameraScript;


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
        cameraScript.SetTarget(player);

        currentScore = 0;

        UIManager.Instance.InitializeInGameUI(currentLevel.id);
        UIManager.Instance.SetMainMenuVisibility(false);
        UIManager.Instance.HideTransitionUI();

        LevelGenerator.instance.on = true;
        StartCoroutine(LoadLevel());
    }

    private void CheckVictory()
    {
        if (currentScore >= currentLevel.scoreGoal)
        {
            StartCoroutine(EndGame(true));
           
        }
    }

    public IEnumerator EndGame(bool playerWins)
    {
        IceSkatingMovement movementScript = player.GetComponent<IceSkatingMovement>();
        movementScript.StopMovement();

        yield return new WaitForSeconds(0.5f);

        UIManager.Instance.SetTransitionUI(playerWins);
        LevelGenerator.instance.on = false;
        Destroy(player);

        if (playerWins)
        {
             IncrementLevel();
        }
    }

    public void IncrementLevel()
    {
        int newLevelID = Mathf.Min(currentLevel.id + 1, levelList.levels.Length);
        saveScript.SaveLevel(newLevelID);
        currentLevel = levelList.levels[newLevelID-1];
    }

    IEnumerator LoadLevel()
    {
        LevelGenerator.instance.ClearLevel();
        yield return null;
        LevelGenerator.instance.GenerateLevel(currentLevel);
    }

}
