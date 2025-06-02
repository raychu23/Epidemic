using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GraphLabelLevel : MonoBehaviour
{
    private DataModel datam;
    public Text levelText;
    private string level = "";

    // Start is called before the first frame update
    void Start()
    {
        datam = FindObjectOfType<DataModel>();
        if (datam.level.Count == 0)
        {
            level = "";
        }
        else
        {
            level = "Level " + datam.level[0].ToString();
        }
        if (level.Equals("Level 0"))
        {
            levelText.text = "Tutorial";
        }
        else
        {
            levelText.text = level;
        }
    }
}
