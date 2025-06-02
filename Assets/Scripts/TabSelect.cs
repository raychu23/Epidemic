using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TabSelect : MonoBehaviour
{

    // Input field to select on tab
    public GameObject nextInput;

    // PlayerData
    private InputIDs inputs;

    // Called once on start
    private void Start()
    {
        inputs = FindObjectOfType<InputIDs>();
        if (inputs.playerID != "" && inputs.groupID != "")
        {
            if (this.name == "PlayerID")
                GetComponent<InputField>().text = inputs.playerID;
            else if (this.name == "GroupID")
                GetComponent<InputField>().text = inputs.groupID;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<InputField>().isFocused && Input.GetKeyDown(KeyCode.Tab))
        {
            nextInput.GetComponent<InputField>().ActivateInputField();
        }
    }
}
