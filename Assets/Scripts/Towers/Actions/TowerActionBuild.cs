using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Build the tower.
/// </summary>
public class TowerActionBuild : TowerAction
{
    // Tower prefab for this icon
    public GameObject towerPrefab;
    // Name of tower (overwrite for hover)
    public string towerName;
	// Icon for disabled state
	public GameObject disabledIcon;
    // Icon for blocked state while player does not have enough currrency
    public GameObject blockedIcon;
    // Used if this action builds a double tower to set the colors automatically
    public GameObject medicineOne;
    public GameObject medicineTwo;

    // Text field for tower price
    private Text price;
	// Level manger has a list with allowed tower upgrades for this level.
	private LevelManager levelManager;
    // User interface manager allows to check current gold amount
    private UIGameView uiManager;

    /// <summary>
    /// Awake this instance.
    /// </summary>
    void Awake()
    {
        price = GetComponentInChildren<Text>();
		levelManager = FindObjectOfType<LevelManager>();
        uiManager = FindObjectOfType<UIGameView>();
		Debug.Assert(price && towerPrefab && enabledIcon && disabledIcon, "Wrong initial parameters");
        // Display tower price
        if (towerPrefab.gameObject.CompareTag("Tower")) {
            price.text = "50";
        } else {
            if (levelManager.level == "1" || levelManager.level == "2")
            {
                price.text = "150";

            } else if (levelManager.level == "2B")
            {
                price.text = "100";
            } else
            {
                if(towerPrefab.gameObject.CompareTag("RR"))
                {
                    price.text = "200";

                } else if (towerPrefab.gameObject.CompareTag("RS"))
                {
                    price.text = "150";

                } else if (towerPrefab.gameObject.CompareTag("SS"))
                {
                    price.text = "100";
                }
            }
        }
           // price.text = towerPrefab.GetComponent<Price>().price.ToString();
		if (levelManager.allowedTowers.Contains(towerPrefab) == true)
		{
			enabledIcon.SetActive(true);
			disabledIcon.SetActive(false);
		}
		else
		{
			enabledIcon.SetActive(false);
			disabledIcon.SetActive(true);
		}
    }

    /// <summary>
	/// Update this instance.
	/// </summary>
	void Update()
    {
        // Mask build icon with blocking icon if player has not anough gold
        if (enabledIcon == true && blockedIcon != null)
        {
            if (uiManager.GetCurrency() >= int.Parse(price.text))
            {
                blockedIcon.SetActive(false);
            }
            else
            {
                blockedIcon.SetActive(true);
            }
        }
    }

    /// <summary>
    /// Clicked this instance.
    /// </summary>
    protected override void Clicked()
	{
        // If player has enough gold
        if (blockedIcon == null || blockedIcon.activeSelf == false)
        {
            // Build the tower
            Tower tower = GetComponentInParent<Tower>();
            if (tower != null)
            {   if(medicineOne.CompareTag("Placeholder"))
                    tower.BuildTower(towerPrefab);
                else if (medicineOne != null && medicineTwo != null)
                    tower.BuildTower(towerPrefab, medicineOne, medicineTwo);
                else if (medicineOne != null)
                    tower.BuildTower(towerPrefab, medicineOne, null);
                else
                    tower.BuildTower(towerPrefab);
            }
        }
	}
}
