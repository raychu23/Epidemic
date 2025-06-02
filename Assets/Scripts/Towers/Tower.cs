using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Tower building and operation.
/// </summary>
public class Tower : MonoBehaviour
{
    // Prefab for actions tree
    public GameObject actions;
    // Selection highlight. Object changes color when turret is selected
    public GameObject highlight;
    // Visualisation of attack or defend range for this tower
    public GameObject range;
    // Data collection variables
    public int redShots, blueShots, redCures, blueCures, purpleShots, purpleCures;
    // User interface manager
    private UIGameView uiManager;
    private LevelManager lvlManager;
    // rangedAtt
    public GameObject ranAttack;
    // tower effectiveness modifiers
    public int redToPurpleEM;
    public int blueToPurpleEM;
    public int purpleToRedEM;
    public int greenToRedEM;
    public int orangeToRedEM;
    public int yellowToRedEM;
    public int purpleToBlueEM;
    public int greenToBlueEM;
    public int orangeToBlueEM;
    public int yellowToBlueEM;

    /// <summary>
    /// Raises the enable event.
    /// </summary>
    void OnEnable()
    {
        EventManager.StartListening("GamePaused", GamePaused);
        EventManager.StartListening("UserClick", UserClick);
        EventManager.StartListening("UserUiClick", UserClick);
        EventManager.StartListening("WaveEnd", WaveEnd);
        EventManager.StartListening("MouseInfo", MouseInfo);
    }

    /// <summary>
    /// Raises the disable event.
    /// </summary>
    void OnDisable()
    {
        EventManager.StopListening("GamePaused", GamePaused);
        EventManager.StopListening("UserClick", UserClick);
        EventManager.StopListening("UserUiClick", UserClick);
        EventManager.StopListening("WaveEnd", WaveEnd);
        EventManager.StopListening("MouseInfo", MouseInfo);
    }

    /// <summary>
    /// Atart this instance.
    /// </summary>
    void Start()
    {
        redShots = 0;
        blueShots = 0;
        purpleShots = 0;
        redCures = 0;
        blueCures = 0;
        purpleCures = 0;
        uiManager = FindObjectOfType<UIGameView>();
        lvlManager = FindObjectOfType<LevelManager>();
        Debug.Assert(uiManager && actions, "Wrong initial parameters");

        CloseActions();
    }

    /// <summary>
    /// Checks which medicines should be available depending on the current level
    /// </summary>
    private void CheckColor()
    {
        AttackRanged att = GetComponentInChildren<AttackRanged>();
        if (att != null)
        {
            foreach (TowerActionMed action in GetComponentsInChildren<TowerActionMed>(true))
            {

                action.gameObject.SetActive(true);

                if (lvlManager.level == "1" || lvlManager.level == "2" || lvlManager.level == "3" ||
                    lvlManager.level == "4" || lvlManager.level == "5"
                    || action.medPrefab.GetComponent<Medicine>().Equals(att.GetComponent<AttackRanged>().attackMed)
                    || (!action.medPrefab.GetComponent<Medicine>().Equals(lvlManager.med1.GetComponent<Medicine>())
                        && !action.medPrefab.GetComponent<Medicine>().Equals(lvlManager.med2.GetComponent<Medicine>())))
                {
                    action.gameObject.SetActive(false);
                }
            }
        }
    }

    /// <summary>
    /// Checks which medicines should be available depending on the current level
    /// </summary>
    private void CheckColorBuild()
    {
        AttackRanged att = GetComponentInChildren<AttackRanged>();
        if (att != null)
        {
            foreach (TowerActionBuild action in GetComponentsInChildren<TowerActionBuild>(true))
            {
                
                action.gameObject.SetActive(true);
                Debug.Log(action.gameObject.name.ToString());
                if (lvlManager.level == "2B" || lvlManager.level == "3B" ||
                    lvlManager.level == "4B" || lvlManager.level == "5B")
                {
                    if (!action.medicineOne.CompareTag("Placeholder"))
                        action.gameObject.SetActive(false);
                }
                else if (lvlManager.level == "1" || lvlManager.level == "2" || lvlManager.level == "3" ||
                    lvlManager.level == "4" || lvlManager.level == "5")
                {
                    if(action.medicineOne.CompareTag("Placeholder"))
                        action.gameObject.SetActive(false);
                    else if (action.medicineOne.GetComponent<Medicine>().Equals(att.GetComponent<AttackRanged>().attackMed)
                    || (!action.medicineOne.GetComponent<Medicine>().Equals(lvlManager.med1.GetComponent<Medicine>())
                        && !action.medicineOne.GetComponent<Medicine>().Equals(lvlManager.med2.GetComponent<Medicine>())))
                    {
                        action.gameObject.SetActive(false);
                    }
                }
                 
            }
        }
    }

