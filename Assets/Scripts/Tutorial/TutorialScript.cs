using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialScript : MonoBehaviour
{
    public GameObject speech;
    public GameObject speechBubble;
    public GameObject arrow1; //Location 1
    public GameObject arrow2; //Funds
    public GameObject arrow3; //Enemy Wave
    public GameObject arrow4; //Health points
    public GameObject arrow5; //Effectiveness/mute/pause
    public GameObject arrow6; //Start wave
    public GameObject arrow7; // Data table
    public GameObject arrow8; //Data visual
    public GameObject continueButton;
    public GameObject location1;
    public GameObject location2;
    public GameObject location3;
    Button dataButton;
    Button dataVisualButton;
    Button waveButton;
    string[] dialogue = 
        {"A few enemy viruses seem to have escaped from our lab. I’ll teach you how to stop them.",
        "First, click on the location indicated by the arrow and select the Red-Red turret. In later levels, other turrets will be available.",
        "The turret you select will determine which medicine will be used. Red turrets use Med R.",
        "Great Job! Your first line of defense is established!",
        "Notice that your available funds displayed on the top right corner have decreased.",
        "This is because buying turrets and medicines both cost money. Spend wisely!",
        "Now, press the Start Wave button and watch to see if your turrets are able to stop the viruses.",
        "",
        "If you were watching closely, you likely noticed that the medicine isn’t 100% effective.",
        "Sometimes shots fail to destroy the virus. You will need to try different medicines to see which works best.",
        "In addition to effectiveness, this panel contains the mute and pause buttons",
        "The current wave number and health points are also displayed here.",
        "We’ve just completed the first of two waves in the tutorial and you lose one health each time a virus gets past your turrets.",
        "You can change the medicine of the turrets during the level to change strategies.",
        "To change medicines, click on one of the installed turrets and select Med B.",
        "Keep in mind, changing medicines may be costly.",
        "As waves progress, you may find certain medicines are better against certain viruses.",
        "Finally, you can click on the Data and the Graphs buttons to get more information about the medicines after a wave ends.",
        "Now, press the Start Wave button, to let the second wave of viruses through. I will leave the rest up to you!",
        "Best of luck!"};
    private DisplayOrdering[] status = new DisplayOrdering[20];
    int i;
    private bool isEnd = false;

    /// <summary>
    /// Raises the enable event.
    /// </summary>
    void OnEnable()
    {
        EventManager.StartListening("WaveEnd", WaveEnd);
        EventManager.StartListening("WaveStart", WaveStart);
    }

    /// <summary>
    /// Raises the disable event.
    /// </summary>
    void OnDisable()
    {
        EventManager.StopListening("WaveEnd", WaveEnd);
        EventManager.StopListening("WaveStart", WaveStart);
    }

    // Start is called before the first frame update
    void Start()
    {
        dataButton = GameObject.Find("ShowData").GetComponent<Button>();
        dataVisualButton = GameObject.Find("DataVisual").GetComponent<Button>();
        waveButton = GameObject.Find("StartWaveButton").GetComponent<Button>();
        speech.SetActive(true);
        speechBubble.SetActive(true);
        arrow1.SetActive(false);
        arrow2.SetActive(false);
        arrow3.SetActive(false);
        arrow4.SetActive(false);
        arrow5.SetActive(false);
        arrow6.SetActive(false);
        arrow7.SetActive(false);
        arrow8.SetActive(false);
        continueButton.SetActive(true);
        dataButton.interactable = true;
        dataVisualButton.interactable = true;
        waveButton.interactable = false;
        location1.GetComponentInChildren<Tower>().Disable();
        location2.GetComponentInChildren<Tower>().Disable();
        location3.GetComponentInChildren<Tower>().Disable();
        i = -1;
        //Shot1
        status[0] = new DisplayOrdering();
        status[0].arr1Sta = false;
        status[0].arr2Sta = false;
        status[0].arr3Sta = false;
        status[0].arr4Sta = false;
        status[0].arr5Sta = false;
        status[0].arr6Sta = false;
        status[0].arr7Sta = false;
        status[0].arr8Sta = false;
        status[0].butSta = true;
        //Shot2
        status[1] = new DisplayOrdering();
        status[1].arr1Sta = true;
        status[1].arr2Sta = false;
        status[1].arr3Sta = false;
        status[1].arr4Sta = false;
        status[1].arr5Sta = false;
        status[1].arr6Sta = false;
        status[1].arr7Sta = false;
        status[1].arr8Sta = false;
        status[1].butSta = false;
        //Shot3
        status[2] = new DisplayOrdering();
        status[2].arr1Sta = true;
        status[2].arr2Sta = false;
        status[2].arr3Sta = false;
        status[2].arr4Sta = false;
        status[2].arr5Sta = false;
        status[2].arr6Sta = false;
        status[2].arr7Sta = false;
        status[2].arr8Sta = false;
        status[2].butSta = true;
        //Shot4
        status[3] = new DisplayOrdering();
        status[3].arr1Sta = false;
        status[3].arr2Sta = false;
        status[3].arr3Sta = false;
        status[3].arr4Sta = false;
        status[3].arr5Sta = false;
        status[3].arr6Sta = false;
        status[3].arr7Sta = false;
        status[3].arr8Sta = false;
        status[3].butSta = true;
        //Shot5
        status[4] = new DisplayOrdering();
        status[4].arr1Sta = false;
        status[4].arr2Sta = true;
        status[4].arr3Sta = false;
        status[4].arr4Sta = false;
        status[4].arr5Sta = false;
        status[4].arr6Sta = false;
        status[4].arr7Sta = false;
        status[4].arr8Sta = false;
        status[4].butSta = true;
        //Shot6
        status[5] = new DisplayOrdering();
        status[5].arr1Sta = false;
        status[5].arr2Sta = true;
        status[5].arr3Sta = false;
        status[5].arr4Sta = false;
        status[5].arr5Sta = false;
        status[5].arr6Sta = false;
        status[5].arr7Sta = false;
        status[5].arr8Sta = false;
        status[5].butSta = true;
        //Shot7
        status[6] = new DisplayOrdering();
        status[6].arr1Sta = false;
        status[6].arr2Sta = false;
        status[6].arr3Sta = false;
        status[6].arr4Sta = false;
        status[6].arr5Sta = false;
        status[6].arr6Sta = false;
        status[6].arr7Sta = false;
        status[6].arr8Sta = false;
        status[6].butSta = false;
        //Shot8
        status[7] = new DisplayOrdering();
        status[7].arr1Sta = false;
        status[7].arr2Sta = false;
        status[7].arr3Sta = false;
        status[7].arr4Sta = false;
        status[7].arr5Sta = false;
        status[7].arr6Sta = false;
        status[7].arr7Sta = false;
        status[7].arr8Sta = false;
        status[7].butSta = false;
        //Shot9
        status[8] = new DisplayOrdering();
        status[8].arr1Sta = false;
        status[8].arr2Sta = false;
        status[8].arr3Sta = false;
        status[8].arr4Sta = false;
        status[8].arr5Sta = true;
        status[8].arr6Sta = false;
        status[8].arr7Sta = false;
        status[8].arr8Sta = false;
        status[8].butSta = true;
        //Shot10
        status[9] = new DisplayOrdering();
        status[9].arr1Sta = false;
        status[9].arr2Sta = false;
        status[9].arr3Sta = false;
        status[9].arr4Sta = false;
        status[9].arr5Sta = true;
        status[9].arr6Sta = false;
        status[9].arr7Sta = false;
        status[9].arr8Sta = false;
        status[9].butSta = true;
        //Shot11
        status[10] = new DisplayOrdering();
        status[10].arr1Sta = false;
        status[10].arr2Sta = false;
        status[10].arr3Sta = false;
        status[10].arr4Sta = false;
        status[10].arr5Sta = true;
        status[10].arr6Sta = false;
        status[10].arr7Sta = false;
        status[10].arr8Sta = false;
        status[10].butSta = true;
        //Shot12
        status[11] = new DisplayOrdering();
        status[11].arr1Sta = false;
        status[11].arr2Sta = false;
        status[11].arr3Sta = true;
        status[11].arr4Sta = true;
        status[11].arr5Sta = false;
        status[11].arr6Sta = false;
        status[11].arr7Sta = false;
        status[11].arr8Sta = false;
        status[11].butSta = true;
        //Shot13
        status[12] = new DisplayOrdering();
        status[12].arr1Sta = false;
        status[12].arr2Sta = false;
        status[12].arr3Sta = true;
        status[12].arr4Sta = true;
        status[12].arr5Sta = false;
        status[12].arr6Sta = false;
        status[12].arr7Sta = false;
        status[12].arr8Sta = false;
        status[12].butSta = true;
        //Shot14
        status[13] = new DisplayOrdering();
        status[13].arr1Sta = false;
        status[13].arr2Sta = false;
        status[13].arr3Sta = false;
        status[13].arr4Sta = false;
        status[13].arr5Sta = false;
        status[13].arr6Sta = false;
        status[13].arr7Sta = false;
        status[13].arr8Sta = false;
        status[13].butSta = true;
        //Shot15
        status[14] = new DisplayOrdering();
        status[14].arr1Sta = true;
        status[14].arr2Sta = false;
        status[14].arr3Sta = false;
        status[14].arr4Sta = false;
        status[14].arr5Sta = false;
        status[14].arr6Sta = false;
        status[14].arr7Sta = false;
        status[14].arr8Sta = false;
        status[14].butSta = true;
        //Shot16
        status[15] = new DisplayOrdering();
        status[15].arr1Sta = false;
        status[15].arr2Sta = false;
        status[15].arr3Sta = false;
        status[15].arr4Sta = false;
        status[15].arr5Sta = false;
        status[15].arr6Sta = false;
        status[15].arr7Sta = false;
        status[15].arr8Sta = false;
        status[15].butSta = false;
        //Shot17
        status[16] = new DisplayOrdering();
        status[16].arr1Sta = false;
        status[16].arr2Sta = false;
        status[16].arr3Sta = false;
        status[16].arr4Sta = false;
        status[16].arr5Sta = false;
        status[16].arr6Sta = false;
        status[16].arr7Sta = false;
        status[16].arr8Sta = false;
        status[16].butSta = true;
        //Shot18
        status[17] = new DisplayOrdering();
        status[17].arr1Sta = false;
        status[17].arr2Sta = false;
        status[17].arr3Sta = false;
        status[17].arr4Sta = false;
        status[17].arr5Sta = false;
        status[17].arr6Sta = false;
        status[17].arr7Sta = true;
        status[17].arr8Sta = true;
        status[17].butSta = false;
        //Shot19
        status[18] = new DisplayOrdering();
        status[18].arr1Sta = false;
        status[18].arr2Sta = false;
        status[18].arr3Sta = false;
        status[18].arr4Sta = false;
        status[18].arr5Sta = false;
        status[18].arr6Sta = true;
        status[18].arr7Sta = false;
        status[18].arr8Sta = false;
        status[18].butSta = true;
        //Shot20
        status[19] = new DisplayOrdering();
        status[19].arr1Sta = false;
        status[19].arr2Sta = false;
        status[19].arr3Sta = false;
        status[19].arr4Sta = false;
        status[19].arr5Sta = false;
        status[19].arr6Sta = false;
        status[19].arr7Sta = false;
        status[19].arr8Sta = false;
        status[19].butSta = true;
    }

    public void End()
    {
        speech.SetActive(false);
        speechBubble.SetActive(false);
        arrow1.SetActive(false);
        arrow2.SetActive(false);
        arrow3.SetActive(false);
        arrow4.SetActive(false);
        arrow5.SetActive(false);
        arrow6.SetActive(false);
        arrow7.SetActive(false);
        arrow8.SetActive(false);
        continueButton.SetActive(false);
        dataButton.interactable = true;
        dataVisualButton.interactable = true;
        Tower[] towerLst = location1.GetComponentsInChildren<Tower>();
        foreach (Tower t in towerLst)
        {
            t.Enable();
        }
        location2.GetComponentInChildren<Tower>().Enable();
        location3.GetComponentInChildren<Tower>().Enable();
    }

    // Update is called once per frame
    public void Update()
    {
        if ((i == 1 && GameObject.Find("RR") == null) ||
               (i == 2 && GameObject.Find("RangedAttack").GetComponent<AttackRanged>().attackMed == null))
        {
            location1.GetComponentInChildren<Tower>().Enable();
            continueButton.SetActive(false);
        }
        else if(i == 6)
        {
            waveButton.interactable = true;
        }
        else if(i == 7)
        {
            waveButton.interactable = false;
            speech.SetActive(false);
            speechBubble.SetActive(false);
        }
        else if(i==8)
        {
            speech.SetActive(true);
            speechBubble.SetActive(true);
            waveButton.interactable = false;
        }
        else if(i==14 || i==16)
        {
            Tower[] towerLst = location1.GetComponentsInChildren<Tower>();
            foreach (Tower t in towerLst){
                t.Enable();
            }
            continueButton.SetActive(true);
        }
        else if (i < 18)
        {
            Tower[] towerLst = location1.GetComponentsInChildren<Tower>();
            foreach (Tower t in towerLst)
            {
                t.Disable();
            }
            continueButton.SetActive(true);
        }
        else if (i == 18)
        {
            continueButton.SetActive(false);
            waveButton.interactable = true;
        }
        else if (isEnd == false)
        {
            End();
            continueButton.SetActive(false);
            isEnd = true;
        }
    }

    public void NextShot()
    {
        if (i > 18)
        {
            i++;
            return;
        }
        i++;
        Text text = speech.GetComponent<Text>();
        text.text = dialogue[i];
        arrow1.SetActive(status[i].arr1Sta);
        arrow2.SetActive(status[i].arr2Sta);
        arrow3.SetActive(status[i].arr3Sta);
        arrow4.SetActive(status[i].arr4Sta);
        arrow5.SetActive(status[i].arr5Sta);
        arrow6.SetActive(status[i].arr6Sta);
        arrow7.SetActive(status[i].arr7Sta);
        arrow8.SetActive(status[i].arr8Sta);
        continueButton.SetActive(status[i].butSta);
    }

    public void WaveEnd(GameObject obj, string param)
    {
        if(!FindObjectOfType<LevelManager>().HasLost())
        {
            NextShot();
            
        }
    }
    public void WaveStart(GameObject obj, string param)
    {
        if (!FindObjectOfType<LevelManager>().HasLost())
        {
            NextShot();

        }
    }
}
