#define Graph_And_Chart_PRO
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ChartAndGraph;
using UnityEngine.UI;
using TMPro;

public class BarInput : MonoBehaviour
{
	public BarChart bar;
	DataModel datam;

    // bottomLevel (medicine) text
	public Text med1Text;
	public Text med2Text;
    public Text med1Text1;
    public Text med2Text2;
    // axis labels
    public Text type1;
    public Text type2;
    public Text type3;
    public Text type4;

    public Text virus1;
    public Text virus2;
    public Text virus3;
    public Text virus4;
    public Text virus5;
    public Text virus6;

    public Text wave1;
    public Text wave2;
    public Text wave3;
    public Text wave4;
    public Text wave5;
    public Text wave6;
    public Text wave7;
    public Text wave8;
    public Text wave9;
    public Text wave10;
    public Text wave11;
    public Text wave12;
    public Text wave13;
    public Text wave14;
    public Text wave15;
    public Text wave16;
    public Text wave17;
    public Text wave18;
    public Text wave19;
    public Text wave20;
    public Text wave21;
    public Text wave22;
    public Text wave23;
    public Text wave24;

    public Text loc1;
    public Text loc2;
    public Text loc3;
    public Text loc4;
    public Text loc5;
    public Text loc6;
    public Text loc7;
    public Text loc8;
    public Text loc9;
    public Text loc10;
    public Text loc11;
    public Text loc12;
    public Text loc13;
    public Text loc14;
    public Text loc15;
    public Text loc16;
    public Text loc17;
    public Text loc18;
    public Text loc19;
    public Text loc20;
    public Text loc21;
    public Text loc22;
    public Text loc23;
    public Text loc24;
    public Text loc25;
    public Text loc26;
    public Text loc27;
    public Text loc28;
    public Text loc29;
    public Text loc30;
    public Text loc31;
    public Text loc32;
    public Text loc33;
    public Text loc34;

    // topLevel (enemy or turretType) text
    public Text[] top1Text;
    public Text[] top2Text;

    public Dropdown xAxis;
    public Dropdown colorBy;

    public Text levelText;

    public int des1;
    public int shot1;
    public int des2;
    public int shot2;
    public int des3;
    public int shot3;
    public int des4;
    public int shot4;
    public int des5;
    public int shot5;
    public int des6;
    public int shot6;
    public int des7;
    public int shot7;
    public int des8;
    public int shot8;
    public int des9;
    public int shot9;
    public int des10;
    public int shot10;
    public int des11;
    public int shot11;
    public int des12;
    public int shot12;
    public int des13;
    public int shot13;
    public int des14;
    public int shot14;

    //axis
    public GameObject waveAxis1;
    public GameObject waveAxis2;
    public GameObject waveAxis3;
    public GameObject waveAxis4;
    public GameObject waveAxis5;
    public GameObject waveAxis6;
    public GameObject waveAxis7;
    public GameObject waveAxis8;
    public GameObject waveAxis9;
    public GameObject waveAxis10;
    public GameObject waveAxis11;
    public GameObject waveAxis12;
    public GameObject waveAxis13;
    public GameObject waveAxis14;


    public GameObject LocAxis1;
    public GameObject LocAxis2;
    public GameObject LocAxis3;
    public GameObject LocAxis4;
    public GameObject LocAxis5;
    public GameObject LocAxis6;
    public GameObject LocAxis7;
    public GameObject LocAxis8;
    public GameObject LocAxis9;
    public GameObject LocAxis10;
    public GameObject LocAxis11;
    public GameObject LocAxis12;
    public GameObject LocAxis13;
    public GameObject LocAxis14;
    public GameObject LocAxis15;

    public GameObject VirusAxis1;
    public GameObject VirusAxis2;
    public GameObject VirusAxis3;
    public GameObject VirusAxis4;
    public GameObject VirusAxis5;
    public GameObject VirusAxis6;
    public GameObject VirusAxis7;

    public GameObject medsAxis2;
    public GameObject medsAxis3;

    public GameObject typeAxis2;
    public GameObject typeAxis3;

    public TextMeshProUGUI levelnum;

    public void ChangeAxes()
    {
        int xval = 0;
        int cval = 0;
        switch (xAxis.value)
        {
            //meds
            case 0:
                {
                    xval = 0;
                    waveAxis1.SetActive(false);
                    waveAxis2.SetActive(false);
                    waveAxis3.SetActive(false);
                    LocAxis1.SetActive(false);
                    LocAxis2.SetActive(false);
                    LocAxis3.SetActive(false);
                    VirusAxis1.SetActive(false);
                    VirusAxis2.SetActive(false);
                    //Setting med names
                    med1Text.text = datam.med1.name;
                    med2Text.text = datam.med2.name;
                    //Setting med colors
                    med1Text.color = datam.med1.GetComponent<Medicine>().color;
                    med2Text.color = datam.med2.GetComponent<Medicine>().color;
                    break;
                }
            //type
            case 1:
                {
                    xval = 1;
                    waveAxis1.SetActive(false);
                    waveAxis2.SetActive(false);
                    waveAxis3.SetActive(false);
                    LocAxis1.SetActive(false);
                    LocAxis2.SetActive(false);
                    LocAxis3.SetActive(false);
                    VirusAxis1.SetActive(false);
                    VirusAxis2.SetActive(false);
                    med1Text.text = "Round";
                    med2Text.text = "Square";
                    med1Text.color = Color.black;
                    med2Text.color = Color.black;
                    break;
                }
            
            case 2:
                {
                    xval = 2;
                    med1Text.text = "";
                    med2Text.text = "";
                    LocAxis1.SetActive(false);
                    LocAxis2.SetActive(false);
                    LocAxis3.SetActive(false);
                    VirusAxis1.SetActive(false);
                    VirusAxis2.SetActive(false);
                    break;
                }
            case 3:
                {
                    xval = 3;
                    med1Text.text = "";
                    med2Text.text = "";
                    waveAxis1.SetActive(false);
                    waveAxis2.SetActive(false);
                    waveAxis3.SetActive(false);
                    VirusAxis1.SetActive(false);
                    VirusAxis2.SetActive(false);
                    break;
                }
            case 4:
                {
                    xval = 4;
                    med1Text.text = "";
                    med2Text.text = "";
                    waveAxis1.SetActive(false);
                    waveAxis2.SetActive(false);
                    waveAxis3.SetActive(false);
                    LocAxis1.SetActive(false);
                    LocAxis2.SetActive(false);
                    LocAxis3.SetActive(false);
                    break;
                }
        }

        switch (colorBy.value)
        {
            case 0:
                {
                    cval = 0;
                    break;
                }
            case 1:
                {
                    cval = 1;
                    break;
                }
            case 2:
                {
                    cval = 2;
                    break;
                }
            case 3:
                {
                    cval = 3;
                    break;
                }
        }
        drawBar(xval, cval);
    }

    // Start is called before the first frame update
    private void Start()
    {
        datam = FindObjectOfType<DataModel>();
        levelnum.text = datam.level[0];
        drawBar(0, 0);
        //Setting med names
        med1Text.text = datam.med1.name;
        med2Text.text = datam.med2.name;
        //Setting med colors
        med1Text.color = datam.med1.GetComponent<Medicine>().color;
        med2Text.color = datam.med2.GetComponent<Medicine>().color;
    }

    private void initialize()
    {
        bar.DataSource.ClearGroups();
        bar.DataSource.ClearValues();
        des1 = 0;
        shot1 = 0;
        des2 = 0;
        shot2 = 0;
        des3 = 0;
        shot3 = 0;
        des4 = 0;
        shot4 = 0;
        des5 = 0;
        shot5 = 0;
        des6 = 0;
        shot6 = 0;
        des7 = 0;
        shot7 = 0;
        des8 = 0;
        shot8 = 0;
        des9 = 0;
        shot9 = 0;
        des10 = 0;
        shot10 = 0;
        des11 = 0;
        shot11 = 0;
        des12 = 0;
        shot12 = 0;
        des13 = 0;
        shot13 = 0;
        des14 = 0;
        shot14 = 0;

        med1Text1.text = "";
        med2Text2.text = "";
        medsAxis2.SetActive(false);
        medsAxis3.SetActive(false);
        typeAxis2.SetActive(false);
        typeAxis3.SetActive(false);
        VirusAxis3.SetActive(false);
        VirusAxis4.SetActive(false);
        VirusAxis5.SetActive(false);
        VirusAxis6.SetActive(false);
        VirusAxis7.SetActive(false);
        waveAxis4.SetActive(false);
        waveAxis5.SetActive(false);
        waveAxis6.SetActive(false);
        waveAxis7.SetActive(false);
        waveAxis8.SetActive(false);
        waveAxis9.SetActive(false);
        waveAxis10.SetActive(false);
        waveAxis11.SetActive(false);
        waveAxis12.SetActive(false);
        waveAxis13.SetActive(false);
        waveAxis14.SetActive(false);
        LocAxis4.SetActive(false);
        LocAxis5.SetActive(false);
        LocAxis6.SetActive(false);
        LocAxis7.SetActive(false);
        LocAxis8.SetActive(false);
        LocAxis9.SetActive(false);
        LocAxis10.SetActive(false);
        LocAxis11.SetActive(false);
        LocAxis12.SetActive(false);
        LocAxis13.SetActive(false);
        LocAxis14.SetActive(false);
        LocAxis15.SetActive(false);
    }
    private void drawBar(int val, int cval)
	{
        initialize();
        switch (val)
        {
            case 0:
                {
                    drawByMeds(cval);
                    break;
                }
            case 1:
                {
                    drawByType(cval);
                    break;
                }
            case 2:
                {
                    drawByWave(cval);
                    break;
                }
            case 3:
                {
                    drawByLocation(cval);
                    break;
                }
            case 4:
                {
                    drawByVirus(cval);
                    break;
                }
        }

        int max = Mathf.Max(des1, shot1, des2, shot2, des3, shot3, des4, shot4, des5, shot5, des6, shot6, des7, shot7);
            if (max == 0)
            {
                bar.DataSource.MaxValue = 1;
            }
            else if (max < 50)
            {
                bar.DataSource.MaxValue = ((max / 10) + 1) * 10;
            }
            else if (max == 50)
            {
                bar.DataSource.MaxValue = 50;
            }
            else
            {
                bar.DataSource.MaxValue = ((max / 100) + 1) * 100;
            }
            bar.DataSource.EndBatch();
        
	}


