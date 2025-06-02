using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UILevelChoose : UiManager
{

    string[] uiTags = { "LevelSelect" };

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        PointerTracer(uiTags);
    }
}
