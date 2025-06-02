using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GraphLabelMed : MonoBehaviour
{
    private DataModel datam;
    public Text med1Text;
    public Text med2Text;
    public Dropdown category;
    //DataModel datam;

    // Start is called before the first frame update
    void Start()
    {
        //datam = GameObject.Find("DataModel").GetComponent<DataModel>();
        datam = FindObjectOfType<DataModel>();
        datam.FindMeds();
        if (datam != null && datam.med1 != null)
        {
            //Setting text
            med1Text.text = datam.med1.name;
            med2Text.text = datam.med2.name;

            //Setting color
            med1Text.color = datam.med1.GetComponent<Medicine>().color;
            med2Text.color = datam.med2.GetComponent<Medicine>().color;
        }
    }

    public void changeText()
    {
        if (datam != null && datam.med1 != null)
        {
            if (category.value == 0)
            {
                ChangeTextToMed();
            }
            else
            {
                ChangeTextToTurret();
            }
        }
    }

    public void ChangeTextToMed() {
        if (datam != null && datam.med1 != null)
        {
        //Setting text
        med1Text.text = datam.med1.name;
        med2Text.text = datam.med2.name;

        //Setting color
        med1Text.color = datam.med1.GetComponent<Medicine>().color;
        med2Text.color = datam.med2.GetComponent<Medicine>().color;
        }
    }

    public void ChangeTextToTurret()
    {
        if (datam != null && datam.med1 != null)
        {
            //Setting text
            med1Text.text = "PillShooter";
            med2Text.text = "BoomThrow";

            //Setting color
            med1Text.color = datam.med1.GetComponent<Medicine>().color;
            med2Text.color = datam.med2.GetComponent<Medicine>().color;
        }
    }

    // Update is called once per frame
    /*void Update()
    {

    }*/
}
