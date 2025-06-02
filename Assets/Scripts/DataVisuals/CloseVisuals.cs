using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseVisuals : MonoBehaviour
{
    void OnClick()
    {
        EventManager.TriggerEvent("ButtonPressed", gameObject, "DataVisual");
    }
}
