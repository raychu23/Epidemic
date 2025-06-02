using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Show unit info on special sheet.
/// </summary>
public class ShowInfo : MonoBehaviour
{
    // Name of unit
    public Text unitName;
    // Primary icon for displaing
    public Image primaryIcon;
    // Primary text for displaing
    public Text primaryText;
    // Secondary icon for displaing
    public Image secondaryIcon;
    // Secondary text for displaing
    public Text secondaryText;
    // Bottom bar
    public GameObject bottom;
    // Ranged attack icon for displaying
    public Sprite rangedAttackIcon;
    // Red Enemy icon
    public Sprite redEnemyIcon;
    // Blue Enemy icon
    public Sprite blueEnemyIcon;
    // Purple Enemy icon
    public Sprite purpleEnemyIcon;
    // Cooldown icon for displaying
    public Sprite cooldownIcon;

    // Offset for info
    private float xOffset = 20f;
    private float yOffset = 25f;

    /// <summary>
    /// Raises the destroy event.
    /// </summary>
    void OnDestroy()
    {
        EventManager.StopListening("MouseInfo", MouseInfo);
        // Old Click System
        //EventManager.StopListening("UserClick", MouseInfo);
    }

    /// <summary>
    /// Awake this instance.
    /// </summary>
    void Awake()
    {
        Debug.Assert(unitName && primaryIcon && primaryText && secondaryIcon && secondaryText, "Wrong intial settings");
    }

    /// <summary>
    /// Start this instance.
    /// </summary>
    void Start()
    {
        EventManager.StartListening("MouseInfo", MouseInfo);
        // Old Click System
        //EventManager.StartListening("UserClick", MouseInfo);
        HideUnitInfo();
    }

    /// <summary>
    /// Shows the unit info.
    /// </summary>
    /// <param name="info">Info.</param>
    public void ShowUnitInfo(UnitInfo info, GameObject obj)
    {

        // Check what the bottom panel should display
        if (info.noBottomInfo)
            bottom.SetActive(false);
        else
        {
            bottom.SetActive(true);
            if (info.primaryIcon != null || info.secondaryIcon != null || info.primaryText != "" || info.secondaryText != "")
            {
                primaryText.text = info.primaryText;
                secondaryText.text = info.secondaryText;

                if (info.primaryIcon != null)
                {
                    primaryIcon.sprite = info.primaryIcon;
                    primaryIcon.gameObject.SetActive(true);
                }

                if (info.secondaryIcon != null)
                {
                    secondaryIcon.sprite = info.secondaryIcon;
                    secondaryIcon.gameObject.SetActive(true);
                }
            }
            else
            {
                Attack attack = obj.GetComponentInChildren<Attack>();

                // Automaticaly set primary icon and text
                if (attack != null)
                {
                    primaryText.text = attack.cooldown.ToString();
                    primaryIcon.sprite = cooldownIcon;
                    primaryIcon.gameObject.SetActive(true);
                }


                if (attack is AttackRanged)
                {
                    secondaryText.text = attack.GetComponent<CircleCollider2D>().radius.ToString();

                    secondaryIcon.sprite = rangedAttackIcon;
                    secondaryIcon.gameObject.SetActive(true);
                }
            }
        }
            

        // Main panel name
        if (info.unitName == "Building Place")
        {
            unitName.text = "Location " + obj.GetComponentInParent<BuildingPlace>().pos;
        }
        else if (info.unitName != "")
        {
            unitName.text = info.unitName;
        }
        else
        {
            unitName.text = obj.name;
        }

        
        MoveInfo();
    }

    /// <summary>
    /// Displays the incoming enemy types
    /// </summary>
    /// <param name="wave"></param>
    private void ShowWaveInfo(int wave)
    {
        bottom.SetActive(true);
        EnemyNumbers numbers = FindObjectOfType<EnemyNumbers>();

        unitName.text = "Next Wave:";

        if (numbers.numRed.Length != 0)
        {
            primaryIcon.sprite = redEnemyIcon;
            primaryIcon.gameObject.SetActive(true);
            primaryText.text = numbers.numRed[wave].ToString();
        }
        
        if (numbers.numBlue.Length != 0)
        {
            secondaryIcon.sprite = blueEnemyIcon;
            secondaryIcon.gameObject.SetActive(true);
            secondaryText.text = numbers.numBlue[wave].ToString();
        }

        if (numbers.numPurple.Length != 0)
        {
            primaryIcon.sprite = purpleEnemyIcon;
            primaryIcon.gameObject.SetActive(true);
            primaryText.text = numbers.numPurple[wave].ToString();
        }
        

        MoveInfo();
    }

