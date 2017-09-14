using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour {

    //Script to control the main menu. Loads the save file on awake.

    private void Awake()
    {
        LoadFile load = new LoadFile();
    }

    // Update is called once per frame
    void Update () {
        GameInfo settings = FindObjectOfType<GameInfo>().GetComponent<GameInfo>();
    }

    public void btnLevelSelect()
    {
        Application.LoadLevel("Level_Select");
    }

    public void btnSettings()
    {
        Application.LoadLevel("Settings");
    }

    public void btnCredits()
    {
        Application.LoadLevel("Credits");
    }
}
