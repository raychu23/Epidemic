using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text;
using System.IO;
using System;

public class LeaderboardButton : MonoBehaviour
{
    public GameObject leaderboard;
    public GameObject leaderboardCloseButton;

    //public static ScoreManager scorelist = new ScoreManager();
    public void Start()
    {

    }

    public void OpenPanelAndButton()
    {
        if (leaderboard != null)
        {
            bool isActive = leaderboard.activeSelf;
            leaderboard.SetActive(!isActive);
            //incrementing data table count
            /*if (!isActive)
                FindObjectOfType<ClickModel>().tableCount++; */
        }
        if (leaderboardCloseButton != null)
        {
            bool isActive = leaderboardCloseButton.activeSelf;
            leaderboardCloseButton.SetActive(!isActive);
        }
    }

    public void ClosePanelAndButton()
    {
        if (leaderboard != null)
        {
            leaderboard.SetActive(false);
        }
        if (leaderboardCloseButton != null)
        {
            leaderboardCloseButton.SetActive(false);
        }
    }

}