    /// <summary>
    /// Shows info on the hovered medicine
    /// </summary>
    private void ShowMedInfo(TowerActionMed med)
    {
        // Print the color in the 'g' format (string)
        unitName.text = med.medPrefab.GetComponent<Medicine>().name;
        bottom.SetActive(false);

        MoveInfo();
    }

    /// <summary>
    /// Shows info on the hovered sell
    /// </summary>
    private void ShowSellInfo(Price p)
    {
        bottom.SetActive(false);
        unitName.text = "Sell For: " + p.sellPrice;

        MoveInfo();
    }

    /// <summary>
    /// Shows information according to sent object (currency/wave/health)
    /// </summary>
    /// <param name="obj"></param>
    /// <param name="information"></param>
    private void ShowUIText(GameObject obj, Text information)
    {
        bottom.SetActive(false);
        switch (obj.name)
        { 
            case "CurrencyInfo":
                unitName.text = "Current Funds: " + information.text;
                break;
            case "WavesInfo":
                unitName.text = "Current Wave: " + information.text;
                break;
            case "DefeatAttempts":
                unitName.text = "Health: " + information.text;
                break;
        }

        MoveInfo();

    }

    private void ShowName(GameObject obj)
    {
        bottom.SetActive(false);
        unitName.text = obj.name;

        MoveInfo();
    }

    private void ShowName(string name)
    {
        bottom.SetActive(false);
        unitName.text = name;

        MoveInfo();
    }

    /// <summary>
    /// Moves the info panel to the correct position
    /// </summary>
    private void MoveInfo()
    {
        // Get and mouse position and shift down
        Vector3 pos = Input.mousePosition;
        pos.x += xOffset;
        pos.y -= yOffset;

        // Check if it is out of screen and move if needed
        Vector3[] corners = new Vector3[4];
        gameObject.GetComponent<RectTransform>().GetWorldCorners(corners);

        // Get rect width and height
        float width = corners[2].x - corners[0].x;
        float height = corners[1].y - corners[0].y;

        // Check X
        float distPastX = pos.x + width - Screen.width;
        if (distPastX > 0)
        {
            pos = new Vector3(pos.x - distPastX, pos.y, pos.z);
        }
        // Check Y
        float distPastY = pos.y - height;
        if (distPastY < 0)
        {
            pos = new Vector3(pos.x, pos.y - distPastY, pos.z);
        }

        gameObject.transform.position = pos;
        gameObject.SetActive(true);
    }

    /// <summary>
    /// Hides the unit info.
    /// </summary>
    public void HideUnitInfo()
    {
        unitName.text = primaryText.text = secondaryText.text = "";
        primaryIcon.gameObject.SetActive(false);
        secondaryIcon.gameObject.SetActive(false);
        gameObject.SetActive(false);
    }

    /// <summary>
    /// User click handler.
    /// </summary>
    /// <param name="obj">Object.</param>
    /// <param name="param">Parameter.</param>
    private void MouseInfo(GameObject obj, string param)
    {
        HideUnitInfo();
        if (obj != null)
        {
            // Clicked object has info for displaing
            UnitInfo unitInfo = obj.GetComponentInChildren<UnitInfo>();
            TowerActionBuild actionBuild = obj.GetComponent<TowerActionBuild>();
            TowerActionMed actionMed = obj.GetComponent<TowerActionMed>();
            TowerActionSell actionSell = obj.GetComponent<TowerActionSell>();
            WaveStart start = obj.GetComponent<WaveStart>();
            Text txt = obj.GetComponentInChildren<Text>();
            if (unitInfo != null)
            {
                ShowUnitInfo(unitInfo, obj);
            }
            else if (actionBuild != null)
            {
                if (actionBuild.name != null)
                    ShowName(actionBuild.towerName);
                else
                    ShowUnitInfo(actionBuild.towerPrefab.GetComponentInChildren<UnitInfo>(), actionBuild.towerPrefab);
            }
            else if (actionMed != null)
            {
                ShowMedInfo(actionMed);
            }
            else if (actionSell != null)
            {
                ShowSellInfo(actionSell.GetComponentInParent<Price>());
            }
            else if (start != null && start.GetCurrentWave() < FindObjectOfType<LevelManager>().waves)
            {
                ShowWaveInfo(start.GetCurrentWave());
            }
            else if (txt != null)
            {
                ShowUIText(obj, txt);
            }
            else
            {
                ShowName(obj);
            }
        }
    }
}
