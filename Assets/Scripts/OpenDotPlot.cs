using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenDotPlot : MonoBehaviour
{
   public void OnClick()
    {
        SceneManager.LoadScene("ScatterPlot", LoadSceneMode.Additive);
    }
}
