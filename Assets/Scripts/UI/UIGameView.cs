using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using System;
using System.Runtime.InteropServices;

/// <summary>
/// User interface and events manager.
/// </summary>
public class UIGameView : UiManager
{
    // This scene will loaded after whis level exit
    public string exitSceneName;
    // Start screen canvas
    /// public GameObject startScreen;
    // Pause menu canvas
    public GameObject pauseMenu;
    // Defeat menu canvas
    public GameObject defeatMenu;
    // Victory menu canvas
    public GameObject victoryMenu;
    // Level interface
    public GameObject levelUI;
    //Victory Stars
    public GameObject victoryStar1;
    public GameObject victoryStar2;
    public GameObject victoryStar3;
    // Avaliable currency amount
    public Text currencyAmount;
    // Capture attempts before defeat
    public Text defeatAttempts;
    // Amount of waves in the level
    public Text totalWaves;
    // Victory and defeat menu display delay
    public float menuDisplayDelay = 1f;
    // Live Effectiveness Text
    public Text liveEffectiveness1;
    public Text liveEffectiveness2;

    public GameObject leaderboardButton;
    public GameObject DataTableButton;
    public GameObject instruct;

    public int dataTableInit = 0;

    // Is game paused?
    private bool paused;
    // Is game set to fast forward?
    private bool fastForward = false;
    // Camera is dragging now
    private bool cameraIsDragged;
    // Origin point of camera dragging start
    private Vector3 dragOrigin = Vector3.zero;
    // Whether wave is in progress or not
    public bool WaveStatus { get; private set; }
    // Whether graph is displayed
    private bool graphStatus = false;
    private LevelManager lvlManager;

    // Live Effectiness Information
    public int MedOneShots { get; set; }
    public int MedTwoShots { get; set; }
    public int MedOneCures { get; set; }
    public int MedTwoCures { get; set; }
    private float medOneEffectiveness = 0;
    private float medTwoEffectiveness = 0;

    private bool defeatTrigger = false;

    /// Only useful if we use a movable camera
    /*
    // Camera control component
    private CameraControl cameraControl;
    */

    /// <summary>
    /// Awake this instance.
    /// </summary>
    void Awake()
    {
        /// cameraControl = FindObjectOfType<CameraControl>();
        /// Debug.Assert(cameraControl && startScreen, "Wrong initial parameters");

        MedOneShots = 0;
        MedTwoShots = 0;
        MedOneCures = 0;
        MedTwoCures = 0;
        Debug.Assert(pauseMenu && defeatMenu && victoryMenu && levelUI && defeatAttempts && currencyAmount, "Wrong initial parameters");
        WaveStatus = false;
    }

    /// <summary>
    /// Raises the enable event.
    /// </summary>
    void OnEnable()
    {
        EventManager.StartListening("UnitKilled", UnitKilled);
        EventManager.StartListening("ButtonPressed", ButtonPressed);
        EventManager.StartListening("Defeat", Defeat);
        EventManager.StartListening("Victory", Victory);
        EventManager.StartListening("WaveStart", WaveStart);
        EventManager.StartListening("WaveEnd", WaveEnd);
        EventManager.StartListening("TowerChange", TowerChange);
    }

    /// <summary>
    /// Raises the disable event.
    /// </summary>
    void OnDisable()
    {
        EventManager.StopListening("UnitKilled", UnitKilled);
        EventManager.StopListening("ButtonPressed", ButtonPressed);
        EventManager.StopListening("Defeat", Defeat);
        EventManager.StopListening("Victory", Victory);
        EventManager.StopListening("WaveStart", WaveStart);
        EventManager.StopListening("WaveEnd", WaveEnd);
        EventManager.StopListening("TowerChange", TowerChange);
    }

    /// <summary>
    /// Start this instance.
    /// </summary>
    void Start()
    {
        lvlManager = FindObjectOfType<LevelManager>();
    }

    /// <summary>
    /// Update this instance.
    /// </summary>
    void Update()
    {
        // Handles spacebar
        if (Input.GetKeyDown("space") && !paused && !defeatTrigger)
        {
            FastForward();
        }

        string[] uiTags = { "ActionIcon", "WaveInfo", "UIText", "UIButton" };

        if (paused == false)
        {
            PointerTracer(uiTags);
        }

        // Live Effectiveness
        LevelManager lvlManager = FindObjectOfType<LevelManager>();

        medOneEffectiveness = CalculateEffectiveness(MedOneShots, MedOneCures);
        medTwoEffectiveness = CalculateEffectiveness(MedTwoShots, MedTwoCures);

        liveEffectiveness1.text = lvlManager.med1.name + ": " + medOneEffectiveness.ToString("0.00") + "%";
        liveEffectiveness2.text = lvlManager.med2.name + ": " + medTwoEffectiveness.ToString("0.00") + "%";

        liveEffectiveness1.color = lvlManager.med1.GetComponent<Medicine>().color;
        liveEffectiveness2.color = lvlManager.med2.GetComponent<Medicine>().color;
    }

