using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SaveFile{
    private string path;

    //A class to create a save file for the game. Save the application verson, and the next level that can be unlocked.

    public SaveFile(GameObject settings)
    {
        path = Application.persistentDataPath + "/data.sv";

        string save = "";

        GameInfo settingsInfo = settings.GetComponent<GameInfo>();

        save += "Version: " + Application.version;
        save += "\nCurrent Level: " + settingsInfo.nextLevel;



        if(!File.Exists(path))
        {
            File.Create(path).Dispose();
        }

        File.WriteAllText(path, save);
    }
}
