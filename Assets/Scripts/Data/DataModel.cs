using System;
using System.Collections.Generic;
using UnityEngine;

public class DataModel : MonoBehaviour
{
    // Singleton
    public static DataModel instance;

    public int waveVar;
    public int currencyVar;
    public int healthVar;

    public List<string> playerId = new List<string>();
    public List<string> groupId = new List<string>();
    public List<DateTime> dateTime = new List<DateTime>();
    public List<string> level = new List<string>();
    public List<int> wave = new List<int>();
    public List<int> funds = new List<int>();
    public List<int> health = new List<int>();
    public List<int> position = new List<int>();
    public List<String> turretType = new List<String>();
    public List<String> upgrade = new List<String>();
    public List<String> medicine = new List<String>();
    public List<String> virus = new List<String>();
    public List<int> count = new List<int>();
    public List<int> shot = new List<int>();
    public List<int> destroyed = new List<int>();
    public List<GameObject> enemies = new List<GameObject>();
    LevelManager lvlManager;
    public GameObject med1;
    public GameObject med2;

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

    /// <summary>
    /// Finds enemies of current level
    /// </summary>
    public void FindEnemies()
    {
        lvlManager = FindObjectOfType<LevelManager>();

        enemies.Clear();

        foreach (GameObject enemy in lvlManager.allowedEnemies)
        {
            enemies.Add(enemy);
        }
    }

    /// <summary>
    /// Finds meds of current level
    /// </summary>
    public void FindMeds()
    {
        lvlManager = FindObjectOfType<LevelManager>();
        if (lvlManager != null)
        {
            med1 = lvlManager.med1;
            med2 = lvlManager.med2;
        }
    }

    public void DataLoop()
    {
        GameObject[] arr = GameObject.FindGameObjectsWithTag("Tower");
        foreach (GameObject obj in arr)
        {
            if (!obj.name.Equals("0"))
            {
                FindEnemies();
                FindMeds();

                Tower t = obj.GetComponent<Tower>();
                if (t.redShots != 0)
                    AddData(obj, t.redShots, t.redCures, "red");
                if (t.blueShots != 0)
                    AddData(obj, t.blueShots, t.blueCures, "blue");
                if (t.purpleShots != 0)
                    AddData(obj, t.purpleShots, t.purpleCures, "purple");
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
        if (t.purpleShots != 0)
            AddData(obj, t.purpleShots, t.purpleCures, "purple");
    }

    private void AddData(GameObject obj, int shot, int cure, string vir)
    {
        EnemyNumbers en = GameObject.Find("EnemyNumbers").GetComponent<EnemyNumbers>();
        Tower tow = obj.GetComponent<Tower>();
        this.playerId.Add(InputIDs.playerdata.playerID);
        this.groupId.Add(InputIDs.playerdata.groupID);
        this.dateTime.Add(DateTime.Now);
        this.level.Add(GameObject.Find("LevelManager").GetComponent<LevelManager>().level);
        this.wave.Add(waveVar);
        this.funds.Add(currencyVar);
        this.health.Add(healthVar);
        this.position.Add(tow.GetComponentInParent<BuildingPlace>().pos);

        // Type and upgrade
        string[] splitter = new string[] { "LV" };
        string[] arr = tow.gameObject.name.Split(splitter, StringSplitOptions.None);
        this.turretType.Add(arr[0]);
        this.upgrade.Add(arr[1]);


        // Finds med type
        AttackRanged rangedAttack = tow.GetComponentInChildren<AttackRanged>();
        string med = rangedAttack.attackMed.name;
        this.medicine.Add(med);


        this.virus.Add(vir);

        // Add wave count of enemy
        if (vir == "red")
        {
            this.count.Add(en.numRed[waveVar - 1]);
        }
        else if (vir == "blue")
        {
            this.count.Add(en.numBlue[waveVar - 1]);
        }
        else if (vir == "purple")
        {
            this.count.Add(en.numPurple[waveVar - 1]);
        }

        this.shot.Add(shot);
        this.destroyed.Add(cure);

        //scoreList.UpdateTable();
    }

    public void ClearData()
    {
        instance = null;
        gameObject.AddComponent<DataModel>();
        Destroy(this);
    }
}

