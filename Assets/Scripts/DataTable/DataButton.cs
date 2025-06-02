using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text;
using System.IO;
using System;

public class DataButton : MonoBehaviour
{
    public GameObject dataPanel;
    public GameObject dataPanelCloseButton;

    //public static ScoreManager scorelist = new ScoreManager();
    public void Start()
    {
       
    }

    public void OpenPanelAndButton()
    {
        if (dataPanel != null)
        {
            bool isActive = dataPanel.activeSelf;
            dataPanel.SetActive(!isActive);
            //incrementing data table count
            if(!isActive)
            ClickModel.instance.tableCount++;
        }
        if (dataPanelCloseButton != null)
        {
            bool isActive = dataPanelCloseButton.activeSelf;
            dataPanelCloseButton.SetActive(!isActive);
        }
    }

    public void ClosePanelAndButton()
    {
        if (dataPanel != null)
        {
            dataPanel.SetActive(false);
        }
        if (dataPanelCloseButton != null)
        {
            dataPanelCloseButton.SetActive(false);
        }
    }

}