    /// <summary>
    /// Opens the actions tree.
    /// </summary>
    private void OpenActions()
    {
        actions.SetActive(true);
        CheckColor();
        CheckColorBuild();
        if (highlight != null)
            highlight.GetComponent<SpriteRenderer>().color = Color.yellow;
    }

    /// <summary>
    /// Closes the actions tree.
    /// </summary>
    private void CloseActions()
    {
        if (actions.activeSelf == true)
        {
            actions.SetActive(false);
            if (highlight != null)
                highlight.GetComponent<SpriteRenderer>().color = Color.white;
        }
    }

    /// <summary>
    /// A bullet from this tower successfully reached the enemy (it hit the target)
    /// </summary>
    public void ShotHit(Weakness colorEnemy, Medicine med)
    {
        // If color is red
        if (colorEnemy == Weakness.Red)
        {
            redShots++;
        }
        else if (colorEnemy == Weakness.Blue)
        {
            blueShots++;
        }
        else if (colorEnemy == Weakness.Purple)
        {
            purpleShots++;
        }

        if (med.name == lvlManager.med1.name)
            uiManager.MedOneShots++;
        else if (med.name == lvlManager.med2.name)
            uiManager.MedTwoShots++;
    }

    /// <summary>
    /// A shot that has hit successfully killed the enemy
    /// </summary>
    public void ShotKill(Weakness colorEnemy, Medicine med)
    {
        // If color is red
        if (colorEnemy == Weakness.Red)
        {
            redCures++;
        }
        else if (colorEnemy == Weakness.Blue)
        {
            blueCures++;
        }
        else if (colorEnemy == Weakness.Purple)
        {
            purpleCures++;
        }

        if (med.name == lvlManager.med1.name)
            uiManager.MedOneCures++;
        else if (med.name == lvlManager.med2.name)
            uiManager.MedTwoCures++;
    }

    /// <summary>
    /// Changes the med type.
    /// </summary>
    /// <param name="medPrefab"></param>
    public void ChangeMed(GameObject medPrefab)
    {
        CloseActions();
        Price price = medPrefab.GetComponent<Price>();
        if (uiManager.SpendCurrency(price.price) == true)
        {
            AttackRanged att = GetComponentInChildren<AttackRanged>();

            // Add row when medicine is changed in game
            if (att.attackMed != null)
            {
                EventManager.TriggerEvent("TowerChange", gameObject, null);
            }
            // Get weakness of med
            Medicine medType = medPrefab.GetComponent<Medicine>();
            // Change the attack type of this turret
            att.attackMed = medType;
            ChangeColor();
            // Deactivate the options to select meds
            /*
             foreach (TowerActionMed action in actions.GetComponentsInChildren<TowerActionMed>())
            {
                action.gameObject.SetActive(false);
            }          
            */
            // Activate upgrade build actions
            foreach (TowerActionBuild action in actions.GetComponentsInChildren<TowerActionBuild>(true))
            {
                action.gameObject.SetActive(true);
            }
            CheckColor();
            ClearVars();
        }
    }

    /// <summary>
    /// Changes the med type with no cost.
    /// </summary>
    /// <param name="medPrefab"></param>
    private void ChangeMedFree(GameObject medPrefab)
    {
        CloseActions();
        AttackRanged att = GetComponentInChildren<AttackRanged>();

        // Add row when medicine is changed in game
        if (att.attackMed != null)
        {
            EventManager.TriggerEvent("TowerChange", gameObject, null);
        }
        // Get weakness of med
        Medicine medType = medPrefab.GetComponent<Medicine>();
        // Change the attack type of this turret
        att.attackMed = medType;
        ChangeColor();
        // Deactivate the options to select meds
        /*
         foreach (TowerActionMed action in actions.GetComponentsInChildren<TowerActionMed>())
        {
            action.gameObject.SetActive(false);
        }          
        */
        // Activate upgrade build actions
        foreach (TowerActionBuild action in actions.GetComponentsInChildren<TowerActionBuild>(true))
        {
            action.gameObject.SetActive(true);
        }
        CheckColor();
        ClearVars();
    }

