using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapActive : MonoBehaviour
{
    public GameObject swapTarget;

    // Update is called once per frame
    public void OnClick()
    {
        swapTarget.SetActive(!swapTarget.activeSelf);
    }
}
