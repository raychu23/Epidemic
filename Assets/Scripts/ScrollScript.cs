using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollScript : MonoBehaviour
{
    public GameObject scroll;
    public GameObject display;

    public void OnClick()
    {
        scroll.SetActive(display.activeSelf);
        display.SetActive(!display.activeSelf);
    }
}
