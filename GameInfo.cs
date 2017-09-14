using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInfo : MonoBehaviour {

    //Script to keep the next level to unlock and the current one the player is playing.

    public int nextLevel { get; set; }
    public int selectedLevel { get; set; }

    private void OnApplicationQuit()
    {
        SaveFile save = new SaveFile(this.gameObject);
    }

    private void OnApplicationPause(bool pause)
    {
        if(pause)
        {
            SaveFile save = new SaveFile(this.gameObject);
        }
    }
}
