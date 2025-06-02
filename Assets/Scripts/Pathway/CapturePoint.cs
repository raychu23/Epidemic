using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// If enemy rise this point - player will be defeated.
/// </summary>
public class CapturePoint : MonoBehaviour
{

    // If capture point is going to be visible to player, true
    public bool visible;
    // Time to shrink
    public float shrinkTime;

    /// <summary>
    /// Raises the trigger enter2d event.
    /// </summary>
    /// <param name="other">Other.</param>
    void OnTriggerEnter2D(Collider2D other)
    {
        if (!visible)
        {
            Destroy(other.gameObject);
        }
        else
        {
            // play animation (probably a coroutine)
            Damage d = other.GetComponent<Damage>();
            if (d != null)
            {
                d.Capture(shrinkTime);
            }
        }

        EventManager.TriggerEvent("Captured", other.gameObject, null);
    }
}
