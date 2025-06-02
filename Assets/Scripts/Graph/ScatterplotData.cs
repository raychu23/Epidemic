using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ChartAndGraph;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Data;

public class ScatterplotData : MonoBehaviour
{
    struct point
    {
        public string ID;
        public string level;
        public int wave;
        public int location;
        public int total_shots;
        public int destroyed;
        public string turret_type;
        public string meds;
        public string virus;

        public float Get(int i)
        {
            switch (i)
            {
                case 2:
                    return wave;
                case 3:
                    return location;
                case 4:
                    return destroyed/total_shots;
                
            }
            return -1;
        }

        public string GetStr(int i)
        {
            switch (i)
            {
                case 1:
                    return level;
                case 6:
                    return turret_type;
                case 7:
                    return meds;
                case 8:
                    return virus;
                case 9:
                    return ID;
                
            }
            return "";
        }

    }
    public GraphChart chart;

    public Dropdown xAxis;
    public Dropdown yAxis;
    public Dropdown dataSet;
    public Dropdown colorBy;
    public Dropdown levelDd;

    public GameObject medsLegend;
    public GameObject locLegend;
    public GameObject waveLegend;
    public GameObject virusLegend;
    public GameObject typeLegend;

    public Toggle showAverages;

    public TextMeshProUGUI xLabel;
    public TextMeshProUGUI yLabel;

    //Chart aspects
    private HorizontalAxis hor;

    private List<point> playerPoints = new List<point>();
    //private point[] groupPoints;

    bool ave = false;

    private float[,] xVal = new float[23,23];
    private double[,] sumVal = new double[23, 23];
    private float[,] countVal = new float[23, 23];

    // Start is called before the first frame update
    void Start()
    {
        //Get the graph chart object
        GameObject graphChart = GameObject.Find("GraphChart");
        hor = graphChart.GetComponent<HorizontalAxis>();
        StartCoroutine(GetDatabaseValues());
        
    }

    public void ChangeAxes()
    {
        int xValues = 3;
        int cValues = 0;
        int dValues = 0;
        string lValues = "0";
        
        switch (xAxis.value)
        {
            //x axis is Meds
            case 0:
                xValues = 7;
                xLabel.SetText("Meds");
                break;
            //x axis is Virus
            case 1:
                xValues = 8;
                xLabel.SetText("Virus");
                break;
            //x axis is Turret Type
            case 2:
                xValues = 6;
                xLabel.SetText("Turret Type");
                break;
            //x axis is Wave
            case 3:
                xValues = 2;
                xLabel.SetText("Wave");
                break;
            //x axis is Location
            case 4:
                xValues = 3;
                xLabel.SetText("Location");
                break;
        }
        switch(dataSet.value)
        {
            case 0:
                dValues = 0;
                break;
            case 1:
                dValues = 1;
                break;
            default:
                break;
        }

        switch(colorBy.value)
        {
            //no colorBy
            case 0:
                cValues = 0;
                medsLegend.SetActive(false);
                locLegend.SetActive(false);
                waveLegend.SetActive(false);
                virusLegend.SetActive(false);
                typeLegend.SetActive(false);
                break;
            //colorBy is Meds
            case 1:
                cValues = 7;
                medsLegend.SetActive(true);
                locLegend.SetActive(false);
                waveLegend.SetActive(false);
                virusLegend.SetActive(false);
                typeLegend.SetActive(false);
                break;
            //colorBy is Virus
            case 2:
                cValues = 8;
                medsLegend.SetActive(false);
                locLegend.SetActive(false);
                waveLegend.SetActive(false);
                virusLegend.SetActive(true);
                typeLegend.SetActive(false);
                break;
            //colorBy is Turret Type
            case 3:
                cValues = 6;
                medsLegend.SetActive(false);
                locLegend.SetActive(false);
                waveLegend.SetActive(false);
                virusLegend.SetActive(false);
                typeLegend.SetActive(true);
                break;
            //colorBy is Wave
            case 4:
                cValues = 2;
                medsLegend.SetActive(false);
                locLegend.SetActive(false);
                waveLegend.SetActive(true);
                virusLegend.SetActive(false);
                typeLegend.SetActive(false);
                break;
            //colorBy is Location
            case 5:
                cValues = 3;
                medsLegend.SetActive(false);
                locLegend.SetActive(true);
                waveLegend.SetActive(false);
                virusLegend.SetActive(false);
                typeLegend.SetActive(false);
                break;
            default:
                break;
        }

        switch (levelDd.value)
        {
            //level 1
            case 0:
                lValues = "1";
                break;
            //level 2
            case 1:
                lValues = "2";
                break;
            //level 2b
            case 2:
                lValues = "2B";
                break;
            //level 3
            case 3:
                lValues = "3";
                break;
            //level 3b
            case 4:
                lValues = "3B";
                break;
            //level 4
            case 5:
                lValues = "4";
                break;
            //level 4b
            case 6:
                lValues = "4B";
                break;
            //level 5
            case 7:
                lValues = "5";
                break;
            //level 5b
            case 8:
                lValues = "5B";
                break;
            default:
                break;

        }

        if (showAverages.isOn)
        {
            ave = true;
        }
        else
        {
            ave = false;
        }
        yLabel.SetText("Percent Destroyed");

        RewriteData(xValues, cValues, lValues, dValues, ave);
    }



