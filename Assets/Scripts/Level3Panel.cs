using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level3Panel : MonoBehaviour
{
    public GameObject panel;
    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("StartWaveButton").GetComponent<Button>().interactable = false;
    }

    // Update is called once per frame
    public void OnClick()
    {
        panel.SetActive(false);
        GameObject.Find("StartWaveButton").GetComponent<Button>().interactable = true;
    }
}
