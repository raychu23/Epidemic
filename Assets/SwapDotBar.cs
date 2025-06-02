using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SwapDotBar : MonoBehaviour
{
    public Dropdown swapChart;
    private ClickModel clickmod;

    private void Start()
    {
        clickmod = ClickModel.instance;
    }

    public void SwapToBar()
    {
        switch (swapChart.value)
        {
            case 0:
                break;
            case 1:
                clickmod.barChartCount++;
                SceneManager.UnloadSceneAsync("ScatterPlot");
                SceneManager.LoadScene("BarChart", LoadSceneMode.Additive);
                break;
        }
    }
    public void SwapToDot()
    {
        switch (swapChart.value)
        {
            case 0:
                break;
            case 1:
                clickmod.dotPlotCount++;
                SceneManager.UnloadSceneAsync("BarChart");
                SceneManager.LoadScene("ScatterPlot", LoadSceneMode.Additive);
                break;
        }
    }
}