    private void RewriteData(int xData, int cData, string lData, int dData, bool ave)
    {
        chart.DataSource.StartBatch();
        // category is for color-by
        chart.DataSource.ClearCategory("Empty");
        chart.DataSource.ClearCategory("Round");
        chart.DataSource.ClearCategory("Square");
        chart.DataSource.ClearCategory("category");
        chart.DataSource.ClearCategory("loc1");
        chart.DataSource.ClearCategory("loc2");
        chart.DataSource.ClearCategory("loc3");
        chart.DataSource.ClearCategory("loc4");
        chart.DataSource.ClearCategory("loc5");
        chart.DataSource.ClearCategory("loc6");
        chart.DataSource.ClearCategory("loc7");
        chart.DataSource.ClearCategory("wave1");
        chart.DataSource.ClearCategory("wave2");
        chart.DataSource.ClearCategory("wave3");
        chart.DataSource.ClearCategory("wave4");
        chart.DataSource.ClearCategory("wave5");
        chart.DataSource.ClearCategory("Med R");
        chart.DataSource.ClearCategory("Med B");
        chart.DataSource.ClearCategory("Med P");
        chart.DataSource.ClearCategory("Med G");
        chart.DataSource.ClearCategory("Med Y");
        chart.DataSource.ClearCategory("Med O");
        chart.DataSource.ClearCategory("red");
        chart.DataSource.ClearCategory("blue");
        chart.DataSource.ClearCategory("purple");
        chart.DataSource.ClearCategory("1");
        chart.DataSource.ClearCategory("2");
        chart.DataSource.ClearCategory("2B");
        chart.DataSource.ClearCategory("3");
        chart.DataSource.ClearCategory("3B");
        chart.DataSource.ClearCategory("4");
        chart.DataSource.ClearCategory("4B");
        chart.DataSource.ClearCategory("5");
        chart.DataSource.ClearCategory("5B");
        chart.DataSource.ClearCategory("type");
        chart.DataSource.ClearCategory("meds");
        chart.DataSource.ClearCategory("virus");
        chart.DataSource.ClearCategory("wave");
        chart.DataSource.ClearCategory("location");
        chart.DataSource.ClearCategory("level");
        chart.DataSource.ClearCategory("avg");

        hor.MainDivisions.UnitsPerDivision = 1;

        List<int> l = new List<int>();
        List<string> ls = new List<string>();

        ///////////////////  set up axis   ////////////////////////
        if (xData == 2)
        {
            hor.MainDivisions.UnitsPerDivision = 1;
            
            for (int i = 0; i < playerPoints.Count; i++)
            {
                if (dData == 0)
                {
                    if (playerPoints[i].ID.CompareTo(Global.playerID) == 0)
                    {
                        if (playerPoints[i].level.CompareTo(lData) == 0)
                        {
                            if (!l.Contains(playerPoints[i].wave))
                            {
                                l.Add(playerPoints[i].wave);
                            }
                        }
                    }
                }
                else
                {
                    if (playerPoints[i].level.CompareTo(lData) == 0)
                    {
                        if (!l.Contains(playerPoints[i].wave))
                        {
                            l.Add(playerPoints[i].wave);
                        }
                    }
                }
            }
            l.Sort();
            chart.HorizontalValueToStringMap[0] = "";
            for (int i = 0; i < l.Count; i++)
            {
                chart.HorizontalValueToStringMap[i + 1] = l[i].ToString();
            }
            chart.HorizontalValueToStringMap[l.Count + 1] = "";
            chart.DataSource.AddPointToCategory("Empty", 0, 0);
            chart.DataSource.AddPointToCategory("Empty", l.Count + 1, 0);
            chart.DataSource.AddPointToCategory("Empty", l.Count + 1, 100);
            chart.DataSource.AddPointToCategory("Empty", 0, 100);
        }
        else if (xData == 3)
        {
            hor.MainDivisions.UnitsPerDivision = 1;
            for(int i = 0; i < playerPoints.Count; i++)
            {
                if (dData == 0)
                {
                    if (playerPoints[i].ID.CompareTo(Global.playerID) == 0)
                    {
                        if (playerPoints[i].level.CompareTo(lData) == 0)
                        {
                            if (!l.Contains(playerPoints[i].location))
                            {
                                l.Add(playerPoints[i].location);
                            }
                        }
                    }
                }
                else
                {
                    if (playerPoints[i].level.CompareTo(lData) == 0)
                    {
                        if (!l.Contains(playerPoints[i].location))
                        {
                            l.Add(playerPoints[i].location);
                        }
                    }
                }
            }
            l.Sort();
            chart.HorizontalValueToStringMap[0] = "";
            for (int i = 0; i < l.Count; i++)
            {
                chart.HorizontalValueToStringMap[i+1] = l[i].ToString();
            }
            chart.HorizontalValueToStringMap[l.Count + 1] = "";
            chart.DataSource.AddPointToCategory("Empty", 0, 0);
            chart.DataSource.AddPointToCategory("Empty", l.Count + 1, 0);
            chart.DataSource.AddPointToCategory("Empty", l.Count + 1, 100);
            chart.DataSource.AddPointToCategory("Empty", 0, 100);
        }
        else if (xData == 6)
        {
            hor.MainDivisions.UnitsPerDivision = 1;
            chart.HorizontalValueToStringMap[0] = "";
            chart.HorizontalValueToStringMap[1] = "Round";
            chart.HorizontalValueToStringMap[2] = "Square";
            chart.HorizontalValueToStringMap[3] = "";
            chart.DataSource.AddPointToCategory("Empty", 0, 0);
            chart.DataSource.AddPointToCategory("Empty", 3, 0);
            chart.DataSource.AddPointToCategory("Empty", 3, 100);
            chart.DataSource.AddPointToCategory("Empty", 0, 100);
        }
        else if (xData == 7)
        {
            hor.MainDivisions.UnitsPerDivision = 1;
            List<string> temp = new List<string>();
            for (int i = 0; i < playerPoints.Count; i++)
            {
                if (dData == 0)
                {
                    if (playerPoints[i].ID.CompareTo(Global.playerID) == 0)
                    {
                        if (playerPoints[i].level.CompareTo(lData) == 0)
                        {
                            if (!temp.Contains(playerPoints[i].meds))
                            {
                                temp.Add(playerPoints[i].meds);
                            }
                        }
                    }
                } else
                {
                    if (playerPoints[i].level.CompareTo(lData) == 0)
                    {
                        if (!temp.Contains(playerPoints[i].meds))
                        {
                            temp.Add(playerPoints[i].meds);
                        }
                    }
                }
            }
            if(temp.Contains("Med R"))
            {
                ls.Add("Med R");
            }
            if (temp.Contains("Med B"))
            {
                ls.Add("Med B");
            }
            if (temp.Contains("Med P"))
            {
                ls.Add("Med P");
            }
            if (temp.Contains("Med G"))
            {
                ls.Add("Med G");
            }
            if (temp.Contains("Med Y"))
            {
                ls.Add("Med Y");
            }
            if (temp.Contains("Med O"))
            {
                ls.Add("Med O");
            }
            chart.HorizontalValueToStringMap[0] = "";
            for (int i = 0; i < ls.Count; i++)
            {
                chart.HorizontalValueToStringMap[i + 1] = ls[i];
            }
            chart.HorizontalValueToStringMap[ls.Count + 1] = "";
            chart.DataSource.AddPointToCategory("Empty", 0, 0);
            chart.DataSource.AddPointToCategory("Empty", ls.Count + 1, 0);
            chart.DataSource.AddPointToCategory("Empty", ls.Count + 1, 100);
            chart.DataSource.AddPointToCategory("Empty", 0, 100);
        }
        else if (xData == 8)
        {
            hor.MainDivisions.UnitsPerDivision = 1;
            List<string> temp = new List<string>();
            for (int i = 0; i < playerPoints.Count; i++)
            {
                if (dData == 0)
                {
                    if (playerPoints[i].ID.CompareTo(Global.playerID) == 0)
                    {
                        if (playerPoints[i].level.CompareTo(lData) == 0)
                        {
                            if (!temp.Contains(playerPoints[i].virus))
                            {
                                temp.Add(playerPoints[i].virus);
                            }
                        }
                    }
                }
                else
                {
                    if (playerPoints[i].level.CompareTo(lData) == 0)
                    {
                        if (!temp.Contains(playerPoints[i].virus))
                        {
                            temp.Add(playerPoints[i].virus);
                        }
                    }
                }

            }
            if (temp.Contains("red"))
            {
                ls.Add("red");
            }
            if (temp.Contains("blue"))
            {
                ls.Add("blue");
            }
            if (temp.Contains("purple"))
            {
                ls.Add("purple");
            }
            chart.HorizontalValueToStringMap[0] = "";
            for (int i = 0; i < ls.Count; i++)
            {
                chart.HorizontalValueToStringMap[i + 1] = ls[i];
            }
            chart.HorizontalValueToStringMap[ls.Count + 1] = "";
            chart.DataSource.AddPointToCategory("Empty", 0, 0);
            chart.DataSource.AddPointToCategory("Empty", ls.Count + 1, 0);
            chart.DataSource.AddPointToCategory("Empty", ls.Count + 1, 100);
            chart.DataSource.AddPointToCategory("Empty", 0, 100);
        }


///////////////////  draw data   ////////////////////////

        if (xData == 6)
        {
            double sum1 = 0.0;
            double sum2 = 0.0;
            int count1 = 0;
            int count2 = 0;
            for (int i = 0; i < playerPoints.Count; i++)
            {
                if (dData == 0)
                {
                    if (playerPoints[i].ID.CompareTo(Global.playerID) == 0)
                    {
                        if (playerPoints[i].level.CompareTo(lData) == 0)
                        {
                            double percentDestroyed = 0.0;
                            if (playerPoints[i].total_shots != 0)
                            {
                                percentDestroyed = (playerPoints[i].destroyed * 100.0) / playerPoints[i].total_shots;
                            }
                            switch (playerPoints[i].turret_type)
                            {
                                case "Round":
                                    PlotPoint(playerPoints[i], 1, percentDestroyed, cData, "type",0);
                                    sum1 += percentDestroyed;
                                    count1++;
                                    break;
                                case "Square":
                                    PlotPoint(playerPoints[i], 2, percentDestroyed, cData, "type",1);
                                    sum2 += percentDestroyed;
                                    count2++;
                                    break;
                                default:
                                    break;
                            }
                        }
                    }
                } else
                {
                    if (playerPoints[i].level.CompareTo(lData) == 0)
                    {
                        double percentDestroyed = 0.0;
                        if (playerPoints[i].total_shots != 0)
                        {
                            percentDestroyed = (playerPoints[i].destroyed * 100.0) / playerPoints[i].total_shots;
                        }
                        switch (playerPoints[i].turret_type)
                        {
                            case "Round":
                                PlotPoint(playerPoints[i], 1, percentDestroyed, cData, "type",0);
                                sum1 += percentDestroyed;
                                count1++;
                                break;
                            case "Square":
                                PlotPoint(playerPoints[i], 2, percentDestroyed, cData, "type",1);
                                sum2 += percentDestroyed;
                                count2++;
                                break;
                            default:
                                break;
                        }
                    }
                }
            }
            if (ave && cData == 0)
            {
                chart.DataSource.AddPointToCategory("avg", 1, sum1 / count1);
                chart.DataSource.AddPointToCategory("avg", 2, sum2 / count2);
            } else if(ave && cData != 0)
            {
                for(int i = 0; i < 2; i++)
                {
                    for(int j = 0; j < 23; j++)
                    {
                        if(countVal[i,j] != 0)
                        {
                            chart.DataSource.AddPointToCategory("avg", xVal[i,j], sumVal[i,j] / countVal[i,j]);
                                    
                        }
                    }
                }
            }
            
        }
        else if (xData == 2)
        {
            double sum1 = 0.0;
            double sum2 = 0.0;
            double sum3 = 0.0;
            double sum4 = 0.0;
            double sum5 = 0.0;
            int count1 = 0;
            int count2 = 0;
            int count3 = 0;
            int count4 = 0;
            int count5 = 0;
            for (int i = 0; i < playerPoints.Count; i++)
            {
                if (dData == 0)
                {
                    if (playerPoints[i].ID.CompareTo(Global.playerID) == 0)
                    {
                        if (playerPoints[i].level.CompareTo(lData) == 0)
                        {
                            double percentDestroyed = 0.0;
                            if (playerPoints[i].total_shots != 0)
                            {
                                percentDestroyed = (playerPoints[i].destroyed * 100.0) / playerPoints[i].total_shots;
                            }

                            switch (playerPoints[i].wave)
                            {
                                case 1:
                                    PlotPoint(playerPoints[i], l.IndexOf(1) + 1, percentDestroyed, cData, "wave",11);
                                    sum1 += percentDestroyed;
                                    count1++;
                                    break;
                                case 2:
                                    PlotPoint(playerPoints[i], l.IndexOf(2) + 1, percentDestroyed, cData, "wave",12);
                                    sum2 += percentDestroyed;
                                    count2++;
                                    break;
                                case 3:
                                    PlotPoint(playerPoints[i], l.IndexOf(3) + 1, percentDestroyed, cData, "wave",13);
                                    sum3 += percentDestroyed;
                                    count3++;
                                    break;
                                case 4:
                                    PlotPoint(playerPoints[i], l.IndexOf(4) + 1, percentDestroyed, cData, "wave",14);
                                    sum4 += percentDestroyed;
                                    count4++;
                                    break;
                                case 5:
                                    PlotPoint(playerPoints[i], l.IndexOf(5) + 1, percentDestroyed, cData, "wave",15);
                                    sum5 += percentDestroyed;
                                    count5++;
                                    break;

                                default:
                                    break;
                            }
                        }
                    }
                }
                else
                {
                    if (playerPoints[i].level.CompareTo(lData) == 0)
                    {
                        double percentDestroyed = 0.0;
                        if (playerPoints[i].total_shots != 0)
                        {
                            percentDestroyed = (playerPoints[i].destroyed * 100.0) / playerPoints[i].total_shots;
                        }

                        switch (playerPoints[i].wave)
                        {
                            case 1:
                                PlotPoint(playerPoints[i], l.IndexOf(1) + 1, percentDestroyed, cData, "wave",11);
                                sum1 += percentDestroyed;
                                count1++;
                                break;
                            case 2:
                                PlotPoint(playerPoints[i], l.IndexOf(2) + 1, percentDestroyed, cData, "wave",12);
                                sum2 += percentDestroyed;
                                count2++;
                                break;
                            case 3:
                                PlotPoint(playerPoints[i], l.IndexOf(3) + 1, percentDestroyed, cData, "wave",13);
                                sum3 += percentDestroyed;
                                count3++;
                                break;
                            case 4:
                                PlotPoint(playerPoints[i], l.IndexOf(4) + 1, percentDestroyed, cData, "wave",14);
                                sum4 += percentDestroyed;
                                count4++;
                                break;
                            case 5:
                                PlotPoint(playerPoints[i], l.IndexOf(5) + 1, percentDestroyed, cData, "wave",15);
                                sum5 += percentDestroyed;
                                count5++;
                                break;

                            default:
                                break;
                        }
                    }
                }
            }
            if (ave && cData == 0)
            {
                if (count1 != 0) { chart.DataSource.AddPointToCategory("avg", l.IndexOf(1) + 1, sum1 / count1); }
                if (count2 != 0) { chart.DataSource.AddPointToCategory("avg", l.IndexOf(2) + 1, sum2 / count2); }
                if (count3 != 0) { chart.DataSource.AddPointToCategory("avg", l.IndexOf(3) + 1, sum3 / count3); }
                if (count4 != 0) { chart.DataSource.AddPointToCategory("avg", l.IndexOf(4) + 1, sum4 / count4); }
                if (count5 != 0) { chart.DataSource.AddPointToCategory("avg", l.IndexOf(5) + 1, sum5 / count5); }
            }
            else if (ave && cData != 0)
            {
                for (int i = 11; i < 16; i++)
                {
                    for (int j = 0; j < 23; j++)
                    {
                        if (countVal[i, j] != 0)
                        {
                            chart.DataSource.AddPointToCategory("avg", xVal[i, j], sumVal[i, j] / countVal[i, j]);

                        }
                    }
                }
            }
            l.Clear();
        }
        else if (xData == 3)
        {
            double sum1 = 0.0;
            double sum2 = 0.0;
            double sum3 = 0.0;
            double sum4 = 0.0;
            double sum5 = 0.0;
            double sum6 = 0.0;
            int count1 = 0;
            int count2 = 0;
            int count3 = 0;
            int count4 = 0;
            int count5 = 0;
            int count6 = 0;
            for (int i = 0; i < playerPoints.Count; i++)
            {
                if (dData == 0)
                {
                    if (playerPoints[i].ID.CompareTo(Global.playerID) == 0)
                    {
                        if (playerPoints[i].level.CompareTo(lData) == 0)
                        {
                            double percentDestroyed = 0.0;
                            if (playerPoints[i].total_shots != 0)
                            {
                                percentDestroyed = (playerPoints[i].destroyed * 100.0) / playerPoints[i].total_shots;
                            }
                            switch (playerPoints[i].location)
                            {
                                case 1:
                                    PlotPoint(playerPoints[i], l.IndexOf(1) + 1, percentDestroyed, cData, "location",16);
                                    sum1 += percentDestroyed;
                                    count1++;
                                    break;
                                case 2:
                                    PlotPoint(playerPoints[i], l.IndexOf(2) + 1, percentDestroyed, cData, "location",17);
                                    sum2 += percentDestroyed;
                                    count2++;
                                    break;
                                case 3:
                                    PlotPoint(playerPoints[i], l.IndexOf(3) + 1, percentDestroyed, cData, "location",18);
                                    sum3 += percentDestroyed;
                                    count3++;
                                    break;
                                case 4:
                                    PlotPoint(playerPoints[i], l.IndexOf(4) + 1, percentDestroyed, cData, "location",19);
                                    sum4 += percentDestroyed;
                                    count4++;
                                    break;
                                case 5:
                                    PlotPoint(playerPoints[i], l.IndexOf(5) + 1, percentDestroyed, cData, "location",20);
                                    sum5 += percentDestroyed;
                                    count5++;
                                    break;
                                case 6:
                                    PlotPoint(playerPoints[i], l.IndexOf(6) + 1, percentDestroyed, cData, "location",21);
                                    sum6 += percentDestroyed;
                                    count6++;
                                    break;
                                default:
                                    break;
                            }
                        }
                    }
                } else
                {
                    if (playerPoints[i].level.CompareTo(lData) == 0)
                    {
                        double percentDestroyed = 0.0;
                        if (playerPoints[i].total_shots != 0)
                        {
                            percentDestroyed = (playerPoints[i].destroyed * 100.0) / playerPoints[i].total_shots;
                        }
                        switch (playerPoints[i].location)
                        {
                            case 1:
                                PlotPoint(playerPoints[i], l.IndexOf(1) + 1, percentDestroyed, cData, "location",16);
                                sum1 += percentDestroyed;
                                count1++;
                                break;
                            case 2:
                                PlotPoint(playerPoints[i], l.IndexOf(2) + 1, percentDestroyed, cData, "location",17);
                                sum2 += percentDestroyed;
                                count2++;
                                break;
                            case 3:
                                PlotPoint(playerPoints[i], l.IndexOf(3) + 1, percentDestroyed, cData, "location",18);
                                sum3 += percentDestroyed;
                                count3++;
                                break;
                            case 4:
                                PlotPoint(playerPoints[i], l.IndexOf(4) + 1, percentDestroyed, cData, "location",19);
                                sum4 += percentDestroyed;
                                count4++;
                                break;
                            case 5:
                                PlotPoint(playerPoints[i], l.IndexOf(5) + 1, percentDestroyed, cData, "location",20);
                                sum5 += percentDestroyed;
                                count5++;
                                break;
                            case 6:
                                PlotPoint(playerPoints[i], l.IndexOf(6) + 1, percentDestroyed, cData, "location",21);
                                sum6 += percentDestroyed;
                                count6++;
                                break;
                            default:
                                break;
                        }
                    }
                }

            }
            if (ave && cData == 0)
            {
                if (count1 != 0) { chart.DataSource.AddPointToCategory("avg", l.IndexOf(1) + 1, sum1 / count1); }
                if (count2 != 0) { chart.DataSource.AddPointToCategory("avg", l.IndexOf(2) + 1, sum2 / count2); }
                if (count3 != 0) { chart.DataSource.AddPointToCategory("avg", l.IndexOf(3) + 1, sum3 / count3); }
                if (count4 != 0) { chart.DataSource.AddPointToCategory("avg", l.IndexOf(4) + 1, sum4 / count4); }
                if (count5 != 0) { chart.DataSource.AddPointToCategory("avg", l.IndexOf(5) + 1, sum5 / count5); }
                if (count6 != 0) { chart.DataSource.AddPointToCategory("avg", l.IndexOf(6) + 1, sum6 / count6); }
            }
            else if (ave && cData != 0)
            {
                for (int i = 16; i < 23; i++)
                {
                    for (int j = 0; j < 23; j++)
                    {
                        if (countVal[i, j] != 0)
                        {
                            chart.DataSource.AddPointToCategory("avg", xVal[i, j], sumVal[i, j] / countVal[i, j]);

                        }
                    }
                }
            }
            l.Clear();
        }
        else if (xData == 7)
        {
            double sum1 = 0.0;
            double sum2 = 0.0;
            double sum3 = 0.0;
            double sum4 = 0.0;
            double sum5 = 0.0;
            double sum6 = 0.0;
            int count1 = 0;
            int count2 = 0;
            int count3 = 0;
            int count4 = 0;
            int count5 = 0;
            int count6 = 0;
            for (int i = 0; i < playerPoints.Count; i++)
            {
                if (dData == 0)
                {
                    if (playerPoints[i].ID.CompareTo(Global.playerID) == 0)
                    {
                        if (playerPoints[i].level.CompareTo(lData) == 0)
                        {
                            double percentDestroyed = 0.0;
                            if (playerPoints[i].total_shots != 0)
                            {
                                percentDestroyed = (playerPoints[i].destroyed * 100.0) / playerPoints[i].total_shots;
                            }
                            if (playerPoints[i].meds.CompareTo("Med R") == 0)
                            {
                                PlotPoint(playerPoints[i], ls.IndexOf("Med R") + 1, percentDestroyed, cData, "meds", 5);
                                sum1 += percentDestroyed;
                                count1++;
                            }
                            else if (playerPoints[i].meds.CompareTo("Med B") == 0)
                            {
                                PlotPoint(playerPoints[i], ls.IndexOf("Med B") + 1, percentDestroyed, cData, "meds",6);
                                sum2 += percentDestroyed;
                                count2++;
                            }
                            else if (playerPoints[i].meds.CompareTo("Med P") == 0)
                            {
                                PlotPoint(playerPoints[i], ls.IndexOf("Med P") + 1, percentDestroyed, cData, "meds",7);
                                sum3 += percentDestroyed;
                                count3++;
                            }
                            else if (playerPoints[i].meds.CompareTo("Med G") == 0)
                            {
                                PlotPoint(playerPoints[i], ls.IndexOf("Med G") + 1, percentDestroyed, cData, "meds",8);
                                sum4 += percentDestroyed;
                                count4++;
                            }
                            else if (playerPoints[i].meds.CompareTo("Med Y") == 0)
                            {
                                PlotPoint(playerPoints[i], ls.IndexOf("Med Y") + 1, percentDestroyed, cData, "meds",9);
                                sum5 += percentDestroyed;
                                count5++;
                            }
                            else if (playerPoints[i].meds.CompareTo("Med O") == 0)
                            {
                                PlotPoint(playerPoints[i], ls.IndexOf("Med O") + 1, percentDestroyed, cData, "meds",10);
                                sum6 += percentDestroyed;
                                count6++;
                            }
                        }
                    }
                } else
                {
                    if (playerPoints[i].level.CompareTo(lData) == 0)
                    {
                        double percentDestroyed = 0.0;
                        if (playerPoints[i].total_shots != 0)
                        {
                            percentDestroyed = (playerPoints[i].destroyed * 100.0) / playerPoints[i].total_shots;
                        }
                        if (playerPoints[i].meds.CompareTo("Med R") == 0)
                        {
                            PlotPoint(playerPoints[i], ls.IndexOf("Med R") + 1, percentDestroyed, cData, "meds", 5);
                            sum1 += percentDestroyed;
                            count1++;
                        }
                        else if (playerPoints[i].meds.CompareTo("Med B") == 0)
                        {
                            PlotPoint(playerPoints[i], ls.IndexOf("Med B") + 1, percentDestroyed, cData, "meds", 6);
                            sum2 += percentDestroyed;
                            count2++;
                        }
                        else if (playerPoints[i].meds.CompareTo("Med P") == 0)
                        {
                            PlotPoint(playerPoints[i], ls.IndexOf("Med P") + 1, percentDestroyed, cData, "meds", 7);
                            sum3 += percentDestroyed;
                            count3++;
                        }
                        else if (playerPoints[i].meds.CompareTo("Med G") == 0)
                        {
                            PlotPoint(playerPoints[i], ls.IndexOf("Med G") + 1, percentDestroyed, cData, "meds", 8);
                            sum4 += percentDestroyed;
                            count4++;
                        }
                        else if (playerPoints[i].meds.CompareTo("Med Y") == 0)
                        {
                            PlotPoint(playerPoints[i], ls.IndexOf("Med Y") + 1, percentDestroyed, cData, "meds", 9);
                            sum5 += percentDestroyed;
                            count5++;
                        }
                        else if (playerPoints[i].meds.CompareTo("Med O") == 0)
                        {
                            PlotPoint(playerPoints[i], ls.IndexOf("Med O") + 1, percentDestroyed, cData, "meds", 10);
                            sum6 += percentDestroyed;
                            count6++;
                        }
                    }
                }
            }
            if (ave && cData == 0)
            {
                if (count1 != 0) { chart.DataSource.AddPointToCategory("avg", ls.IndexOf("Med R") + 1, sum1 / count1); }
                if (count2 != 0) { chart.DataSource.AddPointToCategory("avg", ls.IndexOf("Med B") + 1, sum2 / count2); }
                if (count3 != 0) { chart.DataSource.AddPointToCategory("avg", ls.IndexOf("Med P") + 1, sum3 / count3); }
                if (count4 != 0) { chart.DataSource.AddPointToCategory("avg", ls.IndexOf("Med G") + 1, sum4 / count4); }
                if (count5 != 0) { chart.DataSource.AddPointToCategory("avg", ls.IndexOf("Med Y") + 1, sum5 / count5); }
                if (count6 != 0) { chart.DataSource.AddPointToCategory("avg", ls.IndexOf("Med O") + 1, sum6 / count6); }
            }
            else if (ave && cData != 0)
            {
                for (int i = 5; i < 11; i++)
                {
                    for (int j = 0; j < 23; j++)
                    {
                        if (countVal[i, j] != 0)
                        {
                            chart.DataSource.AddPointToCategory("avg", xVal[i, j], sumVal[i, j] / countVal[i, j]);

                        }
                    }
                }
            }
            ls.Clear();
        }
        else if (xData == 8)
        {
            double sum1 = 0.0;
            double sum2 = 0.0;
            double sum3 = 0.0;
            int count1 = 0;
            int count2 = 0;
            int count3 = 0;
            for (int i = 0; i < playerPoints.Count; i++)
            {
                if (dData == 0)
                {
                    if (playerPoints[i].ID.CompareTo(Global.playerID) == 0)
                    {
                        if (playerPoints[i].level.CompareTo(lData) == 0)
                        {
                            double percentDestroyed = 0.0;
                            if (playerPoints[i].total_shots != 0)
                            {
                                percentDestroyed = (playerPoints[i].destroyed * 100.0) / playerPoints[i].total_shots;
                            }
                            if (playerPoints[i].virus.CompareTo("red") == 0)
                            {
                                PlotPoint(playerPoints[i], ls.IndexOf("red") + 1, percentDestroyed, cData, "virus", 2);
                                sum1 += percentDestroyed;
                                count1++;
                            }
                            else if (playerPoints[i].virus.CompareTo("blue") == 0)
                            {
                                PlotPoint(playerPoints[i], ls.IndexOf("blue") + 1, percentDestroyed, cData, "virus", 3);
                                sum2 += percentDestroyed;
                                count2++;
                            }
                            else if (playerPoints[i].virus.CompareTo("purple") == 0)
                            {
                                PlotPoint(playerPoints[i], ls.IndexOf("purple") + 1, percentDestroyed, cData, "virus", 4);
                                sum3 += percentDestroyed;
                                count3++;
                            }
                        }
                    }
                } else
                {
                    if (playerPoints[i].level.CompareTo(lData) == 0)
                    {
                        double percentDestroyed = 0.0;
                        if (playerPoints[i].total_shots != 0)
                        {
                            percentDestroyed = (playerPoints[i].destroyed * 100.0) / playerPoints[i].total_shots;
                        }
                        if (playerPoints[i].virus.CompareTo("red") == 0)
                        {
                            PlotPoint(playerPoints[i], ls.IndexOf("red") + 1, percentDestroyed, cData, "virus",2);
                            sum1 += percentDestroyed;
                            count1++;
                        }
                        else if (playerPoints[i].virus.CompareTo("blue") == 0)
                        {
                            PlotPoint(playerPoints[i], ls.IndexOf("blue") + 1, percentDestroyed, cData, "virus",3);
                            sum2 += percentDestroyed;
                            count2++;
                        }
                        else if (playerPoints[i].virus.CompareTo("purple") == 0)
                        {
                            PlotPoint(playerPoints[i], ls.IndexOf("purple") + 1, percentDestroyed, cData, "virus",4);
                            sum3 += percentDestroyed;
                            count3++;
                        }
                    }
                }
            }
            if (ave && cData == 0)
            {
                if (count1 != 0) { chart.DataSource.AddPointToCategory("avg", ls.IndexOf("red") + 1, sum1 / count1); }
                if (count2 != 0) { chart.DataSource.AddPointToCategory("avg", ls.IndexOf("blue") + 1, sum2 / count2); }
                if (count3 != 0) { chart.DataSource.AddPointToCategory("avg", ls.IndexOf("purple") + 1, sum3 / count3); }
            }
            else if (ave && cData != 0)
            {
                for (int i = 2; i < 5; i++)
                {
                    for (int j = 0; j < 23; j++)
                    {
                        if (countVal[i, j] != 0)
                        {
                            chart.DataSource.AddPointToCategory("avg", xVal[i, j], sumVal[i, j] / countVal[i, j]);

                        }
                    }
                }
            }
            ls.Clear();
        }

        //Clean Data
        for(int i = 0; i < 23; i++)
        {
            for (int j = 0; j < 23; j++)
            {
                xVal[i, j] = 0;
                sumVal[i, j] = 0;
                countVal[i, j] = 0;
            }
        }

        chart.DataSource.EndBatch();
    }



