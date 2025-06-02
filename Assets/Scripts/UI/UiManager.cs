using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

/// <summary>
/// User interface and events manager.
/// </summary>
public abstract class UiManager : MonoBehaviour
{

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

    }

    /// <summary>
    /// Raises the enable event.
    /// </summary>
    void OnEnable()
    {

    }

    /// <summary>
    /// Raises the disable event.
    /// </summary>
    void OnDisable()
    {

    }

    /// <summary>
    /// Start this instance.
    /// </summary>
    void Start()
    {

    }

    /// <summary>
    /// Update this instance.
    /// </summary>
    void Update()
    {

    }

    protected void PointerTracer(string[] uiTags)
    {
        // Check if pointer over UI components
        GameObject hittedObj = null;
        PointerEventData pointerData = new PointerEventData(EventSystem.current);
        pointerData.position = Input.mousePosition;
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(pointerData, results);

        if (results.Count > 0) // UI components on pointer
        {
            // Search for Action Icon hit in results
            foreach (RaycastResult res in results)
            {
                GameObject resObj = res.gameObject;
                for (int i = 0; i < uiTags.Length; i++)
                {
                    if (resObj.CompareTag(uiTags[i]))
                    {
                        hittedObj = res.gameObject;
                        break;
                    }
                }

            }
            // Send message with user click data on UI component
            if (Input.GetMouseButtonDown(0) == true)
                EventManager.TriggerEvent("UserUiClick", hittedObj, null);
        }
        else // No UI components on pointer
        {
            // Check if pointer over colliders
            RaycastHit2D[] hits = Physics2D.RaycastAll(Camera.main.ScreenToWorldPoint(Input.mousePosition), Camera.main.transform.forward);
            foreach (RaycastHit2D hit in hits)
            {
                // If this object has unit info
                if (hit.collider.CompareTag("UnitInfo"))
                {
                    Tower tower = hit.collider.GetComponentInParent<Tower>();
                    if (tower != null)
                    {
                        hittedObj = tower.gameObject;
                        break;
                    }
                    AiBehavior aiBehavior = hit.collider.GetComponentInParent<AiBehavior>();
                    if (aiBehavior != null)
                    {
                        hittedObj = aiBehavior.gameObject;
                        break;
                    }
                    hittedObj = hit.collider.gameObject;
                    break;
                }
            }
            // Send message with user click data on game space
            if (Input.GetMouseButtonDown(0) == true)
                EventManager.TriggerEvent("UserClick", hittedObj, null);
        }

        EventManager.TriggerEvent("MouseInfo", hittedObj, null);
    }
}
