using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using System.Runtime.InteropServices;

/// <summary>
/// Version of saved data format. Use it to check if stored data format is equal to actual data format
/// </summary>
[Serializable]
public class DataVersion
{
    public int major = 1;
    public int minor = 0;
}

/// <summary>
/// Format of stored game progress data.
/// </summary>
[Serializable]
public class GameProgressData
{
    public System.DateTime saveTime = DateTime.MinValue;	// Saving time
    public string lastCompletedLevel = "";                  // Name of level was last completed
    public List<string> openedLevels = new List<string>();	// List with levels available to play
    public List<int> stars = new List<int>(new int[6]);     // List with stars on each level
}

/// <summary>
/// Structure to store data from a load request temporarily
/// </summary>
[Serializable]
public class ServerInfo
{
    public string completed;
    public string available;
    public int tutorial, l1, l2, l3, l4, l5;
}

/// <summary>
/// Structure to hold data for a level's leaderboard
/// </summary>
[Serializable]
public class LeaderBoardData
{
    [Serializable]
    public class Player
    {
        public string playerID;
        public string groupID;
        public int health;
        public int funds;
    }

    public Player[] players;
}

/// <summary>
/// Format of stored game configurations.
/// </summary>
[Serializable]
public class GameConfigurations
{
    public float soundVolume = 0.5f;
    public float musicVolume = 0.5f;
}

/// <summary>
/// Saving and load data from file.
/// </summary>
public class DataManager : MonoBehaviour
{
    // Singleton
    public static DataManager instance;

    // Game progress data container
    public GameProgressData progress = new GameProgressData();
    // Game configurations container
    public GameConfigurations configs = new GameConfigurations();
    // Game leaderboard container
    public LeaderBoardData lb;
    // Player data
    public GameObject playerData;

    // Data version container
    private DataVersion dataVersion = new DataVersion();
    // Name of file with data version
    private string dataVersionFile = "/DataVersion.dat";
    // Name of file with game progress data
    private string gameProgressFile = "/GameProgress.dat";
    // Name of file with game configurations
    private string gameConfigsFile = "/GameConfigs.dat";