    /// <summary>
    /// Calculates the effectiveness.
    /// </summary>
    /// <param name="shot"></param>
    /// <param name="cure"></param>
    private float CalculateEffectiveness(float shot, float cure)
    {
        if (cure == 0)
            return 0;
        else
            return cure / shot * 100;
    }

    /// <summary>
    /// Stop current scene and load new scene
    /// </summary>
    /// <param name="sceneName">Scene name.</param>
    private void LoadScene(string sceneName)
    {
        if (sceneName != "LevelChoose")
        {
            DataModel.instance.ClearData();
            ClickModel.instance.ClearData();
        }
        EventManager.TriggerEvent("SceneQuit", null, null);
        SceneManager.LoadScene(sceneName);
        Time.timeScale = 1;
    }


    /// <summary>
    /// Resumes the game.
    /// </summary>
    private void ResumeGame()
    {
        GoToLevel();
        PauseGame(false);
        FastForward();
    }

    /// <summary>
    /// Gos to main menu.
    /// </summary>
	private void ExitFromLevel()
    {
        LoadScene(exitSceneName);
    }

    /// <summary>
    /// Closes all UI canvases.
    /// </summary>
    private void CloseAllUI()
    {
        /// startScreen.SetActive (false);
        pauseMenu.SetActive(false);
        defeatMenu.SetActive(false);
        victoryMenu.SetActive(false);
    }

    /// <summary>
    /// Pauses the game.
    /// </summary>
    /// <param name="pause">If set to <c>true</c> pause.</param>
    private void PauseGame(bool pause)
    {
        GameObject.Find("Pause").GetComponent<Button>().interactable = !pause;
        GameObject.Find("Fast Forward").GetComponent<Button>().interactable = !pause;
        //If data table has not been intialized, do not allow user to click show data
        //while game is paused
        if (dataTableInit == 0)
        {
            DataTableButton.GetComponent<Button>().interactable = !pause;
        }
        paused = pause;
        // Stop the time on pause
        Time.timeScale = pause ? 0f : 1f;
        EventManager.TriggerEvent("GamePaused", null, pause.ToString());

    }

    /// <summary>
    /// Gos to pause menu.
    /// </summary>
	private void GoToPauseMenu()
    {
        if (fastForward == true)
        {
            FastForward();
        }
        PauseGame(true);
        CloseAllUI();
        pauseMenu.SetActive(true);
    }

    /// <summary>
    /// Gos to level.
    /// </summary>
    private void GoToLevel()
    {
        CloseAllUI();
        levelUI.SetActive(true);
        PauseGame(false);
    }

    /// <summary>
    /// Gos to defeat menu.
    /// </summary>
	private void Defeat(GameObject obj, string param)
    {
        EventManager.TriggerEvent("WaveEnd", null, null);
        defeatTrigger = true;
        StartCoroutine("DefeatCoroutine");
    }

    /// <summary>
    /// Display defeat menu after delay.
    /// </summary>
    /// <returns>The coroutine.</returns>
    private IEnumerator DefeatCoroutine()
    {
        //Deactivating pause and fastforward buttons
        GameObject.Find("Pause").GetComponent<Button>().interactable = false;
        GameObject.Find("Fast Forward").GetComponent<Button>().interactable = false;
        GameObject.Find("StartWaveButton").GetComponent<Button>().interactable = false;

        Submit();
        yield return new WaitForSeconds(menuDisplayDelay);
        //PauseGame(true);
        CloseAllUI();
        //no leaderboard for tutorial
        if (FindObjectOfType<LevelManager>().level != "0")
        {
            leaderboardButton.SetActive(true);
        }
        defeatMenu.SetActive(true);
    }

    /// <summary>
    /// Gos to victory menu.
    /// </summary>
	private void Victory(GameObject obj, string param)
    {
        //SubmitData();

        StartCoroutine("VictoryCoroutine");
    }

