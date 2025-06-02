using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuteActive : MonoBehaviour
{
    public GameObject soundIcon;
    // Update is called once per frame
    public void OnClick()
    {
        soundIcon.SetActive(!soundIcon.activeSelf);
    }
}