    /// <summary>
    /// Builds the tower.
    /// </summary>
    /// <param name="towerPrefab">Tower prefab.</param>
    public void BuildTower(GameObject towerPrefab)
    {
        // Close active actions tree
        CloseActions();
        Price price = towerPrefab.GetComponent<Price>();

        if (towerPrefab.gameObject.CompareTag("Tower"))
        {
            price.price = 50;
        }
        else
        {
            if (lvlManager.level == "1" || lvlManager.level == "2")
            {
                price.price = 150;

            }
            else if (lvlManager.level == "2B")
            {
                price.price = 100;
            }
            else
            {
                if (towerPrefab.gameObject.CompareTag("RR"))
                {
                    price.price = 200;

                }
                else if (towerPrefab.gameObject.CompareTag("RS"))
                {
                    price.price = 150;

                }
                else if (towerPrefab.gameObject.CompareTag("SS"))
                {
                    price.price = 100;
                }
            }
        }

        // If enough currency
        if (uiManager.SpendCurrency(price.price) == true)
        {
            // Create new tower and place it on same position
            GameObject newTower = Instantiate<GameObject>(towerPrefab, transform.parent);
            newTower.name = towerPrefab.name;
            newTower.transform.position = transform.position;
            newTower.transform.rotation = transform.rotation;
            // If the tower is not the empty tower use the current medtype and keep color
            if (gameObject.name != "L0")
            {
                AttackRanged newRange = newTower.GetComponentInChildren<AttackRanged>();
                Medicine currentMedicine = GetComponentInChildren<AttackRanged>().attackMed;
                if (currentMedicine != null)
                {
                    // med of newTower = med of currentTower
                    newRange.attackMed = currentMedicine;
                    newTower.GetComponent<Tower>().ChangeColor();
                }
                // range of newTower = range of currentTower
                newRange.GetComponent<CircleCollider2D>().offset = ranAttack.GetComponent<CircleCollider2D>().offset;
                newRange.gameObject.transform.GetChild(0).transform.position = transform.Find("RangedAttack").GetChild(0).transform.position;

                // Used in data recording
                // Trigger towerchange with BuildingPlace sent
                EventManager.TriggerEvent("TowerChange", gameObject, null);
            }
            else
            {
                foreach (TowerActionBuild action in newTower.GetComponentsInChildren<TowerActionBuild>())
                {
                    action.gameObject.SetActive(false);
                }
            }
            // Destroy old tower
            Destroy(gameObject);
            EventManager.TriggerEvent("TowerBuild", newTower, null);
        }
    }

    //TODO Clean this code up to make it less repetitious with the former BuildTower 
    /// <summary>
    /// Builds the tower in case of provided medicines. If you want to prebuild with only one med, leave medTwo null
    /// </summary>
    /// <param name="towerPrefab">Tower prefab.</param>
    public void BuildTower(GameObject towerPrefab, GameObject medOne, GameObject medTwo)
    {
        // Close active actions tree
        CloseActions();
        Price price = towerPrefab.GetComponent<Price>();

        if (towerPrefab.gameObject.CompareTag("Tower"))
        {
            price.price = 50;
        }
        else
        {
            if (lvlManager.level == "1" || lvlManager.level == "2")
            {
                price.price = 150;

            }
            else if (lvlManager.level == "2B")
            {
                price.price = 100;
            }
            else
            {
                if (towerPrefab.gameObject.CompareTag("RR"))
                {
                    price.price = 200;

                }
                else if (towerPrefab.gameObject.CompareTag("RS"))
                {
                    price.price = 150;

                }
                else if (towerPrefab.gameObject.CompareTag("SS"))
                {
                    price.price = 100;
                }
            }
        }

        // If enough currency
        if (uiManager.SpendCurrency(price.price) == true)
        {
            // Create new tower and place it on same position
            GameObject newTower = Instantiate<GameObject>(towerPrefab, transform.parent);
            newTower.name = towerPrefab.name;
            newTower.transform.position = transform.position;
            newTower.transform.rotation = transform.rotation;

            foreach (TowerActionBuild action in newTower.GetComponentsInChildren<TowerActionBuild>())
            {
                action.gameObject.SetActive(false);
            }

            if (medOne != null && medTwo != null)
            {
                Tower[] towers = newTower.GetComponentsInChildren<Tower>();

                //TODO There must be some better way to set these values. If Start->Awake, then the L0 instantiations cause errors
                towers[0].SetTowerManagers(lvlManager, uiManager);
                towers[1].SetTowerManagers(lvlManager, uiManager);

                towers[0].ChangeMedFree(medOne);
                towers[1].ChangeMedFree(medTwo);
            }
            else
            {
                Tower t = newTower.GetComponentInChildren<Tower>();
                t.SetTowerManagers(lvlManager, uiManager);
                t.ChangeMedFree(medOne);
            }

            if (gameObject.name != "L0")
            {
                AttackRanged newRange = newTower.GetComponentInChildren<AttackRanged>();
                // range of newTower = range of currentTower
                newRange.GetComponent<CircleCollider2D>().offset = ranAttack.GetComponent<CircleCollider2D>().offset;
                newRange.gameObject.transform.GetChild(0).transform.position = transform.Find("RangedAttack").GetChild(0).transform.position;

                // Used in data recording
                // Trigger towerchange
                EventManager.TriggerEvent("TowerChange", gameObject, null);
            }


            // Destroy old tower
            Destroy(gameObject);
            EventManager.TriggerEvent("TowerBuild", newTower, null);
        }
    }