    private void drawByLocation(int cval)
    {
        if (datam.level[0] == "1" || datam.level[0] == "2" || datam.level[0] == "2B")
        {
            if(cval == 0)
            {
                LocAxis1.SetActive(true);
                LocAxis2.SetActive(false);
                LocAxis3.SetActive(false);
                bar.DataSource.AddGroup("loc1");
                bar.DataSource.AddGroup("loc2");
                bar.DataSource.AddGroup("loc3");
                bar.DataSource.AddGroup("loc4");
            }
            else if (cval == 3 && datam.level[0] == "2")
            {
                LocAxis1.SetActive(true);
                LocAxis2.SetActive(false);
                LocAxis3.SetActive(false);
                bar.DataSource.AddGroup("loc1");
                bar.DataSource.AddGroup("loc2");
                bar.DataSource.AddGroup("loc3");
                bar.DataSource.AddGroup("loc4");
            }
            else if (cval == 3 && datam.level[0] == "2B")
            {
                LocAxis1.SetActive(true);
                LocAxis2.SetActive(false);
                LocAxis3.SetActive(false);
                bar.DataSource.AddGroup("loc1");
                bar.DataSource.AddGroup("loc2");
                bar.DataSource.AddGroup("loc3");
                bar.DataSource.AddGroup("loc4");
            }
            else
            {
                LocAxis13.SetActive(true);
                LocAxis1.SetActive(false);
                LocAxis2.SetActive(false);
                LocAxis3.SetActive(false);
                bar.DataSource.AddGroup("loc11");
                bar.DataSource.AddGroup("loc12");
                bar.DataSource.AddGroup("loc21");
                bar.DataSource.AddGroup("loc22");
                bar.DataSource.AddGroup("loc31");
                bar.DataSource.AddGroup("loc32");
                bar.DataSource.AddGroup("loc41");
                bar.DataSource.AddGroup("loc42");
            }

            if(cval == 1)
            {
                
                LocAxis4.SetActive(true);
                loc1.text = datam.med1.name;
                loc2.text = datam.med2.name;
                loc3.text = datam.med1.name;
                loc4.text = datam.med2.name;
                loc5.text = datam.med1.name;
                loc6.text = datam.med2.name;
                loc7.text = datam.med1.name;
                loc8.text = datam.med2.name;
                loc1.color = datam.med1.GetComponent<Medicine>().color;
                loc2.color = datam.med2.GetComponent<Medicine>().color;
                loc3.color = datam.med1.GetComponent<Medicine>().color;
                loc4.color = datam.med2.GetComponent<Medicine>().color;
                loc5.color = datam.med1.GetComponent<Medicine>().color;
                loc6.color = datam.med2.GetComponent<Medicine>().color;
                loc7.color = datam.med1.GetComponent<Medicine>().color;
                loc8.color = datam.med2.GetComponent<Medicine>().color;
            } else if(cval == 2)
            {
                LocAxis5.SetActive(true);
            } else if(cval == 3)
            {
                if(datam.level[0] != "2" && datam.level[0] != "2B")
                {
                    LocAxis6.SetActive(true);
                }
            }

            bar.DataSource.StartBatch();
            for (int i = 0; i < datam.position.Count; i++)
            {
                if (datam.position[i] == 1)
                {
                    if(cval == 0)
                    {
                        des1 += datam.destroyed[i];
                        shot1 += datam.shot[i];
                    } else if(cval == 1)
                    {
                        if (datam.medicine[i] == datam.med1.name)
                        {
                            des1 += datam.destroyed[i];
                            shot1 += datam.shot[i];
                        }
                        else if (datam.medicine[i] == datam.med2.name)
                        {
                            des2 += datam.destroyed[i];
                            shot2 += datam.shot[i];
                        }
                    }
                    else if (cval == 2)
                    {
                        if (datam.turretType[i] == "Round")
                        {
                            des1 += datam.destroyed[i];
                            shot1 += datam.shot[i];
                        }
                        else if (datam.turretType[i] == "Square")
                        {
                            des2 += datam.destroyed[i];
                            shot2 += datam.shot[i];
                        }
                    } else if(cval == 3)
                    {
                        if(datam.level[0] == "2" || datam.level[0] == "2B")
                        {
                            des1 += datam.destroyed[i];
                            shot1 += datam.shot[i];
                        }
                        else
                        {
                            if (datam.virus[i] == "red")
                            {
                                des1 += datam.destroyed[i];
                                shot1 += datam.shot[i];
                            }
                            else if (datam.virus[i] == "blue")
                            {
                                des2 += datam.destroyed[i];
                                shot2 += datam.shot[i];
                            }
                        }
                    }
                    
                }
                else if (datam.position[i] == 2)
                {
                    if (cval == 0)
                    {
                        des2 += datam.destroyed[i];
                        shot2 += datam.shot[i];
                    }
                    else if (cval == 1)
                    {
                        if (datam.medicine[i] == datam.med1.name)
                        {
                            des3 += datam.destroyed[i];
                            shot3 += datam.shot[i];
                        }
                        else if (datam.medicine[i] == datam.med2.name)
                        {
                            des4 += datam.destroyed[i];
                            shot4 += datam.shot[i];
                        }
                    }
                    else if (cval == 2)
                    {
                        if (datam.turretType[i] == "Round")
                        {
                            des3 += datam.destroyed[i];
                            shot3 += datam.shot[i];
                        }
                        else if (datam.turretType[i] == "Square")
                        {
                            des4 += datam.destroyed[i];
                            shot4 += datam.shot[i];
                        }
                    }
                    else if (cval == 3)
                    {
                        if (datam.level[0] == "2" || datam.level[0] == "2B")
                        {
                            des2 += datam.destroyed[i];
                            shot2 += datam.shot[i];
                        }
                        else
                        {
                            if (datam.virus[i] == "red")
                            {
                                des3 += datam.destroyed[i];
                                shot3 += datam.shot[i];
                            }
                            else if (datam.virus[i] == "blue")
                            {
                                des4 += datam.destroyed[i];
                                shot4 += datam.shot[i];
                            }
                        }
                    }
                }
                else if (datam.position[i] == 3)
                {
                    if (cval == 0)
                    {
                        des3 += datam.destroyed[i];
                        shot3 += datam.shot[i];
                    }
                    else if (cval == 1)
                    {
                        if (datam.medicine[i] == datam.med1.name)
                        {
                            des5 += datam.destroyed[i];
                            shot5 += datam.shot[i];
                        }
                        else if (datam.medicine[i] == datam.med2.name)
                        {
                            des6 += datam.destroyed[i];
                            shot6 += datam.shot[i];
                        }
                    }
                    else if (cval == 2)
                    {
                        if (datam.turretType[i] == "Round")
                        {
                            des5 += datam.destroyed[i];
                            shot5 += datam.shot[i];
                        }
                        else if (datam.turretType[i] == "Square")
                        {
                            des6 += datam.destroyed[i];
                            shot6 += datam.shot[i];
                        }
                    }
                    else if (cval == 3)
                    {
                        if (datam.level[0] == "2" || datam.level[0] == "2B")
                        {
                            des3 += datam.destroyed[i];
                            shot3 += datam.shot[i];
                        }
                        else
                        {
                            if (datam.virus[i] == "red")
                            {
                                des5 += datam.destroyed[i];
                                shot5 += datam.shot[i];
                            }
                            else if (datam.virus[i] == "blue")
                            {
                                des6 += datam.destroyed[i];
                                shot6 += datam.shot[i];
                            }
                        }
                    }
                }
                else if (datam.position[i] == 4)
                {
                    if (cval == 0)
                    {
                        des4 += datam.destroyed[i];
                        shot4 += datam.shot[i];
                    }
                    else if (cval == 1)
                    {
                        if (datam.medicine[i] == datam.med1.name)
                        {
                            des7 += datam.destroyed[i];
                            shot7 += datam.shot[i];
                        }
                        else if (datam.medicine[i] == datam.med2.name)
                        {
                            des8 += datam.destroyed[i];
                            shot8 += datam.shot[i];
                        }
                    }
                    else if (cval == 2)
                    {
                        if (datam.turretType[i] == "Round")
                        {
                            des7 += datam.destroyed[i];
                            shot7 += datam.shot[i];
                        }
                        else if (datam.turretType[i] == "Square")
                        {
                            des8 += datam.destroyed[i];
                            shot8 += datam.shot[i];
                        }
                    }
                    else if (cval == 3)
                    {
                        if (datam.level[0] == "2" || datam.level[0] == "2B")
                        {
                            des4 += datam.destroyed[i];
                            shot4 += datam.shot[i];
                        }
                        else
                        {
                            if (datam.virus[i] == "red")
                            {
                                des7 += datam.destroyed[i];
                                shot7 += datam.shot[i];
                            }
                            else if (datam.virus[i] == "blue")
                            {
                                des8 += datam.destroyed[i];
                                shot8 += datam.shot[i];
                            }
                        }
                    }
                }
            }
            if(cval == 0)
            {
                bar.DataSource.SetValue("Destroyed", "loc1", des1);
                bar.DataSource.SetValue("Total Shots", "loc1", shot1);
                bar.DataSource.SetValue("Destroyed", "loc2", des2);
                bar.DataSource.SetValue("Total Shots", "loc2", shot2);
                bar.DataSource.SetValue("Destroyed", "loc3", des3);
                bar.DataSource.SetValue("Total Shots", "loc3", shot3);
                bar.DataSource.SetValue("Destroyed", "loc4", des4);
                bar.DataSource.SetValue("Total Shots", "loc4", shot4);
            }
            else if(cval == 3 && datam.level[0] == "2")
            {
                bar.DataSource.SetValue("Destroyed", "loc1", des1);
                bar.DataSource.SetValue("Total Shots", "loc1", shot1);
                bar.DataSource.SetValue("Destroyed", "loc2", des2);
                bar.DataSource.SetValue("Total Shots", "loc2", shot2);
                bar.DataSource.SetValue("Destroyed", "loc3", des3);
                bar.DataSource.SetValue("Total Shots", "loc3", shot3);
                bar.DataSource.SetValue("Destroyed", "loc4", des4);
                bar.DataSource.SetValue("Total Shots", "loc4", shot4);
            }
            else if(cval == 3 && datam.level[0] == "2B")
            {
                bar.DataSource.SetValue("Destroyed", "loc1", des1);
                bar.DataSource.SetValue("Total Shots", "loc1", shot1);
                bar.DataSource.SetValue("Destroyed", "loc2", des2);
                bar.DataSource.SetValue("Total Shots", "loc2", shot2);
                bar.DataSource.SetValue("Destroyed", "loc3", des3);
                bar.DataSource.SetValue("Total Shots", "loc3", shot3);
                bar.DataSource.SetValue("Destroyed", "loc4", des4);
                bar.DataSource.SetValue("Total Shots", "loc4", shot4);
            }
            else
            {
                bar.DataSource.SetValue("Destroyed", "loc11", des1);
                bar.DataSource.SetValue("Total Shots", "loc11", shot1);
                bar.DataSource.SetValue("Destroyed", "loc12", des2);
                bar.DataSource.SetValue("Total Shots", "loc12", shot2);
                bar.DataSource.SetValue("Destroyed", "loc21", des3);
                bar.DataSource.SetValue("Total Shots", "loc21", shot3);
                bar.DataSource.SetValue("Destroyed", "loc22", des4);
                bar.DataSource.SetValue("Total Shots", "loc22", shot4);
                bar.DataSource.SetValue("Destroyed", "loc31", des5);
                bar.DataSource.SetValue("Total Shots", "loc31", shot5);
                bar.DataSource.SetValue("Destroyed", "loc32", des6);
                bar.DataSource.SetValue("Total Shots", "loc32", shot6);
                bar.DataSource.SetValue("Destroyed", "loc41", des7);
                bar.DataSource.SetValue("Total Shots", "loc41", shot7);
                bar.DataSource.SetValue("Destroyed", "loc42", des8);
                bar.DataSource.SetValue("Total Shots", "loc42", shot8);
            }
            
        }
        else if (datam.level[0] == "3" || datam.level[0] == "3B" || datam.level[0] == "4" || datam.level[0] == "4B")
        {
            if(cval == 0)
            {
                LocAxis1.SetActive(false);
                LocAxis2.SetActive(true);
                LocAxis3.SetActive(false);
                bar.DataSource.AddGroup("loc1");
                bar.DataSource.AddGroup("loc2");
                bar.DataSource.AddGroup("loc3");
                bar.DataSource.AddGroup("loc4");
                bar.DataSource.AddGroup("loc5");
                bar.DataSource.AddGroup("loc6");
            } else
            {

                LocAxis14.SetActive(true);
                LocAxis1.SetActive(false);
                LocAxis2.SetActive(false);
                LocAxis3.SetActive(false);
                bar.DataSource.AddGroup("loc11");
                bar.DataSource.AddGroup("loc12");
                bar.DataSource.AddGroup("loc21");
                bar.DataSource.AddGroup("loc22");
                bar.DataSource.AddGroup("loc31");
                bar.DataSource.AddGroup("loc32");
                bar.DataSource.AddGroup("loc41");
                bar.DataSource.AddGroup("loc42");
                bar.DataSource.AddGroup("loc51");
                bar.DataSource.AddGroup("loc52");
                bar.DataSource.AddGroup("loc61");
                bar.DataSource.AddGroup("loc62");
            }

            if(cval == 1)
            {
                LocAxis7.SetActive(true);
                
                loc9.text = datam.med1.name;
                loc10.text = datam.med2.name;
                loc11.text = datam.med1.name;
                loc12.text = datam.med2.name;
                loc13.text = datam.med1.name;
                loc14.text = datam.med2.name;
                loc15.text = datam.med1.name;
                loc16.text = datam.med2.name;
                loc17.text = datam.med1.name;
                loc18.text = datam.med2.name;
                loc19.text = datam.med1.name;
                loc20.text = datam.med2.name;
                
                loc9.color = datam.med1.GetComponent<Medicine>().color;
                loc10.color = datam.med2.GetComponent<Medicine>().color;
                loc11.color = datam.med1.GetComponent<Medicine>().color;
                loc12.color = datam.med2.GetComponent<Medicine>().color;
                loc13.color = datam.med1.GetComponent<Medicine>().color;
                loc14.color = datam.med2.GetComponent<Medicine>().color;
                loc15.color = datam.med1.GetComponent<Medicine>().color;
                loc16.color = datam.med2.GetComponent<Medicine>().color;
                loc17.color = datam.med1.GetComponent<Medicine>().color;
                loc18.color = datam.med2.GetComponent<Medicine>().color;
                loc19.color = datam.med1.GetComponent<Medicine>().color;
                loc20.color = datam.med2.GetComponent<Medicine>().color;
            }
            else if(cval == 2)
            {
                LocAxis8.SetActive(true);
            }
            else if(cval == 3)
            {
                LocAxis9.SetActive(true);
            }

            bar.DataSource.StartBatch();
            for (int i = 0; i < datam.position.Count; i++)
            {
                if (datam.position[i] == 1)
                {
                    if (cval == 0)
                    {
                        des1 += datam.destroyed[i];
                        shot1 += datam.shot[i];
                    }
                    else if (cval == 1)
                    {
                        if (datam.medicine[i] == datam.med1.name)
                        {
                            des1 += datam.destroyed[i];
                            shot1 += datam.shot[i];
                        }
                        else if (datam.medicine[i] == datam.med2.name)
                        {
                            des2 += datam.destroyed[i];
                            shot2 += datam.shot[i];
                        }
                    }
                    else if (cval == 2)
                    {
                        if (datam.turretType[i] == "Round")
                        {
                            des1 += datam.destroyed[i];
                            shot1 += datam.shot[i];
                        }
                        else if (datam.turretType[i] == "Square")
                        {
                            des2 += datam.destroyed[i];
                            shot2 += datam.shot[i];
                        }
                    }
                    else if (cval == 3)
                    {
                        if (datam.virus[i] == "red")
                            {
                                des1 += datam.destroyed[i];
                                shot1 += datam.shot[i];
                            }
                            else if (datam.virus[i] == "blue")
                            {
                                des2 += datam.destroyed[i];
                                shot2 += datam.shot[i];
                            }
                    }
                }
                else if (datam.position[i] == 2)
                {
                    if (cval == 0)
                    {
                        des2 += datam.destroyed[i];
                        shot2 += datam.shot[i];
                    }
                    else if (cval == 1)
                    {
                        if (datam.medicine[i] == datam.med1.name)
                        {
                            des3 += datam.destroyed[i];
                            shot3 += datam.shot[i];
                        }
                        else if (datam.medicine[i] == datam.med2.name)
                        {
                            des4 += datam.destroyed[i];
                            shot4 += datam.shot[i];
                        }
                    }
                    else if (cval == 2)
                    {
                        if (datam.turretType[i] == "Round")
                        {
                            des3 += datam.destroyed[i];
                            shot3 += datam.shot[i];
                        }
                        else if (datam.turretType[i] == "Square")
                        {
                            des4 += datam.destroyed[i];
                            shot4 += datam.shot[i];
                        }
                    }
                    else if (cval == 3)
                    {
                        if (datam.virus[i] == "red")
                        {
                            des3 += datam.destroyed[i];
                            shot3 += datam.shot[i];
                        }
                        else if (datam.virus[i] == "blue")
                        {
                            des4 += datam.destroyed[i];
                            shot4 += datam.shot[i];
                        }
                    }
                }
                else if (datam.position[i] == 3)
                {
                    if (cval == 0)
                    {
                        des3 += datam.destroyed[i];
                        shot3 += datam.shot[i];
                    }
                    else if (cval == 1)
                    {
                        if (datam.medicine[i] == datam.med1.name)
                        {
                            des5 += datam.destroyed[i];
                            shot5 += datam.shot[i];
                        }
                        else if (datam.medicine[i] == datam.med2.name)
                        {
                            des6 += datam.destroyed[i];
                            shot6 += datam.shot[i];
                        }
                    }
                    else if (cval == 2)
                    {
                        if (datam.turretType[i] == "Round")
                        {
                            des5 += datam.destroyed[i];
                            shot5 += datam.shot[i];
                        }
                        else if (datam.turretType[i] == "Square")
                        {
                            des6 += datam.destroyed[i];
                            shot6 += datam.shot[i];
                        }
                    }
                    else if (cval == 3)
                    {
                        if (datam.virus[i] == "red")
                        {
                            des5 += datam.destroyed[i];
                            shot5 += datam.shot[i];
                        }
                        else if (datam.virus[i] == "blue")
                        {
                            des6 += datam.destroyed[i];
                            shot6 += datam.shot[i];
                        }
                    }
                }
                else if (datam.position[i] == 4)
                {
                    if (cval == 0)
                    {
                        des4 += datam.destroyed[i];
                        shot4 += datam.shot[i];
                    }
                    else if (cval == 1)
                    {
                        if (datam.medicine[i] == datam.med1.name)
                        {
                            des7 += datam.destroyed[i];
                            shot7 += datam.shot[i];
                        }
                        else if (datam.medicine[i] == datam.med2.name)
                        {
                            des8 += datam.destroyed[i];
                            shot8 += datam.shot[i];
                        }
                    }
                    else if (cval == 2)
                    {
                        if (datam.turretType[i] == "Round")
                        {
                            des7 += datam.destroyed[i];
                            shot7 += datam.shot[i];
                        }
                        else if (datam.turretType[i] == "Square")
                        {
                            des8 += datam.destroyed[i];
                            shot8 += datam.shot[i];
                        }
                    }
                    else if (cval == 3)
                    {
                        if (datam.virus[i] == "red")
                        {
                            des7 += datam.destroyed[i];
                            shot7 += datam.shot[i];
                        }
                        else if (datam.virus[i] == "blue")
                        {
                            des8 += datam.destroyed[i];
                            shot8 += datam.shot[i];
                        }
                    }
                }
                else if (datam.position[i] == 5)
                {
                    if (cval == 0)
                    {
                        des5 += datam.destroyed[i];
                        shot5 += datam.shot[i];
                    }
                    else if (cval == 1)
                    {
                        if (datam.medicine[i] == datam.med1.name)
                        {
                            des9 += datam.destroyed[i];
                            shot9 += datam.shot[i];
                        }
                        else if (datam.medicine[i] == datam.med2.name)
                        {
                            des10 += datam.destroyed[i];
                            shot10 += datam.shot[i];
                        }
                    }
                    else if (cval == 2)
                    {
                        if (datam.turretType[i] == "Round")
                        {
                            des9 += datam.destroyed[i];
                            shot9 += datam.shot[i];
                        }
                        else if (datam.turretType[i] == "Square")
                        {
                            des10 += datam.destroyed[i];
                            shot10 += datam.shot[i];
                        }
                    }
                    else if (cval == 3)
                    {
                        if (datam.virus[i] == "red")
                        {
                            des9 += datam.destroyed[i];
                            shot9 += datam.shot[i];
                        }
                        else if (datam.virus[i] == "blue")
                        {
                            des10 += datam.destroyed[i];
                            shot10 += datam.shot[i];
                        }
                    }
                }
                else if (datam.position[i] == 6)
                {
                    if (cval == 0)
                    {
                        des6 += datam.destroyed[i];
                        shot6 += datam.shot[i];
                    }
                    else if (cval == 1)
                    {
                        if (datam.medicine[i] == datam.med1.name)
                        {
                            des11 += datam.destroyed[i];
                            shot11 += datam.shot[i];
                        }
                        else if (datam.medicine[i] == datam.med2.name)
                        {
                            des12 += datam.destroyed[i];
                            shot12 += datam.shot[i];
                        }
                    }
                    else if (cval == 2)
                    {
                        if (datam.turretType[i] == "Round")
                        {
                            des11 += datam.destroyed[i];
                            shot11 += datam.shot[i];
                        }
                        else if (datam.turretType[i] == "Square")
                        {
                            des12 += datam.destroyed[i];
                            shot12 += datam.shot[i];
                        }
                    }
                    else if (cval == 3)
                    {
                        if (datam.virus[i] == "red")
                        {
                            des11 += datam.destroyed[i];
                            shot11 += datam.shot[i];
                        }
                        else if (datam.virus[i] == "blue")
                        {
                            des12 += datam.destroyed[i];
                            shot12 += datam.shot[i];
                        }
                    }
                }
            }
            if(cval == 0)
            {
                bar.DataSource.SetValue("Destroyed", "loc1", des1);
                bar.DataSource.SetValue("Total Shots", "loc1", shot1);
                bar.DataSource.SetValue("Destroyed", "loc2", des2);
                bar.DataSource.SetValue("Total Shots", "loc2", shot2);
                bar.DataSource.SetValue("Destroyed", "loc3", des3);
                bar.DataSource.SetValue("Total Shots", "loc3", shot3);
                bar.DataSource.SetValue("Destroyed", "loc4", des4);
                bar.DataSource.SetValue("Total Shots", "loc4", shot4);
                bar.DataSource.SetValue("Destroyed", "loc5", des5);
                bar.DataSource.SetValue("Total Shots", "loc5", shot5);
                bar.DataSource.SetValue("Destroyed", "loc6", des6);
                bar.DataSource.SetValue("Total Shots", "loc6", shot6);
            } else
            {
                bar.DataSource.SetValue("Destroyed", "loc11", des1);
                bar.DataSource.SetValue("Total Shots", "loc11", shot1);
                bar.DataSource.SetValue("Destroyed", "loc12", des2);
                bar.DataSource.SetValue("Total Shots", "loc12", shot2);
                bar.DataSource.SetValue("Destroyed", "loc21", des3);
                bar.DataSource.SetValue("Total Shots", "loc21", shot3);
                bar.DataSource.SetValue("Destroyed", "loc22", des4);
                bar.DataSource.SetValue("Total Shots", "loc22", shot4);
                bar.DataSource.SetValue("Destroyed", "loc31", des5);
                bar.DataSource.SetValue("Total Shots", "loc31", shot5);
                bar.DataSource.SetValue("Destroyed", "loc32", des6);
                bar.DataSource.SetValue("Total Shots", "loc32", shot6);
                bar.DataSource.SetValue("Destroyed", "loc41", des7);
                bar.DataSource.SetValue("Total Shots", "loc41", shot7);
                bar.DataSource.SetValue("Destroyed", "loc42", des8);
                bar.DataSource.SetValue("Total Shots", "loc42", shot8);
                bar.DataSource.SetValue("Destroyed", "loc51", des9);
                bar.DataSource.SetValue("Total Shots", "loc51", shot9);
                bar.DataSource.SetValue("Destroyed", "loc52", des10);
                bar.DataSource.SetValue("Total Shots", "loc52", shot10);
                bar.DataSource.SetValue("Destroyed", "loc61", des11);
                bar.DataSource.SetValue("Total Shots", "loc61", shot11);
                bar.DataSource.SetValue("Destroyed", "loc62", des12);
                bar.DataSource.SetValue("Total Shots", "loc62", shot12);
            }
            
        }
        else
        {
            if(cval == 0)
            {
                LocAxis1.SetActive(false);
                LocAxis2.SetActive(false);
                LocAxis3.SetActive(true);
                bar.DataSource.AddGroup("loc1");
                bar.DataSource.AddGroup("loc2");
                bar.DataSource.AddGroup("loc3");
                bar.DataSource.AddGroup("loc4");
                bar.DataSource.AddGroup("loc5");
                bar.DataSource.AddGroup("loc6");
                bar.DataSource.AddGroup("loc7");
            } else
            {

                LocAxis15.SetActive(true);
                LocAxis1.SetActive(false);
                LocAxis2.SetActive(false);
                LocAxis3.SetActive(false);
                bar.DataSource.AddGroup("loc11");
                bar.DataSource.AddGroup("loc12");
                bar.DataSource.AddGroup("loc21");
                bar.DataSource.AddGroup("loc22");
                bar.DataSource.AddGroup("loc31");
                bar.DataSource.AddGroup("loc32");
                bar.DataSource.AddGroup("loc41");
                bar.DataSource.AddGroup("loc42");
                bar.DataSource.AddGroup("loc51");
                bar.DataSource.AddGroup("loc52");
                bar.DataSource.AddGroup("loc61");
                bar.DataSource.AddGroup("loc62");
                bar.DataSource.AddGroup("loc71");
                bar.DataSource.AddGroup("loc72");
            }

            if (cval == 1)
            {
                LocAxis10.SetActive(true);
                
                loc21.text = datam.med1.name;
                loc22.text = datam.med2.name;
                loc23.text = datam.med1.name;
                loc24.text = datam.med2.name;
                loc25.text = datam.med1.name;
                loc26.text = datam.med2.name;
                loc27.text = datam.med1.name;
                loc28.text = datam.med2.name;
                loc29.text = datam.med1.name;
                loc30.text = datam.med2.name;
                loc31.text = datam.med1.name;
                loc32.text = datam.med2.name;
                loc33.text = datam.med1.name;
                loc34.text = datam.med2.name;
                
                loc21.color = datam.med1.GetComponent<Medicine>().color;
                loc22.color = datam.med2.GetComponent<Medicine>().color;
                loc23.color = datam.med1.GetComponent<Medicine>().color;
                loc24.color = datam.med2.GetComponent<Medicine>().color;
                loc25.color = datam.med1.GetComponent<Medicine>().color;
                loc26.color = datam.med2.GetComponent<Medicine>().color;
                loc27.color = datam.med1.GetComponent<Medicine>().color;
                loc28.color = datam.med2.GetComponent<Medicine>().color;
                loc29.color = datam.med1.GetComponent<Medicine>().color;
                loc30.color = datam.med2.GetComponent<Medicine>().color;
                loc31.color = datam.med1.GetComponent<Medicine>().color;
                loc32.color = datam.med2.GetComponent<Medicine>().color;
                loc33.color = datam.med1.GetComponent<Medicine>().color;
                loc34.color = datam.med2.GetComponent<Medicine>().color;
            }
            else if (cval == 2)
            {
                LocAxis11.SetActive(true);
            }
            else if (cval == 3)
            {
                LocAxis12.SetActive(true);
            }

            bar.DataSource.StartBatch();
            for (int i = 0; i < datam.position.Count; i++)
            {
                if (datam.position[i] == 1)
                {
                    if (cval == 0)
                    {
                        des1 += datam.destroyed[i];
                        shot1 += datam.shot[i];
                    }
                    else if (cval == 1)
                    {
                        if (datam.medicine[i] == datam.med1.name)
                        {
                            des1 += datam.destroyed[i];
                            shot1 += datam.shot[i];
                        }
                        else if (datam.medicine[i] == datam.med2.name)
                        {
                            des2 += datam.destroyed[i];
                            shot2 += datam.shot[i];
                        }
                    }
                    else if (cval == 2)
                    {
                        if (datam.turretType[i] == "Round")
                        {
                            des1 += datam.destroyed[i];
                            shot1 += datam.shot[i];
                        }
                        else if (datam.turretType[i] == "Square")
                        {
                            des2 += datam.destroyed[i];
                            shot2 += datam.shot[i];
                        }
                    }
                    else if (cval == 3)
                    {
                        if (datam.virus[i] == "red")
                        {
                            des1 += datam.destroyed[i];
                            shot1 += datam.shot[i];
                        }
                        else if (datam.virus[i] == "blue")
                        {
                            des2 += datam.destroyed[i];
                            shot2 += datam.shot[i];
                        }
                    }
                }
                else if (datam.position[i] == 2)
                {
                    if (cval == 0)
                    {
                        des2 += datam.destroyed[i];
                        shot2 += datam.shot[i];
                    }
                    else if (cval == 1)
                    {
                        if (datam.medicine[i] == datam.med1.name)
                        {
                            des3 += datam.destroyed[i];
                            shot3 += datam.shot[i];
                        }
                        else if (datam.medicine[i] == datam.med2.name)
                        {
                            des4 += datam.destroyed[i];
                            shot4 += datam.shot[i];
                        }
                    }
                    else if (cval == 2)
                    {
                        if (datam.turretType[i] == "Round")
                        {
                            des3 += datam.destroyed[i];
                            shot3 += datam.shot[i];
                        }
                        else if (datam.turretType[i] == "Square")
                        {
                            des4 += datam.destroyed[i];
                            shot4 += datam.shot[i];
                        }
                    }
                    else if (cval == 3)
                    {
                        if (datam.virus[i] == "red")
                        {
                            des3 += datam.destroyed[i];
                            shot3 += datam.shot[i];
                        }
                        else if (datam.virus[i] == "blue")
                        {
                            des4 += datam.destroyed[i];
                            shot4 += datam.shot[i];
                        }
                    }
                }
                else if (datam.position[i] == 3)
                {
                    if (cval == 0)
                    {
                        des3 += datam.destroyed[i];
                        shot3 += datam.shot[i];
                    }
                    else if (cval == 1)
                    {
                        if (datam.medicine[i] == datam.med1.name)
                        {
                            des5 += datam.destroyed[i];
                            shot5 += datam.shot[i];
                        }
                        else if (datam.medicine[i] == datam.med2.name)
                        {
                            des6 += datam.destroyed[i];
                            shot6 += datam.shot[i];
                        }
                    }
                    else if (cval == 2)
                    {
                        if (datam.turretType[i] == "Round")
                        {
                            des5 += datam.destroyed[i];
                            shot5 += datam.shot[i];
                        }
                        else if (datam.turretType[i] == "Square")
                        {
                            des6 += datam.destroyed[i];
                            shot6 += datam.shot[i];
                        }
                    }
                    else if (cval == 3)
                    {
                        if (datam.virus[i] == "red")
                        {
                            des5 += datam.destroyed[i];
                            shot5 += datam.shot[i];
                        }
                        else if (datam.virus[i] == "blue")
                        {
                            des6 += datam.destroyed[i];
                            shot6 += datam.shot[i];
                        }
                    }
                }
                else if (datam.position[i] == 4)
                {
                    if (cval == 0)
                    {
                        des4 += datam.destroyed[i];
                        shot4 += datam.shot[i];
                    }
                    else if (cval == 1)
                    {
                        if (datam.medicine[i] == datam.med1.name)
                        {
                            des7 += datam.destroyed[i];
                            shot7 += datam.shot[i];
                        }
                        else if (datam.medicine[i] == datam.med2.name)
                        {
                            des8 += datam.destroyed[i];
                            shot8 += datam.shot[i];
                        }
                    }
                    else if (cval == 2)
                    {
                        if (datam.turretType[i] == "Round")
                        {
                            des7 += datam.destroyed[i];
                            shot7 += datam.shot[i];
                        }
                        else if (datam.turretType[i] == "Square")
                        {
                            des8 += datam.destroyed[i];
                            shot8 += datam.shot[i];
                        }
                    }
                    else if (cval == 3)
                    {
                        if (datam.virus[i] == "red")
                        {
                            des7 += datam.destroyed[i];
                            shot7 += datam.shot[i];
                        }
                        else if (datam.virus[i] == "blue")
                        {
                            des8 += datam.destroyed[i];
                            shot8 += datam.shot[i];
                        }
                    }
                }
                else if (datam.position[i] == 5)
                {
                    if (cval == 0)
                    {
                        des5 += datam.destroyed[i];
                        shot5 += datam.shot[i];
                    }
                    else if (cval == 1)
                    {
                        if (datam.medicine[i] == datam.med1.name)
                        {
                            des9 += datam.destroyed[i];
                            shot9 += datam.shot[i];
                        }
                        else if (datam.medicine[i] == datam.med2.name)
                        {
                            des10 += datam.destroyed[i];
                            shot10 += datam.shot[i];
                        }
                    }
                    else if (cval == 2)
                    {
                        if (datam.turretType[i] == "Round")
                        {
                            des9 += datam.destroyed[i];
                            shot9 += datam.shot[i];
                        }
                        else if (datam.turretType[i] == "Square")
                        {
                            des10 += datam.destroyed[i];
                            shot10 += datam.shot[i];
                        }
                    }
                    else if (cval == 3)
                    {
                        if (datam.virus[i] == "red")
                        {
                            des9 += datam.destroyed[i];
                            shot9 += datam.shot[i];
                        }
                        else if (datam.virus[i] == "blue")
                        {
                            des10 += datam.destroyed[i];
                            shot10 += datam.shot[i];
                        }
                    }
                }
                else if (datam.position[i] == 6)
                {
                    if (cval == 0)
                    {
                        des6 += datam.destroyed[i];
                        shot6 += datam.shot[i];
                    }
                    else if (cval == 1)
                    {
                        if (datam.medicine[i] == datam.med1.name)
                        {
                            des11 += datam.destroyed[i];
                            shot11 += datam.shot[i];
                        }
                        else if (datam.medicine[i] == datam.med2.name)
                        {
                            des12 += datam.destroyed[i];
                            shot12 += datam.shot[i];
                        }
                    }
                    else if (cval == 2)
                    {
                        if (datam.turretType[i] == "Round")
                        {
                            des11 += datam.destroyed[i];
                            shot11 += datam.shot[i];
                        }
                        else if (datam.turretType[i] == "Square")
                        {
                            des12 += datam.destroyed[i];
                            shot12 += datam.shot[i];
                        }
                    }
                    else if (cval == 3)
                    {
                        if (datam.virus[i] == "red")
                        {
                            des11 += datam.destroyed[i];
                            shot11 += datam.shot[i];
                        }
                        else if (datam.virus[i] == "blue")
                        {
                            des12 += datam.destroyed[i];
                            shot12 += datam.shot[i];
                        }
                    }
                }
                else if (datam.position[i] == 7)
                {
                    if (cval == 0)
                    {
                        des7 += datam.destroyed[i];
                        shot7 += datam.shot[i];
                    }
                    else if (cval == 1)
                    {
                        if (datam.medicine[i] == datam.med1.name)
                        {
                            des13 += datam.destroyed[i];
                            shot13 += datam.shot[i];
                        }
                        else if (datam.medicine[i] == datam.med2.name)
                        {
                            des14 += datam.destroyed[i];
                            shot14 += datam.shot[i];
                        }
                    }
                    else if (cval == 2)
                    {
                        if (datam.turretType[i] == "Round")
                        {
                            des13 += datam.destroyed[i];
                            shot13 += datam.shot[i];
                        }
                        else if (datam.turretType[i] == "Square")
                        {
                            des14 += datam.destroyed[i];
                            shot14 += datam.shot[i];
                        }
                    }
                    else if (cval == 3)
                    {
                        if (datam.virus[i] == "red")
                        {
                            des13 += datam.destroyed[i];
                            shot13 += datam.shot[i];
                        }
                        else if (datam.virus[i] == "blue")
                        {
                            des14 += datam.destroyed[i];
                            shot14 += datam.shot[i];
                        }
                    }
                }
            }
            if(cval == 0)
            {
                bar.DataSource.SetValue("Destroyed", "loc1", des1);
                bar.DataSource.SetValue("Total Shots", "loc1", shot1);
                bar.DataSource.SetValue("Destroyed", "loc2", des2);
                bar.DataSource.SetValue("Total Shots", "loc2", shot2);
                bar.DataSource.SetValue("Destroyed", "loc3", des3);
                bar.DataSource.SetValue("Total Shots", "loc3", shot3);
                bar.DataSource.SetValue("Destroyed", "loc4", des4);
                bar.DataSource.SetValue("Total Shots", "loc4", shot4);
                bar.DataSource.SetValue("Destroyed", "loc5", des5);
                bar.DataSource.SetValue("Total Shots", "loc5", shot5);
                bar.DataSource.SetValue("Destroyed", "loc6", des6);
                bar.DataSource.SetValue("Total Shots", "loc6", shot6);
                bar.DataSource.SetValue("Destroyed", "loc7", des7);
                bar.DataSource.SetValue("Total Shots", "loc7", shot7);
            }
            else
            {
                bar.DataSource.SetValue("Destroyed", "loc11", des1);
                bar.DataSource.SetValue("Total Shots", "loc11", shot1);
                bar.DataSource.SetValue("Destroyed", "loc12", des2);
                bar.DataSource.SetValue("Total Shots", "loc12", shot2);
                bar.DataSource.SetValue("Destroyed", "loc21", des3);
                bar.DataSource.SetValue("Total Shots", "loc21", shot3);
                bar.DataSource.SetValue("Destroyed", "loc22", des4);
                bar.DataSource.SetValue("Total Shots", "loc22", shot4);
                bar.DataSource.SetValue("Destroyed", "loc31", des5);
                bar.DataSource.SetValue("Total Shots", "loc31", shot5);
                bar.DataSource.SetValue("Destroyed", "loc32", des6);
                bar.DataSource.SetValue("Total Shots", "loc32", shot6);
                bar.DataSource.SetValue("Destroyed", "loc41", des7);
                bar.DataSource.SetValue("Total Shots", "loc41", shot7);
                bar.DataSource.SetValue("Destroyed", "loc42", des8);
                bar.DataSource.SetValue("Total Shots", "loc42", shot8);
                bar.DataSource.SetValue("Destroyed", "loc51", des9);
                bar.DataSource.SetValue("Total Shots", "loc51", shot9);
                bar.DataSource.SetValue("Destroyed", "loc52", des10);
                bar.DataSource.SetValue("Total Shots", "loc52", shot10);
                bar.DataSource.SetValue("Destroyed", "loc61", des11);
                bar.DataSource.SetValue("Total Shots", "loc61", shot11);
                bar.DataSource.SetValue("Destroyed", "loc62", des12);
                bar.DataSource.SetValue("Total Shots", "loc62", shot12);
                bar.DataSource.SetValue("Destroyed", "loc71", des13);
                bar.DataSource.SetValue("Total Shots", "loc71", shot13);
                bar.DataSource.SetValue("Destroyed", "loc72", des14);
                bar.DataSource.SetValue("Total Shots", "loc72", shot14);
            }
            
        }
    }

