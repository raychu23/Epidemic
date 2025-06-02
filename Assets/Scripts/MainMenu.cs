using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using System.Runtime.InteropServices;

/// <summary>
/// Main menu operate.
/// </summary>
public class MainMenu : MonoBehaviour
{
    // Name of scene to start on click
    public string startSceneName;
    // Credits menu
    public GameObject creditsMenu;
    // Info panel
    public GameObject infoMenu;
    // Bad Word Menu
    public GameObject badWordMenu;
    // Inputs
    public GameObject player;
    public GameObject group;
    
    [SerializeField] TextAsset badWordsFile;

    private string[] badWords;

    public void Begin()
    {
        
        string pid = GameObject.Find("PText").GetComponent<Text>().text;
        string gid = GameObject.Find("GText").GetComponent<Text>().text;
        
        // Empty Check
        if (string.IsNullOrEmpty(pid) || string.IsNullOrEmpty(gid) || pid.Length > 12 || gid.Length > 12)
        {
            ColorBlock cb = player.GetComponent<InputField>().colors;
            cb.normalColor = Color.red;
            player.GetComponent<InputField>().colors = cb;
            group.GetComponent<InputField>().colors = cb;

            infoMenu.SetActive(true);
            badWordMenu.SetActive(false);

        }
        // Bad Word Filter
        else if (IsBadWord(pid) || IsBadWord(gid))
        {
            badWordMenu.SetActive(true);
            infoMenu.SetActive(false);
        }
        else
        {
            GameObject.Find("PlayerData").GetComponent<InputIDs>().playerID = pid;
            Global.playerID = pid;
            GameObject.Find("PlayerData").GetComponent<InputIDs>().groupID = gid;
            Global.groupID = gid;
            DataManager.instance.LoadGameProgress(startSceneName);
            // Scene loading is in DataManager
            //SceneManager.LoadScene(startSceneName);
        }
        
    }

    /// <summary>
    /// Raises the enable event.
    /// </summary>
    void OnEnable()
    {
        EventManager.StartListening("ButtonPressed", ButtonPressed);
    }

    /// <summary>
    /// Raises the disable event.
    /// </summary>
    void OnDisable()
    {
        EventManager.StopListening("ButtonPressed", ButtonPressed);
    }

    private void Start()
    {
        EventManager.TriggerEvent("WaveStart", null, "0");
        player.GetComponent<InputField>().contentType = InputField.ContentType.Alphanumeric;
        group.GetComponent<InputField>().contentType = InputField.ContentType.Alphanumeric;
    }

    /// <summary>
    /// Checks to see if the corresponding word matches with any words in the bad word file.
    /// </summary>
    /// <param name="word"></param>
    /// <returns></returns>
    private bool IsBadWord(string word)
    {
        word = word.ToLower();
        //Removes whitespace. Another method might be better (splitting the word and checking each)
        word = word.Replace(" ", string.Empty);
        
        int left, right;
        left = 0;
        right = badWords.Length - 1;

        /*
        while (right >= left)
        {
            int curWord = (int)((right + left) / 2);
            if (word.Contains(badWords[curWord]))
            {
                return true;
            }
            else if (word.CompareTo(badWords[curWord]) < 0)
            {
                right = curWord - 1;
            }
            else
                left = curWord + 1;
        }
        */

        while (right >= left)
        {
            if (word.Length <= 3 && word == badWords[left])
            {
                Debug.Log(badWords[left]);
                return true;
            }
            else if (word.Length > 3 && badWords[left].Length > 2 && word.Contains(badWords[left]))
            {
                return true;
            }
            else
                left++;
        }
        
        return false;
    }

    
    void Awake()
    {
        //Debug.Assert(creditsMenu, "Wrong initial settings");
        // Sets up data structure from bad word file
//#if !UNITY_EDITOR
//            Init();
//            CreateDataContext();
//            CODAPSendDataAll();
//#endif

        badWords = badWordsFile.text.Split(',');
        for (int i = 0; i < badWords.Length; i++)
        {
            badWords[i] = badWords[i].Replace(" ", string.Empty);
            badWords[i] = badWords[i].ToLower();
        }
    }

    /// <summary>
    /// Buttons pressed handler.
    /// </summary>
    /// <param name="obj">Object.</param>
    /// <param name="param">Parameter.</param>
    private void ButtonPressed(GameObject obj, string param)
    {
        switch (param)
        {
            case "Start":
                Begin();
                break;
            case "OpenCredits":
                creditsMenu.SetActive(true);
                break;
            case "CloseCredits":
                creditsMenu.SetActive(false);
                break;
            case "Download":
                OpenLinkJSPlugin("https://stat2games.sites.grinnell.edu/data/epidemic/epidemic.html");
                obj.GetComponent<Button>().interactable = false;
                obj.GetComponent<Button>().interactable = true;
                break;
            case "Resources":
                OpenLinkJSPlugin("https://stat2labs.sites.grinnell.edu/epidemic.html");
                obj.GetComponent<Button>().interactable = false;
                obj.GetComponent<Button>().interactable = true;
                break;
        }
    }

    private void OpenLinkJSPlugin(string url)
    {
#if !UNITY_EDITOR
		    OpenWindow(url);
#endif
    }

    [DllImport("__Internal")]
    private static extern void OpenWindow(string url);

    //[DllImport("__Internal")]
    //private static extern void Init();

    //[DllImport("__Internal")]
    //private static extern void CreateDataContext();

    //[DllImport("__Internal")]
    //private static extern void CODAPSendDataAll();
}
