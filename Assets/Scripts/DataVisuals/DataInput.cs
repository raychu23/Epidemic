using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ChartAndGraph;
using UnityEngine.UI;


public class DataInput : MonoBehaviour
{
    public GraphChart chart;

    public Dropdown xAxis;
    public Dropdown yAxis;

    public Toggle showAverages;

    public Text yLabel;
    GameObject model;
    DataModel datam;
    private ClickModel clickmod;

    // Tracks how long the x-axis should be
    private int index;

    char[] changeArr;

    // The variables used on the horizontal axis
    // Example: bottomLevel = medicine
    string[] bottomLevel;

    /// <summary>
    /// Ran when scene starts.
    /// </summary>
    private void Start()
    {
        model = DataModel.instance.gameObject;
        if (model != null)
        {
            datam = model.GetComponent<DataModel>();
            clickmod = ClickModel.instance;
            ClearCategories();

            chart.HorizontalValueToStringMap.Add(0, "");

            // For now, we only ever have two variables on the bottom level
            bottomLevel = new string[2];

            // Setup horizontal axis
            index = 0;

            if (datam.enemies.Count == 1)
            {
                //TODO Hard coded for now until a better solution is found
                chart.HorizontalValueToStringMap.Add(1, "Round");
                chart.HorizontalValueToStringMap.Add(2, "Square");
                chart.HorizontalValueToStringMap.Add(3, "Round");
                chart.HorizontalValueToStringMap.Add(4, "Square");
                index = 4;

            }
            else
            {
                // Setup enemy names on the bottom
                while (index < datam.enemies.Count * 2)
                {
                    int temp = index % datam.enemies.Count;
                    chart.HorizontalValueToStringMap.Add(index + 1, datam.enemies[temp].name);
                    index++;
                }
            }

            // Increment so index is valid
            index++;
            chart.HorizontalValueToStringMap.Add(index, "");

            // Sets the beginning width and height with invisible points
            SetGraphView();

            ChangeGraph("00");

            //Debug.Log("End of Start");
        }
    }

    /// <summary>
    /// Decides which topLevel graph change is needed
    /// </summary>
    /// <param name="change"></param>
    public void ChangeGraph(string change)
    {
        changeArr = change.ToCharArray();

        List<string> categoryVals;

        if (xAxis.value == 0)
        {
            if (changeArr[0] == '1')
            {
                clickmod.medicineCount++;
            }
            bottomLevel[0] = datam.med1.name;
            bottomLevel[1] = datam.med2.name;
            categoryVals = datam.medicine;

            //ChangeMedGraph();
        }
        else
        {
            if (changeArr[0] == '1')
            {
                clickmod.turretTypeCount++;
            }
            bottomLevel[0] = "Pillshooter";
            bottomLevel[1] = "BoomThrow";
            categoryVals = datam.turretType;

            //ChangeTurretGraph();
        }


        if (model != null)
        {
            if (datam.enemies.Count == 1)
                ChangeGraphTurretType(categoryVals);
            else
                ChangeGraphEnemies(categoryVals);
        }
    }

    /// <summary>
    /// Decides how the graph should be updated in the case of topLevel turretType
    /// </summary>
    /// <param name="change"></param>
    private void ChangeGraphTurretType(List<string> categoryVals)
    {
        int avg1 = 0;
        int avg2 = 0;
        int avg3 = 0;
        int avg4 = 0;
        int max = 0;
        int count1 = 0;
        int count2 = 0;
        int count3 = 0;
        int count4 = 0;
        GameObject.Find("Title").GetComponent<Text>().text = yAxis.options[yAxis.value].text;
        chart.DataSource.StartBatch();
        ClearCategories();

        List<int> values1 = UpdateClickData();

        SetGraphView();



        for (int i = 0; i < values1.Count; i++)
        {
            if (categoryVals[i] == bottomLevel[0])
            {
                if (datam.turretType[i] == "Round")
                {
                    chart.DataSource.AddPointToCategory("Red", 1, values1[i]);
                    avg1 += values1[i];
                    count1++;
                    max = Mathf.Max(values1[i], max);
                }
                else if (datam.turretType[i] == "Square")
                {
                    chart.DataSource.AddPointToCategory("Red", 2, values1[i]);
                    avg2 += values1[i];
                    count2++;
                    max = Mathf.Max(values1[i], max);
                }
            }
            else if (categoryVals[i] == bottomLevel[1])
            {
                if (datam.turretType[i] == "Round")
                {
                    chart.DataSource.AddPointToCategory("Blue", 3, values1[i]);
                    avg3 += values1[i];
                    count3++;
                    max = Mathf.Max(values1[i], max);
                }
                else if (datam.turretType[i] == "Square")
                {
                    chart.DataSource.AddPointToCategory("Blue", 4, values1[i]);
                    avg4 += values1[i];
                    count4++;
                    max = Mathf.Max(values1[i], max);
                }
            }
        }
        if (GameObject.Find("Title").GetComponent<Text>().text != "Percent Destroyed")
        {
            max = ((max / 4) + 1) * 4;
            chart.DataSource.AddPointToCategory("Empty", 0, max);
        }
        if (showAverages.isOn)
        {
            if (avg1 != 0 && count1 != 0)
                chart.DataSource.AddPointToCategory("AvgRed", 1, avg1 / count1);
            if (avg2 != 0 && count2 != 0)
                chart.DataSource.AddPointToCategory("AvgBlue", 2, avg2 / count2);
            if (avg3 != 0 && count3 != 0)
                chart.DataSource.AddPointToCategory("AvgRed", 3, avg3 / count3);
            if (avg4 != 0 && count4 != 0)
                chart.DataSource.AddPointToCategory("AvgBlue", 4, avg4 / count4);
        }
        chart.DataSource.EndBatch();
    }