    private void drawByWave(int cval)
    {
        if(datam.level[0] == "1")
        {
            if (cval == 0)
            {
                waveAxis1.SetActive(true);
                waveAxis2.SetActive(false);
                waveAxis3.SetActive(false);
                bar.DataSource.AddGroup("wave1");
                bar.DataSource.AddGroup("wave2");
                bar.DataSource.AddGroup("wave3");
            }
            else
            {
                waveAxis1.SetActive(false);
                waveAxis2.SetActive(false);
                waveAxis3.SetActive(false);
                waveAxis12.SetActive(true);
                bar.DataSource.AddGroup("wave11");
                bar.DataSource.AddGroup("wave12");
                bar.DataSource.AddGroup("wave21");
                bar.DataSource.AddGroup("wave22");
                bar.DataSource.AddGroup("wave31");
                bar.DataSource.AddGroup("wave32");
            }

            if(cval == 1)
            {
                waveAxis4.SetActive(true);
                wave1.text = datam.med1.name;
                wave2.text = datam.med2.name;
                wave3.text = datam.med1.name;
                wave4.text = datam.med2.name;
                wave5.text = datam.med1.name;
                wave6.text = datam.med2.name;
                wave1.color = datam.med1.GetComponent<Medicine>().color;
                wave2.color = datam.med2.GetComponent<Medicine>().color;
                wave3.color = datam.med1.GetComponent<Medicine>().color;
                wave4.color = datam.med2.GetComponent<Medicine>().color;
                wave5.color = datam.med1.GetComponent<Medicine>().color;
                wave6.color = datam.med2.GetComponent<Medicine>().color;
            } else if (cval == 2)
            {
                waveAxis5.SetActive(true);
            } else if (cval == 3)
            {
                waveAxis6.SetActive(true);
            }

            bar.DataSource.StartBatch();
            for (int i = 0; i < datam.wave.Count; i++)
            {
                if (datam.wave[i] == 1)
                {
                    if(cval == 0)
                    {
                        des1 += datam.destroyed[i];
                        shot1 += datam.shot[i];
                    } else if(cval == 1)
                    {
                        if (datam.medicine[i] == datam.med1.name)
                        {
                            des1 += datam.destroyed[i];
                            shot1 += datam.shot[i];
                        }
                        else if (datam.medicine[i] == datam.med2.name)
                        {
                            des2 += datam.destroyed[i];
                            shot2 += datam.shot[i];
                        }
                    } else if(cval == 2)
                    {
                        if (datam.turretType[i] == "Round")
                        {
                            des1 += datam.destroyed[i];
                            shot1 += datam.shot[i];
                        }
                        else if (datam.turretType[i] == "Square")
                        {
                            des2 += datam.destroyed[i];
                            shot2 += datam.shot[i];
                        }
                    } else if (cval == 3)
                    {
                        if (datam.virus[i] == "red")
                        {
                            des1 += datam.destroyed[i];
                            shot1 += datam.shot[i];
                        }
                        else if (datam.virus[i] == "blue")
                        {
                            des2 += datam.destroyed[i];
                            shot2 += datam.shot[i];
                        }
                    }
                    
                }
                else if(datam.wave[i] == 2)
                {
                    if (cval == 0)
                    {
                        des2 += datam.destroyed[i];
                        shot2 += datam.shot[i];
                    }
                    else if (cval == 1)
                    {
                        if (datam.medicine[i] == datam.med1.name)
                        {
                            des3 += datam.destroyed[i];
                            shot3 += datam.shot[i];
                        }
                        else if (datam.medicine[i] == datam.med2.name)
                        {
                            des4 += datam.destroyed[i];
                            shot4 += datam.shot[i];
                        }
                    }
                    else if (cval == 2)
                    {
                        if (datam.turretType[i] == "Round")
                        {
                            des3 += datam.destroyed[i];
                            shot3 += datam.shot[i];
                        }
                        else if (datam.turretType[i] == "Square")
                        {
                            des4 += datam.destroyed[i];
                            shot4 += datam.shot[i];
                        }
                    }
                    else if (cval == 3)
                    {
                        if (datam.virus[i] == "red")
                        {
                            des3 += datam.destroyed[i];
                            shot3 += datam.shot[i];
                        }
                        else if (datam.virus[i] == "blue")
                        {
                            des4 += datam.destroyed[i];
                            shot4 += datam.shot[i];
                        }
                    }
                }
                else if (datam.wave[i] == 3)
                {
                    if (cval == 0)
                    {
                        des3 += datam.destroyed[i];
                        shot3 += datam.shot[i];
                    }
                    else if (cval == 1)
                    {
                        if (datam.medicine[i] == datam.med1.name)
                        {
                            des5 += datam.destroyed[i];
                            shot5 += datam.shot[i];
                        }
                        else if (datam.medicine[i] == datam.med2.name)
                        {
                            des6 += datam.destroyed[i];
                            shot6 += datam.shot[i];
                        }
                    }
                    else if (cval == 2)
                    {
                        if (datam.turretType[i] == "Round")
                        {
                            des5 += datam.destroyed[i];
                            shot5 += datam.shot[i];
                        }
                        else if (datam.turretType[i] == "Square")
                        {
                            des6 += datam.destroyed[i];
                            shot6 += datam.shot[i];
                        }
                    }
                    else if (cval == 3)
                    {
                        if (datam.virus[i] == "red")
                        {
                            des5 += datam.destroyed[i];
                            shot5 += datam.shot[i];
                        }
                        else if (datam.virus[i] == "blue")
                        {
                            des6 += datam.destroyed[i];
                            shot6 += datam.shot[i];
                        }
                    }
                }
            }
            if(cval == 0)
            {
                bar.DataSource.SetValue("Destroyed", "wave1", des1);
                bar.DataSource.SetValue("Total Shots", "wave1", shot1);
                bar.DataSource.SetValue("Destroyed", "wave2", des2);
                bar.DataSource.SetValue("Total Shots", "wave2", shot2);
                bar.DataSource.SetValue("Destroyed", "wave3", des3);
                bar.DataSource.SetValue("Total Shots", "wave3", shot3);
            } else
            {
                bar.DataSource.SetValue("Destroyed", "wave11", des1);
                bar.DataSource.SetValue("Total Shots", "wave11", shot1);
                bar.DataSource.SetValue("Destroyed", "wave12", des2);
                bar.DataSource.SetValue("Total Shots", "wave12", shot2);
                bar.DataSource.SetValue("Destroyed", "wave21", des3);
                bar.DataSource.SetValue("Total Shots", "wave21", shot3);
                bar.DataSource.SetValue("Destroyed", "wave22", des4);
                bar.DataSource.SetValue("Total Shots", "wave22", shot4);
                bar.DataSource.SetValue("Destroyed", "wave31", des5);
                bar.DataSource.SetValue("Total Shots", "wave31", shot5);
                bar.DataSource.SetValue("Destroyed", "wave32", des6);
                bar.DataSource.SetValue("Total Shots", "wave32", shot6);
            }
            
        }
        else if(datam.level[0] == "2" || datam.level[0] == "2B")
        {
            if(cval == 0 || cval == 3)
            {
                waveAxis1.SetActive(false);
                waveAxis2.SetActive(true);
                waveAxis3.SetActive(false);
                bar.DataSource.AddGroup("wave1");
                bar.DataSource.AddGroup("wave2");
                bar.DataSource.AddGroup("wave3");
                bar.DataSource.AddGroup("wave4");
            }
            else
            {
                waveAxis1.SetActive(false);
                waveAxis2.SetActive(false);
                waveAxis3.SetActive(false);
                waveAxis13.SetActive(true);
                bar.DataSource.AddGroup("wave11");
                bar.DataSource.AddGroup("wave12");
                bar.DataSource.AddGroup("wave21");
                bar.DataSource.AddGroup("wave22");
                bar.DataSource.AddGroup("wave31");
                bar.DataSource.AddGroup("wave32");
                bar.DataSource.AddGroup("wave41");
                bar.DataSource.AddGroup("wave42");
            }

            if(cval == 1)
            {
                waveAxis7.SetActive(true);

                wave7.text = datam.med1.name;
                wave8.text = datam.med2.name;
                wave9.text = datam.med1.name;
                wave10.text = datam.med2.name;
                wave11.text = datam.med1.name;
                wave12.text = datam.med2.name;
                wave13.text = datam.med1.name;
                wave14.text = datam.med2.name;
                wave7.color = datam.med1.GetComponent<Medicine>().color;
                wave8.color = datam.med2.GetComponent<Medicine>().color;
                wave9.color = datam.med1.GetComponent<Medicine>().color;
                wave10.color = datam.med2.GetComponent<Medicine>().color;
                wave11.color = datam.med1.GetComponent<Medicine>().color;
                wave12.color = datam.med2.GetComponent<Medicine>().color;
                wave13.color = datam.med1.GetComponent<Medicine>().color;
                wave14.color = datam.med2.GetComponent<Medicine>().color;
            } else if(cval == 2)
            {
                waveAxis8.SetActive(true);
            }
            

            bar.DataSource.StartBatch();
            for (int i = 0; i < datam.wave.Count; i++)
            {
                if (datam.wave[i] == 1)
                {
                    if(cval == 0 || cval == 3)
                    {
                        des1 += datam.destroyed[i];
                        shot1 += datam.shot[i];
                    }
                    else if(cval == 1)
                    {
                        if (datam.medicine[i] == datam.med1.name)
                        {
                            des1 += datam.destroyed[i];
                            shot1 += datam.shot[i];
                        }
                        else if (datam.medicine[i] == datam.med2.name)
                        {
                            des2 += datam.destroyed[i];
                            shot2 += datam.shot[i];
                        }
                    }
                    else if (cval == 2)
                {
                    if (datam.turretType[i] == "Round")
                    {
                        des1 += datam.destroyed[i];
                        shot1 += datam.shot[i];
                    }
                    else if (datam.turretType[i] == "Square")
                    {
                        des2 += datam.destroyed[i];
                        shot2 += datam.shot[i];
                    }
                }
                
            }
                else if (datam.wave[i] == 2)
                {
                    if(cval == 0 || cval == 3)
                    {
                        des2 += datam.destroyed[i];
                        shot2 += datam.shot[i];
                    }
                    else if (cval == 1)
                    {
                        if (datam.medicine[i] == datam.med1.name)
                        {
                            des3 += datam.destroyed[i];
                            shot3 += datam.shot[i];
                        }
                        else if (datam.medicine[i] == datam.med2.name)
                        {
                            des4 += datam.destroyed[i];
                            shot4 += datam.shot[i];
                        }
                    }
                    else if (cval == 2)
                    {
                        if (datam.turretType[i] == "Round")
                        {
                            des3 += datam.destroyed[i];
                            shot3 += datam.shot[i];
                        }
                        else if (datam.turretType[i] == "Square")
                        {
                            des4 += datam.destroyed[i];
                            shot4 += datam.shot[i];
                        }
                    }
                }
                else if (datam.wave[i] == 3)
                {
                    if (cval == 0 || cval == 3)
                    {
                        des3 += datam.destroyed[i];
                        shot3 += datam.shot[i];
                    }
                    else if (cval == 1)
                    {
                        if (datam.medicine[i] == datam.med1.name)
                        {
                            des5 += datam.destroyed[i];
                            shot5 += datam.shot[i];
                        }
                        else if (datam.medicine[i] == datam.med2.name)
                        {
                            des6 += datam.destroyed[i];
                            shot6 += datam.shot[i];
                        }
                    }
                    else if (cval == 2)
                    {
                        if (datam.turretType[i] == "Round")
                        {
                            des5 += datam.destroyed[i];
                            shot5 += datam.shot[i];
                        }
                        else if (datam.turretType[i] == "Square")
                        {
                            des6 += datam.destroyed[i];
                            shot6 += datam.shot[i];
                        }
                    }
                }
                else if (datam.wave[i] == 4)
                {
                    if (cval == 0 || cval == 3)
                    {
                        des4 += datam.destroyed[i];
                        shot4 += datam.shot[i];
                    }
                    else if (cval == 1)
                    {
                        if (datam.medicine[i] == datam.med1.name)
                        {
                            des7 += datam.destroyed[i];
                            shot7 += datam.shot[i];
                        }
                        else if (datam.medicine[i] == datam.med2.name)
                        {
                            des8 += datam.destroyed[i];
                            shot8 += datam.shot[i];
                        }
                    }
                    else if (cval == 2)
                    {
                        if (datam.turretType[i] == "Round")
                        {
                            des7 += datam.destroyed[i];
                            shot7 += datam.shot[i];
                        }
                        else if (datam.turretType[i] == "Square")
                        {
                            des8 += datam.destroyed[i];
                            shot8 += datam.shot[i];
                        }
                    }
                }
            }
            if(cval == 0 || cval == 3)
            {
                bar.DataSource.SetValue("Destroyed", "wave1", des1);
                bar.DataSource.SetValue("Total Shots", "wave1", shot1);
                bar.DataSource.SetValue("Destroyed", "wave2", des2);
                bar.DataSource.SetValue("Total Shots", "wave2", shot2);
                bar.DataSource.SetValue("Destroyed", "wave3", des3);
                bar.DataSource.SetValue("Total Shots", "wave3", shot3);
                bar.DataSource.SetValue("Destroyed", "wave4", des4);
                bar.DataSource.SetValue("Total Shots", "wave4", shot4);
            }
            else
            {
                bar.DataSource.SetValue("Destroyed", "wave11", des1);
                bar.DataSource.SetValue("Total Shots", "wave11", shot1);
                bar.DataSource.SetValue("Destroyed", "wave12", des2);
                bar.DataSource.SetValue("Total Shots", "wave12", shot2);
                bar.DataSource.SetValue("Destroyed", "wave21", des3);
                bar.DataSource.SetValue("Total Shots", "wave21", shot3);
                bar.DataSource.SetValue("Destroyed", "wave22", des4);
                bar.DataSource.SetValue("Total Shots", "wave22", shot4);
                bar.DataSource.SetValue("Destroyed", "wave31", des5);
                bar.DataSource.SetValue("Total Shots", "wave31", shot5);
                bar.DataSource.SetValue("Destroyed", "wave32", des6);
                bar.DataSource.SetValue("Total Shots", "wave32", shot6);
                bar.DataSource.SetValue("Destroyed", "wave41", des7);
                bar.DataSource.SetValue("Total Shots", "wave41", shot7);
                bar.DataSource.SetValue("Destroyed", "wave42", des8);
                bar.DataSource.SetValue("Total Shots", "wave42", shot8);
            }
            
        }
        else
        {
            if(cval == 0)
            {
                waveAxis1.SetActive(false);
                waveAxis2.SetActive(false);
                waveAxis3.SetActive(true);
                bar.DataSource.AddGroup("wave1");
                bar.DataSource.AddGroup("wave2");
                bar.DataSource.AddGroup("wave3");
                bar.DataSource.AddGroup("wave4");
                bar.DataSource.AddGroup("wave5");
            } else
            {
                waveAxis1.SetActive(false);
                waveAxis2.SetActive(false);
                waveAxis3.SetActive(false);
                waveAxis14.SetActive(true);
                bar.DataSource.AddGroup("wave11");
                bar.DataSource.AddGroup("wave12");
                bar.DataSource.AddGroup("wave21");
                bar.DataSource.AddGroup("wave22");
                bar.DataSource.AddGroup("wave31");
                bar.DataSource.AddGroup("wave32");
                bar.DataSource.AddGroup("wave41");
                bar.DataSource.AddGroup("wave42");
                bar.DataSource.AddGroup("wave51");
                bar.DataSource.AddGroup("wave52");
            }

            if (cval == 1)
            {
                waveAxis9.SetActive(true);
                wave15.text = datam.med1.name;
                wave16.text = datam.med2.name;
                wave17.text = datam.med1.name;
                wave18.text = datam.med2.name;
                wave19.text = datam.med1.name;
                wave20.text = datam.med2.name;
                wave21.text = datam.med1.name;
                wave22.text = datam.med2.name;
                wave23.text = datam.med1.name;
                wave24.text = datam.med2.name;
                wave15.color = datam.med1.GetComponent<Medicine>().color;
                wave16.color = datam.med2.GetComponent<Medicine>().color;
                wave17.color = datam.med1.GetComponent<Medicine>().color;
                wave18.color = datam.med2.GetComponent<Medicine>().color;
                wave19.color = datam.med1.GetComponent<Medicine>().color;
                wave20.color = datam.med2.GetComponent<Medicine>().color;
                wave21.color = datam.med1.GetComponent<Medicine>().color;
                wave22.color = datam.med2.GetComponent<Medicine>().color;
                wave23.color = datam.med1.GetComponent<Medicine>().color;
                wave24.color = datam.med2.GetComponent<Medicine>().color;
            }
            else if (cval == 2)
            {
                waveAxis10.SetActive(true);
            }
            else if (cval == 3)
            {
                waveAxis11.SetActive(true);
            }

            bar.DataSource.StartBatch();
                for (int i = 0; i < datam.wave.Count; i++)
                {
                    if (datam.wave[i] == 1)
                    {
                    if (cval == 0)
                    {
                        des1 += datam.destroyed[i];
                        shot1 += datam.shot[i];
                    }
                    else if (cval == 1)
                    {
                        if (datam.medicine[i] == datam.med1.name)
                        {
                            des1 += datam.destroyed[i];
                            shot1 += datam.shot[i];
                        }
                        else if (datam.medicine[i] == datam.med2.name)
                        {
                            des2 += datam.destroyed[i];
                            shot2 += datam.shot[i];
                        }
                    }
                    else if (cval == 2)
                    {
                        if (datam.turretType[i] == "Round")
                        {
                            des1 += datam.destroyed[i];
                            shot1 += datam.shot[i];
                        }
                        else if (datam.turretType[i] == "Square")
                        {
                            des2 += datam.destroyed[i];
                            shot2 += datam.shot[i];
                        }
                    }
                    else
                    {
                        if (datam.virus[i] == "red")
                        {
                            des1 += datam.destroyed[i];
                            shot1 += datam.shot[i];
                        }
                        else if (datam.virus[i] == "blue")
                        {
                            des2 += datam.destroyed[i];
                            shot2 += datam.shot[i];
                        }
                    }
                }
                    else if (datam.wave[i] == 2)
                    {
                    if (cval == 0)
                    {
                        des2 += datam.destroyed[i];
                        shot2 += datam.shot[i];
                    }
                    else if (cval == 1)
                    {
                        if (datam.medicine[i] == datam.med1.name)
                        {
                            des3 += datam.destroyed[i];
                            shot3 += datam.shot[i];
                        }
                        else if (datam.medicine[i] == datam.med2.name)
                        {
                            des4 += datam.destroyed[i];
                            shot4 += datam.shot[i];
                        }
                    }
                    else if (cval == 2)
                    {
                        if (datam.turretType[i] == "Round")
                        {
                            des3 += datam.destroyed[i];
                            shot3 += datam.shot[i];
                        }
                        else if (datam.turretType[i] == "Square")
                        {
                            des4 += datam.destroyed[i];
                            shot4 += datam.shot[i];
                        }
                    }
                    else
                    {
                        if (datam.virus[i] == "red")
                        {
                            des3 += datam.destroyed[i];
                            shot3 += datam.shot[i];
                        }
                        else if (datam.virus[i] == "blue")
                        {
                            des4 += datam.destroyed[i];
                            shot4 += datam.shot[i];
                        }
                    }
                }
                    else if (datam.wave[i] == 3)
                    {
                    if (cval == 0)
                    {
                        des3 += datam.destroyed[i];
                        shot3 += datam.shot[i];
                    }
                    else if (cval == 1)
                    {
                        if (datam.medicine[i] == datam.med1.name)
                        {
                            des5 += datam.destroyed[i];
                            shot5 += datam.shot[i];
                        }
                        else if (datam.medicine[i] == datam.med2.name)
                        {
                            des6 += datam.destroyed[i];
                            shot6 += datam.shot[i];
                        }
                    }
                    else if (cval == 2)
                    {
                        if (datam.turretType[i] == "Round")
                        {
                            des5 += datam.destroyed[i];
                            shot5 += datam.shot[i];
                        }
                        else if (datam.turretType[i] == "Square")
                        {
                            des6 += datam.destroyed[i];
                            shot6 += datam.shot[i];
                        }
                    }
                    else
                    {
                        if (datam.virus[i] == "red")
                        {
                            des5 += datam.destroyed[i];
                            shot5 += datam.shot[i];
                        }
                        else if (datam.virus[i] == "blue")
                        {
                            des6 += datam.destroyed[i];
                            shot6 += datam.shot[i];
                        }
                    }
                }
                else if (datam.wave[i] == 4)
                {
                    if (cval == 0)
                    {
                        des4 += datam.destroyed[i];
                        shot4 += datam.shot[i];
                    }
                    else if (cval == 1)
                    {
                        if (datam.medicine[i] == datam.med1.name)
                        {
                            des7 += datam.destroyed[i];
                            shot7 += datam.shot[i];
                        }
                        else if (datam.medicine[i] == datam.med2.name)
                        {
                            des8 += datam.destroyed[i];
                            shot8 += datam.shot[i];
                        }
                    }
                    else if (cval == 2)
                    {
                        if (datam.turretType[i] == "Round")
                        {
                            des7 += datam.destroyed[i];
                            shot7 += datam.shot[i];
                        }
                        else if (datam.turretType[i] == "Square")
                        {
                            des8 += datam.destroyed[i];
                            shot8 += datam.shot[i];
                        }
                    }
                    else
                    {
                        if (datam.virus[i] == "red")
                        {
                            des7 += datam.destroyed[i];
                            shot7 += datam.shot[i];
                        }
                        else if (datam.virus[i] == "blue")
                        {
                            des8 += datam.destroyed[i];
                            shot8 += datam.shot[i];
                        }
                    }
                }
                else if (datam.wave[i] == 5)
                {
                    if (cval == 0)
                    {
                        des5 += datam.destroyed[i];
                        shot5 += datam.shot[i];
                    }
                    else if (cval == 1)
                    {
                        if (datam.medicine[i] == datam.med1.name)
                        {
                            des9 += datam.destroyed[i];
                            shot9 += datam.shot[i];
                        }
                        else if (datam.medicine[i] == datam.med2.name)
                        {
                            des10 += datam.destroyed[i];
                            shot10 += datam.shot[i];
                        }
                    }
                    else if (cval == 2)
                    {
                        if (datam.turretType[i] == "Round")
                        {
                            des9 += datam.destroyed[i];
                            shot9 += datam.shot[i];
                        }
                        else if (datam.turretType[i] == "Square")
                        {
                            des10 += datam.destroyed[i];
                            shot10 += datam.shot[i];
                        }
                    }
                    else
                    {
                        if (datam.virus[i] == "red")
                        {
                            des9 += datam.destroyed[i];
                            shot9 += datam.shot[i];
                        }
                        else if (datam.virus[i] == "blue")
                        {
                            des10 += datam.destroyed[i];
                            shot10 += datam.shot[i];
                        }
                    }
                }
            }
                if(cval == 0)
            {
                bar.DataSource.SetValue("Destroyed", "wave1", des1);
                bar.DataSource.SetValue("Total Shots", "wave1", shot1);
                bar.DataSource.SetValue("Destroyed", "wave2", des2);
                bar.DataSource.SetValue("Total Shots", "wave2", shot2);
                bar.DataSource.SetValue("Destroyed", "wave3", des3);
                bar.DataSource.SetValue("Total Shots", "wave3", shot3);
                bar.DataSource.SetValue("Destroyed", "wave4", des4);
                bar.DataSource.SetValue("Total Shots", "wave4", shot4);
                bar.DataSource.SetValue("Destroyed", "wave5", des5);
                bar.DataSource.SetValue("Total Shots", "wave5", shot5);
            }
            else
            {
                bar.DataSource.SetValue("Destroyed", "wave11", des1);
                bar.DataSource.SetValue("Total Shots", "wave11", shot1);
                bar.DataSource.SetValue("Destroyed", "wave12", des2);
                bar.DataSource.SetValue("Total Shots", "wave12", shot2);
                bar.DataSource.SetValue("Destroyed", "wave21", des3);
                bar.DataSource.SetValue("Total Shots", "wave21", shot3);
                bar.DataSource.SetValue("Destroyed", "wave22", des4);
                bar.DataSource.SetValue("Total Shots", "wave22", shot4);
                bar.DataSource.SetValue("Destroyed", "wave31", des5);
                bar.DataSource.SetValue("Total Shots", "wave31", shot5);
                bar.DataSource.SetValue("Destroyed", "wave32", des6);
                bar.DataSource.SetValue("Total Shots", "wave32", shot6);
                bar.DataSource.SetValue("Destroyed", "wave41", des7);
                bar.DataSource.SetValue("Total Shots", "wave41", shot7);
                bar.DataSource.SetValue("Destroyed", "wave42", des8);
                bar.DataSource.SetValue("Total Shots", "wave42", shot8);
                bar.DataSource.SetValue("Destroyed", "wave51", des9);
                bar.DataSource.SetValue("Total Shots", "wave51", shot9);
                bar.DataSource.SetValue("Destroyed", "wave52", des10);
                bar.DataSource.SetValue("Total Shots", "wave52", shot10);
            }
                

        }
    }

