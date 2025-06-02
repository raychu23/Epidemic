using UnityEngine;
using TMPro;

public class XClickTracker : MonoBehaviour
{
    public void UpdateClicks()
    {
        TMP_Dropdown dropdown = gameObject.GetComponent<TMP_Dropdown>();
        switch (dropdown.value)
        {
            case 0:
                DataClicks.xMeds++;
                break;
            case 1:
                DataClicks.xVirus++;
                break;
            case 2:
                DataClicks.xTurrettype++;
                break;
            case 3:
                DataClicks.xWave++;
                break;
            case 4:
                DataClicks.xLocation++;
                break;
            case 5:
                DataClicks.xLevel++;
                break;
        }
    }
}