    //    //---------------Helpers-----------------
        private void PlotPoint(point p, float x, double y, int cData, string pointName, int xValue)
    {
        switch(cData)
        {
            case 0:
                chart.DataSource.AddPointToCategory(pointName, x, y);
                break;
            case 2:
                PlotByWave(p, x, y, xValue);
                break;
            case 3:
                PlotByLocation(p, x, y, xValue);
                break;
            case 6:
                PlotByType(p, x, y, xValue);
                break;
            case 7:
                PlotByMeds(p, x, y, xValue);
                break;
            case 8:
                PlotByVirus(p, x, y, xValue);
                break;
        }
    }

    private void PlotByWave(point p, float x, double y, int xValue)
    {

        if (p.wave == 1)
        {
            chart.DataSource.AddPointToCategory("wave1", x-0.16, y);
            xVal[xValue, 11] = (float)(x - 0.16);
            sumVal[xValue, 11] += y;
            countVal[xValue, 11]++;
        }
        else if (p.wave == 2)
        {
            chart.DataSource.AddPointToCategory("wave2", x-0.08, y);
            xVal[xValue, 12] = (float)(x - 0.08);
            sumVal[xValue, 12] += y;
            countVal[xValue, 12]++;
        }
        else if (p.wave == 3)
        {
            chart.DataSource.AddPointToCategory("wave3", x, y);
            xVal[xValue, 13] = (float)(x);
            sumVal[xValue, 13] += y;
            countVal[xValue, 13]++;
        }
        else if (p.wave == 4)
        {
            chart.DataSource.AddPointToCategory("wave4", x+0.08, y);
            xVal[xValue, 14] = (float)(x + 0.08);
            sumVal[xValue, 14] += y;
            countVal[xValue, 14]++;
        }
        else if (p.wave == 5)
        {
            chart.DataSource.AddPointToCategory("wave5", x+0.16, y);
            xVal[xValue, 15] = (float)(x + 0.16);
            sumVal[xValue, 15] += y;
            countVal[xValue, 15]++;
        }
    }

