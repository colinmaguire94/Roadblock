using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class LoadFile{

    //Class to load the save file if it exists, if not creates it.

    private string path;

	public LoadFile()
    {
        path = Application.persistentDataPath + "/data.sv";

        if(File.Exists(path))
        {
            loadExisitngFile();
        }
        else
        {
            createFile();
        }


    }

    void createFile()
    {
        GameObject settings = new GameObject();
        settings.name = "Settings";
        settings.AddComponent<GameInfo>();
        Object.DontDestroyOnLoad(settings);

        GameInfo settingsInfo = settings.GetComponent<GameInfo>();
        settingsInfo.nextLevel = 1;
    }

    void loadExisitngFile()
    {
        GameObject settings = new GameObject();
        settings.name = "Settings";
        settings.AddComponent<GameInfo>();
        Object.DontDestroyOnLoad(settings);

        GameInfo settingsInfo = settings.GetComponent<GameInfo>();

        string[] saves = File.ReadAllLines(path);

        foreach(string line in saves)
        {
            if(line.Contains("Current Level:"))
            {
                string newLine = line.Replace("Current Level: ", "");
                int x;
                int.TryParse(newLine, out x);
                settingsInfo.nextLevel = x;
            }
        }
    }
}
