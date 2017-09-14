using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelLayout : MonoBehaviour {

    //Script to load the level that the user is on. Takes the level prefab and instantiate it.

    public levelPieces[] levels;
    public GameObject congratsUI;
    private GameObject levelPieces;

    public float[] xPlacement2, yPlacement2, xPlacement3, yPlacement3;

    private void Awake()
    {
        Destroy(levelPieces);
        GameInfo settings = FindObjectOfType<GameInfo>().GetComponent<GameInfo>();
        levelPieces = Instantiate(levels[settings.selectedLevel - 1].pieces);
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.Escape))
        {
            Application.LoadLevel("Level_Select");
        }
	}

    public void nextLevel()
    {
        Destroy(levelPieces);
        GameInfo settings = FindObjectOfType<GameInfo>().GetComponent<GameInfo>();
        levelPieces = Instantiate(levels[settings.selectedLevel].pieces);
        congratsUI.SetActive(false);
        settings.selectedLevel++;
    }

    public void victoryLevel()
    {
        GameInfo settings = FindObjectOfType<GameInfo>().GetComponent<GameInfo>();
        if (settings.selectedLevel == settings.nextLevel)
        {
            settings.nextLevel++;
        }
    }

    public void ResetLevel()
    {
        Destroy(levelPieces);
        GameInfo settings = FindObjectOfType<GameInfo>().GetComponent<GameInfo>();
        levelPieces = Instantiate(levels[settings.selectedLevel - 1].pieces);
        congratsUI.SetActive(false);
    }
}

[System.Serializable]
public class levelPieces
{
    public string levelNum;
    public GameObject pieces;

    public levelPieces()
    {

    }
}