    private void PlotByLocation(point p, float x, double y, int xValue)
    {

        if (p.location == 1)
        {
            chart.DataSource.AddPointToCategory("loc1", x-0.16, y);
            xVal[xValue, 16] = (float)(x - 0.16);
            sumVal[xValue, 16] += y;
            countVal[xValue, 16]++;
        }
        else if (p.location == 2)
        {
            chart.DataSource.AddPointToCategory("loc2", x-0.08, y);
            xVal[xValue, 17] = (float)(x - 0.08);
            sumVal[xValue, 17] += y;
            countVal[xValue, 17]++;
        }
        else if (p.location == 3)
        {
            chart.DataSource.AddPointToCategory("loc3", x, y);
            xVal[xValue, 18] = (float)(x);
            sumVal[xValue, 18] += y;
            countVal[xValue, 18]++;
        }
        else if (p.location == 4)
        {
            chart.DataSource.AddPointToCategory("loc4", x+0.08, y);
            xVal[xValue, 19] = (float)(x + 0.08);
            sumVal[xValue, 19] += y;
            countVal[xValue, 19]++;
        }
        else if (p.location == 5)
        {
            chart.DataSource.AddPointToCategory("loc5", x+0.16, y);
            xVal[xValue, 20] = (float)(x + 0.16);
            sumVal[xValue, 20] += y;
            countVal[xValue, 20]++;
        }
        else if (p.location == 6)
        {
            chart.DataSource.AddPointToCategory("loc6", x+0.24, y);
            xVal[xValue, 21] = (float)(x + 0.24);
            sumVal[xValue, 21] += y;
            countVal[xValue, 21]++;
        }
        else if (p.location == 7)
        {
            chart.DataSource.AddPointToCategory("loc7", x + 0.32, y);
            xVal[xValue, 22] = (float)(x + 0.32);
            sumVal[xValue, 22] += y;
            countVal[xValue, 22]++;
        }
    }

