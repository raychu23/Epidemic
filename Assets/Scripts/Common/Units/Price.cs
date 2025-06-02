using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Price of tower or unit.
/// </summary>
public class Price : MonoBehaviour
{
    // Level manger has a list with allowed tower upgrades for this level.
    //private LevelManager levelManager;
    // Price in currency
    public int price;
    // Sell price (for towers)
    public int sellPrice;


    //private void Awake()
    //{
    //    levelManager = FindObjectOfType<LevelManager>();
    //    if(levelManager.level == "1" || levelManager.level == "2")
    //    {
    //        price -= 30;
    //    }
    //}
}


