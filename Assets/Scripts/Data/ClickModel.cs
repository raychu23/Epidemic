using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text;
using System.IO;
using System;
using UnityEngine.SceneManagement;

public class ClickModel : MonoBehaviour
{
    // Singleton
    public static ClickModel instance;

    public int waveVar;

    public List<string> playerId = new List<string>();
    public List<string> groupId = new List<string>();
    public List<DateTime> dateTime = new List<DateTime>();
    public List<string> level = new List<string>();
    public List<int> wave = new List<int>();
    public List<int> table = new List<int>();
    public List<int> graphs = new List<int>();
    public List<int> barChart = new List<int>();
    public List<int> dotPlot = new List<int>();
    public List<int> medicine = new List<int>();
    public List<int> turretType = new List<int>();
    public List<int> shots = new List<int>();
    public List<int> destroyed = new List<int>();
    public List<int> percentDestroyed = new List<int>();
    public List<int> showAverages = new List<int>();

    public int tableCount;
    public int graphsCount;
    public int barChartCount;
    public int dotPlotCount;
    public int medicineCount;
    public int turretTypeCount;
    public int shotsCount;
    public int destroyedCount;
    public int percentDestroyedCount;
    public int showAveragesCount;

    /// <summary>
    /// Awake this instance.
    /// </summary>
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
        {
            Destroy(gameObject);
            return;
        }
    }

    /*
    public void DataLoop()
    {
        GameObject[] arr = GameObject.FindGameObjectsWithTag("Tower");
        foreach (GameObject obj in arr)
        {
            if (!obj.name.Equals("0"))
            {
                Tower t = obj.GetComponent<Tower>();
                if (t.redShots != 0)
                    AddData(obj, t.redShots, t.redCures, "red");
                if (t.blueShots != 0)
                    AddData(obj, t.blueShots, t.blueCures, "blue");
            }

        }

    }

    public void DataSingle(GameObject obj)
    {
        Tower t = obj.GetComponent<Tower>();
        if (t.redShots != 0)
            AddData(obj, t.redShots, t.redCures, "red");
        if (t.blueShots != 0)
            AddData(obj, t.blueShots, t.blueCures, "blue");
    } */

    public void AddCount()
    { 
        this.playerId.Add(InputIDs.playerdata.playerID);
        this.groupId.Add(InputIDs.playerdata.groupID);
        this.dateTime.Add(DateTime.Now);
        this.level.Add(GameObject.Find("LevelManager").GetComponent<LevelManager>().level);
        this.wave.Add(waveVar);
        this.table.Add(tableCount);
        this.graphs.Add(graphsCount);
        this.barChart.Add(barChartCount);
        this.dotPlot.Add(dotPlotCount);
        this.medicine.Add(medicineCount);
        this.turretType.Add(turretTypeCount);
        this.shots.Add(shotsCount);
        this.destroyed.Add(destroyedCount);
        this.percentDestroyed.Add(percentDestroyedCount);
        this.showAverages.Add(showAveragesCount);

        //Resetting the counts
        tableCount = 0;
        graphsCount = 0;
        barChartCount = 0;
        dotPlotCount = 0;
        medicineCount = 0;
        turretTypeCount = 0;
        shotsCount = 0;
        destroyedCount = 0;
        percentDestroyedCount = 0;
        showAveragesCount = 0;

}

    public void ClearData()
    {
        instance = null;
        gameObject.AddComponent<ClickModel>();
        Destroy(this);
    }
}