    private void PlotByMeds(point p, float x, double y, int xValue)
    {

        if (p.meds.CompareTo("Med R") == 0)
        {
            chart.DataSource.AddPointToCategory("Med R", x+0.08, y);
            xVal[xValue, 5] = (float)(x + 0.08);
            sumVal[xValue, 5] += y;
            countVal[xValue, 5]++;
        }
        else if (p.meds.CompareTo("Med B") == 0)
        {
            chart.DataSource.AddPointToCategory("Med B", x-0.08, y);
            xVal[xValue, 6] = (float)(x - 0.08);
            sumVal[xValue, 6] += y;
            countVal[xValue, 6]++;
        }
        else if (p.meds.CompareTo("Med P") == 0)
        {
            chart.DataSource.AddPointToCategory("Med P", x+0.08, y);
            xVal[xValue, 7] = (float)(x + 0.08);
            sumVal[xValue, 7] += y;
            countVal[xValue, 7]++;
        }
        else if (p.meds.CompareTo("Med G") == 0)
        {
            chart.DataSource.AddPointToCategory("Med G", x-0.08, y);
            xVal[xValue, 8] = (float)(x - 0.08);
            sumVal[xValue, 8] += y;
            countVal[xValue, 8]++;
        }
        else if (p.meds.CompareTo("Med Y") == 0)
        {
            chart.DataSource.AddPointToCategory("Med Y", x+0.08, y);
            xVal[xValue, 9] = (float)(x + 0.08);
            sumVal[xValue, 9] += y;
            countVal[xValue, 9]++;
        }
        else if (p.meds.CompareTo("Med O") == 0)
        {
            chart.DataSource.AddPointToCategory("Med O", x-0.08, y);
            xVal[xValue, 10] = (float)(x - 0.08);
            sumVal[xValue, 10] += y;
            countVal[xValue, 10]++;
        }
    }

