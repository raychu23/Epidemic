using UnityEngine;
using System.Collections;
using System.Globalization;
using System.Linq;
using System;

// SplitCsvGrid function used from Unity Wiki: http://wiki.unity3d.com/index.php/CSVReader#ExampleCSV.txt

public class CSVReader : MonoBehaviour
{
    public TextAsset csvFile;
    public TextAsset leaderCsv;
    public static string[,] grid;
    public static string[,] leaders;

    public void Start()
    {
        grid = SplitCsvGrid(csvFile.text);
        leaders = NewSplitCsvGrid(leaderCsv.text);
        Debug.Log("size = " + (1 + leaders.GetUpperBound(0)) + "," + (1 + leaders.GetUpperBound(1)));
        Debug.Log("size = " + (1 + grid.GetUpperBound(0)) + "," + (1 + grid.GetUpperBound(1)));
        //DebugOutputGrid(leaders);
    }

    // Outputs the content of a 2D array, useful for checking the importer
    // Comment in last print statement to test function
    static public void DebugOutputGrid(string[,] grid)
    {
        string textOutput = "";
        for (int y = 0; y < grid.GetUpperBound(1); y++)
        {
            for (int x = 0; x < grid.GetUpperBound(0); x++)
            {
                textOutput = grid[x, y];
                Debug.Log(grid[x, y] + "\n");
                textOutput += "|";
            }
            textOutput += "\n";
        }
        //Debug.Log(textOutput);
    }

    public static string[,] GetLeaders()
    {
        return leaders;
    }

    // splits a CSV file into a 2D string array
    static public string[,] NewSplitCsvGrid(string csvText)
    {
        string[] lines = csvText.Split('\n');

        // creates new 2D string grid to output to
        string[,] outputGrid = new string[10, 5];
        for (int x = 0; x < 10; x++)
        {
            string[] row = lines[x].Split(';');
            for (int y = 0; y < 5; y++)
            {
                outputGrid[x, y] = row[y];
            }
        }

        return outputGrid;
    }

    // splits a CSV file into a 2D string array
    static public string[,] SplitCsvGrid(string csvText)
    {
        string[] lines = csvText.Split("\n"[0]);

        // finds the max width of row
        int width = 0;
        for (int i = 0; i < lines.Length; i++)
        {
            string[] row = SplitCsvLine(lines[i]);
            width = Mathf.Max(width, row.Length);
        }

        // creates new 2D string grid to output to
        string[,] outputGrid = new string[width + 1, lines.Length + 1];
        for (int y = 0; y < lines.Length; y++)
        {
            string[] row = SplitCsvLine(lines[y]);
            for (int x = 0; x < row.Length; x++)
            {
                outputGrid[x, y] = row[x];

                // This line was to replace "" with " in my output.
                // Include or edit it as you wish.
                outputGrid[x, y] = outputGrid[x, y].Replace("\"\"", "\"");
            }
        }

        return outputGrid;
    }

    // splits a CSV row
    static public string[] SplitCsvLine(string line)
    {
        return (from System.Text.RegularExpressions.Match m in System.Text.RegularExpressions.Regex.Matches(line,
        @"(((?<x>(?=[,\r\n]+))|""(?<x>([^""]|"""")+)""|(?<x>[^,\r\n]+)),?)",
        System.Text.RegularExpressions.RegexOptions.ExplicitCapture)
                select m.Groups[1].Value).ToArray();
    }
}
