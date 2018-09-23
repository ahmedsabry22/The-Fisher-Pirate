using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mission : MonoBehaviour, IMission
{
    public bool Won
    {
        get { return (won); }
    }

    public bool Lost
    {
        get { return (lost); }
    }

    public FishTypes targetFishType;
    public int numberOfReqieredFish;
    public Text progressText;
    public GameObject winPanel;
    public GameObject losePanel;

    public static Mission Instance;

    private int huntedFish;
    private bool won;
    private bool lost;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }

        progressText.text = "(" + huntedFish + " / " + numberOfReqieredFish + ")";
    }

    public void OnFishHunted()
    {
        huntedFish++;
        progressText.text = "(" + huntedFish + " / " + numberOfReqieredFish + ")";
        CheckWinCondition();
    }

    public void CheckWinCondition()
    {
        if (huntedFish >= numberOfReqieredFish)
        {
            OnMissionWon();
        }
    }

    public void OnMissionWon()
    {
        won = true;

        Time.timeScale = 0;
        winPanel.SetActive(true);
    }

    public void OnMissionLose()
    {
        lost = true;
        Time.timeScale = 0;
        losePanel.SetActive(true);
    }
}