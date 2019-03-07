﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveScript : MonoBehaviour
{
    public void SaveLevel(int currentLevel)
    {
        PlayerPrefs.SetInt("Level", currentLevel);
    }

    public int GetSavedLevel()
    {
        int level = 0;

        if (PlayerPrefs.HasKey("Level"))
        {
            level = PlayerPrefs.GetInt("Level");
        }

        return level;
    }

    public void DeleteSave()
    {
        PlayerPrefs.DeleteKey("Level");
    }
}
