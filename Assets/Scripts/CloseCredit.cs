using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CloseCredit : MonoBehaviour
{
    public void OnClick()
    {
        SceneManager.UnloadSceneAsync("Credits");
    }
}
