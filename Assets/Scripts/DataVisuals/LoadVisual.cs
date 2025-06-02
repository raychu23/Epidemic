using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadVisual : MonoBehaviour
{

    bool status;

    private void Start()
    {
        status = false;
    }
    public void OnClick()
    {
        if (status == false)
        {
            SceneManager.LoadScene("BarChart", LoadSceneMode.Additive);
            status = true;
        }
        else if (status == true)
        {
            SceneManager.UnloadSceneAsync("BarChart");
            status = false;
        }
    }
}
