using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
[ExecuteInEditMode]
/// <summary>
/// Level manager inspector.
/// </summary>
public class LevelManagerInspector : MonoBehaviour
{
	[HideInInspector]
	// List with all enemies prefabs
	public List<GameObject> enemiesList = new List<GameObject>();

	[HideInInspector]
	// Enemies list for this level
	public List<GameObject> enemies
	{
		get
		{
			return levelManager.allowedEnemies;
		}
		set
		{
			levelManager.allowedEnemies = value;
		}
	}

	[HideInInspector]
	// List with all towers prefabs
	public List<GameObject> towersList = new List<GameObject>();

	[HideInInspector]
	// Towers list for this level
	public List<GameObject> towers
	{
		get
		{
			return levelManager.allowedTowers;
		}
		set
		{
			levelManager.allowedTowers = value;
		}
	}

	[HideInInspector]
	// Starting currency amount for this level
	public int currencyAmount
	{
		get
		{
			return levelManager.currencyAmount;
		}
		set
		{
			levelManager.currencyAmount = value;
		}
	}

	[HideInInspector]
	// Defeat attempts before loose for this level
	public int defeatAttempts
	{
		get
		{
			return levelManager.defeatAttempts;
		}
		set
		{
			levelManager.defeatAttempts = value;
		}
	}

	// Level manager component
	private LevelManager levelManager;

	/// <summary>
	/// Raises the enable event.
	/// </summary>
	void OnEnable()
	{
		levelManager = GetComponent<LevelManager>();
		Debug.Assert(levelManager, "Wrong stuff settings");
	}
}
#endif
