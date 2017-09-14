using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using UnityEditor.SceneManagement;

public class LevelSelect : MonoBehaviour {

    //Script to select the levels. Only shows the levels if they have been unlocked, and allows the user to flip through multiple pages of levels.

    private int levelGroup = 0;

    public GameObject[] selectionGroups;

    public GameObject btnNext, btnPrev;

    private GameObject[] levelBtns = new GameObject[16];

    private GameInfo settings;

	// Use this for initialization
	void Start () {
        settings = GameObject.FindObjectOfType<GameInfo>();
        int level = settings.nextLevel;

        levelGroup = (level - 1) / 16;

        Component[] btns;
        btns = selectionGroups[levelGroup].GetComponentsInChildren<Button>();

        int index = 0;

        foreach(Component btn in btns)
        {
            levelBtns[index] = btn.gameObject;
            levelBtns[index].SetActive(false);
            index++;
        }

        int levelRange = level - (16 * levelGroup);

        for(int i = 0; i < levelRange; i++)
        {
            levelBtns[i].SetActive(true);
        }
	}
	
	// Update is called once per frame
	void Update () {
        for (int i = 0; i < 4; i++)
        {
            selectionGroups[i].SetActive(false);
        }
        selectionGroups[levelGroup].SetActive(true);

        if(levelGroup == 0)
        {
            btnPrev.SetActive(false);
        }
        else if(levelGroup == selectionGroups.Length - 1)
        {
            btnNext.SetActive(false);
        }
        else
        {
            btnNext.SetActive(true);
            btnPrev.SetActive(true);
        }

        if(Input.GetKey(KeyCode.Escape))
        {
            Application.LoadLevel("Main_Menu");
        }
    }

    public void btnChangeGroup(int x)
    {
        levelGroup += x;
    }

    public void btnPickLevel(int x)
    {
        settings.selectedLevel = x;
        Application.LoadLevel("Levels");
    }
}
