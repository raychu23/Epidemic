using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System;
using UnityEngine.SceneManagement;
using System.Runtime.InteropServices;

//this script sends game data to the server
public class SubmitData : MonoBehaviour
{
    // Singleton
    public static SubmitData instance;

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

    //This Method respond to the click on the submit button
    public void SubmitUpload()
    {
        if (SceneManager.GetActiveScene().name != "Tutorial")
        {
            DataModel data = DataModel.instance;
            ClickModel click = ClickModel.instance;
            StartCoroutine(Upload(data, click));
            // data.ClearData();
        }
    }

    IEnumerator Upload(DataModel data, ClickModel click)
    {
        int gameNum = -1;

        UnityWebRequest getGameNum = UnityWebRequest.Get("https://stat2games.sites.grinnell.edu/php/DefendersEpidemic/getDefendersEpidemicGameNum.php");
        yield return getGameNum.SendWebRequest();
        try
        {
            gameNum = int.Parse(getGameNum.downloadHandler.text);
        }
        catch (Exception e)
        {
            Debug.Log("Fetching game number failed.  Error message: " + e.ToString());
        }


        //try
        //{
        //    SendGameData(gameNum, data.level[0]);
        //}
        //catch (Exception e)
        //{
        //    Debug.Log("Error: " + e.ToString());
        //}
        

        for (int index = 0; index < data.playerId.Count; index++)
        {
            // CODAP integration
            //try
            //{
            //    SendLevelData(data.playerId[index], data.groupId[index], data.wave[index], data.funds[index], data.health[index], data.position[index],
            //                  data.turretType[index], data.upgrade[index], data.medicine[index], data.virus[index], data.count[index], data.shot[index], data.destroyed[index]);
            //}
            //catch (Exception e)
            //{
            //    Debug.Log("Error: " + e.ToString());
            //}

            Debug.Log(index);
            WWWForm form = new WWWForm();
            form.AddField("gameNum", gameNum);
            form.AddField("playerID", data.playerId[index]);
            form.AddField("groupID", data.groupId[index]);
            form.AddField("level", data.level[index]);
            form.AddField("wave", data.wave[index]);
            form.AddField("funds", data.funds[index]);
            form.AddField("health", data.health[index]);
            form.AddField("position", data.position[index]);
            form.AddField("turretType", data.turretType[index]);
            form.AddField("upgrade", data.upgrade[index]);
            form.AddField("medicine", data.medicine[index]);
            form.AddField("virus", data.virus[index]);
            form.AddField("count", data.count[index]);
            form.AddField("shot", data.shot[index]);
            form.AddField("destroyed", data.destroyed[index]);
            string url = "https://stat2games.sites.grinnell.edu/php/DefendersEpidemic/sendDefendersEpidemicGameInfo.php";
            UnityWebRequest www = UnityWebRequest.Post(url, form);
            yield return www.SendWebRequest();
            //Debug.Log(www.uploadProgress);
            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log("Player data created successfully.");
            }
        }

        for (int index = 0; index < click.playerId.Count; index++)
        {
            WWWForm clickForm = new WWWForm();
            clickForm.AddField("gameNum", gameNum);
            clickForm.AddField("playerID", click.playerId[index]);
            clickForm.AddField("groupID", click.groupId[index]);
            clickForm.AddField("level", click.level[index]);
            clickForm.AddField("wave", click.wave[index]);
            clickForm.AddField("table", click.table[index]);
            clickForm.AddField("graphs", click.graphs[index]);
            clickForm.AddField("barChart", click.barChart[index]);
            clickForm.AddField("dotPlot", click.dotPlot[index]);
            clickForm.AddField("medicine", click.medicine[index]);
            clickForm.AddField("turretType", click.turretType[index]);
            clickForm.AddField("shots", click.shots[index]);
            clickForm.AddField("destroyed", click.destroyed[index]);
            clickForm.AddField("percentDestroyed", click.percentDestroyed[index]);
            clickForm.AddField("showAverage", click.showAverages[index]);

            string url = "https://stat2games.sites.grinnell.edu/php/DefendersEpidemic/sendDefendersEpidemicClickData.php";
            UnityWebRequest www = UnityWebRequest.Post(url, clickForm);
            yield return www.SendWebRequest();
            //Debug.Log(www.uploadProgress);
            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log("Player click data recorded.");
            }

        }

        //UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }

    public void SendLeaderBoardData()
    {
        if (SceneManager.GetActiveScene().name != "Tutorial")
        {
            DataModel data = DataModel.instance;
            StartCoroutine(SendLeaderBoardDataCoroutine(data));
        }
    }

    private IEnumerator SendLeaderBoardDataCoroutine(DataModel data)
    {
        int finalIndex = data.playerId.Count - 1;
        string url = "https://stat2games.sites.grinnell.edu/php/DefendersEpidemic/sendDefendersEpidemicLeaderBoard.php";
        WWWForm form = new WWWForm();
        form.AddField("playerID", data.playerId[finalIndex]);
        form.AddField("groupID", data.groupId[finalIndex]);
        form.AddField("level", data.level[finalIndex]);
        form.AddField("health", data.health[finalIndex]);
        form.AddField("funds", data.funds[finalIndex]);
        UnityWebRequest www = UnityWebRequest.Post(url, form);
        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);
        }
        else
        {
            Debug.Log("LeaderBoard sent recorded.");
        }
    }

    //[DllImport("__Internal")]
    //private static extern void SendLevelData(String playerID, String groupID, int wave, int funds,
    //                                     int health, int position, string turretType, string upgrade, string medicine, string virus,
    //                                     int count, int shot, int destroyed);
    //[DllImport("__Internal")]
    //private static extern void SendGameData(int gameNum, string level);
}




