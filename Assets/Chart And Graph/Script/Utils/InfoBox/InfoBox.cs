#define Graph_And_Chart_PRO
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

namespace ChartAndGraph
{
    /// <summary>
    /// this class demonstrates the use of chart events
    /// </summary>
    public partial class InfoBox : MonoBehaviour
    {
        public PieChart[] PieChart;
        public BarChart[] BarChart;
        public GraphChartBase[] GraphChart;
        public RadarChart[] RadarChart;

        public Text infoText; 
         
        void BarHovered(BarChart.BarEventArgs args)
        {
            if (args.Category == "Destroyed")
            {
                infoText.text = string.Format("{0} : {2}", args.Category, args.Group, args.Value);
            }
            else
            {
                BarInput bi = GameObject.FindObjectOfType<BarInput>();
                //if (args.Group == "Med1Red")
                //infoText.text = string.Format("{0} : {1}", "Missed", args.Value - bi.med1RedDes);
                //else if (args.Group == "Med1Blue")
                //infoText.text = string.Format("{0} : {1}", "Missed", args.Value - bi.med1BlueDes);
                //else if (args.Group == "Med2Red")
                //infoText.text = string.Format("{0} : {1}", "Missed", args.Value - bi.med2RedDes);
                //else if (args.Group == "Med2Blue")
                //infoText.text = string.Format("{0} : {1}", "Missed", args.Value - bi.med2BlueDes);
                if (args.Group == "med1" || args.Group == "med11" || args.Group == "round" || args.Group == "wave1" || args.Group == "loc1" || args.Group == "virus1" || args.Group == "virus11" || args.Group == "wave11" || args.Group == "loc11")
                    infoText.text = string.Format("{0} : {1}", "Missed", args.Value - bi.des1);
                else if (args.Group == "med2" || args.Group == "med21" || args.Group == "square" || args.Group == "wave2" || args.Group == "loc2" || args.Group == "virus2" || args.Group == "virus21" || args.Group == "wave12" || args.Group == "loc12")
                    infoText.text = string.Format("{0} : {1}", "Missed", args.Value - bi.des2);
                else if(args.Group == "wave3" || args.Group == "med12" || args.Group == "round2" || args.Group == "loc3" || args.Group == "virus12" || args.Group == "wave21" || args.Group == "loc21")
                    infoText.text = string.Format("{0} : {1}", "Missed", args.Value - bi.des3);
                else if (args.Group == "wave4" || args.Group == "med22" || args.Group == "square2" || args.Group == "loc4" || args.Group == "virus22" || args.Group == "wave22" || args.Group == "loc22")
                    infoText.text = string.Format("{0} : {1}", "Missed", args.Value - bi.des4);
                else if (args.Group == "wave5" || args.Group == "loc5" || args.Group == "wave31" || args.Group == "loc31")
                    infoText.text = string.Format("{0} : {1}", "Missed", args.Value - bi.des5);
                else if (args.Group == "loc6" || args.Group == "wave32" || args.Group == "loc32")
                    infoText.text = string.Format("{0} : {1}", "Missed", args.Value - bi.des6);
                else if (args.Group == "loc7" || args.Group == "wave41" || args.Group == "loc41")
                    infoText.text = string.Format("{0} : {1}", "Missed", args.Value - bi.des7);
                else if (args.Group == "wave42" || args.Group == "loc42")
                    infoText.text = string.Format("{0} : {1}", "Missed", args.Value - bi.des8);
                else if (args.Group == "wave51" || args.Group == "loc51")
                    infoText.text = string.Format("{0} : {1}", "Missed", args.Value - bi.des9);
                else if (args.Group == "wave52" || args.Group == "loc52")
                    infoText.text = string.Format("{0} : {1}", "Missed", args.Value - bi.des10);
                else if (args.Group == "loc61")
                    infoText.text = string.Format("{0} : {1}", "Missed", args.Value - bi.des11);
                else if (args.Group == "loc62")
                    infoText.text = string.Format("{0} : {1}", "Missed", args.Value - bi.des12);
                else if (args.Group == "loc71")
                    infoText.text = string.Format("{0} : {1}", "Missed", args.Value - bi.des13);
                else if (args.Group == "loc72")
                    infoText.text = string.Format("{0} : {1}", "Missed", args.Value - bi.des14);
            }
        }

