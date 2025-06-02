using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Building place for towers.
/// </summary>
public class BuildingPlace : MonoBehaviour
{
    public int pos;
    /*  Legacy from before DataModel Change
    public string tType;
    public string med;
    public int redShot;
    public int blueShot;
    public int redCured;
    public int blueCured;
    */
    /*
    private void OnEnable()
    {
        EventManager.StartListening("WaveEnd", WaveEnd);
        EventManager.StartListening("TowerChange", TowerChange);
    }

    private void OnDisable()
    {
        EventManager.StopListening("WaveEnd", WaveEnd);
        EventManager.StopListening("TowerChange", TowerChange);
    }
    */

    /*
    
    private void WaveEnd(GameObject obj, string param)
    {
        // Check for empty/LV0 turret
        if (this.gameObject.GetComponentInChildren<Tower>().gameObject.name != "L0")
            Read();
    }

    private void TowerChange(GameObject obj, string param)
    {
        if (obj == this.gameObject)
        {
            Read();
        }
    }

    private void Read()
    {
        Tower t = GetComponentInChildren<Tower>();
        AttackRanged rangedAttack = t.GetComponentInChildren<AttackRanged>();
        Weakness color = rangedAttack.damage;
        tType = t.gameObject.name;
        if (color == Weakness.Blue)
        {
            med = "blue";
        }
        else if (color == Weakness.Red)
        {
            med = "red";
        }
        else
        {
            med = "none";
        }
        redShot = t.redShots;
        blueShot = t.blueShots;
        redCured = t.redCures;
        blueCured = t.blueCures;
    }
    */
}
