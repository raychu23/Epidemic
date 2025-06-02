
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SLS.Widgets.Table;

public class EachWaveData : MonoBehaviour
{
    
    //public GameObject entryPrefab;
    private Table table;

    //public TextAsset csv;
    DataModel datam;

    int lastPos = 0;

    // Use this for initialization
    void Start()
    {
        this.table = this.GetComponent<Table>();

        this.table.ResetTable();

        this.table.AddTextColumn();
        this.table.AddTextColumn();
        this.table.AddTextColumn();
        this.table.AddTextColumn();
        this.table.AddTextColumn();
        this.table.AddTextColumn();
        this.table.AddTextColumn();
        this.table.AddTextColumn();


        this.table.Initialize(this.OnTableSelected);

        int uid = -1;

        Datum d = Datum.Body(uid.ToString());

        d.elements.Add("Wave");
        d.elements.Add("Position");
        d.elements.Add("TurretType");
        d.elements.Add("Upgrade");
        d.elements.Add("Medicine");
        d.elements.Add("Virus");
        d.elements.Add("Shot");
        d.elements.Add("Destroyed");


        this.table.data.Add(d);


        datam = DataModel.instance;
        //this.dayCount = datam.day.Count;

        if (datam == null)
        {
            Debug.Log("datam is null");
            return;
        } 

        this.table.StartRenderEngine();
        GameObject.FindObjectOfType<UIGameView>().dataTableInit = 1;
        //Debug.Log("Number of rows initially: " + datam.position.Count);
    }

    
    // Update is called once per frame
    void Update()
    {
        //Debug.Log("Number of rows : " + datam.position.Count);

        if (datam.position.Count - lastPos == 0)
        {
            // This means there haven't been any new waves so do nothing
        }
        else if (datam.position.Count - lastPos == 1)
        {
            // This means there has been a single new day added to datam
            UpdateTable(lastPos); // So we update the table with this new day

            // increment last day by one to account for new day addition
            lastPos += 1;

        }
        else if (datam.position.Count - lastPos > 1)
        {
            // This means our code failed to be efficient and did not add the new days
            // So add all new days and set last day to current day
            UpdateTable(lastPos);
            lastPos = datam.position.Count;
        }
    }

        
    public void UpdateTable(int lastDay)
    {

        for (int index = lastDay; index < datam.position.Count; index++)
        {
            Datum d = Datum.Body(index.ToString());

            d.elements.Add(datam.wave[index]);
            d.elements.Add(datam.position[index]);
            d.elements.Add(datam.turretType[index]);
            d.elements.Add(datam.upgrade[index]);
            d.elements.Add(datam.medicine[index]);
            d.elements.Add(datam.virus[index]);
            d.elements.Add(datam.shot[index]);
            d.elements.Add(datam.destroyed[index]);
            

            this.table.data.Add(d);

        }
    } 

    private void OnTableSelected(Datum datum, Column column)
    {
        string cidx = "N/A";
        if (column != null) cidx = column.idx.ToString();
        print("You Clicked: " + datum.uid + " Column: " + cidx);
    }
}