    /// <summary>
    /// Decides how the graph should be updated in the case of topLevel enemies
    /// </summary>
    /// <param name="change"></param>
    private void ChangeGraphEnemies(List<string> categoryVals)
    {
        int avg1 = 0;
        int avg2 = 0;
        int avg3 = 0;
        int avg4 = 0;
        int max = 0;
        int count1 = 0;
        int count2 = 0;
        int count3 = 0;
        int count4 = 0;
        GameObject.Find("Title").GetComponent<Text>().text = yAxis.options[yAxis.value].text;
        chart.DataSource.StartBatch();
        ClearCategories();

        List<int> values1 = UpdateClickData();

        SetGraphView();



        for (int i = 0; i < values1.Count; i++)
        {
            if (categoryVals[i] == bottomLevel[0])
            {
                if (datam.virus[i] == "red")
                {
                    chart.DataSource.AddPointToCategory("Red", 1, values1[i]);
                    avg1 += values1[i];
                    count1++;
                    max = Mathf.Max(values1[i], max);
                }
                else if (datam.virus[i] == "blue")
                {
                    chart.DataSource.AddPointToCategory("Blue", 2, values1[i]);
                    avg2 += values1[i];
                    count2++;
                    max = Mathf.Max(values1[i], max);
                }
            }
            else if (categoryVals[i] == bottomLevel[1])
            {
                if (datam.virus[i] == "red")
                {
                    chart.DataSource.AddPointToCategory("Red", 3, values1[i]);
                    avg3 += values1[i];
                    count3++;
                    max = Mathf.Max(values1[i], max);
                }
                else if (datam.virus[i] == "blue")
                {
                    chart.DataSource.AddPointToCategory("Blue", 4, values1[i]);
                    avg4 += values1[i];
                    count4++;
                    max = Mathf.Max(values1[i], max);
                }
            }
        }
        if (GameObject.Find("Title").GetComponent<Text>().text != "Percent Destroyed")
        {
            max = ((max / 4) + 1) * 4;
            chart.DataSource.AddPointToCategory("Empty", 0, max);
        }
        if (showAverages.isOn)
        {
            if (avg1 != 0 && count1 != 0)
                chart.DataSource.AddPointToCategory("AvgRed", 1, avg1 / count1);
            if (avg2 != 0 && count2 != 0)
                chart.DataSource.AddPointToCategory("AvgBlue", 2, avg2 / count2);
            if (avg3 != 0 && count3 != 0)
                chart.DataSource.AddPointToCategory("AvgRed", 3, avg3 / count3);
            if (avg4 != 0 && count4 != 0)
                chart.DataSource.AddPointToCategory("AvgBlue", 4, avg4 / count4);
        }
        chart.DataSource.EndBatch();
    }



    /// <summary>
    /// Plots invisible points on the graph to change the viewport required by the variables.
    /// </summary>
    private void SetGraphView()
    {
        chart.DataSource.AddPointToCategory("Empty", 0, 0);
        chart.DataSource.AddPointToCategory("Empty", index, 0);
        chart.DataSource.AddPointToCategory("Empty", 0, 10);
    }

    /// <summary>
    /// Updates click data and returns the data that will need to be plotted
    /// </summary>
    /// <returns></returns>
    private List<int> UpdateClickData()
    {
        switch (yAxis.value)
        {
            case 0:
                if (changeArr[1] == '1')
                    clickmod.shotsCount++;
                return datam.shot;
            case 1:
                if (changeArr[1] == '1')
                    clickmod.destroyedCount++;
                return datam.destroyed;
            case 2:
                List<int> percentDestroyed = new List<int>();
                for (int i = 0; i < datam.shot.Count; i++)
                {
                    percentDestroyed.Add((int)((Mathf.Round(100 * (float)datam.destroyed[i] / (float)datam.shot[i]))));
                }
                if (changeArr[1] == '1')
                    clickmod.percentDestroyedCount++;
                return percentDestroyed;
            default:
                return datam.shot;
        }
    }

    /// <summary>
    /// Updates clickmod. Either adds 1 to the averages count if the averages option is on, or does nothing.
    /// </summary>
    public void updateAveragesCount()
    {
        if (model != null)
        {
            if (showAverages.isOn)
                clickmod.showAveragesCount++;
        }
    }

    /// <summary>
    /// Clears all categories
    /// </summary>
    private void ClearCategories()
    {
        chart.DataSource.ClearCategory("Empty");
        chart.DataSource.ClearCategory("Red");
        chart.DataSource.ClearCategory("Blue");
        chart.DataSource.ClearCategory("Purple");
        chart.DataSource.ClearCategory("AvgRed");
        chart.DataSource.ClearCategory("AvgBlue");
        chart.DataSource.ClearCategory("AvgPurple");
    }
}
