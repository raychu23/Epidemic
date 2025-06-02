using UnityEngine;
using TMPro;

public class ColorByClickTracker : MonoBehaviour
{
    public void UpdateClicks()
    {
        TMP_Dropdown dropdown = gameObject.GetComponent<TMP_Dropdown>();
        switch (dropdown.value)
        {
            case 0:
                DataClicks.colorMeds++;
                break;
            case 1:
                DataClicks.colorVirus++;
                break;
            case 2:
                DataClicks.colorTurrettype++;
                break;
            case 3:
                DataClicks.colorWave++;
                break;
            case 4:
                DataClicks.colorLocation++;
                break;
            case 5:
                DataClicks.colorLevel++;
                break;
        }
    }
}
