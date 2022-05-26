using System.Collections;
using System;
using System.IO;
using System.Collections.Generic;
using UnityEngine;

public static class TotalTimer
{
    static float totalTime = 0f;

    const string file = "Assets/Files/HighScore.txt";
    static List<string> times = new List<string>();

    public static List<string> GetTable()
    {
        return times;
    }

    public static void UpdateTimer(float seconds)
    {
        totalTime += seconds;
    }

    public static void ResetTimer()
    {
        totalTime = 0;
    }

    public static string FinalTime()
    {
        return string.Format("{0:00}:{1:00}", totalTime/60, totalTime%60);
    }

    static void Read(string fn)
    {
        StreamReader reader = new StreamReader(fn);

        string line;
        while ((line = reader.ReadLine()) != null)
        {
            times.Add(line);
        }

        reader.Close();
    }

    public static void SaveScore()
    {
        times.Add(FinalTime());
        times.Sort();
        Write(file);
    }

    static void Write(string fn)
    {
        StreamWriter writer = new StreamWriter(fn, false);

        foreach(string line in times)
        {
            writer.WriteLine(line);
        }

        writer.Close();
    }

    public static void InitiateTable()
    {
        Read(file);
        times.Sort();
    }
}