        void RadarHovered(RadarChart.RadarEventArgs args)
        {
            infoText.text = string.Format("{0},{1} : {2}", args.Category, args.Group, ChartAdancedSettings.Instance.FormatFractionDigits(2, args.Value));
        }
        void GraphClicked(GraphChartBase.GraphEventArgs args)
        {
            if (args.Magnitude < 0f)
                infoText.text = string.Format("{0} : {2}", args.Category, args.XString, args.YString);
            else
                infoText.text = string.Format("{0} : {1},{2} : Sample Size {3} Clicked", args.Category, args.XString, args.YString, args.Magnitude);
        }

        void GraphHoverd(GraphChartBase.GraphEventArgs args)
        {
            if (args.Magnitude < 0f)
                infoText.text = string.Format("{0} : {2}", args.Category, args.XString, args.YString);
            else
                infoText.text = string.Format("{0} : {1},{2} : Sample Size {3}", args.Category, args.XString, args.YString, args.Magnitude);
        }

        void GraphLineClicked(GraphChartBase.GraphEventArgs args)
        {
            if (args.Magnitude < 0f)
                infoText.text = string.Format("Line Start at {0} : {1},{2} Clicked", args.Category, args.XString, args.YString);
            else
                infoText.text = string.Format("Line Start at{0} : {1},{2} : Sample Size {3} Clicked", args.Category, args.XString, args.YString, args.Magnitude);
        }

        void GraphLineHoverd(GraphChartBase.GraphEventArgs args)
        {
            if (args.Magnitude < 0f)
                infoText.text = string.Format("Line Start at {0} : {1},{2}", args.Category, args.XString, args.YString);
            else
                infoText.text = string.Format("Line Start at {0} : {1},{2} : Sample Size {3}", args.Category, args.XString, args.YString, args.Magnitude);
        }

        void PieHovered(PieChart.PieEventArgs args)
        {
            infoText.text = string.Format("{0} : {1}", args.Category, args.Value);
        }


        void NonHovered()
        {
            infoText.text = "";
        }

        partial void HookCandle();

        public void HookChartEvents()
        {
            if (PieChart != null)
            {
                foreach (PieChart pie in PieChart)
                {
                    if (pie == null)
                        continue;
                    pie.PieHovered.AddListener(PieHovered);        // add listeners for the pie chart events
                    pie.NonHovered.AddListener(NonHovered);
                }
            }

            if (BarChart != null)
            {
                foreach (BarChart bar in BarChart)
                {
                    if (bar == null)
                        continue;
                    bar.BarHovered.AddListener(BarHovered);        // add listeners for the bar chart events
                    bar.NonHovered.AddListener(NonHovered);
                }
            }

            if(GraphChart  != null)
            {
                foreach(GraphChartBase graph in GraphChart)
                {
                    if (graph == null)
                        continue;
                    graph.PointClicked.AddListener(GraphClicked);
                    graph.PointHovered.AddListener(GraphHoverd);
                    if(graph is GraphChart)
                    {
                        ((GraphChart)graph).LineClicked.AddListener(GraphLineClicked);
                        ((GraphChart)graph).LineHovered.AddListener(GraphLineHoverd);
                    }
                    graph.NonHovered.AddListener(NonHovered);
                }
            }
            HookCandle();
            if (RadarChart != null) 
            {
                foreach (RadarChart radar in RadarChart)
                {
                    if (radar == null)
                        continue;
                    radar.PointHovered.AddListener(RadarHovered);
                    radar.NonHovered.AddListener(NonHovered);
                }
            }
        }

        // Use this for initialization
        void Start()
        {
            HookChartEvents();
        }

        // Update is called once per frame
        void Update()
        {
        }
    }
}