    /// <summary>
    /// Display victory menu after delay.
    /// </summary>
    /// <returns>The coroutine.</returns>
    private IEnumerator VictoryCoroutine()
    {
        Submit();
        SendLeaderBoardData();
        yield return new WaitForSeconds(menuDisplayDelay);
        // PauseGame(true);
        CloseAllUI();

        //Deactivating pause and fastforward buttons
        GameObject.Find("Pause").GetComponent<Button>().interactable = false;
        GameObject.Find("Fast Forward").GetComponent<Button>().interactable = false;

        // --- Game progress autosaving ---
        // Get the name of completed level
        DataManager.instance.progress.lastCompletedLevel = SceneManager.GetActiveScene().name;
        // Check if this level have no completed before
        bool hit = false;
        string levelName = SceneManager.GetActiveScene().name;
        if (levelName.EndsWith("B"))
        {
            levelName = levelName.Remove(levelName.Length - 1);
            levelName = levelName.Trim();
        }
        foreach (string level in DataManager.instance.progress.openedLevels)
        {
            if (level == levelName)
            {
                hit = true;
                break;
            }
        }
        if (hit == false)
        {
            DataManager.instance.progress.openedLevels.Add(levelName);
        }

        // Save Stars
        if (levelName == "Tutorial")
        {
            if (DataManager.instance.progress.stars[0] < GetDefeatAttempts())
                DataManager.instance.progress.stars[0] = GetDefeatAttempts();
        }
        else
        {
            int sceneIndex = (int) char.GetNumericValue(levelName[levelName.Length - 1]);

            if (DataManager.instance.progress.stars[sceneIndex] < GetDefeatAttempts())
                DataManager.instance.progress.stars[sceneIndex] = GetDefeatAttempts();
        }

        // Save game progress
        DataManager.instance.SaveGameProgress();
        victoryStar1.SetActive(false);
        victoryStar2.SetActive(false);
        victoryStar3.SetActive(false);
        switch (GetDefeatAttempts())
        {
            case 1:
                victoryStar1.SetActive(true);
                break;
            case 2:
                victoryStar1.SetActive(true);
                victoryStar2.SetActive(true);
                break;
            case 3:
                victoryStar1.SetActive(true);
                victoryStar2.SetActive(true);
                victoryStar3.SetActive(true);
                break;
        }
        //no leaderboard for tutorial
        if (FindObjectOfType<LevelManager>().level != "0")
        {
            leaderboardButton.SetActive(true);
        }
        victoryMenu.SetActive(true);
    }

    /// <summary>
    /// Restarts current level.
    /// </summary>
	private void RestartLevel()
    {
        LoadScene(SceneManager.GetActiveScene().name);
    }

    /// <summary>
    /// Gets the current defeat attempts.
    /// </summary>
    /// <returns></returns>
    private int GetDefeatAttempts()
    {
        int.TryParse(defeatAttempts.text, out int health);
        return health;
    }

    /// <summary>
    /// Gets current currency amount.
    /// </summary>
    /// <returns>The currency.</returns>
    public int GetCurrency()
    {
        int.TryParse(currencyAmount.text, out int currency);
        return currency;
    }

    /// <summary>
    /// Sets currency amount.
    /// </summary>
    /// <param name="currency">Currency.</param>
	public void SetCurrency(int currency)
    {
        currencyAmount.text = currency.ToString();
    }

    public void SetWave(int waves)
    {
        totalWaves.text = waves.ToString();
    }
    /// <summary>
    /// Adds the currency.
    /// </summary>
    /// <param name="currency">Currency.</param>
	public void AddCurrency(int currency)
    {
        SetCurrency(GetCurrency() + currency);
    }

    /// <summary>
    /// Spends the currency if it is.
    /// </summary>
    /// <returns><c>true</c>, if currency was spent, <c>false</c> otherwise.</returns>
    /// <param name="cost">Cost.</param>
    public bool SpendCurrency(int cost)
    {
        bool res = false;
        int currentCurrency = GetCurrency();
        if (currentCurrency >= cost)
        {
            SetCurrency(currentCurrency - cost);
            res = true;
        }
        return res;
    }

    /// <summary>
    /// Sets the defeat attempts.
    /// </summary>
    /// <param name="attempts">Attempts.</param>
    public void SetDefeatAttempts(int attempts)
    {
        defeatAttempts.text = attempts.ToString();
    }

