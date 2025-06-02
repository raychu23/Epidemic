using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Level control script.
/// </summary>
public class LevelManager : MonoBehaviour
{
    public GameObject med1;
    public GameObject med2;
	// UI scene. Load on level start
	public string levelUiSceneName;
	// Currency amount for this level
	public int currencyAmount = 1000;
	// How many times enemies can reach capture point before defeat
	public int defeatAttempts = 3;
    public int waves = 2;
    public string level;
	// List with allowed randomly generated enemy for this level
	public List<GameObject> allowedEnemies = new List<GameObject>();
	// List with allowed towers for this level
	public List<GameObject> allowedTowers = new List<GameObject>();

    // User interface manager
    private UIGameView uiManager;
    // Nymbers of enemy spawners in this level
    private int spawnNumbers;
	// Current loose counter
	private int beforeLoseCounter;
	// Victory or defeat condition already triggered
	private bool defeatTriggered = false;

    /// <summary>
    /// Awake this instance.
    /// </summary>
    void Awake()
    {
		// Load UI scene
		SceneManager.LoadScene(levelUiSceneName, LoadSceneMode.Additive);
    }

	/// <summary>
	/// Start this instance.
	/// </summary>
	void Start()
	{
		uiManager = FindObjectOfType<UIGameView>();
		SpawnPoint[] spawnPoints = FindObjectsOfType<SpawnPoint>();
		spawnNumbers = spawnPoints.Length;
		if (spawnNumbers <= 0)
		{
			Debug.LogError("Have no spawners");
		}
		// Set random enemies list for each spawner
		foreach (SpawnPoint spawnPoint in spawnPoints)
		{
			spawnPoint.randomEnemiesList = allowedEnemies;
		}
		Debug.Assert(uiManager, "Wrong initial parameters");
        // Set currency amount for this level
        uiManager.SetCurrency(currencyAmount);
        uiManager.SetWave(waves);
		beforeLoseCounter = defeatAttempts;
		uiManager.SetDefeatAttempts(beforeLoseCounter);
	}

    /// <summary>
    /// Raises the enable event.
    /// </summary>
    void OnEnable()
    {
        EventManager.StartListening("Captured", Captured);
        EventManager.StartListening("AllEnemiesAreDead", AllEnemiesAreDead);
    }

    /// <summary>
    /// Raises the disable event.
    /// </summary>
    void OnDisable()
    {
        EventManager.StopListening("Captured", Captured);
        EventManager.StopListening("AllEnemiesAreDead", AllEnemiesAreDead);
    }

    /// <summary>
    /// Enemy reached capture point.
    /// </summary>
    /// <param name="obj">Object.</param>
    /// <param name="param">Parameter.</param>
    private void Captured(GameObject obj, string param)
    {
		if (beforeLoseCounter > 0)
		{
			beforeLoseCounter--;
			uiManager.SetDefeatAttempts(beforeLoseCounter);
			if (beforeLoseCounter <= 0)
			{
                // Defeat
                if (defeatTriggered != true)
				    EventManager.TriggerEvent("Defeat", null, null);
                defeatTriggered = true;

            }
        }
    }

    /// <summary>
    /// All enemies are dead.
    /// </summary>
    /// <param name="obj">Object.</param>
    /// <param name="param">Parameter.</param>
    private void AllEnemiesAreDead(GameObject obj, string param)
    {
        spawnNumbers--;
        // Enemies dead at all spawners
        if (spawnNumbers <= 0)
        {
			// Check if lose condition was not triggered before
			if (defeatTriggered == false)
			{
	            // Victory
				EventManager.TriggerEvent("Victory", null, null);
			}
        }
    }

    /// <summary>
    /// Returns true if the player has lost the level.
    /// </summary>
    /// <returns></returns>
    public bool HasLost()
    {
        return defeatTriggered;
    }
}