    private void PlotByVirus(point p, float x, double y, int xValue)
    {

        if (p.virus.CompareTo("red") == 0)
        {
            chart.DataSource.AddPointToCategory("red", x+0.08, y);
            xVal[xValue, 2] = (float)(x + 0.08);
            sumVal[xValue, 2] += y;
            countVal[xValue, 2]++;
        }
        else if (p.virus.CompareTo("blue") == 0)
        {
            chart.DataSource.AddPointToCategory("blue", x-0.08, y);
            xVal[xValue, 3] = (float)(x - 0.08);
            sumVal[xValue, 3] += y;
            countVal[xValue, 3]++;
        }
        else if (p.virus.CompareTo("purple") == 0)
        {
            chart.DataSource.AddPointToCategory("purple", x, y);
            xVal[xValue, 4] = (float)(x);
            sumVal[xValue, 4] += y;
            countVal[xValue, 4]++;
        }
    }

    private void PlotByType(point p, float x, double y, int xValue)
    {

        if (p.turret_type.CompareTo("Round") == 0)
        {
            chart.DataSource.AddPointToCategory("Round", x+0.08, y);
            xVal[xValue, 0] = (float)(x + 0.08);
            sumVal[xValue, 0] += y;
            countVal[xValue, 0]++;
        }
        else if (p.turret_type.CompareTo("Square") == 0)
        {
            chart.DataSource.AddPointToCategory("Square", x-0.08, y);
            xVal[xValue, 1] = (float)(x - 0.08);
            sumVal[xValue, 1] += y;
            countVal[xValue, 1]++;
        }
    }