    /// <summary>
    /// On unit killed by other unit.
    /// </summary>
    /// <param name="obj">Object.</param>
    /// <param name="param">Parameter.</param>
	private void UnitKilled(GameObject obj, string param)
    {
        // If this is enemy
        if (obj.CompareTag("Enemy") || obj.CompareTag("FlyingEnemy"))
        {
            Price price = obj.GetComponent<Price>();
            if (price != null)
            {
                // Add currency for enemy kill
                if(lvlManager.level == "5" || lvlManager.level == "5B")
                {
                    price.price = 5;
                }
                AddCurrency(price.price);
            }
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
            case "Pause":
                GoToPauseMenu();
                break;
            case "Resume":
                GoToLevel();
                break;
            case "Back":
                ExitFromLevel();
                break;
            case "Restart":
                RestartLevel();
                break;
            case "FastForward":
                FastForward();
                break;
            case "DataVisual":
                DataVisual();
                break;
            case "BarChart":
                BarChart();
                break;
            case "Instruction":
                OpenLinkJSPlugin("https://stat2labs.sites.grinnell.edu/epidemic.html");
                obj.GetComponent<Button>().interactable = false;
                obj.GetComponent<Button>().interactable = true;
                break;
        }
    }
    private void BarChart()
    {

        if (fastForward)
        {
            FastForward();
        }
        if (paused)
        {
            //pause game only if game is not already paused
            if (!pauseMenu.activeSelf)
            {
                PauseGame(false);
            }
            if (defeatTrigger || victoryMenu.activeSelf)
            {
                GameObject.Find("Pause").GetComponent<Button>().interactable = false;
                GameObject.Find("Fast Forward").GetComponent<Button>().interactable = false;
            }
        }
        else
            PauseGame(true);

        if (graphStatus == false)
        {
            SceneManager.LoadScene("BarChart", LoadSceneMode.Additive);
            graphStatus = true;
            ClickModel.instance.graphsCount++;
        }
        else if (graphStatus == true)
        {
            SceneManager.UnloadSceneAsync("BarChart");
            graphStatus = false;
        }
    }

    /// <summary>
    /// Functions that must occur when data visualization appears
    /// </summary>
    private void DataVisual()
    {

        if (fastForward)
        {
            FastForward();
        }
        if (paused)
        {
            //pause game only if game is not already paused
            if (!pauseMenu.activeSelf)
            {
                PauseGame(false);
            }
            if (defeatTrigger || victoryMenu.activeSelf)
            {
                GameObject.Find("Pause").GetComponent<Button>().interactable = false;
                GameObject.Find("Fast Forward").GetComponent<Button>().interactable = false;
            }
        }
        else
            PauseGame(true);

        if (graphStatus == false)
        {
            SceneManager.LoadScene("ScatterPlot", LoadSceneMode.Additive);
            graphStatus = true;
            ClickModel.instance.graphsCount++;
        }
        else if (graphStatus == true)
        {
            SceneManager.UnloadSceneAsync("ScatterPlot");
            graphStatus = false;
        }
    }

    /// <summary>
    /// Causes the game to work in a fast forward timescale.
    /// </summary>
    private void FastForward()
    {
        Image cur = GameObject.Find("Fast Forward").GetComponent<Image>();
        fastForward = !fastForward;
        if (fastForward)
        {
            cur.color = Color.green;
            Time.timeScale = 4f;
        }
        else
        {
            cur.color = Color.white;
            Time.timeScale = 1f;
        }
    }

    private void WaveEnd(GameObject obj, string param)
    {
        if (fastForward)
        {
            FastForward();
        }

        DataModel dm = DataModel.instance;
        SendLevelInfo(dm);
        dm.DataLoop();

        ClickModel cm = ClickModel.instance;
        cm.waveVar = GameObject.Find("StartWaveButton").GetComponent<WaveStart>().GetCurrentWave();
        cm.AddCount();

        // For data when wave is on or off
        WaveStatus = false;
    }

    private void WaveStart(GameObject obj, string param)
    {
        WaveStatus = true;
    }

    private void TowerChange(GameObject obj, string param)
    {
        Tower tow = obj.GetComponent<Tower>();
        Debug.Assert(tow != null, "TowerChange event should be sent a tower", obj);
        // if the wave is currently running and the turret has information
        if (WaveStatus && (tow.redShots != 0 || tow.blueShots != 0 || tow.purpleShots != 0))
        {
            DataModel dm = DataModel.instance;
            SendLevelInfo(dm);
            dm.DataSingle(obj);
        }
    }

    /// <summary>
    /// Sends the UI related level info to the DataModel
    /// </summary>
    /// <param name="dm"></param>
    private void SendLevelInfo(DataModel dm)
    {
        dm.currencyVar = GetCurrency();
        dm.healthVar = GetDefeatAttempts();
        dm.waveVar = GameObject.Find("StartWaveButton").GetComponent<WaveStart>().GetCurrentWave();
    }

    /// <summary>
    /// Raises the destroy event.
    /// </summary>
    void OnDestroy()
    {
        StopAllCoroutines();
    }

    private void Submit()
    {
        SubmitData.instance.SubmitUpload();
    }

    private void SendLeaderBoardData()
    {
        SubmitData.instance.SendLeaderBoardData();
    }

    private void OpenLinkJSPlugin(string url)
    {
        #if !UNITY_EDITOR
		            OpenWindow(url);
        #endif
    }

    [DllImport("__Internal")]
    private static extern void OpenWindow(string url);
}
