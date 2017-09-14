using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SettingsScreen : MonoBehaviour {

    //Script to control the settings.

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.Escape))
        {
            Application.LoadLevel("Main_Menu");
        }
	}

    public void deleteSave()
    {
        string path = Application.persistentDataPath + "/data.sv";

        if (!File.Exists(path))
        {
            File.Create(path).Dispose();
        }
        GameInfo settings = FindObjectOfType<GameInfo>();
        settings.nextLevel = 1;
    }
}