    public IEnumerator GetDatabaseValues()
    {
        WWWForm form = new WWWForm();
        form.AddField("PlayerID", Global.playerID);
        form.AddField("GroupID", Global.groupID);
        string url = "https://www.stat2games.sites.grinnell.edu/data/epidemic/getdata.php";
        UnityWebRequest www = UnityWebRequest.Post(url, form);
        yield return www.SendWebRequest();
        string data = www.downloadHandler.text;
        if (data.Contains("Failed"))
        {
            Debug.Log(data);
            yield break;
        }
        string[] splitData = data.Split(new char[] { '\n' }, System.StringSplitOptions.None);
        for (int i = 1; i < splitData.Length - 1; i++)
        {
            string[] rows = splitData[i].Split(new char[] { ',' }, System.StringSplitOptions.None);
            if (string.Compare(rows[2], Global.groupID) == 0)
            {
                point temp = new point
                {
                    //    playerPoints[i].ID = playerdt.Rows[i][1].ToString();
                    //    playerPoints[i].level = playerdt.Rows[i][4].ToString();
                    //    playerPoints[i].wave = int.Parse(playerdt.Rows[i][5].ToString());
                    //    playerPoints[i].location = int.Parse(playerdt.Rows[i][8].ToString());
                    //    playerPoints[i].total_shots = int.Parse(playerdt.Rows[i][14].ToString());
                    //    playerPoints[i].destroyed = int.Parse(playerdt.Rows[i][15].ToString());
                    //    playerPoints[i].turret_type = playerdt.Rows[i][9].ToString();
                    //    playerPoints[i].meds = playerdt.Rows[i][11].ToString();
                    //    playerPoints[i].virus = playerdt.Rows[i][12].ToString();
                    ID = rows[1].ToString(),
                    level = rows[4].ToString(),
                    wave = int.Parse(rows[5].ToString()),
                    location = int.Parse(rows[8].ToString()),
                    total_shots = int.Parse(rows[14].ToString()),
                    destroyed = int.Parse(rows[15].ToString()),
                    turret_type = rows[9].ToString(),
                    meds = rows[11].ToString(),
                    virus = rows[12].ToString()
                };
                playerPoints.Add(temp);
            }
        }

        //DataTable dt = new DataTable();

        //string[] headers = splitData[0].Split(new char[] { ',' }, System.StringSplitOptions.None);
        //foreach (string header in headers)
        //{
        //    dt.Columns.Add(header);
        //}

        //for (int i = 1; i < splitData.Length - 1; i++)
        //{
        //    string[] rows = splitData[i].Split(new char[] { ',' }, System.StringSplitOptions.None);
        //    DataRow dr = dt.NewRow();

        //    if(string.Compare(rows[2], Global.groupID) == 0)
        //    {
        //        for (int j = 0; j < headers.Length; j++)
        //        {
        //            dr[j] = rows[j];
        //        }
        //    }


        //    dt.Rows.Add(dr);
        //}

        //DataView dv = new DataView(dt);
        //dv.RowFilter = "GroupID = 'r'";
        //groupPoints = new point[dv.Count];
        //DataTable groupdt = dv.ToTable();
        //for (int i = 0; i < dv.Count; i++)
        //{
        //    groupPoints[i].level = groupdt.Rows[i][4].ToString();
        //    groupPoints[i].wave = int.Parse(groupdt.Rows[i][5].ToString());
        //    groupPoints[i].location = int.Parse(groupdt.Rows[i][8].ToString());
        //    groupPoints[i].total_shots = int.Parse(groupdt.Rows[i][14].ToString());
        //    groupPoints[i].destroyed = int.Parse(groupdt.Rows[i][15].ToString());
        //    groupPoints[i].turret_type = groupdt.Rows[i][9].ToString();
        //    groupPoints[i].meds = groupdt.Rows[i][11].ToString();
        //    groupPoints[i].virus = groupdt.Rows[i][12].ToString();
        //}

        //dv.RowFilter = "GroupID = '" + Global.groupID + "'";
        //playerPoints = new point[dv.Count];
        //DataTable playerdt = dv.ToTable();
        //for (int i = 0; i < dv.Count; i++)
        //{
        //    playerPoints[i].ID = playerdt.Rows[i][1].ToString();
        //    playerPoints[i].level = playerdt.Rows[i][4].ToString();
        //    playerPoints[i].wave = int.Parse(playerdt.Rows[i][5].ToString());
        //    playerPoints[i].location = int.Parse(playerdt.Rows[i][8].ToString());
        //    playerPoints[i].total_shots = int.Parse(playerdt.Rows[i][14].ToString());
        //    playerPoints[i].destroyed = int.Parse(playerdt.Rows[i][15].ToString());
        //    playerPoints[i].turret_type = playerdt.Rows[i][9].ToString();
        //    playerPoints[i].meds = playerdt.Rows[i][11].ToString();
        //    playerPoints[i].virus = playerdt.Rows[i][12].ToString();
        //}
        xLabel.SetText("Meds");
        yLabel.SetText("Percent Destroyed");
        RewriteData(7, 0, "1", 0, ave);

    }

}