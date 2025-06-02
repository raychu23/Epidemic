using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Select a medicine.
/// </summary>
public class TowerActionMed : TowerAction
{
    // Med prefab for this icon
    public GameObject medPrefab;
    // Icon for disabled state
    public GameObject disabledIcon;
    // Icon for blocked state while player does not have enough currrency
    public GameObject blockedIcon;

    // Text field for med price
    private Text price;
    // Tower of this action
    Tower tower;
    // User interface manager allows to check current gold amount
    private UIGameView uiManager;


    /// <summary>
    /// Awake this instance.
    /// </summary>
    void Awake()
    {
        tower = GetComponentInParent<Tower>();
        price = GetComponentInChildren<Text>();
        uiManager = FindObjectOfType<UIGameView>();
        Debug.Assert(price && medPrefab && enabledIcon, "Wrong initial parameters");
        // Display med price
        price.text = medPrefab.GetComponent<Price>().price.ToString();
    }

    /// <summary>
	/// Update this instance.
	/// </summary>
	void Update()
    {
        // Mask build icon with blocking icon if player has not enough gold
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
        // Change med of the tower
        if (tower != null)
        {
            tower.ChangeMed(medPrefab);
        }
    }
}