    private void drawByType(int cval)
    {
        if (cval == 0 || cval == 2)
        {
            typeAxis2.SetActive(false);
            typeAxis3.SetActive(false);
            bar.DataSource.AddGroup("round");
            bar.DataSource.AddGroup("square");
        }
        else if(cval == 1)
        {
            med1Text.text = "";
            med2Text.text = "";
            med1Text1.text = "Round";
            med2Text2.text = "Square";
            med1Text1.color = Color.black;
            med2Text2.color = Color.black;
            bar.DataSource.AddGroup("round");
            bar.DataSource.AddGroup("round2");
            bar.DataSource.AddGroup("square");
            bar.DataSource.AddGroup("square2");

            typeAxis2.SetActive(true);
            typeAxis3.SetActive(false);
            type1.text = datam.med1.name;
            type3.text = datam.med1.name;
            type4.text = datam.med2.name;
            type2.text = datam.med2.name;
            type1.color = datam.med1.GetComponent<Medicine>().color;
            type3.color = datam.med1.GetComponent<Medicine>().color;
            type4.color = datam.med2.GetComponent<Medicine>().color;
            type2.color = datam.med2.GetComponent<Medicine>().color;
        }
        else if (cval == 3)
        {
            if(datam.level[0] == "2" || datam.level[0] == "2B")
            {
                typeAxis2.SetActive(false);
                typeAxis3.SetActive(false);
                bar.DataSource.AddGroup("round");
                bar.DataSource.AddGroup("square");
            }
            else
            {
                med1Text.text = "";
                med2Text.text = "";
                med1Text1.text = "Round";
                med2Text2.text = "Square";
                med1Text1.color = Color.black;
                med2Text2.color = Color.black;
                bar.DataSource.AddGroup("round");
                bar.DataSource.AddGroup("round2");
                bar.DataSource.AddGroup("square");
                bar.DataSource.AddGroup("square2");

                typeAxis3.SetActive(true);
                typeAxis2.SetActive(false);
            }
            
        }

        if (datam != null)
        {
            bar.DataSource.StartBatch();

            for(int i = 0; i < datam.turretType.Count; i++)
            {
                if(datam.turretType [i] == "Round")
                {
                    if (cval == 0 || cval == 2)
                    {
                        des1 += datam.destroyed[i];
                        shot1 += datam.shot[i];
                    }
                    else if (cval == 1)
                    {
                        if (datam.medicine[i] == datam.med1.name)
                        {
                            des1 += datam.destroyed[i];
                            shot1 += datam.shot[i];
                        }
                        else if (datam.medicine[i] == datam.med2.name)
                        {
                            des3 += datam.destroyed[i];
                            shot3 += datam.shot[i];
                        }
                    }
                    else if (cval == 3)
                    {
                        if (datam.level[i] != "2" && datam.level[i] != "2B")
                        {
                            if (datam.virus[i] == "red")
                            {
                                des1 += datam.destroyed[i];
                                shot1 += datam.shot[i];
                            }
                            else if (datam.virus[i] == "blue")
                            {
                                des3 += datam.destroyed[i];
                                shot3 += datam.shot[i];
                            }
                        }
                        else
                        {
                            des1 += datam.destroyed[i];
                            shot1 += datam.shot[i];
                        }

                    }
                } else
                {
                    if (cval == 0 || cval == 2)
                    {
                        des2 += datam.destroyed[i];
                        shot2 += datam.shot[i];
                    }
                    else if (cval == 1)
                    {
                        if (datam.medicine[i] == datam.med1.name)
                        {
                            des2 += datam.destroyed[i];
                            shot2 += datam.shot[i];
                        }
                        else if (datam.medicine[i] == datam.med2.name)
                        {
                            des4 += datam.destroyed[i];
                            shot4 += datam.shot[i];
                        }
                    }
                    else if (cval == 3)
                    {
                        if (datam.level[i] != "2" && datam.level[i] != "2B")
                        {
                            if (datam.virus[i] == "red")
                            {
                                des2 += datam.destroyed[i];
                                shot2 += datam.shot[i];
                            }
                            else if (datam.virus[i] == "blue")
                            {
                                des4 += datam.destroyed[i];
                                shot4 += datam.shot[i];
                            }
                        }
                        else
                        {
                            des2 += datam.destroyed[i];
                            shot2 += datam.shot[i];
                        }

                    }
                }
            }
        }

        if (cval == 0 || cval == 2)
        {
            bar.DataSource.SetValue("Destroyed", "round", des1);
            bar.DataSource.SetValue("Total Shots", "round", shot1);
            bar.DataSource.SetValue("Destroyed", "square", des2);
            bar.DataSource.SetValue("Total Shots", "square", shot2);
        }
        else if (cval == 1)
        {
            bar.DataSource.SetValue("Destroyed", "round", des1);
            bar.DataSource.SetValue("Total Shots", "round", shot1);
            bar.DataSource.SetValue("Destroyed", "round2", des3);
            bar.DataSource.SetValue("Total Shots", "round2", shot3);
            bar.DataSource.SetValue("Destroyed", "square", des2);
            bar.DataSource.SetValue("Total Shots", "square", shot2);
            bar.DataSource.SetValue("Destroyed", "square2", des4);
            bar.DataSource.SetValue("Total Shots", "square2", shot4);
        } else if(cval == 3)
        {
            if (datam.level[0] == "2" || datam.level[0] == "2B")
            {
                bar.DataSource.SetValue("Destroyed", "round", des1);
                bar.DataSource.SetValue("Total Shots", "round", shot1);
                bar.DataSource.SetValue("Destroyed", "square", des2);
                bar.DataSource.SetValue("Total Shots", "square", shot2);
            }
            else
            {
                bar.DataSource.SetValue("Destroyed", "round", des1);
                bar.DataSource.SetValue("Total Shots", "round", shot1);
                bar.DataSource.SetValue("Destroyed", "round2", des3);
                bar.DataSource.SetValue("Total Shots", "round2", shot3);
                bar.DataSource.SetValue("Destroyed", "square", des2);
                bar.DataSource.SetValue("Total Shots", "square", shot2);
                bar.DataSource.SetValue("Destroyed", "square2", des4);
                bar.DataSource.SetValue("Total Shots", "square2", shot4);
            }
        }
    }


