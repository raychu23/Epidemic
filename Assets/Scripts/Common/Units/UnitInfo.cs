using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Unit info, displayed on click.
/// </summary>
public class UnitInfo : MonoBehaviour
{
    public string unitName;
    public Sprite primaryIcon;
    public string primaryText;
    public Sprite secondaryIcon;
    public string secondaryText;
    // Disables bottom hover panel
    public bool noBottomInfo;
    // Color
    public Color color;

    /*
    private void OnMouseOver()
    {
        EventManager.TriggerEvent("MouseInfo", GetComponentInParent<Tower>().gameObject, null);
    }

    private void OnMouseExit()
    {
        EventManager.TriggerEvent("MouseInfo", null, null);
    }

    private void OnMouseDown()
    {
        EventManager.TriggerEvent("MouseInfo", null, null);
    }
    */
}
