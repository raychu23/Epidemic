#define Graph_And_Chart_PRO
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using ChartAndGraph;

public class BarChartFeed : MonoBehaviour {
    BarChart barChart;

    DataModel datModel;

    // List of towers
    private Tower[] lst;
    



    void Start () {
        barChart = GetComponent<BarChart>();
        datModel = DataModel.instance;
        // Find all towers
        lst = FindObjectsOfType<Tower>();

        if (barChart != null)
        {
        }
    }
    private void Update()
    {

        // Cure counts for meds
        int red_red = 0;
        int red_blue = 0;
        int blue_blue = 0;
        int blue_red = 0;

        /*
        foreach (Tower t in lst)
        {
            AttackRanged att = t.GetComponentInChildren<AttackRanged>();
            if (att != null)
            {
                switch (att.attackMed)
                {
                    case Weakness.Red:
                        red_red += t.redCures;
                        red_blue += t.blueCures;
                        break;
                    case Weakness.Blue:
                        blue_red += t.redCures;
                        blue_blue += t.blueCures;
                        break;
                }
            }
        }
        */
        barChart.DataSource.SetValue("Red", "Red Virus", red_red);
        barChart.DataSource.SetValue("Red", "Blue Virus", red_blue);
        barChart.DataSource.SetValue("Blue", "Red Virus", blue_red);
        barChart.DataSource.SetValue("Blue", "Blue Virus", blue_blue);

        barChart.DataSource.MaxValue = Mathf.Max(red_blue, red_red, blue_blue, blue_red);
        if (barChart.DataSource.MaxValue == 0)
            barChart.DataSource.MaxValue = 1;


    }
}