    private void drawByVirus(int cval)
    {
        if (datam.level[0] == "2" || datam.level[0] == "2B")
        {
            if(cval == 0 || cval == 3)
            {
                bar.DataSource.AddGroup("virus1");
            } else if(cval == 1 || cval == 2)
            {
                bar.DataSource.AddGroup("virus1");
                bar.DataSource.AddGroup("virus2");
            } 
            VirusAxis1.SetActive(true);
            VirusAxis2.SetActive(false);

            if(cval == 1)
            {
                VirusAxis3.SetActive(true);
                virus5.text = datam.med1.name;
                virus6.text = datam.med2.name;
                virus5.color = datam.med1.GetComponent<Medicine>().color;
                virus6.color = datam.med2.GetComponent<Medicine>().color;
            } else if(cval == 2)
            {
                VirusAxis4.SetActive(true);
            }

            bar.DataSource.StartBatch();
            for (int i = 0; i < datam.virus.Count; i++)
            {
                if(cval == 0 || cval == 3)
                {
                    des1 += datam.destroyed[i];
                    shot1 += datam.shot[i];
                } else if (cval == 1)
                {
                    if (datam.medicine[i] == datam.med1.name)
                    {
                        des1 += datam.destroyed[i];
                        shot1 += datam.shot[i];
                    }
                    else if (datam.medicine[i] == datam.med2.name)
                    {
                        des2 += datam.destroyed[i];
                        shot2 += datam.shot[i];
                    }
                } else if(cval == 2)
                {
                    if (datam.turretType[i] == "Round")
                    {
                        des1 += datam.destroyed[i];
                        shot1 += datam.shot[i];
                    }
                    else if (datam.turretType[i] == "Square")
                    {
                        des2 += datam.destroyed[i];
                        shot2 += datam.shot[i];
                    }
                }
            }
            if(cval == 0 || cval == 3)
            {
                bar.DataSource.SetValue("Destroyed", "virus1", des1);
                bar.DataSource.SetValue("Total Shots", "virus1", shot1);
            } else if(cval == 1 || cval == 2)
            {
                bar.DataSource.SetValue("Destroyed", "virus1", des1);
                bar.DataSource.SetValue("Total Shots", "virus1", shot1);
                bar.DataSource.SetValue("Destroyed", "virus2", des2);
                bar.DataSource.SetValue("Total Shots", "virus2", shot2);
            }
        }
        else
        {
            if(cval == 0 || cval == 3)
            {
                bar.DataSource.AddGroup("virus1");
                bar.DataSource.AddGroup("virus2");
                VirusAxis1.SetActive(false);
                VirusAxis2.SetActive(true);
            } else if(cval == 1 || cval == 2)
            {
                bar.DataSource.AddGroup("virus11");
                bar.DataSource.AddGroup("virus12");
                bar.DataSource.AddGroup("virus21");
                bar.DataSource.AddGroup("virus22");

                VirusAxis1.SetActive(false);
                VirusAxis2.SetActive(false);
                VirusAxis7.SetActive(true);
            }
            

            if (cval == 1)
            {
                VirusAxis5.SetActive(true);

                virus1.text = datam.med1.name;
                virus3.text = datam.med1.name;
                virus2.text = datam.med2.name;
                virus4.text = datam.med2.name;
                virus1.color = datam.med1.GetComponent<Medicine>().color;
                virus3.color = datam.med1.GetComponent<Medicine>().color;
                virus2.color = datam.med2.GetComponent<Medicine>().color;
                virus4.color = datam.med2.GetComponent<Medicine>().color;
            }
            else if (cval == 2)
            {
                VirusAxis6.SetActive(true);
            }

            bar.DataSource.StartBatch();
            for (int i = 0; i < datam.virus.Count; i++)
            {
                if (datam.virus[i] == "red")
                {
                    if(cval == 0 || cval == 3)
                    {
                        des1 += datam.destroyed[i];
                        shot1 += datam.shot[i];
                    } else if(cval == 1)
                    {
                        if (datam.medicine[i] == datam.med1.name)
                        {
                            des1 += datam.destroyed[i];
                            shot1 += datam.shot[i];
                        }
                        else if (datam.medicine[i] == datam.med2.name)
                        {
                            des3 += datam.destroyed[i];
                            shot3 += datam.shot[i];
                        }
                    } else if(cval == 2)
                    {
                        if (datam.turretType[i] == "Round")
                        {
                            des1 += datam.destroyed[i];
                            shot1 += datam.shot[i];
                        }
                        else if (datam.turretType[i] == "Square")
                        {
                            des3 += datam.destroyed[i];
                            shot3 += datam.shot[i];
                        }
                    }
                    
                }
                else
                {
                    if (cval == 0 || cval == 3)
                    {
                        des2 += datam.destroyed[i];
                        shot2 += datam.shot[i];
                    }
                    else if (cval == 1)
                    {
                        if (datam.medicine[i] == datam.med1.name)
                        {
                            des2 += datam.destroyed[i];
                            shot2 += datam.shot[i];
                        }
                        else if (datam.medicine[i] == datam.med2.name)
                        {
                            des4 += datam.destroyed[i];
                            shot4 += datam.shot[i];
                        }
                    }
                    else if (cval == 2)
                    {
                        if (datam.turretType[i] == "Round")
                        {
                            des2 += datam.destroyed[i];
                            shot2 += datam.shot[i];
                        }
                        else if (datam.turretType[i] == "Square")
                        {
                            des4 += datam.destroyed[i];
                            shot4 += datam.shot[i];
                        }
                    }
                }

            }
            if(cval == 0 || cval == 3)
            {
                bar.DataSource.SetValue("Destroyed", "virus1", des1);
                bar.DataSource.SetValue("Total Shots", "virus1", shot1);
                bar.DataSource.SetValue("Destroyed", "virus2", des2);
                bar.DataSource.SetValue("Total Shots", "virus2", shot2);
            } else
            {
                bar.DataSource.SetValue("Destroyed", "virus11", des1);
                bar.DataSource.SetValue("Total Shots", "virus11", shot1);
                bar.DataSource.SetValue("Destroyed", "virus12", des3);
                bar.DataSource.SetValue("Total Shots", "virus12", shot3);
                bar.DataSource.SetValue("Destroyed", "virus21", des2);
                bar.DataSource.SetValue("Total Shots", "virus21", shot2);
                bar.DataSource.SetValue("Destroyed", "virus22", des4);
                bar.DataSource.SetValue("Total Shots", "virus22", shot4);
            }
            
        }
    }

