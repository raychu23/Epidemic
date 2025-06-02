using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SLS.Widgets.Table;
using UnityEngine.Networking;

public class Leaderboard : MonoBehaviour
{
    private DataModel datam;
    private Table table;
    private DataManager dm;

    LeaderBoardData lb;
    int curIndex;
    int curHealth;
    int curFunds;
    int position;
    string level;

    // Use this for initialization
    void Start()
    {
        datam = DataModel.instance;
        dm = DataManager.instance;
        this.table = this.GetComponent<Table>();
        this.table.ResetTable();

        this.table.AddTextColumn();
        this.table.AddTextColumn();
        this.table.AddTextColumn();
        this.table.AddTextColumn();

        this.table.Initialize(this.OnTableSelected);

        // This is to account for the first row of title
        int uid = -1;
        Datum d = Datum.Body(uid.ToString());

        d.elements.Add("PlayerID");
        d.elements.Add("GroupID");
        d.elements.Add("Health");
        d.elements.Add("Funds");

        this.table.data.Add(d);

        this.table.StartRenderEngine();

        level = GameObject.Find("LevelManager").GetComponent<LevelManager>().level;


        StartCoroutine(LoadLeaderBoard(level));
    }

    public void CheckForChange()
    {
        curIndex = datam.health.Count - 1;
        curHealth = datam.health[curIndex];
        curFunds = datam.funds[curIndex];
        Debug.Log("Health = " + curHealth);
        Debug.Log("Funds = " + curFunds);

        position = -1;

        for (int i = 0; i < 5; i++)
        {
            if (lb.players[i].health < curHealth)
            {
                position = i;
                break;
            }
            else if (lb.players[i].health == curHealth)
            {
                if (lb.players[i].funds < curFunds)
                {
                    position = i;
                    break;
                }
            }
        }
        Debug.Log("Position = " + position);
        if (position != -1)
        {
            //UpdateLb();
        }
        PopulateTable();
    }

    void UpdateLb()
    {
        for(int i = 4; i > position; i--)
        {
            lb.players[i].playerID = lb.players[i-1].playerID;
            lb.players[i].groupID = lb.players[i-1].groupID;
            lb.players[i].health = lb.players[i-1].health;
            lb.players[i].funds = lb.players[i-1].funds;
        }
        lb.players[position].playerID = datam.playerId[curIndex];
        lb.players[position].groupID = datam.groupId[curIndex];
        lb.players[position].health = curHealth;
        lb.players[position].funds = curFunds;
    }

    void PopulateTable()
    {
        for (int i = 0; i < 5; i++)
        {
            Datum d = Datum.Body(i.ToString());

            d.elements.Add(lb.players[i].playerID);
            d.elements.Add(lb.players[i].groupID);
            d.elements.Add(lb.players[i].health);
            d.elements.Add(lb.players[i].funds);

            this.table.data.Add(d);
        }
    }

    private void OnTableSelected(Datum datum, Column column)
    {
        string cidx = "N/A";
        if (column != null) cidx = column.idx.ToString();
        print("You Clicked: " + datum.uid + " Column: " + cidx);
    }

    private IEnumerator LoadLeaderBoard(string lvl)
    {
        yield return StartCoroutine(dm.GetLeaderBoard(lvl));
        lb = dm.lb;

        Debug.Log("Funds 0= " + lb.players[0].funds);
        Debug.Log("Funds 1= " + lb.players[1].funds);
        Debug.Log("Funds 2= " + lb.players[2].funds);
        Debug.Log("Funds 3= " + lb.players[3].funds);
        Debug.Log("Funds 4= " + lb.players[4].funds);

        PopulateTable();

        /*
        if (datam == null)
        {
            Debug.Log("datam is null");
            PopulateTable();
        }
        else
        {
            CheckForChange();
        }
        */
    }
}