    /// <summary>
    /// Awake this instance.
    /// </summary>
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);

            UpdateDataVersion();
            // Old version (now called when you click the main menu start button)
            //LoadGameProgress();
            LoadGameConfigs();
        }
        else if (instance != this)
        {
            Destroy(gameObject);
            return;
        }
        playerData = GameObject.Find("PlayerData");
        // Testing
        //GetLeaderBoard(1);
        //GetLeaderBoard(2);
        
    }

    /// <summary>
    /// Raises the destroy event.
    /// </summary>
    void OnDestroy()
    {
        if (instance == this)
        {
            instance = null;
        }
    }

    /// <summary>
    /// Updates the version of data format.
    /// </summary>
    private void UpdateDataVersion()
    {
        if (File.Exists(Application.persistentDataPath + dataVersionFile) == true)
        {
            BinaryFormatter bfOpen = new BinaryFormatter();
            FileStream fileToOpen = File.Open(Application.persistentDataPath + dataVersionFile, FileMode.Open);
            DataVersion version = (DataVersion)bfOpen.Deserialize(fileToOpen);
            fileToOpen.Close();

            switch (version.major)
            {
                case 1:
                    // Stored data has version 1.x
                    // Some handler to convert data if it is needed ...
                    break;
            }
        }
        BinaryFormatter bfCreate = new BinaryFormatter();
        FileStream fileToCreate = File.Create(Application.persistentDataPath + dataVersionFile);
        bfCreate.Serialize(fileToCreate, dataVersion);
        fileToCreate.Close();
    }

    /// <summary>
    /// Delete file with saved game data. For debug only
    /// </summary>
    public void DeleteGameProgress()
    {
        File.Delete(Application.persistentDataPath + gameProgressFile);
        progress = new GameProgressData();
        Debug.Log("Saved game progress deleted");
    }

    /// <summary>
    /// Saves the game progress to file.
    /// </summary>
    public void SaveGameProgress()
    {
        StartCoroutine(SaveRequest());
        // Old saving
        /*
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + gameProgressFile);
        progress.saveTime = DateTime.Now;
        bf.Serialize(file, progress);
        file.Close();
        */
    }

    IEnumerator SaveRequest()
    {
        WWWForm form = new WWWForm();
        form.AddField("playerID", playerData.GetComponent<InputIDs>().playerID);
        form.AddField("groupID", playerData.GetComponent<InputIDs>().groupID);
        form.AddField("completed", progress.lastCompletedLevel);
        form.AddField("available", progress.openedLevels.Count);
        form.AddField("tutorial", progress.stars[0]);
        form.AddField("l1", progress.stars[1]);
        form.AddField("l2", progress.stars[2]);
        form.AddField("l3", progress.stars[3]);
        form.AddField("l4", progress.stars[4]);
        form.AddField("l5", progress.stars[5]);

        string url = "https://stat2games.sites.grinnell.edu/php/DefendersEpidemic/sendDefendersEpidemicSaveData.php";
        UnityWebRequest www = UnityWebRequest.Post(url, form);
        yield return www.SendWebRequest();
        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);
        }
        else
        {
            Debug.Log("Player save created successfully.");
        }
    }

    /// <summary>
    /// Loads the game progress from file.
    /// </summary>
    public void LoadGameProgress(string name)
    {
        StartCoroutine(LoadRequest(name));
        //try
        //{
        //    CODAPSendDataGroup(playerData.GetComponent<InputIDs>().groupID);
        //    CODAPSendDataPlayer(playerData.GetComponent<InputIDs>().playerID);
        //}
        //catch (Exception e)
        //{
        //    Debug.Log("Error: " + e.ToString());
        //}

        // Old loading
        /*
        if (File.Exists(Application.persistentDataPath + gameProgressFile) == true)
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + gameProgressFile, FileMode.Open);
            progress = (GameProgressData)bf.Deserialize(file);
            file.Close();
        }
        */
    }

    IEnumerator LoadRequest(string name)
    {
        string url = "https://stat2games.sites.grinnell.edu/php/DefendersEpidemic/getDefendersEpidemicSaveData.php";
        WWWForm form = new WWWForm();

        // Testing purposes
        // playerData.GetComponent<InputIDs>().playerID = "Liam";
        form.AddField("playerid", playerData.GetComponent<InputIDs>().playerID);
        form.AddField("groupid", playerData.GetComponent<InputIDs>().groupID);
        UnityWebRequest www = UnityWebRequest.Post(url, form);
        yield return www.SendWebRequest();
        progress.openedLevels.Add("Tutorial");


        try
        {
            // Get and parse JSON info
            ServerInfo dat = JsonUtility.FromJson<ServerInfo>(www.downloadHandler.text);
            progress.lastCompletedLevel = dat.completed;
            int levelInt = int.Parse(dat.available);
            


            // Clear openedLevels
            progress.openedLevels.Clear();
            // Set tutorial level (edge case)
            progress.openedLevels.Add("Tutorial");
            // Add opened levels to list
            for (int i = 1; i < levelInt; i++)
            {
                progress.openedLevels.Add("Level " + i);
            }

            // Add stars
            progress.stars[0] = dat.tutorial;
            progress.stars[1] = dat.l1;
            progress.stars[2] = dat.l2;
            progress.stars[3] = dat.l3;
            progress.stars[4] = dat.l4;
            progress.stars[5] = dat.l5;


        }
        catch (Exception e)
        {
            Debug.Log("Fetching Save Data failed.  Error message: " + e.ToString());
        }

        //TODO Remove before production
        // Clear openedLevels
        progress.openedLevels.Clear();
        // Set tutorial level (edge case)
        progress.openedLevels.Add("Tutorial");
        // Add opened levels to list
        //TODO Change this back before production to (i < levelInt)
        for (int i = 1; i < 6; i++)
        {
            progress.openedLevels.Add("Level " + i);
        }
        // end of removal zone

        SceneManager.LoadScene(name);

    }

    public IEnumerator GetLeaderBoard(string level)
    {
        yield return StartCoroutine(LeaderBoardCoroutine(level));
    }

    private IEnumerator LeaderBoardCoroutine(string level)
    {
        string url = "https://stat2games.sites.grinnell.edu/php/DefendersEpidemic/getDefendersEpidemicLeaderBoard.php";
        WWWForm form = new WWWForm();
        form.AddField("level", level);
        UnityWebRequest www = UnityWebRequest.Post(url, form);
        yield return www.SendWebRequest();

        try
        {
            // Get and parse JSON info
            LeaderBoardData lbData = JsonUtility.FromJson<LeaderBoardData>(www.downloadHandler.text);
            lb = lbData;
            Debug.Log("lb update");

            // Testing
            //Debug.Log(lb.players[0].playerID);
        }
        catch (Exception e)
        {
            Debug.Log(www.downloadHandler.text);
            Debug.Log("Fetching LeaderBoard failed.  Error message: " + e.ToString());
        }
    }

    /// <summary>
    /// Saves the game configurations to file.
    /// </summary>
    public void SaveGameConfigs()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + gameConfigsFile);
        bf.Serialize(file, configs);
        file.Close();
    }

    /// <summary>
    /// Loads the game configurations from file.
    /// </summary>
    public void LoadGameConfigs()
    {
        if (File.Exists(Application.persistentDataPath + gameConfigsFile) == true)
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + gameConfigsFile, FileMode.Open);
            configs = (GameConfigurations)bf.Deserialize(file);
            file.Close();
        }
    }

    public void ClearMemory()
    {
        instance = null;
        gameObject.AddComponent<DataManager>();
        Destroy(this);
    }


    //    [DllImport("__Internal")]
    //    private static extern void CODAPSendDataGroup(string playerID);
    //    [DllImport("__Internal")]
    //    private static extern void CODAPSendDataPlayer(string groupID);
}