    private void drawByMeds(int cval)
    {
        if (cval == 0 || cval == 1)
        {
            bar.DataSource.AddGroup("med1");
            bar.DataSource.AddGroup("med2");
            medsAxis2.SetActive(false);
            medsAxis3.SetActive(false);
        } else if (cval == 2)
        {
            med1Text.text = "";
            med2Text.text = "";
            med1Text1.text = datam.med1.name;
            med2Text2.text = datam.med2.name;
            med1Text1.color = datam.med1.GetComponent<Medicine>().color;
            med2Text2.color = datam.med2.GetComponent<Medicine>().color;
            bar.DataSource.AddGroup("med11");
            bar.DataSource.AddGroup("med12");
            bar.DataSource.AddGroup("med21");
            bar.DataSource.AddGroup("med22");

            medsAxis2.SetActive(true);
            medsAxis3.SetActive(false);
        }
        else if (cval == 3)
        {
            if (datam.level[0] == "2" || datam.level[0] == "2B")
            {
                bar.DataSource.AddGroup("med1");
                bar.DataSource.AddGroup("med2");
                medsAxis2.SetActive(false);
                medsAxis3.SetActive(false);
            }
            else
            {
                med1Text.text = "";
                med2Text.text = "";
                med1Text1.text = datam.med1.name;
                med2Text2.text = datam.med2.name;
                med1Text1.color = datam.med1.GetComponent<Medicine>().color;
                med2Text2.color = datam.med2.GetComponent<Medicine>().color;
                bar.DataSource.AddGroup("med11");
                bar.DataSource.AddGroup("med12");
                bar.DataSource.AddGroup("med21");
                bar.DataSource.AddGroup("med22");

                medsAxis3.SetActive(true);
                medsAxis2.SetActive(false);
            }

        }

        
        if (datam != null && datam.med1 != null)
        {
            bar.DataSource.StartBatch();
            for (int i = 0; i < datam.medicine.Count; i++)
            {
                if (datam.medicine[i] == datam.med1.name)
                {
                    if(cval == 0 || cval == 1)
                    {
                        des1 += datam.destroyed[i];
                        shot1 += datam.shot[i];
                    } else if(cval == 2)
                    {
                        if(datam.turretType[i] == "Round")
                        {
                            des1 += datam.destroyed[i];
                            shot1 += datam.shot[i];
                        }
                        else if (datam.turretType[i] == "Square")
                        {
                            des3 += datam.destroyed[i];
                            shot3 += datam.shot[i];
                        }
                    }
                    else if (cval == 3)
                    {
                        if (datam.level[i] != "2" && datam.level[i] != "2B")
                        {
                            if (datam.virus[i] == "red")
                            {
                                des1 += datam.destroyed[i];
                                shot1 += datam.shot[i];
                            }
                            else if (datam.virus[i] == "blue")
                            {
                                des3 += datam.destroyed[i];
                                shot3 += datam.shot[i];
                            }
                        } else
                        {
                            des1 += datam.destroyed[i];
                            shot1 += datam.shot[i];
                        }

                    }


                }
                else if (datam.medicine[i] == datam.med2.name)
                {

                    if (cval == 0 || cval == 1)
                    {
                        des2 += datam.destroyed[i];
                        shot2 += datam.shot[i];
                    }
                    else if (cval == 2)
                    {
                        if (datam.turretType[i] == "Round")
                        {
                            des2 += datam.destroyed[i];
                            shot2 += datam.shot[i];
                        }
                        else if (datam.turretType[i] == "Square")
                        {
                            des4 += datam.destroyed[i];
                            shot4 += datam.shot[i];
                        }
                    }
                    else if (cval == 3)
                    {
                        if (datam.level[i] != "2" && datam.level[i] != "2B")
                        {
                            if (datam.virus[i] == "red")
                            {
                                des2 += datam.destroyed[i];
                                shot2 += datam.shot[i];
                            }
                            else if (datam.virus[i] == "blue")
                            {
                                des4 += datam.destroyed[i];
                                shot4 += datam.shot[i];
                            }
                        }
                        else
                        {
                            des2 += datam.destroyed[i];
                            shot2 += datam.shot[i];
                        }
                    }
                }
            }
        }
        if (cval == 0 || cval == 1)
        {
            bar.DataSource.SetValue("Destroyed", "med1", des1);
            bar.DataSource.SetValue("Total Shots", "med1", shot1);
            bar.DataSource.SetValue("Destroyed", "med2", des2);
            bar.DataSource.SetValue("Total Shots", "med2", shot2);
        } else if (cval == 2)
        {
            bar.DataSource.SetValue("Destroyed", "med11", des1);
            bar.DataSource.SetValue("Total Shots", "med11", shot1);
            bar.DataSource.SetValue("Destroyed", "med12", des3);
            bar.DataSource.SetValue("Total Shots", "med12", shot3);
            bar.DataSource.SetValue("Destroyed", "med21", des2);
            bar.DataSource.SetValue("Total Shots", "med21", shot2);
            bar.DataSource.SetValue("Destroyed", "med22", des4);
            bar.DataSource.SetValue("Total Shots", "med22", shot4);
        } else if (cval == 3)
        {
            if(datam.level[0] == "2" || datam.level[0] == "2B")
            {
                bar.DataSource.SetValue("Destroyed", "med1", des1);
                bar.DataSource.SetValue("Total Shots", "med1", shot1);
                bar.DataSource.SetValue("Destroyed", "med2", des2);
                bar.DataSource.SetValue("Total Shots", "med2", shot2);
            }
            else
            {
                bar.DataSource.SetValue("Destroyed", "med11", des1);
                bar.DataSource.SetValue("Total Shots", "med11", shot1);
                bar.DataSource.SetValue("Destroyed", "med12", des3);
                bar.DataSource.SetValue("Total Shots", "med12", shot3);
                bar.DataSource.SetValue("Destroyed", "med21", des2);
                bar.DataSource.SetValue("Total Shots", "med21", shot2);
                bar.DataSource.SetValue("Destroyed", "med22", des4);
                bar.DataSource.SetValue("Total Shots", "med22", shot4);
            }
            
        } 
        
    }


}