    /// <summary>
    /// Changes color of ColoredPart to corresponding medtype
    /// </summary>
    private void ChangeColor()
    {
        Medicine medType = GetComponentInChildren<AttackRanged>().attackMed;
        // Get renderer of this turret
        SpriteRenderer mat = GetComponentInChildren<NavAgent>().transform.Find("ColoredPart").GetComponent<SpriteRenderer>();
        // Change color of material to corresponding med type
        mat.color = medType.color;
    }

    /// <summary>
    /// Sells the tower with half of price.
    /// </summary>
    /// <param name="emptyPlacePrefab">Empty place prefab.</param>
    public void SellTower(GameObject emptyPlacePrefab)
    {
        CloseActions();
        /*
		DefendersSpawner defendersSpawner = GetComponent<DefendersSpawner>();
		// Destroy defenders on tower sell
		if (defendersSpawner != null)
		{
			foreach (KeyValuePair<GameObject, Transform> pair in defendersSpawner.defPoint.activeDefenders)
			{
				Destroy(pair.Key);
			}
		} */
        Price price = GetComponent<Price>();
        uiManager.AddCurrency(price.sellPrice);
        // Place building place
        GameObject newTower = Instantiate<GameObject>(emptyPlacePrefab, transform.parent);
        newTower.name = emptyPlacePrefab.name;
        newTower.transform.position = transform.position;
        newTower.transform.rotation = transform.rotation;

        // Record data
        EventManager.TriggerEvent("TowerChange", gameObject, null);

        // Destroy old tower
        Destroy(gameObject);
        EventManager.TriggerEvent("TowerSell", null, null);
    }

    /// <summary>
    /// Disable tower raycast and close building tree on game pause.
    /// </summary>
    /// <param name="obj">Object.</param>
    /// <param name="param">Parameter.</param>
    private void GamePaused(GameObject obj, string param)
    {
        if (param == bool.TrueString) // Paused
        {
            CloseActions();
        }
    }

    /// <summary>
    /// On user click.
    /// </summary>
    /// <param name="obj">Object.</param>
    /// <param name="param">Parameter.</param>
    private void UserClick(GameObject obj, string param)
    {
        if (obj == gameObject) // This tower is clicked
        {
            if (actions.activeSelf == false)
            {
                // Open building tree if it is not
                OpenActions();
            }
        }
        else // Other click
        {
            // Close active building tree
            CloseActions();
        }
    }

    /// <summary>
    /// On mouse over
    /// </summary>
    /// <param name="obj"></param>
    /// <param name="param"></param>
    private void MouseInfo(GameObject obj, string param)
    {
        if (obj == gameObject)
        {
            ShowRange(true);
        }
        else
        {
            ShowRange(false);
        }
    }

    /// <summary>
    /// Display tower's attack or defend range.
    /// </summary>
    /// <param name="condition">If set to <c>true</c> condition.</param>
	public void ShowRange(bool condition)
    {
        if (range != null)
        {
            range.SetActive(condition);
        }
    }

    /// <summary>
    /// Clears the shot recording variables.
    /// </summary>
    private void ClearVars()
    {
        redShots = 0;
        blueShots = 0;
        redCures = 0;
        blueCures = 0;
    }

    /// <summary>
    /// Event for WaveEnd that causes the tower to clear the shot data.
    /// </summary>
    /// <param name="obj"></param>
    /// <param name="param"></param>
    private void WaveEnd(GameObject obj, string param)
    {
        //Debug.Log("Turret: " + blueCures + " " + redCures);
        ClearVars();
    }

    /// <summary>
    /// Sets the managers of t to the current tower's managers.
    /// </summary>
    /// <param name="t"></param>
    private void SetTowerManagers(LevelManager lvl, UIGameView ui)
    {
        lvlManager = lvl;
        uiManager = ui;
    }

    public void Enable()
    {
        EventManager.StartListening("UserClick", UserClick);
    }

    public void Disable()
    {
        EventManager.StopListening("UserClick", UserClick);
    }
}
